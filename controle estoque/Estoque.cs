using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace controle_estoque
{
    public class Estoque: IControleEstoque
 
   {
        privact Dictionary<string, Produtos> _Produtos;
        
    public Estoque()
        {
            _produtos = new Dictionary<string, Produto>();

        }
        public void AdcionarProduto(string sku, string nomeProduto, int estoqueEntrada, decimal precoEntrada, decimal precoSaida)
        {
            var produto = new Produtos
            {
                SKU = sku,
                NomeProduto = nomeProduto,
                EstoqueEntrada = estoqueEntrada,
                PrecoEntrada = precoEntrada,
                PrecoSaida = precoSaida
            };
            _produtos[sku] = produto;
        }
        public Produtos BuscarProdutosPorSKU( sku)
        {
            return _produtos.GetValueOrDefault(sku);

        }
        public void AtualizarEstoque(string sku, int estoqueSaida, decimal precoSaida)
        {
            var produto = BuscarProdutoPorSKU(sku);
            if(produto != null)
            {
                produto.EstoqueEntrada -= EstoqueSaida;
                Console.WriteLine($"Venda registrada: {estoqueSaida} unidades de produto.NomeProduto}");
                var lucro = (precoSaida - produto.precoEntrada) * estoqueSaida;
                Console.WriteLine($"O lucro da venda: {lucro:C}");
}
            else
            {
                Console.WriteLine($"Não há estoque suficiente para vender o produto {produto.NomeProduto}.");

            }
       else
            {
                Console.WriteLine($"Produto com SKU {sku} não encontrado.");
            }
        }


    }

}
