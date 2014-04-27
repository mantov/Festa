using Entidades;
using Entidades.Padroes;
using FestaTestUnit.Stubs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FestaTestUnit
{
    [TestClass]
    public class ObservadorTest
    {
        [TestMethod]
        public void Registra_O_Observador()
        {
            IObservado observado = new Evento();
            IObservador observador = new Convidado();

            Assert.IsTrue(observado.RegistrarObservador(observador));
        }

        [TestMethod]
        public void Remove_O_Observador()
        {
            IObservado observado = new Evento();
            IObservador observador = new Convidado();

            Assert.IsTrue(observado.RemoverObservador(observador));
        }

        [TestMethod]
        public void Notifica_O_Observador()
        {
            IObservado observado = new Evento();
            IObservador observador = new Convidado();

            Assert.IsTrue(observado.NotificarObservador());
        }

        [TestMethod]
        public void Atualiza_Observador()
        {
            IObservador observador = new Convidado();
            
            Assert.IsTrue(observador.Atualizar("machadinha","na minha casa"));
        }
    }
}
