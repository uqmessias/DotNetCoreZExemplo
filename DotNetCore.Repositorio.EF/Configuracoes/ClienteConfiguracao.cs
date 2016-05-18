using DotNetCore.Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotNetCore.Repositorio.EF.Configuracoes
{
    public class ClienteConfiguracao : EntidadeConfiguracao<Cliente>
    {
        public ClienteConfiguracao(EntityTypeBuilder<Cliente> entityBuilder) : base(entityBuilder)
        {
            entityBuilder.ToTable("Clientes");
        }
    }
}
