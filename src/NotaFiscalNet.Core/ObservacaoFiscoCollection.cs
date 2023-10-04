﻿using NotaFiscalNet.Core.Interfaces;
using System;
using System.Linq;

namespace NotaFiscalNet.Core
{
    /// <summary>
    /// Representa uma Coleção de Observações do Fisco. Informar no máximo 10 observações.
    /// </summary>
    public sealed class ObservacaoFiscoCollection : BaseCollection<ObservacaoFisco>, ISerializavel, IModificavel
    {
        /// <summary>
        /// Quantidade Máxima de Elementos
        /// </summary>
        private int capacidade = 10;

        /// <summary>
        /// Override para não permitir adicionar além da capacidade
        /// </summary>
        /// <param name="e">CancelEventArgs</param>
        protected override void PreAdd(System.ComponentModel.CancelEventArgs e, ObservacaoFisco item)
        {
            if (Count == capacidade)
                throw new ApplicationException(
                    $"A capacidade máxima deste campo é de {capacidade.ToString()} observações.");

            base.PreAdd(e, item);
        }

	    /// <summary>
	    /// Retorna se existe alguma instancia da classe modificada na coleção
	    /// </summary>
	    public bool Modificado => this.Any(item => item.Modificado);

        void ISerializavel.Serializar(System.Xml.XmlWriter writer, INFe nfe)
        {
            foreach (ObservacaoFisco observacao in this)
            {
                if (observacao.Modificado)
                    observacao.Serializar(writer, nfe);
            }
        }
    }
}