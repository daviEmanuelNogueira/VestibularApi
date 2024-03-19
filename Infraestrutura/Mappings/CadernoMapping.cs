using Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutura.Mappings
{
    public class CadernoMapping : IEntityTypeConfiguration<Caderno>
    {
        public void Configure(EntityTypeBuilder<Caderno> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Nome)
               .IsRequired()
               .HasColumnType("varchar(50)");

            builder.Property(a => a.Descricao)
               .IsRequired()
               .HasColumnType("varchar(50)");

            builder.ToTable("caderno_tb");
        }
    }
}
