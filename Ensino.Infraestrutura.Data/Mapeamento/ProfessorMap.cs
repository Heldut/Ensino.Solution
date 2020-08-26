using Ensino.Dominio.Entidade;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ensino.Infraestrutura.Data.Mapeamento
{
    public class ProfessorMap : BaseMap<Professor>
    {
        public override void Configure(EntityTypeBuilder<Professor> builder)
        {
            base.Configure(builder);
            builder.ToTable("Professor");

            // Relacionamento com Aluno
            builder
                .HasMany(c => c.Alunos)
                .WithOne(c => c.Professor)
                .HasForeignKey(c => c.ProfessorId)
                .HasPrincipalKey(c => c.Id)
                .OnDelete(DeleteBehavior.Restrict);

            // Colunas
            builder.Property(c => c.Nome)
                .IsRequired()
                .HasColumnType("varchar(100)")
                .HasColumnName("Nome")
                .HasMaxLength(100);
        }
    }
}
