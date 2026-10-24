# ExoApi

API RESTful para gerenciamento de projetos, desenvolvida em C# com ASP.NET Core 5, Entity Framework Core e SQL Server — atividade do SENAI (Desenvolvimento de APIs).

## Arquitetura em camadas

```
ExoApi/
├── Controllers/   → ProjetosController: recebe as requisições HTTP e devolve JSON
├── Interfaces/    → IProjetoRepository: contrato das operações de CRUD
├── Repositories/  → ProjetoRepository: acesso ao banco via Entity Framework
├── Contexts/      → SqlContext: mapeamento das classes para o SQL Server
├── Models/        → Projeto: entidade que representa a tabela Projetos
└── Startup.cs     → registro do banco, injeção de dependência e Swagger
```

## Endpoints

| Método | Rota                  | Descrição                  | Respostas         |
|--------|-----------------------|----------------------------|-------------------|
| GET    | `/api/projetos`       | Lista todos os projetos    | 200               |
| GET    | `/api/projetos/{id}`  | Busca um projeto pelo Id   | 200, 404          |
| POST   | `/api/projetos`       | Cadastra um projeto        | 201, 400          |
| PUT    | `/api/projetos/{id}`  | Atualiza um projeto        | 204, 400, 404     |
| DELETE | `/api/projetos/{id}`  | Remove um projeto          | 204, 404          |

Exemplo de corpo (POST/PUT):

```json
{
  "titulo": "Sistema de Chamados",
  "statusProjeto": "Em andamento",
  "dataInicio": "2026-10-01",
  "tecnologias": "C#, .NET, SQL Server",
  "requisitos": "Abertura e acompanhamento de chamados",
  "area": "Desenvolvimento"
}
```

## Como executar

1. Rode o script `db.sql` no SSMS ou Azure Data Studio.
2. Ajuste a string de conexão em `ExoApi/appsettings.json` (ex.: `Server=localhost\\SQLEXPRESS` ou `Server=localhost`).
3. Abra `ExoApi.sln` no Visual Studio 2019 e execute (F5).
4. Teste pelo Swagger (`https://localhost:5001/swagger`) ou pelo Insomnia/Postman.

## Tecnologias

- C# / ASP.NET Core 5 (Web API)
- Entity Framework Core 5 (SqlServer)
- SQL Server
- Swagger (Swashbuckle)
