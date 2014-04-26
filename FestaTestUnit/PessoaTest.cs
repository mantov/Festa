using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using Entidades;
using Entidades.Interfaces;
using FestaTestUnit.Stubs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace FestaTestUnit
{
    [TestClass]
    public class PessoaTest
    {
        [TestMethod]
        public void Obrigatorios_Foram_Preenchidos()
        {
            var pessoa = PessoaStub.GetInstance(0);

            Assert.IsNotNull(pessoa);
            Assert.IsTrue(pessoa.ToString() == string.Format("{0}#{1}", pessoa.Nome, pessoa.DataDeNascimento.ToString("d")));
        }

        [TestMethod]
        public void Metodo_ToString_Mostrando_Data_Adequada()
        {
            var pessoa = PessoaStub.GetInstance(0);
            pessoa.DataDeNascimento = Convert.ToDateTime("18/01/1978");

            Assert.IsTrue(pessoa.ToString() == string.Format("{0}#{1}", pessoa.Nome, pessoa.DataDeNascimento.ToString("d")));
        }

        [TestMethod]
        public void Uma_Pessoa_Tem_Pelo_Menos_Um_Endereco()
        {
            var pessoa = PessoaStub.GetInstance(0);
            var endereco = EnderecoStub.GetInstance(0);

            pessoa.AdicionarEndereco(endereco);

            Assert.IsTrue(pessoa.Enderecos.Contains(endereco));
        }

        [TestMethod]
        public void Salva_Pessoa()
        {
            var mockPessoa = new Mock<IPessoaRepositorio>();
            var pessoa = PessoaStub.GetInstance(0);

            mockPessoa.Setup(repositorio => repositorio.Salvar(pessoa)).Returns(new Pessoa());
        }


        [TestMethod()]
        public void Adicionar_Endereco()
        {
            var mockPessoa = new Mock<IPessoaRepositorio>();
            var pessoa = PessoaStub.GetInstance(0);
            var endereco = EnderecoStub.GetInstance(0);
            pessoa.Enderecos.Add(endereco);

            mockPessoa.Setup(repositorio => repositorio.SalvarEndereco(endereco)).Returns(pessoa);
        }


        [TestMethod()]
        public void Apagar_Pessoa()
        {
            var mockPessoa = new Mock<IPessoaRepositorio>();
            var pessoa = PessoaStub.GetInstance(0);

            mockPessoa.Setup(repositorio => repositorio.Apagar(pessoa));
        }

        [TestMethod()]
        public void Obter_Uma_Pessoa_Por_Id()
        {
            var mockPessoa = new Mock<IPessoaRepositorio>();
            var pessoa = PessoaStub.GetInstance(0);

            mockPessoa.Setup(repositorio => repositorio.Obter((int)pessoa.Id)).Returns(pessoa);
        }

        [TestMethod()]
        public void Obter_Todas_As_Pessoas()
        {
            var mockPessoa = new Mock<IPessoaRepositorio>();

            mockPessoa.Setup(repositorio => repositorio.ObterTodos()).Returns(new List<Pessoa>());
        }

        [TestMethod()]
        public void ObterPessoaPorEnderecoTest()
        {
            var mockPessoa = new Mock<IPessoaRepositorio>();
            var pessoa = PessoaStub.GetInstance(0);
            var endereco = EnderecoStub.GetInstance(0);
            pessoa.Enderecos.Add(endereco);

            //mockPessoa.Setup(repositorio => repositorio.ObterPessoaPorEndereco(endereco)).Returns();
        }

        [TestMethod()]
        public void RemoverEnderecoTest()
        {
            var mockPessoa = new Mock<IPessoaRepositorio>();
            var mockEndereco = new Mock<IEnderecoRespositorio>();
            var pessoa = PessoaStub.GetInstance(0);
            var endereco = EnderecoStub.GetInstance(0);

            pessoa.Enderecos.Add(endereco);

            var catalogoEndereco = new CatalogoEndereco(endereco, pessoa);

        }
    }

}
