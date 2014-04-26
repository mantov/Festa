using System;
using System.Collections.Generic;
using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FestaTestUnit
{
    [TestClass]
    public class EnderecoTeste
    {
        [TestMethod]
        public void Lista_De_Endereco_Tem_Um_Endereco_Ao_Menos()
        {
            var endereco = new Endereco();
            var enderecoLista = new List<Endereco>();
            
            endereco = EnderecoStub.GetInstance(0);
            enderecoLista.Add(endereco);

            Assert.IsTrue(enderecoLista.Contains(endereco));
        }


    }
}
