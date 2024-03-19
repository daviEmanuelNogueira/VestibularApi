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
    public class QuestaoMapping : IEntityTypeConfiguration<Questao>
    {
        public void Configure(EntityTypeBuilder<Questao> builder)
        {
            builder.HasKey(q => q.Id);

            builder.Property(q => q.CadernoId)
               .HasColumnType("int");

            builder.Property(q => q.NumeroQuestao)
                .HasColumnType("int");

            builder.Property(q => q.RespostaCorreta)
                .HasColumnType("varchar(1)");

            builder.Property(q => q.Descricao)
                .HasColumnType("varchar(500)");

            builder.Property(q => q.AlternativaA)
                .HasColumnType("varchar(500)");

            builder.Property(q => q.AlternativaB)
                .HasColumnType("varchar(500)");

            builder.Property(q => q.AlternativaC)
                .HasColumnType("varchar(500)");

            builder.Property(q => q.AlternativaD)
                .HasColumnType("varchar(500)");

            builder.HasOne(q => q.Caderno)
                .WithMany(c => c.Questoes)
                .HasForeignKey(q => q.CadernoId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.ToTable("questao_tb");
        }
    }
}
