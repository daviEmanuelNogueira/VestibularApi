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
    public class AlunoMapping : IEntityTypeConfiguration<Aluno>
    {
        public void Configure(EntityTypeBuilder<Aluno> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Nome)
               .IsRequired()
               .HasColumnType("varchar(50)");

            builder.Property(a => a.CPF)
               .IsRequired()
               .HasColumnType("varchar(11)");

            builder.Property(a => a.Pontuacao)
               .HasColumnType("decimal(5,2)");

            builder.Property(a => a.CadernoId)
               .HasColumnType("int");

            builder.Property(a => a.DataCadastro)
                .HasColumnType("DateTime");

            builder.ToTable("aluno_tb");
        }
    }
}
