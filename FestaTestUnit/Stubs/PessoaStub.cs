using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace FestaTestUnit.Stubs
{
    public static class PessoaStub
    {
        public static Pessoa GetInstance(int id)
        {
            var pessoa = new Pessoa();

            pessoa.Id = id;
            pessoa.Nome = "Alexandre";
            pessoa.DataDeNascimento = Convert.ToDateTime("18/01/1978");

            return pessoa;
        }

    }
}
