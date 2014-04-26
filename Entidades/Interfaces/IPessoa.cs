using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Interfaces
{
    public interface IPessoa
    {
        int? Id { get; set; }
        string Nome { get; set; }
        DateTime DataDeNascimento { get; set; }
        
    }

}
