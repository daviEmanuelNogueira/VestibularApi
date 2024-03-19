using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infraestrutura.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "caderno_tb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(50)", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_caderno_tb", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "aluno_tb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(50)", nullable: false),
                    CPF = table.Column<string>(type: "varchar(11)", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "DateTime", nullable: false),
                    CadernoId = table.Column<int>(type: "int", nullable: false),
                    Pontuacao = table.Column<decimal>(type: "decimal(5,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_aluno_tb", x => x.Id);
                    table.ForeignKey(
                        name: "FK_aluno_tb_caderno_tb_CadernoId",
                        column: x => x.CadernoId,
                        principalTable: "caderno_tb",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "questao_tb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CadernoId = table.Column<int>(type: "int", nullable: false),
                    NumeroQuestao = table.Column<int>(type: "int", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(500)", nullable: false),
                    AlternativaA = table.Column<string>(type: "varchar(500)", nullable: false),
                    AlternativaB = table.Column<string>(type: "varchar(500)", nullable: false),
                    AlternativaC = table.Column<string>(type: "varchar(500)", nullable: false),
                    AlternativaD = table.Column<string>(type: "varchar(500)", nullable: false),
                    RespostaCorreta = table.Column<string>(type: "varchar(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_questao_tb", x => x.Id);
                    table.ForeignKey(
                        name: "FK_questao_tb_caderno_tb_CadernoId",
                        column: x => x.CadernoId,
                        principalTable: "caderno_tb",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "prova_tb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlunoId = table.Column<int>(type: "int", nullable: false),
                    CadernoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_prova_tb", x => x.Id);
                    table.ForeignKey(
                        name: "FK_prova_tb_aluno_tb_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "aluno_tb",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_prova_tb_caderno_tb_CadernoId",
                        column: x => x.CadernoId,
                        principalTable: "caderno_tb",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "resposta_tb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProvaId = table.Column<int>(type: "int", nullable: false),
                    NumeroQuestao = table.Column<int>(type: "int", nullable: false),
                    AlternativaEscolhida = table.Column<string>(type: "varchar(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_resposta_tb", x => x.Id);
                    table.ForeignKey(
                        name: "FK_resposta_tb_prova_tb_ProvaId",
                        column: x => x.ProvaId,
                        principalTable: "prova_tb",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "caderno_tb",
                columns: new[] { "Id", "Descricao", "Nome" },
                values: new object[] { 1, "Caderno do Vestibular 2024", "Caderno Azul" });

            migrationBuilder.InsertData(
                table: "questao_tb",
                columns: new[] { "Id", "AlternativaA", "AlternativaB", "AlternativaC", "AlternativaD", "CadernoId", "Descricao", "NumeroQuestao", "RespostaCorreta" },
                values: new object[,]
                {
                    { 1, "3", "4", "5", "6", 1, "Qual é o resultado da expressão 2 + 2?", 1, "B" },
                    { 2, "3", "4", "5", "6", 1, "Qual é a raiz quadrada de 16?", 2, "B" },
                    { 3, "10", "12", "15", "20", 1, "Qual é o resultado da expressão 3 * 5?", 3, "C" },
                    { 4, "2", "3", "4", "5", 1, "Quanto é 9 dividido por 3?", 4, "B" },
                    { 5, "2", "3", "4", "5", 1, "Qual é o resultado da expressão 7 - 4?", 5, "B" },
                    { 6, "14", "16", "18", "20", 1, "Qual é o dobro de 8?", 6, "B" },
                    { 7, "2", "4", "5", "6", 1, "Qual é o resultado da expressão 10 / 2?", 7, "B" },
                    { 8, "10", "12", "14", "16", 1, "Qual é o resultado da expressão 4 * 3?", 8, "B" },
                    { 9, "3", "4", "5", "6", 1, "Quanto é 25 dividido por 5?", 9, "C" },
                    { 10, "6", "9", "12", "15", 1, "Qual é o resultado da expressão 3^2?", 10, "B" },
                    { 11, "Casa", "Comida", "Correr", "Livro", 1, "Qual das palavras abaixo é um verbo?", 11, "C" },
                    { 12, "Cachorros", "Cachorroes", "Cachorrões", "Cachorroz", 1, "Qual é o plural de 'cachorro'?", 12, "A" },
                    { 13, "Feliz", "Triste", "Contente", "Radiante", 1, "Qual é o antônimo de 'alegre'?", 13, "B" },
                    { 14, "O", "A", "Os", "As", 1, "Qual é o artigo definido masculino singular?", 14, "A" },
                    { 15, "Folhas", "Folhax", "Folhões", "Folhaes", 1, "Qual é o plural de 'folha'?", 15, "A" },
                    { 16, "Andando", "Andido", "Andava", "Andou", 1, "Qual é a forma verbal correta?", 16, "A" },
                    { 17, "Cavalona", "Cavalona", "Cavalina", "Cavala", 1, "Qual é o feminino de 'cavalo'?", 17, "D" },
                    { 18, "Bolões", "Bolas", "Bolões", "Bolões", 1, "Qual é o plural de 'bola'?", 18, "B" },
                    { 19, "Claro", "Opaco", "Negro", "Obscuro", 1, "Qual é o antônimo de 'escuro'?", 19, "A" },
                    { 20, "Livros", "Livres", "Livroes", "Livrões", 1, "Qual é o plural de 'livro'?", 20, "A" },
                    { 21, "Buenos Aires", "Rio de Janeiro", "Brasília", "São Paulo", 1, "Qual é a capital do Brasil?", 21, "C" },
                    { 22, "Brasil", "Rússia", "China", "Estados Unidos", 1, "Qual é o maior país do mundo em extensão territorial?", 22, "B" },
                    { 23, "Amazonas", "Tietê", "São Francisco", "Paraná", 1, "Qual é o principal rio do Brasil?", 23, "A" },
                    { 24, "Monte Kilimanjaro", "Monte Everest", "Monte Fuji", "Monte Aconcágua", 1, "Qual é o ponto mais alto do mundo?", 24, "B" },
                    { 25, "Ásia", "África", "Europa", "Austrália", 1, "Qual é o menor continente do mundo?", 25, "D" },
                    { 26, "Tóquio", "Nova York", "Cidade do México", "Xangai", 1, "Qual é a cidade mais populosa do mundo?", 26, "A" },
                    { 27, "Deserto do Saara", "Deserto do Atacama", "Deserto da Arábia", "Deserto de Gobi", 1, "Qual é o deserto mais quente do mundo?", 27, "A" },
                    { 28, "Japão", "Estados Unidos", "Indonésia", "Itália", 1, "Qual é o país que possui mais vulcões ativos?", 28, "C" },
                    { 29, "Havaí", "Maldivas", "Filipinas", "Indonésia", 1, "Qual é o maior arquipélago do mundo?", 29, "D" },
                    { 30, "Rússia", "Estados Unidos", "Brasil", "Reino Unido", 1, "Qual é o único país do mundo que está presente em todos os continentes?", 30, "A" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_aluno_tb_CadernoId",
                table: "aluno_tb",
                column: "CadernoId");

            migrationBuilder.CreateIndex(
                name: "IX_prova_tb_AlunoId",
                table: "prova_tb",
                column: "AlunoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_prova_tb_CadernoId",
                table: "prova_tb",
                column: "CadernoId");

            migrationBuilder.CreateIndex(
                name: "IX_questao_tb_CadernoId",
                table: "questao_tb",
                column: "CadernoId");

            migrationBuilder.CreateIndex(
                name: "IX_resposta_tb_ProvaId",
                table: "resposta_tb",
                column: "ProvaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "questao_tb");

            migrationBuilder.DropTable(
                name: "resposta_tb");

            migrationBuilder.DropTable(
                name: "prova_tb");

            migrationBuilder.DropTable(
                name: "aluno_tb");

            migrationBuilder.DropTable(
                name: "caderno_tb");
        }
    }
}
