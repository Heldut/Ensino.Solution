using Ensino.Dominio.Entidade;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ensino.Infraestrutura.Data.Mapeamento
{
    public class BaseMap<T> : IEntityTypeConfiguration<T> where T : EntidadeBase
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(c => c.Id);
        }
    }
}
