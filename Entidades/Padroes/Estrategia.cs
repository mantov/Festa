using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Padroes
{
    public static class Estrategia 
    {
        public static string Agradeca(string presente, Agradecimento agradecimento)
        {
            return agradecimento.RespostaAoRecebimento(presente);
        }
    }

    public class Efusivo : Agradecimento
    {
        public string RespostaAoRecebimento(string presente)
        {
            return string.Format("Poxa, que maravilha! Muito obrigado mesmo pelo {0}. Eu já queria há anos um {0}!",
                presente);
        }
    }

    public class Discreto : Agradecimento
    {
        public string RespostaAoRecebimento(string presente)
        {
            return string.Format("Muita gentileza o {0}. Estou muito grato!",
               presente);
        }
    }

    public class Sarcastico : Agradecimento
    {
        public string RespostaAoRecebimento(string presente)
        {
            return string.Format("Wow! Um {0}! Vejam só: um {0}! Na falta de um presente merda eu não fico mais!",
               presente);
        }
    }


    public interface Agradecimento
    {
        string RespostaAoRecebimento(string presente);
    }
}
