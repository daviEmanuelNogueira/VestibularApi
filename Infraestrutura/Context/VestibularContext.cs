using Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutura.Context
{
    public class VestibularContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public VestibularContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DbSet<Aluno> Aluno { get; set; }
        //public DbSet<Avaliacao> Avaliacao { get; set; }
        public DbSet<Prova> Prova { get; set; }
        public DbSet<Resposta> Questao { get; set; }
        public DbSet<Resposta> Resposta { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("VestibularDb"));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Caderno>().HasData(new Caderno(1, "Caderno Azul", "Caderno do Vestibular 2024"));

            string baseDirectory = Environment.CurrentDirectory;

            // Combina o diretório base com o nome do arquivo JSON
            string questoesPath = Path.Combine(baseDirectory, "Questoes.json");

            string jsonContent = File.ReadAllText(questoesPath);

            List<Questao> questoes = JsonConvert.DeserializeObject<List<Questao>>(jsonContent);

            foreach (var item in questoes)
            {
                modelBuilder.Entity<Questao>()
                .HasData(new Questao(item.Id, 
                                     item.NumeroQuestao, 
                                     item.CadernoId, 
                                     item.Descricao,
                                     item.AlternativaA, 
                                     item.AlternativaB, 
                                     item.AlternativaC, 
                                     item.AlternativaD,
                                     item.RespostaCorreta));
            }

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(VestibularContext).Assembly);
        }
    }
}
