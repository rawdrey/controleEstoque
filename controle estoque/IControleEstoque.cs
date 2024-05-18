using System;

namespace controle_estoque
{
    public interface IControleEstoque
    {
        void AdicionarProduto(string sku, string nomeProduto, int estoqueEntrada, decimal precoEntrada, decimal precoVenda);
        Produto BuscarProdutoPorSKU(string sku);
        void AtualizarEstoque(string sku, int quantidade, decimal precoSaida);
        void ListarProdutos();
    }
}
