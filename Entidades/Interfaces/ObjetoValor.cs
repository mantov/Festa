namespace Entidades.Interfaces
{
    public abstract class ObjetoValor
    {
        public abstract bool ComparaValor(ObjetoValor objetoValor);

        public abstract override int GetHashCode();

        public override bool Equals(object obj)
        {
            var nulo = obj == null;
            var tipoDiferente = !((obj??new object()).GetType() == GetType());

            return !nulo && !tipoDiferente && ComparaValor((ObjetoValor)obj);
        }
    }
}