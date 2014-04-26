using Entidades.Padroes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FestaTestUnit
{
    [TestClass]
    public class EstrategiaTest
    {
        [TestMethod]
        public void Agradecendo_Discretamente()
        {
            var agradecimentoRecebido = Estrategia.Agradeca("pomada", new Discreto());
            var agradecimentoEsperado = "Muita gentileza o pomada. Estou muito grato!";
            
            Assert.AreEqual(agradecimentoRecebido,agradecimentoEsperado);

        }

        [TestMethod]
        public void Agradecendo_Efusivamente()
        {
            var agradecimentoRecebido = Estrategia.Agradeca("salompa", new Efusivo());
            var agradecimentoEsperado = "Poxa, que maravilha! Muito obrigado mesmo pelo salompa. " +
                                        "Eu já queria há anos um salompa!";
            
            Assert.AreEqual(agradecimentoRecebido,agradecimentoEsperado);
            
        }

        [TestMethod]
        public void Agradecendo_Sarcasticamente()
        {
            var agradecimentoRecebido = Estrategia.Agradeca("goiaba", new Sarcastico());
            var agradecimentoEsperado = "Wow! Um goiaba! Vejam só: um goiaba! Na falta de um presente merda eu não fico mais!";

            Assert.AreEqual(agradecimentoRecebido, agradecimentoEsperado);

        }
    }
}

