using DotNetCore.Dominio;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotNetCore.Repositorio.EF.Configuracoes
{
    public abstract class EntidadeConfiguracao<T> where T: Entidade
    {
        public EntidadeConfiguracao(EntityTypeBuilder<T> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Codigo);
            entityBuilder.Ignore(x => x.Erros);
        }
    }
}