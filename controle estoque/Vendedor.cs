using System;

namespace controle_estoque
{
    public class Vendedor
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public Endereco Endereco { get; set; }
        public Estoque Estoque { get; set; }

        public Vendedor(string nome, string cpf, string telefone, string email, Endereco endereco)
        {
            Nome = nome;
            CPF = cpf;
            Telefone = telefone;
            Email = email;
            Endereco = endereco;
            Estoque = new Estoque();
        }
    }
}
