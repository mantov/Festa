using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Interfaces
{
    public interface IPessoaRepositorio:IRepositorio<Pessoa>
    {
        IEnumerable<Pessoa> ObterPessoaPorEndereco(Endereco endereco);
        Pessoa SalvarEndereco(Endereco endereco);
    }
}
