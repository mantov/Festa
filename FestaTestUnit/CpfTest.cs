using System;
using Entidades;
using Entidades.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FestaTestUnit
{
    [TestClass]
    public class CpfTest
    {
        [TestMethod]
        public void Cpf_Eh_Valido()
        {
            var cpf1 = CpfStub.GetInstance(0);
            var cpf2 = CpfStub.GetInstance(1);
            
            Assert.IsFalse(cpf1.Valido());
            Assert.IsTrue(cpf2.Valido());

        }

        [TestMethod]
        public void Construtor_Valido()
        {
            var cpf = new Cpf("12345678911");

            Assert.IsTrue(cpf.Valor == "12345678911");

        }


        [TestMethod]
        public void Cpf_Esta_Limpo()
        {
            var cpf = new Cpf(@"12.3$4@5$\_67_..89(11");

            Assert.IsTrue(cpf.Valor == "12345678911");

        }

        [TestMethod]
        public void CPF_Sai_Formatado()
        {
            var cpf = new Cpf("12345678990");
            var formatado = cpf.ToString();
            var comparativo = "123.456.789-90";
            var cpf1 = new Cpf("123");
            var formatado2 = cpf1.ToString();
            var comparativo2 = "000.000.001-23";

            Assert.AreEqual(formatado,comparativo);
            Assert.AreEqual(formatado2,comparativo2);
        }

        [TestMethod]
        public void Comparacacao()
        {
            var cpf1 = new Cpf("123.456.789-90");
            var cpf2 = new Cpf("123.456.789-90");

            Assert.IsTrue(cpf1.ComparaValor((ObjetoValor)cpf2));
        }

        [TestMethod]
        public void Verifica_Hash()
        {
            const int hashNaoHash = 1;
            var cpf = new Cpf("123456789-20");

            Assert.AreEqual(cpf.GetHashCode(),hashNaoHash);
        }

        [TestMethod]
        public void Tamanho_CPF()
        {
            var cpf = new Cpf("1231213");

            Assert.IsFalse(cpf.Valido());
        }

        [TestMethod]
        public void CompletaCPF()
        {
           
        }
    }
}
