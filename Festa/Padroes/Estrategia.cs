using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Festa.Padroes
{
    public class Estrategia
    {

    }

    public interface Agradecimento
    {
        string RespostaAoRecebimento(string presente);
    }
}
