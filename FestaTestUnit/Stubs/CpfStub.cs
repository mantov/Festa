using System.Collections.Generic;
using Entidades;

namespace FestaTestUnit
{
    public class CpfStub
    {
        public static Cpf GetInstance(int tipo)
        {
            switch (tipo)
            {
                case 0:
                    return new Cpf("123.456.789-01");
                case 1:
                    return new Cpf("035.681.896-90");
            }
            return new Cpf("12345678901");
        }

        public static List<Cpf> GetInstances()
        {
            var cpf1 = new Cpf("035.681.896-90");
            var cpf2 = new Cpf("12345678901");
            var cpf3 = new Cpf("843.285.405-05");
            var listaCpf = new List<Cpf>();

            listaCpf.Add(cpf1);
            listaCpf.Add(cpf2);
            listaCpf.Add(cpf3);

            return listaCpf;
        }
    }
}