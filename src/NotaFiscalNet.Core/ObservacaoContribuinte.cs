﻿using NotaFiscalNet.Core.Interfaces;
using NotaFiscalNet.Core.Utils;
using NotaFiscalNet.Core.Validacao;
using System.Xml;

namespace NotaFiscalNet.Core
{
    /// <summary>
    /// Representa as Observações de Uso Livre do Contribuinte
    /// </summary>
    public sealed class ObservacaoContribuinte : ISerializavel, IModificavel
    {
        private string _campo = string.Empty;
        private string _texto = string.Empty;

        /// <summary>
        /// Retorna ou define o Nome do Campo Livre
        /// </summary>
        [NFeField(ID = "Z05", FieldName = "xCampo", DataType = "token", MinLength = 1, MaxLength = 20, NodeType = XmlNodeType.Attribute)]
        [CampoValidavel(1, ChaveErroValidacao.CampoNaoPreenchido)]
        public string Campo
        {
            get => _campo;
	        set => _campo = ValidationUtil.TruncateString(value, 20);
        }

        /// <summary>
        /// Retorna ou define o Texto do Campo Livre
        /// </summary>
        [NFeField(ID = "Z06", FieldName = "xTexto", DataType = "token", MinLength = 1, MaxLength = 60)]
        [CampoValidavel(2, ChaveErroValidacao.CampoNaoPreenchido)]
        public string Texto
        {
            get => _texto;
	        set => _texto = ValidationUtil.TruncateString(value, 60);
        }

        /// <summary>
        /// Retorna se a Classe foi modificada
        /// </summary>
        public bool Modificado => !string.IsNullOrEmpty(Campo) ||
                                  !string.IsNullOrEmpty(Texto);

        public void Serializar(XmlWriter writer, INFe nfe)
        {
            writer.WriteStartElement("obsCont"); // Elemento 'obsCont'
            writer.WriteAttributeString("xCampo", SerializationUtil.ToToken(Campo, 20));
            writer.WriteElementString("xTexto", SerializationUtil.ToToken(Texto, 60));
            writer.WriteEndElement(); // Elemento 'obsCont'
        }
    }
}