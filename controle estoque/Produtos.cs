using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace controle_estoque
{
    public class Produto
    {
        public string SKU { get; set; }
        public string NomeProduto { get; set; }
        public int Estoque { get; set; }
        public decimal PrecoEntrada { get; set; }
        public decimal PrecoSaida { get; set; }
    }
}