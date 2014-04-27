namespace Entidades.Padroes
{
    public static class Estrategia 
    {
        public static string Agradeca(string presente, IAgradecimento agradecimento)
        {
            return agradecimento.RespostaAoRecebimento(presente);
        }
    }

    public class Efusivo : IAgradecimento
    {
        public string RespostaAoRecebimento(string presente)
        {
            return string.Format("Poxa, que maravilha! Muito obrigado mesmo pelo {0}. Eu já queria há anos um {0}!",
                presente);
        }
    }

    public class Discreto : IAgradecimento
    {
        public string RespostaAoRecebimento(string presente)
        {
            return string.Format("Muita gentileza o {0}. Estou muito grato!",
               presente);
        }
    }

    public class Sarcastico : IAgradecimento
    {
        public string RespostaAoRecebimento(string presente)
        {
            return string.Format("Wow! Um {0}! Vejam só: um {0}! Na falta de um presente merda eu não fico mais!",
               presente);
        }
    }

    public interface IAgradecimento
    {
        string RespostaAoRecebimento(string presente);
    }
}
