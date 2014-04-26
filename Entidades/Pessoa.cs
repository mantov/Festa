using System;
using System.Collections.Generic;
using Entidades.Interfaces;

namespace Entidades
{

    public class Pessoa : IPessoa,IPessoaRepositorio
    {
        public Pessoa()
        {
            Enderecos = new List<Endereco>();
        }

        public string Nome { get; set; }
        public DateTime DataDeNascimento { get; set; }
        public int? Id { get; set; }
        public List<Endereco> Enderecos { get; set; }

        public override string ToString()
        {
            return string.Format("{0}#{1}", Nome, DataDeNascimento.ToString("d"));
        }

        public void AdicionarEndereco(Endereco endereco)
        {
            this.Enderecos.Add(endereco);
        }

        public Pessoa Salvar(Pessoa valor)
        {
            throw new NotImplementedException();
        }

        public void Apagar(Pessoa valor)
        {
            throw new NotImplementedException();
        }

        public Pessoa Obter(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pessoa> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pessoa> ObterPessoaPorEndereco(Endereco endereco)
        {
            throw new NotImplementedException();
        }

        public Pessoa SalvarEndereco(Endereco endereco)
        {
            return new Pessoa();
        }

        public void RemoverEndereco(Endereco endereco)
        {
            throw new NotImplementedException();
        }
    }
}