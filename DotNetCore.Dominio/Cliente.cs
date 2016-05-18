namespace DotNetCore.Dominio
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
    public class Cliente: Entidade, IRaizDeAgregacao
    {
        public string Nome { get; protected set; }
        public string CPF { get; protected set; }
        protected Cliente() { }

        internal Cliente(string nome, string cpf)
        {
            Nome = nome;
            CPF = cpf;
        }
    }
}
