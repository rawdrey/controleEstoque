using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace controle_estoque
{
    public interface IControleEstoque
    {
        public void AdcionarProduto(string sku, string nomeProduto, int estoqueEntrada, decimal precoEntrada, decimal precoSaida);
        Produtos BuscarProdutoPorSKU(string SKU);
        void AtualizarEstoque(string sku, int estoqueSaida, decimal precoSaida);

    }
}