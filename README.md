# 🏗️ Documentação: API com Clean Architecture

Este guia serve como referência para a estrutura de pastas, dependências e comandos 
utilizados na criação de uma API robusta e desacoplada.

---

### 📊 Grafo de Dependências (Flow)

As setas indicam quem "enxerga" quem. Note que o Domain é o centro de tudo.

      +-------------------------------------------+
      |               [ Web/API ]                 |
      |   (Controllers, Middlewares, Program.cs)  |
      +-------+-------------+--------------+------+
              |             |              |
              v             v              |
      +-------+-------+   +----------------+------+
      | [Application] |<--+   [Infrastructure]    |
      | (Services,DTO)|   | (EF, Auth, Repo Impl) |
      +-------+-------+   +--------+--------------+
              |                    |
              |      +-------------+
              v      v
      +-------+------+--------+
      |       [ Domain ]      |
      | (Entities, Interfaces)|
      +-----------------------+

---

### 📂 Camadas e Responsabilidades

#### 1. Domain
* **Papel**: Regras de negócio puras e entidades.
* **Dependências**: Nenhuma (Independente).
* **Pastas**: `Entities`, `Enums`, `Exceptions`.

#### 2. Application
* **Papel**: Orquestra casos de uso e define DTOs.
* **Dependências**: Referencia `Domain`.
* **Pastas**: `Services`, `Interfaces`, `DTOs`.

#### 3. Infrastructure
* **Papel**: Detalhes técnicos (Banco, JWT, Criptografia).
* **Dependências**: Referencia `Domain` (para tabelas) e `Application` (para implementar interfaces).
* **Pastas**: `Data`, `Repositories`, `Migrations`, `Encryption`, `Authentication`.

#### 4. Web/API
* **Papel**: Ponto de entrada e registro de dependências.
* **Dependências**: Referencia `Application` e `Infrastructure` (para injeção de dependência).

---

### 💻 Guia de Comandos (.NET CLI)

#### 1. Criando a Estrutura
```bash
# Criar Solution
dotnet new sln -o MinhaSolucao

# Criar Projetos
dotnet new classlib -o MinhaSolucao.Domain
dotnet new classlib -o MinhaSolucao.Application
dotnet new classlib -o MinhaSolucao.Infrastructure
dotnet new webapi -o MinhaSolucao.API

# Adicionar à Solution
dotnet sln add **/*.csproj
```

#### 2. Configurando Referencias
```bash
# Application -> Domain
dotnet add MinhaSolucao.Application/ reference MinhaSolucao.Domain/

# Infrastructure -> Domain e Application
dotnet add MinhaSolucao.Infrastructure/ reference MinhaSolucao.Domain/
dotnet add MinhaSolucao.Infrastructure/ reference MinhaSolucao.Application/

# API -> Application e Infrastructure
dotnet add MinhaSolucao.API/ reference MinhaSolucao.Application/
dotnet add MinhaSolucao.API/ reference MinhaSolucao.Infrastructure/
```

#### 3. Cloando e rodando o projeto

Siga os passos abaixo para configurar o ambiente e rodar a API localmente.

#### 1. Pré-requisitos
Antes de iniciar, certifique-se de ter as seguintes ferramentas instaladas:

* **SDK do .NET 9.0** ou superior.
* **Docker** e **Docker Compose** (para instanciar o banco de dados PostgreSQL).
* **Make** (opcional - para usuários Linux/macOS).

```bash
# Sobe o container do banco de dados em segundo plano
docker compose up -d
```

#### 2. Instalação da Ferramenta EF Core
Para gerenciar as migrações do banco de dados, você precisa da dotnet-ef tool instalada globalmente:
```bash
# Instala a tool (apenas a primeira vez)
dotnet tool install --global dotnet-ef

# Ou atualiza, caso já possua
dotnet tool update --global dotnet-ef

# Verifica se a instalação foi bem-sucedida
dotnet ef
```

#### 3. Clonando e Executando

Com o banco rodando e as ferramentas instaladas, siga a sequência:
```bash
# Clone o repositório
git clone _url_

# Restaure as dependências do NuGet
dotnet restore

# Aplique as migrations para criar as tabelas
dotnet ef database update --project TimeSheet.Infrastructure --startup-project TimeSheet.API

# Execute a API
dotnet run --project TimeSheet.API
```

#### 4. Caso estiver em um ambiente Linux com make instalado, pode simplificar o processo usando os atalhos do nosso Makefile:
```bash
# Roda as migrations
make update

# Roda o projeto
make run
```

### Backlog
#### 1. Gestão de Entradas (Edição e Exclusão)
- PUT /api/TimeLog/{id}: Para editar um comentário ou ajustar o horário de início/fim.

- DELETE /api/TimeLog/{id}: Para remover um lançamento duplicado ou incorreto.

#### 2. Dashboard e Relatórios (A Entrega de Valor)

- GET /api/TimeLog/summary: Uma rota que retorna o total de horas trabalhadas no dia, na semana e no mês atual.

- GET /api/TimeLog/report: Com filtros de startDate e endDate. É essencial para que o usuário possa gerar uma "folha" para exportar ou conferir no final do mês.
