namespace Entidades
{
    public static class EnderecoStub
    {
        public static Endereco GetInstance(int id)
        {
            var endereco = new Endereco();
            
            endereco.id = id;
            endereco.Complemento = "Apto 82";
            endereco.Logradouro = "Rua dos Campos";
            endereco.Numero = "14B";

            return endereco;
        }
    }
}