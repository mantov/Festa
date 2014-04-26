using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;

namespace Entidades.Interfaces
{
    public abstract class RepositorioNHibernate<T>: IRepositorio<T>
    {
        protected ISession _sessao;

        protected RepositorioNHibernate(ISession sessao)
        {
            this._sessao = sessao;
        }

        public T Salvar(T valor)
        {
            using (ITransaction trans = this._sessao.BeginTransaction())
            {
                this._sessao.Clear();
                this._sessao.SaveOrUpdate(valor);
                trans.Commit();
            }
            return valor;
        }
        public abstract void Apagar(T valor);
        public abstract T Obter(int id);
        public abstract IEnumerable<T> ObterTodos();
    }
}
