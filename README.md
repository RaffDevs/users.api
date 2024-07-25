# users.api
Code Assessment para os candidatos a vagas de Analista de Sistemas,
Este projeto servirá como uma etapa de seleção e visa conhecer melhor os candidatos.
Obs: este teste não tem caráter eliminatório.

Os candidatos devem seguir os seguintes passos para concluir esta etapa:

* Clonar este repositório
* Utilizar o projeto Users.Api para desenvolver a API
* A API deve respeitar a especificação contida no arquivo swagger.json
* A API deve passar nos testes contidos no projeto Users.Tests
* Os dados da API devem ser armazenados em um banco de dados, podendo optar por MS Sql Server, PostgreSQL ou SQLite
* O projeto deve utilizar Entity Framework
* Devem enviar ao RH o link para um novo o repositório no github contendo a solução

## Resolução

### Descrição do teste técnico
Implementação de uma API de usuarios seguido por testes unitários para validação da api.

### Estrutura do projeto
A API, embora simples, está implementada usando princípios do Clean Architecture e CQRS (Command Query Responsibility Segregation). Isso garante uma separação clara de responsabilidades e facilita a manutenção e evolução do projeto.

### Requisitos para rodar o projeto
- Docker
- Docker Compose
- .NET Core SDK
- Ferramenta `dotnet ef tools` instalada globalmente
- .NET instalado para executar os testes

### Como rodar o projeto
1. **Tenha os requisitos instalados.**
2. **Clone este repositório.**
   
   ```sh
   git clone https://github.com/RaffDevs/users.api
   cd path/to/your/solution
   ```
3. **Na pasta raiz do repositório, execute**:

   ```sh
   docker-compose up --build -d
   ```
4. **Entre na pasta Users.Api e execute**:
   ```sh
   dotnet ef migrations add InitialMigration
   ````
5. **Ainda nessa pasta, execute a aplicação da migration**:

   ```sh
    dotnet ef database update --connection       
   "Host=localhost;Port=5202;Pooling=true;Database=users;User 
    Id=dev;Password=senhaXPTO;"
   ```
   **Observação: Este comando está usando a string de conexão com os parâmetros padrões. Caso queira alterar, não se esqueça de alterar no docker-compose e também no arquivo Startup**.
   
6. **Pronto! O projeto já deve estar rodando. Para testar, acesse:**
   ```sh
   http://localhost:5201/api/Users/hello
   ```
   Deve retornar um "hello world"

 
### Como rodar os testes

1. **Acesse a pasta raiz do repositório e, tendo o .NET instaldo, execute:**
   
   ```sh
   dotnet test
   ```
 
**Dessa forma, os testes unitários serão executados. O esperado é que todos passem!**
