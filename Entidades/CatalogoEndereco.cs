using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Interfaces;

namespace Entidades
{
    public class CatalogoEndereco
    {
        private IPessoaRepositorio _pessoaRepositorio;
        private IEnderecoRespositorio _enderecoRepositorio;

        public void InvalidarEndereco(Pessoa pessoa, Endereco endereco)
        {
            pessoa.RemoverEndereco(endereco);
            pessoa.Salvar(pessoa);

            endereco.InvalidarEndereco(_pessoaRepositorio);
            _enderecoRepositorio.Salvar(endereco);
        }

        public CatalogoEndereco(IEnderecoRespositorio enderecoRespositorio, IPessoaRepositorio pessoaRepositorio)
        {
            if (enderecoRespositorio == null)
            {
                throw Excecao.ParametroInvalido("enderecoRepositorio");
            }

            if (pessoaRepositorio == null)
            {
                throw Excecao.ParametroInvalido("pessoaRepositorio");
            }

            _enderecoRepositorio = enderecoRespositorio;
            _pessoaRepositorio = pessoaRepositorio;
        }

    }
}
