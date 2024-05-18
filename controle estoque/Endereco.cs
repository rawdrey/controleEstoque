using System;

namespace controle_estoque
{
    public class Endereco
    {
        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }

        public Endereco(string rua, string numero, string complemento, string cidade, string estado)
        {
            Rua = rua;
            Numero = numero;
            Complemento = complemento;
            Cidade = cidade;
            Estado = estado;
        }
    }
}
