using System;
using System.Collections.Generic;

namespace controle_estoque
{
    class Program
    {
        static List<Vendedor> vendedores = new List<Vendedor>();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Controle de Estoque");
                Console.WriteLine("1 - Adicionar Vendedor");
                Console.WriteLine("2 - Adicionar Produto");
                Console.WriteLine("3 - Pesquisar Produto");
                Console.WriteLine("4 - Listar Produtos");
                Console.WriteLine("5 - Adicionar Venda");
                Console.WriteLine("6 - Listar Vendedores");
                Console.WriteLine("7 - Ver Vendas e Lucro de um Vendedor");
                Console.WriteLine("8 - Sair");
                Console.Write("Escolha uma opção: ");

                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        AdicionarVendedor();
                        break;
                    case "2":
                        AdicionarProduto();
                        break;
                    case "3":
                        PesquisarProduto();
                        break;
                    case "4":
                        ListarProdutos();
                        break;
                    case "5":
                        AdicionarVenda();
                        break;
                    case "6":
                        ListarVendedores();
                        break;
                    case "7":
                        VerVendasLucroVendedor();
                        break;
                    case "8":
                        Console.WriteLine("Saindo do programa...");
                        return;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }

                Console.WriteLine(); // Adiciona uma linha em branco para melhorar a legibilidade
            }
        }

        static void AdicionarVendedor()
        {
            Console.WriteLine("Adicionar Vendedor");
            Console.Write("Nome completo: ");
            string nome = Console.ReadLine();
            Console.Write("CPF: ");
            string cpf = Console.ReadLine();
            Console.Write("Telefone: ");
            string telefone = Console.ReadLine();
            Console.Write("E-mail: ");
            string email = Console.ReadLine();
            Console.Write("Rua: ");
            string rua = Console.ReadLine();
            Console.Write("Número: ");
            string numero = Console.ReadLine();
            Console.Write("Complemento: ");
            string complemento = Console.ReadLine();
            Console.Write("Cidade: ");
            string cidade = Console.ReadLine();
            Console.Write("Estado: ");
            string estado = Console.ReadLine();

            Endereco endereco = new Endereco(rua, numero, complemento, cidade, estado);
            Vendedor vendedor = new Vendedor(nome, cpf, telefone, email, endereco);
            vendedores.Add(vendedor);

            Console.WriteLine("Vendedor cadastrado com sucesso.");
        }

        static void AdicionarProduto()
        {
            Console.WriteLine("Adicionar Produto");

            if (vendedores.Count == 0)
            {
                Console.WriteLine("Nenhum vendedor cadastrado.");
                return;
            }

            ListarVendedores();

            Console.Write("Escolha o número do vendedor: ");
            int indiceVendedor = int.Parse(Console.ReadLine()) - 1;

            if (indiceVendedor < 0 || indiceVendedor >= vendedores.Count)
            {
                Console.WriteLine("Vendedor não encontrado.");
                return;
            }

            var vendedor = vendedores[indiceVendedor];

            Console.Write("SKU: ");
            string sku = Console.ReadLine();
            Console.Write("Nome do Produto: ");
            string nomeProduto = Console.ReadLine();
            Console.Write("Preço de Compra: ");
            decimal precoCompra = decimal.Parse(Console.ReadLine());
            Console.Write("Preço de Venda: ");
            decimal precoVenda = decimal.Parse(Console.ReadLine());
            Console.Write("Estoque Inicial: ");
            int estoqueEntrada = int.Parse(Console.ReadLine());

            vendedor.Estoque.AdicionarProduto(sku, nomeProduto, estoqueEntrada, precoCompra, precoVenda);

            Console.WriteLine("Produto adicionado com sucesso.");
        }

        static void PesquisarProduto()
        {
            if (vendedores.Count == 0)
            {
                Console.WriteLine("Nenhum vendedor cadastrado.");
                return;
            }

            Console.Write("Digite o SKU do produto: ");
            string sku = Console.ReadLine();

            foreach (var vendedor in vendedores)
            {
                Produto produto = vendedor.Estoque.BuscarProdutoPorSKU(sku);
                if (produto != null)
                {
                    Console.WriteLine($"Produto encontrado - Vendedor: {vendedor.Nome}, Nome: {produto.NomeProduto}, Estoque: {produto.Estoque}, Preço: {produto.PrecoVenda:C}");
                    return;
                }
            }

            Console.WriteLine("Produto não encontrado.");
        }

        static void ListarProdutos()
        {
            if (vendedores.Count == 0)
            {
                Console.WriteLine("Nenhum vendedor cadastrado.");
                return;
            }

            foreach (var vendedor in vendedores)
            {
                Console.WriteLine($"Vendedor: {vendedor.Nome}");
                vendedor.Estoque.ListarProdutos();
            }
        }

        static void AdicionarVenda()
        {
            if (vendedores.Count == 0)
            {
                Console.WriteLine("Nenhum vendedor cadastrado.");
                return;
            }

            Console.WriteLine("Adicionar Venda");

            ListarVendedores();

            Console.Write("Escolha o número do vendedor: ");
            int indiceVendedor = int.Parse(Console.ReadLine()) - 1;

            if (indiceVendedor < 0 || indiceVendedor >= vendedores.Count)
            {
                Console.WriteLine("Vendedor não encontrado.");
                return;
            }

            var vendedor = vendedores[indiceVendedor];

            Console.Write("SKU do produto: ");
            string sku = Console.ReadLine();
            Console.Write("Quantidade: ");
            int quantidade = int.Parse(Console.ReadLine());

            Produto produto = vendedor.Estoque.BuscarProdutoPorSKU(sku);
            if (produto == null)
            {
                Console.WriteLine("Produto não encontrado.");
                return;
            }

            vendedor.Estoque.AtualizarEstoque(sku, quantidade, produto.PrecoVenda);

        }

        static void ListarVendedores()
        {
            Console.WriteLine("\nLista de Vendedores:");
            for (int i = 0; i < vendedores.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {vendedores[i].Nome}");
            }
        }

        static void VerVendasLucroVendedor()
        {
            if (vendedores.Count == 0)
            {
                Console.WriteLine("Nenhum vendedor cadastrado.");
                return;
            }

            ListarVendedores();

            Console.Write("Escolha o número do vendedor: ");
            int indiceVendedor = int.Parse(Console.ReadLine()) - 1;

            if (indiceVendedor < 0 || indiceVendedor >= vendedores.Count)
            {
                Console.WriteLine("Vendedor não encontrado.");
                return;
            }

            var vendedor = vendedores[indiceVendedor];

            Console.WriteLine($"\nVendas e Lucro do Vendedor: {vendedor.Nome}");
            foreach (var venda in vendedor.Estoque.Vendas)
            {
                Console.WriteLine($"SKU: {venda.SKU}, Quantidade: {venda.EstoqueSaida}, Preço de Venda: {venda.PrecoSaida:C}");
            }

            decimal lucroTotal = 0;
            foreach (var venda in vendedor.Estoque.Vendas)
            {
                var produto = vendedor.Estoque.BuscarProdutoPorSKU(venda.SKU);
                decimal lucro = (venda.PrecoSaida - produto.PrecoEntrada) * venda.EstoqueSaida;
                lucroTotal += lucro;
            }

            Console.WriteLine($"Lucro Total: {lucroTotal:C}");
        }
    }
}
