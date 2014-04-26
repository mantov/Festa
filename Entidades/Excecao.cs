using System;

namespace Entidades
{
    public class Excecao
    {
        public static Exception ExcecaoCpfInvalido(string cpfInválido)
        {
            return new Exception(cpfInválido);
        }

        public static Exception ParametroInvalido(string enderecoRepositorio)
        {
            return new Exception(enderecoRepositorio);
        }
    }
}