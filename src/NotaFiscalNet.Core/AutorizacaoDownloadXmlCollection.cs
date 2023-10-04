using NotaFiscalNet.Core.Interfaces;
using System;
using System.ComponentModel;
using System.Xml;

namespace NotaFiscalNet.Core
{
    /// <summary>
    /// Representa uma cole��o de autoriza��es para acesso ao xml do documento fiscal
    /// </summary>
    /// <remarks>
    /// Essa classe � usada internamente pela dll para controlar a capacidade do n� serializ�vel
    /// </remarks>
    public sealed class AutorizacaoDownloadXmlCollection : BaseCollection<AutorizacaoDownloadXml>, ISerializavel
    {
        private const int CAPACIDADE = 10;

        /// <summary>
        /// Serializa a cole��o
        /// </summary>
        /// <param name="writer">Escritor</param>
        /// <param name="nfe">Documento Fiscal</param>
        public void Serializar(XmlWriter writer, INFe nfe)
        {
            foreach (var autorizacao in this)
            {
                ISerializavel obj = autorizacao;
                obj.Serializar(writer, nfe);
            }
        }

        /// <summary>
        /// Executa antes de adicionar a cole��o
        /// </summary>
        /// <param name="e">Evento</param>
        /// <param name="item">Autoriza��o</param>
        protected override void PreAdd(CancelEventArgs e, AutorizacaoDownloadXml item)
        {
            if (Count == CAPACIDADE)
                throw new ApplicationException(
                    $"A capacidade m�xima deste campo � de {CAPACIDADE} autoriza��o/autoriza��es.");

            base.PreAdd(e, item);
        }
    }
}