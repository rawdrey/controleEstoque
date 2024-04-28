using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace controle_estoque
{
    public class Estoque : IControleEstoque
    {
        private readonly Dictionary<string, Produto> _produtos;

        public Estoque()
        {
            _produtos = new Dictionary<string, Produto>();
        }

        public void AdicionarProduto(string sku, string nomeProduto, int estoqueEntrada, decimal precoEntrada)
        {
            if (_produtos.ContainsKey(sku))
            {
                _produtos[sku].Estoque += estoqueEntrada;
                _produtos[sku].PrecoEntrada = precoEntrada;
            }
            else
            {
                var produto = new Produto
                {
                    SKU = sku,
                    NomeProduto = nomeProduto,
                    Estoque = estoqueEntrada,
                    PrecoEntrada = precoEntrada,
                };
                _produtos[sku] = produto;
            }
            Console.WriteLine("Produto adicionado/atualizado com sucesso!");
        }

        public Produto BuscarProdutoPorSKU(string sku)
        {
            Produto produto;
            _produtos.TryGetValue(sku, out produto);
            return produto;
        }
    

    public void AtualizarEstoque(string sku, int quantidade, decimal precoSaida)
        {
            var produto = BuscarProdutoPorSKU(sku);
            if (produto != null)
            {
                if (produto.Estoque >= quantidade)
                {
                    produto.Estoque -= quantidade;
                    produto.PrecoSaida = precoSaida;
                    Console.WriteLine($"Venda registrada: {quantidade} unidades de {produto.NomeProduto}.");
                    var lucro = (precoSaida - produto.PrecoEntrada) * quantidade;
                    Console.WriteLine($"Lucro da venda: {lucro:C}");
                }
                else
                {
                    Console.WriteLine($"Não há estoque suficiente de {produto.NomeProduto} para a venda.");
                }
            }
            else
            {
                Console.WriteLine($"Produto com SKU {sku} não encontrado.");
            }
        }

        public void ListarProdutos()
        {
            Console.WriteLine("\nProdutos em Estoque:");
            foreach (var produto in _produtos.Values)
            {
                Console.WriteLine($"SKU: {produto.SKU}, Nome: {produto.NomeProduto}, Estoque: {produto.Estoque}, Preço de Entrada: {produto.PrecoEntrada:C}");
            }

        }

        public bool RemoverProduto(string sku)
        {
            if (_produtos.ContainsKey(sku))
            {
                _produtos.Remove(sku);
                return true;
            }
            return false;
        }
    }
}