using System.Collections.Generic;
using Entidades.Interfaces;

namespace Entidades
{
    public class Endereco:IEnderecoRespositorio
    {
        public int? id { get; set; }

        public string Logradouro { get; set; }

        public string Numero { get; set; }

        public string Complemento { get; set; }

        public Endereco Salvar(Endereco valor)
        {
            throw new System.NotImplementedException();
        }

        public void Apagar(Endereco valor)
        {
            throw new System.NotImplementedException();
        }

        public Endereco Obter(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Endereco> ObterTodos()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Endereco> ObterEnderecoPorPessoa(Pessoa morador)
        {
            throw new System.NotImplementedException();
        }

        public void InvalidarEndereco(IPessoaRepositorio pessoaRepositorio)
        {
            throw new System.NotImplementedException();
        }
    }
}