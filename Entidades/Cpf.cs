using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Entidades.Interfaces;

namespace Entidades
{
    public class Cpf:ObjetoValor
    {
        private const int _TamanhoCpfEsperado = 11;
        private string _valor;
        enum tipoDigitoVerificador
        {
            cpf=10,
            cnpj=16
        }

        public Cpf(string cpf)
        {
            this.Valor = cpf;

            if (!Valido())
            {
                //throw Excecao.ExcecaoCpfInvalido(string.Format("CPF {0} é inválido.",cpf));
            }

        }

       
        public string Valor { get { return _valor; } set { _valor = LimpaNaoNumeros(value); } }

        public bool Valido()
        {
            if (Valor.Length != 11)
            {
                return false;
            }

            var tempCpf = Valor.Substring(0, 9);
            var soma = Soma(tempCpf);
            var resto = Resto(soma);
            var digito = resto.ToString();

            tempCpf = tempCpf + digito;
            soma = Soma(tempCpf);
            resto = Resto(soma);
            digito = digito + resto.ToString();

            return Valor.EndsWith(digito);
        }

        private static int Soma(string tempCpf)
        {
            var soma = 0;
            var tamanho = tempCpf.Length;
            var multiplicador = tamanho - 9;
            var contadorMinimo = Convert.ToInt16(tipoDigitoVerificador.cpf) - tamanho + multiplicador;

            for (var contradorRegressivo = tamanho; contradorRegressivo >= contadorMinimo; contradorRegressivo--)
            {
                soma += int.Parse(tempCpf[contradorRegressivo - 1].ToString())*(contradorRegressivo - multiplicador);
            }

            return soma;
        }

        private static int Resto(int soma)
        {
            var resto = soma%11;
            resto = resto > 9?0:resto;
            
            return resto;
        }

        private string LimpaNaoNumeros(string valor)
        {
            var digitsOnly = new Regex(@"[^\d]");

            return digitsOnly.Replace(valor, "").Trim();
        }

        public override bool ComparaValor(ObjetoValor objetoValor)
        {
            return this.Valor == LimpaNaoNumeros(objetoValor.ToString());
        }

        public override string ToString()
        {
            return FormataCpf(Valor);
        }

        private string FormataCpf(string valor)
        {
            var valorLimpo = LimpaNaoNumeros(valor);
            var tamanhoCpf = valorLimpo.Length;
            //var diferencaTamanhoCpf= _TamanhoCpfEsperado - tamanhoCpf;
            var valorCompleto = tamanhoCpf == _TamanhoCpfEsperado? valor: valor.PadLeft(_TamanhoCpfEsperado, '0');
            return string.Format("{0}{1}{2}.{3}{4}{5}.{6}{7}{8}-{9}{10}",valorCompleto[0],valorCompleto[1],valorCompleto[2],
                valorCompleto[3],valorCompleto[4],valorCompleto[5],valorCompleto[6],valorCompleto[7],valorCompleto[8],
                valorCompleto[9],valorCompleto[10]);
        }

        public override int GetHashCode()
        {
            return 1;
        }
    }
}