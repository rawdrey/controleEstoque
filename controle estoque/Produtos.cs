using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace controle_estoque
{
    class Produtos
    {
        public string SKU { get; set; };
        public string NomeProduto { get; set; };
        public int QuantidadeEntrada { get; set; };
        public decimal PrecoEntrada { get; set; };
        public decimal PrecoSaida { get; set; };

        public Produtos(string SKU, string NomeProduto, int QuantidadeEntrada, decimal PrecoEntrada, PrecoSaida);
        {
        SKU = sku;
NomeProduto = nomeProduto;
QuantidadeEntrada = quantidadeEntrada;
            PrecoEntrada = precoEntrada;
            PrecoSaida = precoSaida;

}

}
