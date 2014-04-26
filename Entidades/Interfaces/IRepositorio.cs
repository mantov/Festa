using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Interfaces
{
    public interface IRepositorio<T>
    {
        T Salvar(T valor);

        void Apagar(T valor);

        T Obter(int id);

        IEnumerable<T> ObterTodos();
    }
}
