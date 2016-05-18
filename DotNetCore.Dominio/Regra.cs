namespace DotNetCore.Dominio
{
    public abstract class Regra
    {
        public string Mensagem { get; private set; }

        protected Regra(string mensagem)
        {
            Mensagem = mensagem;
        }
    }
}