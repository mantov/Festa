using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Interfaces
{
    public interface IEnderecoRespositorio:IRepositorio<Endereco>
    {
        IEnumerable<Endereco> ObterEnderecoPorPessoa(Pessoa morador);
    }
}
