﻿using NotaFiscalNet.Core.Interfaces;
using NotaFiscalNet.Core.Utils;
using NotaFiscalNet.Core.Validacao;

using System;
using System.Xml;

namespace NotaFiscalNet.Core
{
    /// <summary>
    /// Representa um Item de Produto do Detalhe da Nota Fiscal Eletrônica.
    /// </summary>
    public sealed class Produto : ISerializavel, IModificavel
    {
        private string _informacoesAdicionais = string.Empty;
	    private string _codigo = string.Empty;
        private string _codigoGTIN = string.Empty;
        private string _descricao = string.Empty;
        private string _codigoNCM;
        private string _codigoNVE;
        private string _CodigoEXTIPI = string.Empty;
        private int _cfop;
        private string _unidadeComercial = string.Empty;
        private decimal _quantidade;
        private decimal _valorUnitario;
        private decimal _valorTotalBruto;
        private string _codigoGTINTributario = string.Empty;
        private string _unidadeTributavel = string.Empty;
        private decimal _quantidadeTributavel;
        private decimal _valorUnitarioTributavel;
        private decimal _valorTotalFrete;
        private decimal _valorTotalSeguro;
        private decimal _valorDesconto;
        private decimal _valorOutrasDespesasAcessorias;
	    private TipoProdutoEspecifico _tipoProdutoEspecifico;
	    private string _pedidoCompra;
        private int _itemPedidoCompra;

        private string _numeroRecopi;
        private Guid? _numeroFci;

        /// <summary>
        /// [nItem] Retorna o número do item gerado automaticamente. Este número é sequencial, e vai
        /// de 1 até 990.
        /// </summary>
        /// <remarks>
        /// Caso um item seja removido da coleção ProdutoCollection, todos os itens na coleção serão re-enumerados.
        /// </remarks>
        [NFeField(ID = "H02", FieldName = "nItem", DataType = "token", Pattern = "[1-9]{1}[0-9]{0,1}|[1-8]{1}[0-9]{2}|[9]{1}[0-8]{1}[0-9]{1}|[9]{1}[9]{1}[0]{1}", NodeType = XmlNodeType.Attribute)]
        [CampoValidavel(1, Opcional = true)]
        public int NumeroItem { get; internal set; }

        /// <summary>
        /// [cProd] Retorna ou define o Código do Produto ou Serviço. Preencher com CFOP caso se
        /// trate de itens não relacionados com mercadorias/produto e que o contribuinte não possua
        /// codificação própria. Neste caso, o formato do código deverá ser 'CFOP9999'.
        /// </summary>
        [NFeField(FieldName = "cProd", DataType = "token", ID = "I02", MinLength = 1, MaxLength = 60)]
        [CampoValidavel(2, ChaveErroValidacao.CampoNaoPreenchido)]
        public string Codigo
        {
            get => _codigo;
	        set => _codigo = ValidationUtil.TruncateString(value, 60) ?? string.Empty;
        }

        /// <summary>
        /// [cEAN] Retorna ou define o Código GTIN (Global Trade Item Number) do produto. Preencher
        /// com o código GTIN-8, GTIN-12, GTIN-13 ou GTIN-14 (antigos códigos EAN, UPC e DUN-14), não
        /// informar se o produto não possuir este código.
        /// </summary>
        [NFeField(FieldName = "cEAN", DataType = "token", ID = "I03", Pattern = @"[0-9]{0}|[0-9]{8}|[0-9]{12,14}")]
        [CampoValidavel(3, Opcional = true)]
        public string CodigoGTIN
        {
            get => _codigoGTIN;
	        set
            {
                ValidationUtil.ValidateGTIN(value, "CodigoGTIN");
                _codigoGTIN = value ?? string.Empty;
            }
        }

        /// <summary>
        /// [xProd] Retorna ou define a Descrição do Produto (ou serviço).
        /// </summary>
        [NFeField(FieldName = "xProd", DataType = "token", ID = "I04", MinLength = 1, MaxLength = 120)]
        [CampoValidavel(4, ChaveErroValidacao.CampoNaoPreenchido)]
        public string Descricao
        {
            get => _descricao;
	        set => _descricao = ValidationUtil.TruncateString(value, 120) ?? string.Empty;
        }

        /// <summary>
        /// [NCM] Retorna ou define o Código NCM (Nomenclatura Comun do Mercosul). Tamanho (8
        /// caracteres numéricos). Ver tabela de Capítulos da NCM. Será permitida a informação do
        /// gênero (posição do capítulo do NCM) quando a operação não for de comércio exterior
        /// (importação/exportação) ou o produto não seja tributado pelo IPI. Em caso de item de
        /// serviço ou item que não tenham produto (Ex. transferência de crédito, crédito do ativo
        /// imobilizado, etc.), informar o código 00 (zeros) (v2.0)
        /// </summary>
        [NFeField(FieldName = "NCM", DataType = "token", ID = "I05", Pattern = @"[0-9]{8}")]
        [CampoValidavel(5, ChaveErroValidacao.CampoNaoPreenchido)]
        public string CodigoNCM
        {
            get => _codigoNCM;
	        set
            {
                ValidationUtil.ValidateNCM(value, "CodigoNCM");
                _codigoNCM = value;
            }
        }

        /// <summary>
        /// [NVE] Retorna ou define o Código NVE (Nomenclatura de Valor Aduaneiro e Estatística).
        /// </summary>
        [NFeField(FieldName = "NVE", ID = "105a", Pattern = @"[A-Z]{2}[0-9]{4}")]
        [CampoValidavel(5, ChaveErroValidacao.CampoNaoPreenchido)]
        public string CodigoNVE
        {
            get => _codigoNVE;
	        set => _codigoNVE = ValidationUtil.ValidateNVE(value, "CodigoNVE");
        }

        /// <summary>
        /// [EXTIPI] Retorna ou define o Código Ex (desdobramento de classificação) da TIPI (Tabela
        /// de Incidência do imposto sobre Produtos Industrializados). <br/> Em caso de Serviço, o
        /// valor não deverá ser informado. Formato 00 ou 000.
        /// </summary>
        [NFeField(FieldName = "EXTIPI", DataType = "token", ID = "I08", Pattern = @"[0-9]{2,3}", Opcional = true)]
        [CampoValidavel(6, Opcional = true)]
        public string CodigoExTIPI
        {
            get => _CodigoEXTIPI;
	        set => _CodigoEXTIPI = ValidationUtil.ValidateExTIPI(value, "CodigoExTIPI") ?? string.Empty;
        }

        /// <summary>
        /// [CFOP] Retorna ou define o CFOP (Código Fiscal de Operações e Prestações).
        /// </summary>
        [NFeField(FieldName = "CFOP", DataType = "TCfop", ID = "I08", Pattern = @"[123567][0-9]([0-9][1-9]|[1-9][0-9])")]
        [CampoValidavel(8, ChaveErroValidacao.CampoNaoPreenchido)]
        public int CFOP
        {
            get => _cfop;
	        set => _cfop = ValidationUtil.ValidateTCfop(value, "CFOP");
        }

        /// <summary>
        /// [uCom] Retorna ou define a Unidade (ex. PCT, CX, UND, KG, CM, etc) de comercialização do produto.
        /// </summary>
        [NFeField(FieldName = "uCom", DataType = "token", ID = "I09", MinLength = 1, MaxLength = 6)]
        [CampoValidavel(9, ChaveErroValidacao.CampoNaoPreenchido)]
        public string Unidade
        {
            get => _unidadeComercial;
	        set => _unidadeComercial = ValidationUtil.TruncateString(value, 6) ?? string.Empty;
        }

        /// <summary>
        /// [qCom] Retorna ou define a Quantidade (referente ao número de itens deste item de produto
        /// ou serviço sendo vendido). Permite até 4 casas decimais, e 11 inteiros.
        /// </summary>
        [NFeField(FieldName = "qCom", DataType = "TDec_1504", ID = "I10", Pattern = @"0|0\.[0-9]{1,4}|[1-9]{1}[0-9]{0,14}|[1-9]{1}[0-9]{0,14}(\.[0-9]{1,4})?")]
        [CampoValidavel(10, ChaveErroValidacao.CampoNaoPreenchido)]
        public decimal Quantidade
        {
            get => _quantidade;
	        set => _quantidade = ValidationUtil.ValidateTDec_1104v(value, "Quantidade");
        }

        /// <summary>
        /// [vUnCom] Retorna ou define o Valor Unitário do produto (ou serviço). Informar até 10
        /// casas decimais (se maior, será arredondado para cima).
        /// </summary>
        [NFeField(FieldName = "vUnCom", DataType = "TDec_1110", ID = "I10a", Pattern = @"0|0\.[0-9]{1,10}|[1-9]{1}[0-9]{0,10}|[1-9]{1}[0-9]{0,10}(\.[0-9]{1,10})?")]
        [CampoValidavel(11, ChaveErroValidacao.CampoNaoPreenchido)]
        public decimal ValorUnitario
        {
            get => _valorUnitario;
	        set => _valorUnitario = ValidationUtil.ValidateTDec_1110(value, "ValorUnitario");
        }

        /// <summary>
        /// [vProd] Retorna ou define o Valor Total Bruto dos Produtos ou Serviços.
        /// </summary>
        [NFeField(FieldName = "vProd", DataType = "TDec_1302", ID = "I11", Pattern = @"0|0\.[0-9]{2}|[1-9]{1}[0-9]{0,12}(\.[0-9]{2})?")]
        [CampoValidavel(12, ChaveErroValidacao.CampoNaoPreenchido)]
        public decimal ValorTotalBruto
        {
            get => _valorTotalBruto;
	        set => _valorTotalBruto = ValidationUtil.ValidateTDec_1302(value, "ValorTotalBruto");
        }

        /// <summary>
        /// [cEANTrib] Retorna ou define o Código GTIN (Global Trade Item Number) da unidade
        /// tributável do produto. Preencher com o código GTIN-8, GTIN-12, GTIN-13 ou GTIN-14
        /// (antigos códigos EAN, UPC e DUN-14) da unidade tributável do produto. Não informar caso
        /// de o produto não possua este código.
        /// </summary>
        [NFeField(FieldName = "cEANTrib", DataType = "token", ID = "I12", Pattern = @"[0-9]{0}|[0-9]{8}|[0-9]{12,14}")]
        [CampoValidavel(13, Opcional = true)]
        public string CodigoGTINTributario
        {
            get => _codigoGTINTributario;
	        set => _codigoGTINTributario = ValidationUtil.ValidateGTIN(value, "CodigoGTINTributario") ?? string.Empty;
        }

        /// <summary>
        /// [uTrib] Retorna ou define a Unidade Tributável do produto. De 1 a 6 caracteres.
        /// </summary>
        [NFeField(FieldName = "uTrib", DataType = "token", ID = "I13", MinLength = 1, MaxLength = 6)]
        [CampoValidavel(14, ChaveErroValidacao.CampoNaoPreenchido)]
        public string UnidadeTributavel
        {
            get => _unidadeTributavel;
	        set => _unidadeTributavel = ValidationUtil.TruncateString(value, 6) ?? string.Empty;
        }

        /// <summary>
        /// [qTrib] Retorna ou define a Quantidade Tributável.
        /// </summary>
        [NFeField(FieldName = "qTrib", DataType = "TDec_1504", ID = "I14", Pattern = @"0|0\.[0-9]{1,4}|[1-9]{1}[0-9]{0,14}|[1-9]{1}[0-9]{0,14}(\.[0-9]{1,4})?")]
        [CampoValidavel(15, ChaveErroValidacao.CampoNaoPreenchido)]
        public decimal QuantidadeTributavel
        {
            get => _quantidadeTributavel;
	        set => _quantidadeTributavel = ValidationUtil.ValidateTDec_1104v(value, "QuantidadeTributavel");
        }

        /// <summary>
        /// [vUnTrib] Retorna ou define o Valor Unitário de Tributação.
        /// </summary>
        [NFeField(FieldName = "vUnTrib", DataType = "TDec_1110", ID = "I14a", Pattern = @"0|0\.[0-9]{1,10}|[1-9]{1}[0-9]{0,10}|[1-9]{1}[0-9]{0,10}(\.[0-9]{1,10})?")]
        [CampoValidavel(16, ChaveErroValidacao.CampoNaoPreenchido)]
        public decimal ValorUnitarioTributavel
        {
            get => _valorUnitarioTributavel;
	        set => _valorUnitarioTributavel = ValidationUtil.ValidateTDec_1110(value, "ValorUnitarioTributavel");
        }

        /// <summary>
        /// [vFrete] Retorna ou define o Valor Total do Frete. Opcional.
        /// </summary>
        [NFeField(FieldName = "vFrete", DataType = "TDec_1302Opc", ID = "I15", Pattern = @"0\.[0-9]{1}[1-9]{1}|0\.[1-9]{1}[0-9]{1}|[1-9]{1}[0-9]{0,12}(\.[0-9]{2})?", Opcional = true)]
        [CampoValidavel(17, Opcional = true)]
        public decimal ValorTotalFrete
        {
            get => _valorTotalFrete;
	        set => _valorTotalFrete = ValidationUtil.ValidateTDec_1302Opc(value, "ValorTotalFrete");
        }

        /// <summary>
        /// [vSeg] Retorna ou define o Valor Total do Seguro. Opcional.
        /// </summary>
        [NFeField(FieldName = "vSeg", DataType = "TDec_1302Opc", ID = "I16", Pattern = @"0\.[0-9]{1}[1-9]{1}|0\.[1-9]{1}[0-9]{1}|[1-9]{1}[0-9]{0,12}(\.[0-9]{2})?")]
        [CampoValidavel(18, Opcional = true)]
        public decimal ValorTotalSeguro
        {
            get => _valorTotalSeguro;
	        set => _valorTotalSeguro = ValidationUtil.ValidateTDec_1302Opc(value, "ValorTotalSeguro");
        }

        /// <summary>
        /// [vDesc] Retorna ou define o Valor do Desconto do produto.
        /// </summary>
        [NFeField(FieldName = "vDesc", DataType = "TDec_1302Opc", ID = "I17", Pattern = @"0\.[0-9]{1}[1-9]{1}|0\.[1-9]{1}[0-9]{1}|[1-9]{1}[0-9]{0,12}(\.[0-9]{2})?")]
        [CampoValidavel(19, Opcional = true)]
        public decimal ValorDesconto
        {
            get => _valorDesconto;
	        set => _valorDesconto = ValidationUtil.ValidateTDec_1302Opc(value, "ValorDesconto");
        }

        /// <summary>
        /// [vOutro] Retorna ou define outras despesas acessórias.
        /// </summary>
        [NFeField(FieldName = "vOutro", DataType = "TDec_1302Opc", ID = "I17", Pattern = @"0\.[0-9]{1}[1-9]{1}|0\.[1-9]{1}[0-9]{1}|[1-9]{1}[0-9]{0,12}(\.[0-9]{2})?")]
        [CampoValidavel(20, Opcional = true)]
        public decimal ValorOutrasDespesasAcessorias
        {
            get => _valorOutrasDespesasAcessorias;
	        set => _valorOutrasDespesasAcessorias = ValidationUtil.ValidateTDec_1302Opc(value, "ValorOutrasDespesasAcessorias");
        }

        /// <summary>
        /// [indTot] Retorna ou define se o item ou produto compoe o valor total da NFe. Este campo
        /// deverá ser preenchido com: False – o valor do item (vProd) não compõe o valor total da
        /// NF-e (vProd) True – o valor do item (vProd) compõe o valor total da NF-e (vProd)
        /// </summary>
        [NFeField(FieldName = "indTot"), CampoValidavel(20, Opcional = true)]
        public bool ItemCompoeValorTotalNFe { get; set; }

        /// <summary>
        /// [DI] Retorna a lista de Declarações de Importação do Produto. Opcional.
        /// </summary>
        [NFeField(FieldName = "DI", ID = "I18", Opcional = true)]
        [CampoValidavel(20, Opcional = true)]
        public DeclaracaoImportacaoCollection DeclaracoesImportacao { get; }

	    /// <summary>
        /// [detExport] Retorna a lista com o detalhamento da Exportação.
        /// </summary>
        [NFeField(FieldName = "detExport", ID = "I50", Opcional = true)]
        public DetalheExportacaoCollection DetalhamentoExportacao { get; }

	    /// <summary>
        /// [xPed] Retorna ou define o Pedido de Compra, informação de interesse do emissor para
        /// controle do B2B
        /// </summary>
        [NFeField(FieldName = "xPed", DataType = "token", MinLength = 1, MaxLength = 15)]
        [CampoValidavel(21, Opcional = true)]
        public string PedidoCompra
        {
            get => _pedidoCompra;
	        set => _pedidoCompra = ValidationUtil.TruncateString(value, 15);
        }

        /// <summary>
        /// [nItemPed] Retorna ou define o número do item do pedido de compra
        /// </summary>
        [NFeField(FieldName = "nItemPed", Pattern = @"[0-9]{1,6}", Opcional = true)]
        [CampoValidavel(5, Opcional = true)]
        public int ItemPedidoCompra
        {
            get => _itemPedidoCompra;
	        set
            {
                ValidationUtil.ValidateRange(value, 0, 999999, "ItemPedidoCompra");
                _itemPedidoCompra = value;
            }
        }

        /// <summary>
        /// [nFCI] Retorna ou define o número de controle da FCI (Ficha de Conteúdo de Importação).
        /// </summary>
        [NFeField(FieldName = "nFCI", Pattern = @"TGuid", Opcional = true)]
        public Guid? NumeroFCI
        {
            get => _numeroFci;
	        set
            {
                if (value == Guid.Empty)
                    _numeroFci = null;
                _numeroFci = value;
            }
        }

        /// <summary>
        /// Retorna ou define o Tipo de Produto Específico (que indica se haverá detalhamento do
        /// produto ou não).
        /// </summary>
        public TipoProdutoEspecifico TipoProdutoEspecifico
        {
            get => _tipoProdutoEspecifico;
	        set => _tipoProdutoEspecifico = ValidationUtil.ValidateEnum(value, "TipoProdutoEspecifico");
        }

        /// <summary>
        /// [veicProd] Retorna os detalhes do produto referente a um Veículo Novo.
        /// </summary>
        /// <remarks>Informar apenas se o campo TipoProdutoEspecifico for igual a 'VeiculoNovo'.</remarks>
        [NFeField(FieldName = "veicProd", ID = "J01", Opcional = true)]
        [CampoValidavel(21)]
        public VeiculoNovo DetalhamentoVeiculo { get; }

	    /// <summary>
        /// [med] Retorna ou define a lista de detalhamentos de Medicamentos.
        /// </summary>
        /// <remarks>Informar apenas se o campo TipoProdutoEspecifico for igual a 'Medicamento'.</remarks>
        [NFeField(FieldName = "med", ID = "K01")]
        [CampoValidavel(22)]
        //[ValidateField(22, Opcional = true)]
        public MedicamentoCollection DetalhamentoMedicamento { get; }

	    /// <summary>
        /// [arma] Retorna ou define a lista de detalhamentos de Armamentos. Informar apenas se o
        /// campo TipoProdutoEspecifico for igual a 'Armamento'.
        /// </summary>
        [NFeField(FieldName = "arma", ID = "L01")]
        [CampoValidavel(23)]
        public ArmamentoCollection DetalhamentoArmamento { get; }

	    /// <summary>
        /// [comb] Retorna o detalhamento das informações de Combustível.
        /// </summary>
        /// <remarks>Informar apenas se o campo TipoProdutoEspecifico for igual a 'Combustivel'.</remarks>
        [NFeField(FieldName = "comb", ID = "L101")]
        [CampoValidavel(24)]
        public Combustivel DetalhamentoCombustivel { get; }

	    /// <summary>
        /// [nRECOPI] Retorna ou define o Número do RECOPI (Registro e Controle das Operações com o
        /// Papel Imune Nacional).
        /// </summary>
        [NFeField(FieldName = "nRECOPI", Pattern = @"[0-9]{20}", Opcional = true)]
        public string NumeroRECOPI
        {
            get => _numeroRecopi;
	        set
            {
                if (!ValidationUtil.ValidateRegex(value, "^[0-9]{20}$"))
                    throw new ArgumentException("O valor informado para o Número do RECOPI é inválido.");
                _numeroRecopi = value;
            }
        }

        /// <summary>
        /// [infAdProd] Retorna ou define as Informações Adicionais do Produto (norma referenciada,
        /// informações complementares). Opcional.
        /// </summary>
        [NFeField(ID = "V01", FieldName = "infAdProd", DataType = "TString", MinLength = 1, MaxLength = 500, Pattern = "[1-9]{1}[0-9]{0,1}|[1-8]{1}[0-9]{2}|[9]{1}[0-8]{1}[0-9]{1}|[9]{1}[9]{1}[0]{1}", Opcional = true)]
        [CampoValidavel(25, Opcional = true)]
        public string InformacoesAdicionais
        {
            get => _informacoesAdicionais;
	        set => _informacoesAdicionais = ValidationUtil.TruncateString(value, 500);
        }

        /// <summary>
        /// [imposto] Retorna ou define os Impostos do Produto
        /// </summary>
        [NFeField(ID = "M01", FieldName = "imposto")]
        [CampoValidavel(26, ChaveErroValidacao.CampoNaoPreenchido)]
        public ImpostoProduto Imposto { get; }

	    /// <summary>
        /// [impostoDevol] Retorna ou define as informações do Imposto Devolvido.
        /// </summary>
        [NFeField(ID = "U50", FieldName = "impostoDevol"), CampoValidavel(26, ChaveErroValidacao.CampoNaoPreenchido)]
        public ImpostoDevolvido ImpostoDevolvido { get; set; }

        /// <summary>
        /// Retorna se a Classe foi modificada
        /// </summary>
        public bool Modificado => !string.IsNullOrEmpty(Codigo) ||
                                  !string.IsNullOrEmpty(CodigoGTIN) ||
                                  !string.IsNullOrEmpty(Descricao) ||
                                  !string.IsNullOrEmpty(CodigoNCM) ||
                                  !string.IsNullOrEmpty(CodigoNVE) ||
                                  !string.IsNullOrEmpty(CodigoExTIPI) ||
                                  CFOP != 0 ||
                                  !string.IsNullOrEmpty(Unidade) ||
                                  Quantidade != 0m ||
                                  ValorUnitario != 0m ||
                                  ValorTotalBruto != 0m ||
                                  !string.IsNullOrEmpty(CodigoGTINTributario) ||
                                  !string.IsNullOrEmpty(UnidadeTributavel) ||
                                  QuantidadeTributavel != 0m ||
                                  ValorUnitarioTributavel != 0m ||
                                  ValorTotalFrete != 0m ||
                                  ValorTotalSeguro != 0m ||
                                  ValorDesconto != 0m ||
                                  ValorOutrasDespesasAcessorias != 0m ||
                                  DeclaracoesImportacao.Modificado ||
                                  DetalhamentoExportacao.Count > 0 ||
                                  !string.IsNullOrEmpty(PedidoCompra) ||
                                  ItemPedidoCompra != 0 ||
                                  NumeroFCI.HasValue && NumeroFCI.Value != Guid.Empty ||
                                  DetalhamentoVeiculo.Modificado ||
                                  DetalhamentoMedicamento.Modificado ||
                                  DetalhamentoArmamento.Modificado ||
                                  DetalhamentoCombustivel.Modificado ||
                                  !String.IsNullOrEmpty(NumeroRECOPI) ||
                                  Imposto.Modificado ||
                                  !string.IsNullOrEmpty(InformacoesAdicionais);

        /// <summary>
        /// Inicializa uma nova instância da classe Produto.
        /// </summary>
        public Produto()
        {
            _informacoesAdicionais = string.Empty;
            Imposto = new ImpostoProduto(this);
            _codigo = string.Empty;
            _codigoGTIN = string.Empty;
            _codigoNCM = string.Empty;
            _codigoNVE = string.Empty;
            _descricao = string.Empty;
            _CodigoEXTIPI = string.Empty;
            ItemCompoeValorTotalNFe = true;
            _unidadeComercial = string.Empty;
            _codigoGTINTributario = string.Empty;
            _unidadeTributavel = string.Empty;
            DeclaracoesImportacao = new DeclaracaoImportacaoCollection(this);
            DetalhamentoExportacao = new DetalheExportacaoCollection();
            _tipoProdutoEspecifico = TipoProdutoEspecifico.ProdutoNaoEspecifico;
            DetalhamentoVeiculo = new VeiculoNovo(this);
            DetalhamentoMedicamento = new MedicamentoCollection(this);
            DetalhamentoArmamento = new ArmamentoCollection(this);
            DetalhamentoCombustivel = new Combustivel(this);
        }

        public void Serializar(XmlWriter writer, INFe nfe)
        {
            writer.WriteStartElement("det");
            writer.WriteAttributeString("nItem", NumeroItem.ToString());

            /// início do elemento 'prod'
            writer.WriteStartElement("prod");

            writer.WriteElementString("cProd", Codigo.ToToken(60));
            writer.WriteElementString("cEAN", CodigoGTIN.ToToken(14));
            writer.WriteElementString("xProd", Descricao.ToToken(120));
            writer.WriteElementString("NCM", CodigoNCM.ToToken(8));

            if (!String.IsNullOrEmpty(CodigoNVE))
                writer.WriteElementString("NVE", CodigoNVE);

            if (IsStrValid(CodigoExTIPI))
                writer.WriteElementString("EXTIPI", CodigoExTIPI.ToToken(3));

            writer.WriteElementString("CFOP", CFOP == 0 ? null : CFOP.ToString());
            writer.WriteElementString("uCom", Unidade.ToToken(6));
            writer.WriteElementString("qCom", Quantidade.ToTDec_1104v());
            writer.WriteElementString("vUnCom", ValorUnitario.ToTDec_1110());
            writer.WriteElementString("vProd", ValorTotalBruto.ToTDec_1302());
            writer.WriteElementString("cEANTrib", CodigoGTINTributario.ToToken(14));
            writer.WriteElementString("uTrib", UnidadeTributavel.ToToken(6));
            writer.WriteElementString("qTrib", QuantidadeTributavel.ToTDec_1104v());
            writer.WriteElementString("vUnTrib", ValorUnitarioTributavel.ToTDec_1110());

            if (ValorTotalFrete > 0)
                writer.WriteElementString("vFrete", ValorTotalFrete.ToTDec_1302());

            if (ValorTotalSeguro > 0)
                writer.WriteElementString("vSeg", ValorTotalSeguro.ToTDec_1302());

            if (ValorDesconto > 0)
                writer.WriteElementString("vDesc", ValorDesconto.ToTDec_1302());

            if (ValorOutrasDespesasAcessorias > 0)
                writer.WriteElementString("vOutro", ValorOutrasDespesasAcessorias.ToTDec_1302());

            writer.WriteElementString("indTot", ItemCompoeValorTotalNFe ? "1" : "0");

            // Escreve o elemento 'DI' caso tenha sido preenchido.
            DeclaracoesImportacao.Serializar(writer, nfe);

            // Escreve o elemento 'detExport', caso haja um na coleção
            DetalhamentoExportacao.Serializar(writer, nfe);

            if (IsStrValid(PedidoCompra))
                writer.WriteElementString("xPed", PedidoCompra.ToToken(15));

            if (ItemPedidoCompra > 0)
                writer.WriteElementString("nItemPed", ItemPedidoCompra.ToToken());

            if (NumeroFCI.HasValue && NumeroFCI.Value != Guid.Empty)
                writer.WriteElementString("nFCI", NumeroFCI.ToString().ToUpper());

            switch (TipoProdutoEspecifico)
            {
                case TipoProdutoEspecifico.VeiculoNovo:
                    Render(DetalhamentoVeiculo, writer, nfe);
                    break;

                case TipoProdutoEspecifico.Medicamento:
                    Render(DetalhamentoMedicamento, writer, nfe);
                    break;

                case TipoProdutoEspecifico.Armamento:
                    Render(DetalhamentoArmamento, writer, nfe);
                    break;

                case TipoProdutoEspecifico.Combustivel:
                    Render(DetalhamentoCombustivel, writer, nfe);
                    break;

                case TipoProdutoEspecifico.PapelImune:
                    writer.WriteElementString("nRECOPI", NumeroRECOPI);
                    break;
            }

            writer.WriteEndElement(); // fim do elemento 'prod'

            ((ISerializavel)Imposto).Serializar(writer, nfe);

            ImpostoDevolvido.SerializeIfNotNull(writer, nfe);

            if (!string.IsNullOrEmpty(InformacoesAdicionais))
                writer.WriteElementString("infAdProd", SerializationUtil.ToTString(InformacoesAdicionais, 500));

            writer.WriteEndElement(); // fim do elemento 'det'
        }

        private bool IsStrValid(string value)
        {
            return !string.IsNullOrEmpty(value) && value.Length > 0;
        }

        private void Render(ISerializavel entity, XmlWriter writer, INFe nfe)
        {
            entity.Serializar(writer, nfe);
        }
    }
}