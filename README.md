# Projeto:

Tech Challenge FASE 3: Qualidade e Segurança no Desenvolvimento - `Aplicação Prova e Processamento Resultado.`

-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

# O Problema:

O Tech Challenge desta fase será a construção de dois microsserviços que devem se comunicar através de um broker como RabbitMQ ou SB (Service Bus).

Por exemplo: um microsserviço que recebe um input "gatilho" e dispara um evento para um broker que deve processar e salvar o dado em um banco de dados. Esse banco de dados pode ser o mesmo criado na primeira fase do curso.

-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

# Descrição do projeto:
  
Projeto desenvolvido pelo grupo de estudos da Pós Tech FIAP do curso: Arquitetura de Sistemas .NET com Azure. 

Trata-se de uma aplicação no qual sua arquitetura é baseada em Event Driven e Microsserviços na estrutura de producer, fila, consumer e persistencia. Este projeto foi desenvolvido utilizando as tecnologias, a saber: 
- Linguagem de programação C# com os frameworks .NET e ASP. NET Core nas versões 8;
- O serviço (service bus) de filas em nuvem da Azure e;
- Banco de dados local.

### Producer
Este serviço está separado em camadas com responsabilidades especificas, sendo: 
- A camada do Core, no qual, administra e implementa o modelo de domínio;
- A camada de infraestrutura que representa os mapeamentos das entidades e respectivamente seus relacionamentos para a devida persistência no banco de dados e por fim;
- A API que possui os endpoints responsáveis por realizar o cadastro dos alunos e provas, também, enviar as respostas de cada aluno relativo as provas para a fila e aguardar o processamento para apresentação do resultado.

### Fila
Irá receber as provas, questões respondidas de cada aluno e aguardar o processamento para o resultado.

### Consumer
Este serviço receberá da fila a prova preenchida por aluno e irá aplicar as regras de negócio específicas para processar o resultado e apresentar o ranqueamento do aluno.

-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

# Participantes do projeto:
  
- [Alex dos Santos Rosa](https://github.com/aleqsrosa) - RM352258; 
- [Davi Emanuel Torres de Souza Nogueira](https://github.com/daviEmanuelNogueira) - RM351602;
- [Fillipe Luis da Silva](https://github.com/fillipelsilva) - RM352110;
- [Pedro Henrique Sousa de Abreu](https://github.com/PedroAbreuHS) - RM352428.

-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

# Desenvolvimento (Como rodar):
  
Para executar esses projetos você precisa seguir as etapas abaixo:
- Acessar o repositório do projeto através do link: https://github.com/daviEmanuelNogueira/VestibularApi;
- Baixar o zip do projeto ou fazer um fork do mesmo;
- Segue a opção de configuração da fila (appsettings.json);
```
"MassTransitAzure": {
   "Conexao": "Endpoint=sb://azureservicebustc3.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=PH1uXI/hSnOm5c5V1Z2w53P+cIz+Qrrjq+ASbKvikk8=",
   "NomeFila": "Fila"
 }
```
- Abrir o projeto, preferencialmente, na IDE Visual Studio considerando que facilitará para a execução;
- Configurar a api como startup project;
- Rodar o comando update-database no package manage console apontando para o projeto de infraestrutura (neste instante, será criado um caderno e 30 questões automaticamente);
- Clicar na opção, configurar startup projects, selecionar multiple startup projects e colocar o projeto consumidor quanto o projeto vestibularapi como start;
- Após iniciar o swagger realizar as devidas interações com a aplicação;
- 1º: cadastrar o aluno (Aluno/CreateAluno);
```
{
  "id": 0,
  "nome": "AlunoTeste",
  "cpf": "11111111111",
  "dataCadastro": "2024-03-19T22:14:11.437Z",
  "cadernoId": 1,
  "pontuacao": 0
}
```
- 2º: cadastrar a prova com as suas respectivas respostas (essas provas que vão para a fila) (Prova/CreateProva);
```
{
  "alunoId": 1,
  "cadernoId": 1,
  "respostas": [
    {
      "id": 0,
      "provaId": 0,
      "NumeroQuestao": 1,
      "alternativaEscolhida": "B"
    },{
      "id": 0,
      "provaId": 0,
      "NumeroQuestao": 2,
      "alternativaEscolhida": "B"
    },{
      "id": 0,
      "provaId": 0,
      "NumeroQuestao": 3,
      "alternativaEscolhida": "B"
    },{
      "id": 0,
      "provaId": 0,
      "NumeroQuestao": 4,
      "alternativaEscolhida": "B"
    }
  ]
}
```
- 3º: Clicar no endpoint de avaliar o aluno e passar o id do aluno criado no passo 1º (Aluno/AvaliarAluno);
- A fim de tornar o exemplo mais real, é possível incluir mais alunos e respostas repetindo os passos 1º, 2º e 3º;
- 4º: Clicar no endpoint de ranking para poder gerar o ranqueamento (Ranking/RankearAluno);
 


-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
