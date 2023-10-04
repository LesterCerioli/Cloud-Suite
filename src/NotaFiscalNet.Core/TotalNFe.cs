﻿using NotaFiscalNet.Core.Interfaces;
using NotaFiscalNet.Core.Validacao;

namespace NotaFiscalNet.Core
{
    /// <summary>
    /// Contém as informações de Totalização da Nota Fiscal Eletrônica.
    /// </summary>

    public sealed class TotalNFe : ISerializavel
    {
	    /// <summary>
        /// Retorna o Total de ICMS
        /// </summary>
        [NFeField(ID = "W01", FieldName = "ICMSTot")]
        [CampoValidavel(1, ChaveErroValidacao.CampoNaoPreenchido)]
        public TotalICMS ICMS { get; } = new TotalICMS();

	    /// <summary>
        /// Retorna o Total de ISSQN. Opcional.
        /// </summary>
        [NFeField(ID = "W17", FieldName = "ISSQNtot", Opcional = true)]
        [CampoValidavel(2, Opcional = true)]
        public TotalISSQN ISSQN { get; } = new TotalISSQN();

	    /// <summary>
        /// Retorna as Retenções de Tributos Federais. Opcional.
        /// </summary>
        /// <remarks>
        /// Exemplos de atos normativos que definem obrigatoriedade da retenção de contribuições:
        /// a) IRPJ/CSLL/PIS/COFINS - Fonte - Recebimentos de Órgãos Públicos Federais Lei nº 9.430,
        ///    de 27 de dezembro de 1996, art. 64 Lei nº 10.833/2003, art. 34 como normas
        /// infralegais, temos como exemplo: Instrução Normativa SRF nº 480/2004 e Instrução
        /// Normativa nº 539, de 25/04/2005.
        /// b) Retenção do Imposto de Renda pelas Fontes Pagadoras REMUNERAÇÃO DE SERVIÇOS
        ///    PROFISSIONAIS PRESTADOS POR PESSOA JURÍDICA LEI Nº 7.450/85, ART. 52
        /// c) IRPJ, CSLL, COFINS e PIS - Serviços Prestados por Pessoas Jurídicas - Retenção na
        ///    Fonte Lei nº 10.833 de 29.12.2003, arts. 30, 31, 32, 35 e 36
        /// </remarks>
        [NFeField(ID = "W23", FieldName = "retTrib", Opcional = true)]
        [CampoValidavel(3, Opcional = true)]
        public RetencaoTributosFederais RetencaoTributosFederais { get; } = new RetencaoTributosFederais();

	    /// <summary>
        /// Retorna o valor indicando se a Nota Fiscal Eletrônica está em modo somente-leitura.
        /// </summary>
        /// <remarks>
        /// A Nota Fiscal Eletrônica estará em modo somente-leitura quando for instanciada a partir
        /// de um arquivo assinado digitalmente.
        /// </remarks>
        public bool IsReadOnly { get; } = false;

	    void ISerializavel.Serializar(System.Xml.XmlWriter writer, INFe nfe)
        {
            writer.WriteStartElement("total");

            ((ISerializavel)ICMS).Serializar(writer, nfe);
            if (ISSQN.Modificado)
                ((ISerializavel)ISSQN).Serializar(writer, nfe);
            if (RetencaoTributosFederais.Modificado)
                ((ISerializavel)RetencaoTributosFederais).Serializar(writer, nfe);

            writer.WriteEndElement(); // fim do elemento 'total'
        }
    }
}