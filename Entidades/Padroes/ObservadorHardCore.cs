using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Padroes
{
    public static class ObservadorHardCore
    {
        public static void Executa()
        {
            var evento = new Evento();
            var convidado1 = new Convidado();
            var convidado2 = new Convidado();
            var convidado3 = new Convidado();

            evento.RegistrarObservador(convidado1);
            evento.RegistrarObservador(convidado2);
            evento.RegistrarObservador(convidado3);
            evento.MudaPresenteLocal();
            evento.NotificarObservador();

        }

    }

    public interface IObservador
    {
        bool Atualizar(string presente, string local);
    }
    public interface MostrarAplicacoes
    {
        void Mostrar();
    }
    public interface IObservado
    {
        bool RegistrarObservador(IObservador observador);
        bool RemoverObservador(IObservador observador);
        bool NotificarObservador();
    }

    public class Evento : IObservado
    {
        public Evento()
        {
            Observadores = new List<IObservador>();
        }
        private List<IObservador> Observadores { get; set; }

        private string Presente { get; set; }

        private string Local { get; set; }

        public bool RegistrarObservador(IObservador observador)
        {
            try
            {
                Observadores.Add(observador);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void MudaPresenteLocal()
        {
            this.Presente = string.Format("Um relógio que marque somente a hora {0}", DateTime.Now.ToShortTimeString());
            this.Local = string.Format("Esteja na minha casa exatamente {0}", DateTime.Now.AddHours(2).ToShortTimeString());
        }

        bool IObservado.RemoverObservador(IObservador observador)
        {
            try
            {
                var indice = Observadores.IndexOf(observador);

                Observadores.RemoveAt(indice);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool NotificarObservador()
        {
            try
            {
                foreach (var observador in Observadores)
                {
                    observador.Atualizar(this.Presente, this.Local);
                }

                return true;
            }
            catch
            {

                return false;
            }

        }

        public bool RemoverObservador { get; set; }
    }

    public class Convidado : IObservador, MostrarAplicacoes
    {
        public string Presente { get; set; }

        public string Local { get; set; }

        public bool Atualizar(string presente, string local)
        {
            try
            {
                this.Presente = presente;
                this.Local = local;
                Mostrar();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void Mostrar()
        {
            Console.WriteLine(string.Format("{0} {1}", Presente, Local));
        }

    }
}
