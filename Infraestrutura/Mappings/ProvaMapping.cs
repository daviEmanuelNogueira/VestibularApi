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
    public class ProvaMapping : IEntityTypeConfiguration<Prova>
    {
        public void Configure(EntityTypeBuilder<Prova> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.AlunoId)
               .IsRequired();

            builder.HasOne(p => p.Caderno)
               .WithMany(c => c.Provas)
               .HasForeignKey(p => p.CadernoId)
               .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.Aluno)
               .WithOne(a => a.Prova)
               .HasForeignKey<Prova>(p => p.AlunoId);

            builder.ToTable("prova_tb");
        }
    }
}
