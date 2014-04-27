using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Padroes
{
    public static class ObservadorSoftCore
    {
        public static void Executa()
        {
            PessoaConvidada pessoaConvidada = new PessoaConvidada();
            var convidado1 = new Convidado2("A");
            var convidado2 = new Convidado2("B");
            var convidado3 = new Convidado2("C");

            pessoaConvidada.Subscribe(convidado1);
            pessoaConvidada.Subscribe(convidado2);
            pessoaConvidada.Subscribe(convidado3);
            
            pessoaConvidada.TrackEvento2(new Evento2("varinha", "na zona"));
        }

    }

    public struct Evento2
    {
        private string presente, local;


        public Evento2(string presente, string local)
        {
            this.presente = presente;
            this.local = local;
        }

        public string Presente
        { get { return this.presente; } }

        public string Local
        { get { return this.local; } }

    }

    public class PessoaConvidada : IObservable<Evento2>
    {
        public PessoaConvidada()
        {
            ListaConvidados = new List<IObserver<Evento2>>();
        }

        public List<IObserver<Evento2>> ListaConvidados { get; set; }
        public IDisposable Subscribe(IObserver<Evento2> convidado)
        {
            if (!ListaConvidados.Contains(convidado))
            {
                ListaConvidados.Add(convidado);
            }

            return new Unsubscriber(ListaConvidados, convidado);
        }

        private class Unsubscriber : IDisposable
        {
            private List<IObserver<Evento2>> _listaConvidados;
            private IObserver<Evento2> _convidado;

            public void Dispose()
            {
                if (_convidado != null && _listaConvidados.Contains(_convidado))
                    _listaConvidados.Remove(_convidado);
            }

            public Unsubscriber(List<IObserver<Evento2>> listaConvidados, IObserver<Evento2> convidado)
            {
                this._listaConvidados = listaConvidados;
                this._convidado = convidado;
            }
        }

        public void TrackEvento2(Evento2? loc)
        {
            foreach (var observer in ListaConvidados)
            {
                if (!loc.HasValue)
                {
                    observer.OnError(new Evento2UnknownException());
                }
                else
                {
                    observer.OnNext(loc.Value);
                }
            }
        }

        public void EndTransmission()
        {
            foreach (var observer in ListaConvidados.ToArray())
            {
                if (ListaConvidados.Contains(observer))
                {
                    observer.OnCompleted();
                }
            }

            ListaConvidados.Clear();
        }
    }
    public class Evento2UnknownException : Exception
    {
        internal Evento2UnknownException()
        { }
    }

    public class Convidado2 : IObserver<Evento2>
    {
        private IDisposable unsubscriber;
        private string instName;

        public Convidado2(string name)
        {
            this.instName = name;
        }

        public string Name
        { get { return this.instName; } }

        public virtual void Subscribe(IObservable<Evento2> provider)
        {
            if (provider != null)
                unsubscriber = provider.Subscribe(this);
        }

        public virtual void OnCompleted()
        {
            Console.WriteLine("The Location Tracker has completed transmitting data to {0}.", this.Name);
            this.Unsubscribe();
        }

        public virtual void OnError(Exception e)
        {
            Console.WriteLine("{0}: The location cannot be determined.", this.Name);
        }

        public virtual void OnNext(Evento2 value)
        {
            Console.WriteLine("{3}: Traga para mim no meu aniversário um {0} no {1} as {2}.", value.Presente, value.Local, DateTime.Now.AddHours(2).ToShortTimeString(), this.Name);
        }

        public virtual void Unsubscribe()
        {
            unsubscriber.Dispose();
        }
    }
}
