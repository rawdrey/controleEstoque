using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace controle_estoque
{
    class Program
    {
        static void Main(string[] args)
        {
            var estoque = new Estoque();

            while (true)
            {
                Console.WriteLine("\nControle de Estoque");
                Console.WriteLine("1. Adicionar produto");
                Console.WriteLine("2. Adicionar venda");
                Console.WriteLine("3. Listar produtos");
                Console.WriteLine("4. Remover Produtos:");
                Console.WriteLine("5. Sair");

                Console.Write("Escolha uma opção (1/2/3/4/5): ");
                var opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        AdicionarProduto(estoque);
                        break;

                    case "2":
                        AdicionarVenda(estoque);
                        break;

                    case "3":
                        estoque.ListarProdutos();
                        break;
                    case "4":
                        RemoverProduto(estoque);
                        break;
                    case "5":
                        
                        Console.WriteLine("Encerrando o programa.");
                        return;

                    default:
                        Console.WriteLine("Opção inválida. Digite novamente.");
                        break;
                }
            }
        }

        static void AdicionarProduto(Estoque estoque)
        {
            Console.Write("Digite o SKU do produto: ");
            var sku = Console.ReadLine();
            Console.Write("Digite o nome do produto: ");
            var nomeProduto = Console.ReadLine();
            Console.Write("Digite a quantidade em estoque: ");
            int estoqueEntrada;
            if (!int.TryParse(Console.ReadLine(), out estoqueEntrada) || estoqueEntrada <= 0)
            {
                Console.WriteLine("Quantidade em estoque inválida.");
                return;
            }
            Console.Write("Digite o preço de entrada: ");
            decimal precoEntrada;
            if (!decimal.TryParse(Console.ReadLine(), out precoEntrada) || precoEntrada <= 0)
            {
                Console.WriteLine("Preço de entrada inválido.");
                return;
            }

            estoque.AdicionarProduto(sku, nomeProduto, estoqueEntrada, precoEntrada);
        }

        static void AdicionarVenda(Estoque estoque)
        {
            Console.Write("Digite o SKU do produto vendido: ");
            var sku = Console.ReadLine();
            var produto = estoque.BuscarProdutoPorSKU(sku);
            if (produto == null)
            {
                Console.WriteLine($"Produto com SKU {sku} não encontrado.");
                return;
            }

            Console.WriteLine($"Nome do produto: {produto.NomeProduto}");

            Console.Write("Digite a quantidade vendida: ");
            int quantidade;
            if (!int.TryParse(Console.ReadLine(), out quantidade) || quantidade <= 0)
            {
                Console.WriteLine("Quantidade vendida inválida.");
                return;
            }

            if (produto.Estoque < quantidade)
            {
                Console.WriteLine($"Não há estoque suficiente de {produto.NomeProduto} para a venda.");
                return;
            }

            Console.Write("Digite o preço de saída: ");
            decimal precoSaida;
            if (!decimal.TryParse(Console.ReadLine(), out precoSaida) || precoSaida <= 0)
            {
                Console.WriteLine("Preço de saída inválido.");
                return;
            }

            estoque.AtualizarEstoque(sku, quantidade, precoSaida);

            Console.Write("Deseja continuar vendendo (S/N)? ");
            var continuar = Console.ReadLine();
            if (continuar.ToUpper() != "S")
            {
                Console.WriteLine("Venda concluída.");
            }
        }
        static void RemoverProduto(Estoque estoque)
        {
            Console.Write("Incira o SKu desejado:");
            string sku = Console.ReadLine();
            if(estoque.RemoverProduto(sku))
            {
                    Console.WriteLine($"produto {nomeProduto} removido com sucesso.");
            }
            else
            {
                Console.WriteLine($"Produto com SKU {sku} não encontrado.");

            }
        }

    }
}