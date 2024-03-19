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
    public class RespostaMapping : IEntityTypeConfiguration<Resposta>
    {
        public void Configure(EntityTypeBuilder<Resposta> builder)
        {
            builder.HasKey(r => r.Id);

            builder.Property(r => r.AlternativaEscolhida)
               .IsRequired()
               .HasColumnType("varchar(1)");

            builder.HasOne(r => r.Prova)
                .WithMany(p => p.Respostas)
                .HasForeignKey(r => r.ProvaId);

            builder.ToTable("resposta_tb");
        }
    }
}
