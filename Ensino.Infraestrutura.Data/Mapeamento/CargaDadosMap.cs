using System;
using Ensino.Dominio.Entidade;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ensino.Infraestrutura.Data.Mapeamento
{
    public class CargaDadosMap : BaseMap<CargaDados>
    {
        public override void Configure(EntityTypeBuilder<CargaDados> builder)
        {
            base.Configure(builder);
            builder.ToTable("CargaDados");

            // Colunas
            builder.Property(c => c.Descricao)
                .IsRequired()
                .HasColumnType("varchar(1000)")
                .HasColumnName("Descricao")
                .HasMaxLength(100);

            builder.Property(c => c.DataUpload)
                   .IsRequired()
                   .HasColumnName("DataUpload")
                   .HasColumnType("datetime")
                   .HasDefaultValue(DateTime.Now);
        }
    }
}
