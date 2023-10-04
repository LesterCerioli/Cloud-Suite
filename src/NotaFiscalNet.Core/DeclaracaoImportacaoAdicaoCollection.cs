﻿using System.Linq;
using NotaFiscalNet.Core.Interfaces;
using System.Xml;

namespace NotaFiscalNet.Core
{
    /// <summary>
    /// Representa uma Coleção de Adições na Declaração de Importação do Produto
    /// </summary>
    public sealed class DeclaracaoImportacaoAdicaoCollection : BaseCollection<DeclaracaoImportacaoAdicao>,
        ISerializavel, IModificavel
    {
        /// <summary>
        /// Retorna se existe alguma instancia da classe modificada na coleção
        /// </summary>
        public bool Modificado => this.Any(item => item.Modificado);
	    
        public void Serializar(XmlWriter writer, INFe nfe)
        {
            foreach (var declaracao in this)
            {
                if (declaracao.Modificado)
                    declaracao.Serializar(writer, nfe);
            }
        }
    }
}