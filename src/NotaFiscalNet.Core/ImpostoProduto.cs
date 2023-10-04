﻿using NotaFiscalNet.Core.Interfaces;
using NotaFiscalNet.Core.Utils;
using NotaFiscalNet.Core.Validacao;
using System;

namespace NotaFiscalNet.Core
{
    /// <summary>
    /// Representa os Tributos incidentes no Produto ou Serviço
    /// </summary>
    public sealed class ImpostoProduto : ISerializavel, IModificavel
    {
        private Icms _icms;
	    private decimal? _valorTotalTributos;

	    internal ImpostoProduto(Produto produto)
        {
            Produto = produto;
            ICMS = new ImpostoICMS(this);
            IPI = new ImpostoIPI(this);
            II = new ImpostoII(this);
            PIS = new ImpostoPIS(this);
            PISST = new ImpostoPISST(this);
            COFINS = new ImpostoCOFINS(this);
            COFINSST = new ImpostoCOFINSST(this);
            ISSQN = new ImpostoISSQN(this);
        }

        /// <summary>
        /// [vTotTrib] Retorna ou define o valor estimado total de impostos federais, estaduais e municipais.
        /// </summary>
        [NFeField(FieldName = "vTotTrib", DataType = "TDec_1302")]
        public decimal? ValorTotalTributos
        {
            get => _valorTotalTributos;
	        set => _valorTotalTributos = value.HasValue
		        ? (decimal?)ValidationUtil.ValidateTDec_1302(value.Value, "ValorTotalTributos")
		        : null;
        }

        /// <summary>
        /// Retorna ou define o imposto ICMS sendo empregado no produto.
        /// </summary>
        public Icms Icms
        {
            get => _icms;
	        set
            {
                ValidarConflitoISSQN();
                _icms = value;
            }
        }

        /// <summary>
        /// Retorna o ICMS
        /// </summary>
        [Obsolete("Usar o campos Icms.")]
        [NFeField(ID = "N01", FieldName = "ICMS")]
        [CampoValidavel(1, Opcional = true)]
        public ImpostoICMS ICMS { get; }

	    /// <summary>
        /// Retorna o valor representando as informações de declaração do IPI para o produto. Opcional.
        /// </summary>
        [NFeField(ID = "O01", FieldName = "IPI", Opcional = true)]
        [CampoValidavel(2, Opcional = true)]
        public ImpostoIPI IPI { get; }

	    /// <summary>
        /// Retorna o II (Imposto de Importação). Opcional.
        /// </summary>
        [NFeField(ID = "P01", FieldName = "II", Opcional = true)]
        [CampoValidavel(3, Opcional = true)]
        public ImpostoII II { get; }

	    /// <summary>
        /// Retorna o ISSQN
        /// </summary>
        [NFeField(ID = "U01", FieldName = "ISSQN")]
        [CampoValidavel(4, Opcional = true)]
        public ImpostoISSQN ISSQN { get; }

	    /// <summary>
        /// Retorna as informações do PIS (Programa de Integração Social).
        /// </summary>
        [NFeField(ID = "Q01", FieldName = "PIS")]
        [CampoValidavel(5, ChaveErroValidacao.CampoNaoPreenchido)]
        public ImpostoPIS PIS { get; }

	    /// <summary>
        /// Retorna o PIS ST. Opcional.
        /// </summary>
        [NFeField(ID = "R01", FieldName = "PISST", Opcional = true)]
        [CampoValidavel(6, Opcional = true)]
        public ImpostoPISST PISST { get; }

	    /// <summary>
        /// Retorna o COFINS
        /// </summary>
        [NFeField(ID = "S01", FieldName = "COFINS")]
        [CampoValidavel(7, ChaveErroValidacao.CampoNaoPreenchido)]
        public ImpostoCOFINS COFINS { get; }

	    /// <summary>
        /// Retorna o COFINS ST. Opcional.
        /// </summary>
        [NFeField(ID = "T01", FieldName = "COFINSST")]
        [CampoValidavel(8, Opcional = true)]
        public ImpostoCOFINSST COFINSST { get; }

	    /// <summary>
        /// Retorna a referência para o objeto Produto no qual o Imposto se refere.
        /// </summary>
        internal Produto Produto { get; }

	    /// <summary>
        /// Retorna se a Classe foi modificada
        /// </summary>
        public bool Modificado => ICMS.Modificado || Icms != null ||
                                  IPI.Modificado ||
                                  II.Modificado ||
                                  PIS.Modificado ||
                                  PISST.Modificado ||
                                  COFINS.Modificado ||
                                  COFINSST.Modificado ||
                                  ISSQN.Modificado;

        void ISerializavel.Serializar(System.Xml.XmlWriter writer, INFe nfe)
        {
            writer.WriteStartElement("imposto"); // Elemento 'imposto'

            if (ValorTotalTributos.HasValue)
                writer.WriteElementString("vTotTrib", ValorTotalTributos.Value.ToTDec_1302());

            if (Icms != null || ICMS.Modificado)
            {
                /// Nova maneira de registrar o imposto ICMS.
                if (Icms != null)
                {
                    writer.WriteStartElement("ICMS");
                    ((ISerializavel)Icms).Serializar(writer, nfe);
                    writer.WriteEndElement();
                }
                else
                {
                    // TODO: Obsoleto
                    if (ICMS.Modificado)
                        ((ISerializavel)ICMS).Serializar(writer, nfe);
                }

                if (IPI.Modificado)
                    ((ISerializavel)IPI).Serializar(writer, nfe);
                if (II.Modificado)
                    ((ISerializavel)II).Serializar(writer, nfe);
            }
            else
            {
                if (IPI.Modificado)
                    ((ISerializavel)IPI).Serializar(writer, nfe);

                if (ISSQN.Modificado)
                    ((ISerializavel)ISSQN).Serializar(writer, nfe);
            }

            if (PIS.Modificado)
                ((ISerializavel)PIS).Serializar(writer, nfe);
            if (PISST.Modificado)
                ((ISerializavel)PISST).Serializar(writer, nfe);
            if (COFINS.Modificado)
                ((ISerializavel)COFINS).Serializar(writer, nfe);
            if (COFINSST.Modificado)
                ((ISerializavel)COFINSST).Serializar(writer, nfe);

            writer.WriteEndElement(); // Elemento 'imposto'
        }

        private void ValidarConflitoISSQN()
        {
            if (ISSQN.Modificado)
                throw new ErroValidacaoNFeException(ChaveErroValidacao.ConflitoICMSISSQN);
        }
    }
}