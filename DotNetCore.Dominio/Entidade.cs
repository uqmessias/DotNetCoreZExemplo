using System;
using System.Collections.Generic;

namespace DotNetCore.Dominio
{
    public abstract class Entidade
    {
        public virtual IList<Regra> Erros { get; protected set; }
        public virtual Guid Codigo { get; protected set; }

        protected Entidade()
        {
            Erros = new List<Regra>();
            Codigo = Guid.NewGuid();
        }

        public virtual void AdicionarRegraQuebrada(Regra regraDeNegocio)
        {
            Erros.Add(regraDeNegocio);
        }

        public virtual void AdicionarRegrasQuebradas(params Regra[] regrasDeNegocio)
        {
            foreach (var regra in regrasDeNegocio)
                AdicionarRegraQuebrada(regra);
        }

        public bool EhValido()
        {
            return !this.ContemErros();
        }

        public void SeForValido(Action acao)
        {
            if (EhValido())
                acao.Invoke();
        }

        protected void AplicarRegraSe<TRegra>(Func<bool> verificacao) where TRegra : Regra, new()
        {
            if (verificacao())
                this.AdicionarRegraQuebrada<TRegra>();
        }

        protected void AplicarRegraSe<TRegra>(Func<bool> verificacao, Action acao) where TRegra : Regra, new()
        {
            AplicarRegraSe<TRegra>(verificacao);
            SeForValido(acao);
        }
    }
}