using System;
using Ensino.Dominio.Entidade;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ensino.Infraestrutura.Data.Mapeamento
{
    public class AlunoMap : BaseMap<Aluno>
    {
        public override void Configure(EntityTypeBuilder<Aluno> builder)
        {
            base.Configure(builder);
            builder.ToTable("Aluno");

            // Relacionamento com Professor
            builder
                .HasOne(jd => jd.Professor)
                .WithMany(c => c.Alunos)
                .HasForeignKey(c => c.ProfessorId)
                .HasPrincipalKey(jd => jd.Id)
                .OnDelete(DeleteBehavior.Restrict);

            // Colunas
            builder.Property(c => c.Nome)
                .IsRequired()
                .HasColumnType("varchar(100)")
                .HasColumnName("Nome")
                .HasMaxLength(100);

            builder.Property(c => c.Mensalidade)
                .HasColumnType("decimal(18,2)")
                .HasColumnName("Mensalidade");

            builder.Property(c => c.DataVencimento)
                   .IsRequired()
                   .HasColumnName("DataVencimento")
                   .HasColumnType("datetime")
                   .HasDefaultValue(DateTime.Now);
        }
    }
}
