using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using FestaTestUnit;
using FestaTestUnit.Stubs;

namespace Festa
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var pessoa = PessoaStub.GetInstance(0);
                var listaCpf = CpfStub.GetInstances();
            
                ImprimeSaida(listaCpf, pessoa);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.ReadLine();
            }
        }

        private static void ImprimeSaida(List<Cpf> listaCpf, Pessoa pessoa)
        {
            foreach (var cpf in listaCpf)
            {
                if (cpf.Valido())
                {
                    Console.WriteLine(cpf.Valor);
                    Console.WriteLine(cpf.ToString());
                }
            }
            Console.WriteLine(pessoa.ToString());
            Console.ReadLine();
        }
    }
}
