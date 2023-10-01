﻿using NotaFiscalNet.Core.Interfaces;
using NotaFiscalNet.Core.Utils;
using NotaFiscalNet.Core.Validacao;
using System;

namespace NotaFiscalNet.Core
{
    /// <summary>
    /// Representa o Imposto Sobre Serviços de Qualquer Natureza do Produto
    /// </summary>
    public sealed class ImpostoISSQN : ISerializavel, IModificavel
    {
        private decimal _baseCalculo;
        private decimal _aliquota;
        private decimal _valor;
        private int _codigoMunicipioFatoGeradorIBGE;
        private string _codigoServico;

	    private string _codigoServicoPrestadoMunicipio;
        private string _numeroProcessoSuspensao;

        internal ImpostoISSQN(ImpostoProduto imposto)
        {
            Imposto = imposto;
        }

        /// <summary>
        /// Retorna a referência para o objeto ImpostoProduto no qual o Imposto se refere.
        /// </summary>
        internal ImpostoProduto Imposto { get; }

	    private void ValidarConflitoIcmsIpiII()
        {
            if (Imposto.ICMS.Modificado)
                throw new ErroValidacaoNFeException(ChaveErroValidacao.ConflitoISSQNICMS);
            if (Imposto.IPI.Modificado)
                throw new ErroValidacaoNFeException(ChaveErroValidacao.ConflitoISSQNIPI);
            if (Imposto.II.Modificado)
                throw new ErroValidacaoNFeException(ChaveErroValidacao.ConflitoISSQNII);
        }

        /// <summary>
        /// [vBC] Retorna ou define a Base de Cálculo do ISSQN
        /// </summary>
        [NFeField(ID = "U02", FieldName = "vBC", DataType = "TDec_1302", Pattern = @"0|0\.[0-9]{2}|[1-9]{1}[0-9]{0,12}(\.[0-9]{2})?")]
        [CampoValidavel(1, ChaveErroValidacao.CampoNaoPreenchido)]
        public decimal BaseCalculo
        {
            get => _baseCalculo;
	        set
            {
                ValidarConflitoIcmsIpiII();
                ValidationUtil.ValidateTDec_1302(value, "BaseCalculo");
                _baseCalculo = value;
            }
        }

        /// <summary>
        /// [vAliq] Retorna ou define a Alíquota do ISSQN
        /// </summary>
        [NFeField(ID = "U03", FieldName = "vAliq", DataType = "TDec_0302", Pattern = @"0|0\.[0-9]{2}|[1-9]{1}[0-9]{0,2}(\.[0-9]{2})?")]
        [CampoValidavel(2, ChaveErroValidacao.CampoNaoPreenchido)]
        public decimal Aliquota
        {
            get => _aliquota;
	        set
            {
                ValidarConflitoIcmsIpiII();
                ValidationUtil.ValidateTDec_0302(value, "Aliquota");
                _aliquota = value;
            }
        }

        /// <summary>
        /// [vISSQN] Retorna ou define o valor do ISSQN
        /// </summary>
        [NFeField(ID = "U04", FieldName = "vISSQN", DataType = "TDec_1302", Pattern = @"0|0\.[0-9]{2}|[1-9]{1}[0-9]{0,12}(\.[0-9]{2})?")]
        [CampoValidavel(3, ChaveErroValidacao.CampoNaoPreenchido)]
        public decimal ValorISSQN
        {
            get => _valor;
	        set
            {
                ValidarConflitoIcmsIpiII();
                ValidationUtil.ValidateTDec_1302(value, "ValorISSQN");
                _valor = value;
            }
        }

        /// <summary>
        /// [cMunFG] Retorna ou define o Código do Município do Fato Gerador de acordo com a Tabela
        /// do IBGE.
        /// </summary>
        [NFeField(ID = "U05", FieldName = "cMunFG", DataType = "TCodMunIBGE", Pattern = "[0-9]{7}")]
        [CampoValidavel(4, ChaveErroValidacao.CampoNaoPreenchido)]
        public int CodigoMunicipioFatoGeradorIBGE
        {
            get => _codigoMunicipioFatoGeradorIBGE;
	        set
            {
                ValidarConflitoIcmsIpiII();
                ValidationUtil.ValidateTCodMunIBGE(value, "CodigoMunicipioFatoGeradorIBGE");
                _codigoMunicipioFatoGeradorIBGE = value;
            }
        }

        /// <summary>
        /// [cListServ] Retorna ou define o Código do Serviço baseado na Lei Complementar 116/2003
        /// </summary>
        [NFeField(ID = "U06", FieldName = "cListServ", DataType = "TCListServ")]
        [CampoValidavel(5, ChaveErroValidacao.CampoNaoPreenchido)]
        public string CodigoServico
        {
            get => _codigoServico;
	        set
            {
                ValidarConflitoIcmsIpiII();
                _codigoServico = ValidationUtil.ValidateTCListServ(value, "CodigoServico");
            }
        }

        /// <summary>
        /// [vDeducao] Retorna ou define o Valor Dedução para redução da Base de Cálculo.
        /// </summary>
        [NFeField(ID = "U07", FieldName = "vDeducao", DataType = "TDec_1302Opc")]
        public decimal? ValorDeducao { get; set; }

        /// <summary>
        /// [vOutro] Retorna ou define o Valor de outras retenções.
        /// </summary>
        [NFeField(ID = "U08", FieldName = "vOutro", DataType = "TDec_1302Opc")]
        public decimal? ValorOutrasRetencoes { get; set; }

        /// <summary>
        /// [vDescIncond] Retorna ou define o Valor de Desconto Incondicionado.
        /// </summary>
        [NFeField(ID = "U09", FieldName = "vDescIncond", DataType = "TDec_1302Opc")]
        public decimal? ValorDescontoIncondicionado { get; set; }

        /// <summary>
        /// [vDescCond] Retorna ou define o Valor de Desconto Condicionado.
        /// </summary>
        [NFeField(ID = "U10", FieldName = "vDescCond", DataType = "TDec_1302Opc")]
        public decimal? ValorDescontoCondicionado { get; set; }

        /// <summary>
        /// [vISSRet] Retorna ou define o Valor de retenção do ISS.
        /// </summary>
        [NFeField(ID = "U11", FieldName = "vISSRet", DataType = "TDec_1302Opc")]
        public decimal? ValorIssRetido { get; set; }

        /// <summary>
        /// [indISS] Retorna ou define o indicador de exigibilidade do ISS.
        /// </summary>
        [NFeField(ID = "U12", FieldName = "indISS")]
        public IndicadorExigibilidadeIss IndicadorExigibilidade { get; set; }

        /// <summary>
        /// [cServico] Retorna ou define o Código do Serviço Prestado dentro do Município.
        /// </summary>
        [NFeField(ID = "U13", FieldName = "cServico")]
        public string CodigoServicoPrestadoMunicipio
        {
            get => _codigoServicoPrestadoMunicipio;
	        set => _codigoServicoPrestadoMunicipio = ValidationUtil.ValidateRange(value, 1, 20, "CodigoServicoPrestadoMunicipio");
        }

        /// <summary>
        /// [cMun] Retorna ou define o Código do Município de Incidência do Imposto.
        /// </summary>
        [NFeField(ID = "U14", FieldName = "cMun", DataType = "TCodMunIBGE")]
        public int? CodigoMunicipioIncidenciaImposto { get; set; }

        /// <summary>
        /// [cPais] Retorna ou define o Código do País onde o serviço foi prestado.
        /// </summary>
        [NFeField(ID = "U15", FieldName = "cPais", DataType = "Tpais")]
        public int? CodigoPaisServicoPrestado { get; set; }

        /// <summary>
        /// [nProcesso] Retorna ou define o Númerp do Processo administrativo ou judicial de
        /// suspensão do processo.
        /// </summary>
        [NFeField(ID = "U16", FieldName = "nProcesso", DataType = "xs:string", MinLength = 1, MaxLength = 30)]
        public string NumeroProcessoSuspensao
        {
            get => _numeroProcessoSuspensao;
	        set => _numeroProcessoSuspensao = ValidationUtil.ValidateRange(value, 1, 30, "NumeroProcessoSuspensao");
        }

        /// <summary>
        /// [indIncentivo] Retorna ou define o valor indicando se existe ou não incentivo fiscal.
        /// </summary>
        [NFeField(ID = "U17", FieldName = "indIncentivo", DataType = "xs:string")]
        public bool PossuiIncentivoFiscal { get; set; }

        /// <summary>
        /// Retorna se a Classe foi modificada
        /// </summary>
        public bool Modificado => Aliquota != 0m ||
                                  BaseCalculo != 0m ||
                                  ValorISSQN != 0m ||
                                  CodigoMunicipioFatoGeradorIBGE != 0 ||
                                  !String.IsNullOrEmpty(CodigoServico) ||
                                  ValorDeducao.HasValue ||
                                  ValorOutrasRetencoes.HasValue ||
                                  ValorDescontoIncondicionado.HasValue ||
                                  ValorDescontoCondicionado.HasValue ||
                                  ValorIssRetido.HasValue ||
                                  IndicadorExigibilidade.IsDefined() ||
                                  !String.IsNullOrEmpty(CodigoServicoPrestadoMunicipio) ||
                                  CodigoMunicipioIncidenciaImposto.HasValue ||
                                  CodigoPaisServicoPrestado.HasValue ||
                                  !String.IsNullOrEmpty(NumeroProcessoSuspensao) ||
                                  PossuiIncentivoFiscal;

        void ISerializavel.Serializar(System.Xml.XmlWriter writer, INFe nfe)
        {
            writer.WriteStartElement("ISSQN"); // Elemento 'ISSQN'
            writer.WriteElementString("vBC", BaseCalculo.ToTDec_1302());
            writer.WriteElementString("vAliq", Aliquota.ToTDec_0302a04());
            writer.WriteElementString("vISSQN", ValorISSQN.ToTDec_1302());
            writer.WriteElementString("cMunFG", SerializationUtil.ToString7(CodigoMunicipioFatoGeradorIBGE));
            writer.WriteElementString("cListServ", CodigoServico);

            if (ValorDeducao.HasValue)
                writer.WriteElementString("vDeducao", ValorDeducao.ToTDec_1302Opc());

            if (ValorOutrasRetencoes.HasValue)
                writer.WriteElementString("vOutro", ValorOutrasRetencoes.ToTDec_1302Opc());

            if (ValorDescontoIncondicionado.HasValue)
                writer.WriteElementString("vDescIncond", ValorDescontoIncondicionado.ToTDec_1302Opc());

            if (ValorDescontoCondicionado.HasValue)
                writer.WriteElementString("vDescCond", ValorDescontoCondicionado.ToTDec_1302Opc());

            if (ValorIssRetido.HasValue)
                writer.WriteElementString("vISSRet", ValorIssRetido.ToTDec_1302Opc());

            writer.WriteElementString("indISS", IndicadorExigibilidade.GetEnumValue());

            if (!String.IsNullOrEmpty(CodigoServicoPrestadoMunicipio))
                writer.WriteElementString("cServico", CodigoServicoPrestadoMunicipio);

            if (CodigoMunicipioIncidenciaImposto.HasValue)
                writer.WriteElementString("cMun", CodigoMunicipioIncidenciaImposto.ToString());

            if (CodigoPaisServicoPrestado.HasValue)
                writer.WriteElementString("cPais", CodigoPaisServicoPrestado.ToString());

            if (!String.IsNullOrEmpty(NumeroProcessoSuspensao))
                writer.WriteElementString("nProcesso", NumeroProcessoSuspensao);

            writer.WriteElementString("indIncentivo", PossuiIncentivoFiscal ? "1" : "2");

            writer.WriteEndElement(); // Elemento 'ISSQN'
        }
    }
}