# 📑 Resumo do Projeto: AgendaBem (Sistema de Agendamentos)
O projeto consiste em uma aplicação Console em .NET 8 (C#) arquitetada para gerenciar agendamentos de serviços. Ele simula um cenário real de evolução de software, partindo de estruturas simples em memória até chegar a uma arquitetura robusta, desacoplada e persistida em banco de dados relacional.

---

## 1. Principais Funcionalidades (O que o sistema faz)
O sistema realiza o ciclo completo de gerenciamento de dados (CRUD):

Agendamento de Serviços (Create): Permite registrar novos compromissos com nome do cliente, tipo de serviço e data/hora.

Listagem e Relatórios (Read): Exibe todos os agendamentos cadastrados, formatando datas para o padrão brasileiro (dd/MM às HH:mm).

Atualização Cadastral (Update): Permite alterar dados de um agendamento existente (ex: mudar status do serviço, corrigir nomes).

Cancelamento/Remoção (Delete): Permite remover registros do banco de dados.

Persistência Automática: Os dados não são perdidos ao fechar o programa; eles são gravados automaticamente em um arquivo de banco de dados SQLite (agenda_bem_final.db).

---

## 2. Pontos Chave de Programação (Como o sistema foi feito)
O destaque deste projeto não é o que ele faz, mas como ele foi estruturado. A arquitetura segue rigorosamente os princípios de Design de Software Moderno:

### A. Arquitetura em Camadas (Clean Architecture)
O código é separado em responsabilidades distintas para facilitar manutenção e testes:

Domain: Contém as entidades (Appointment) e interfaces (IRepository). É o "coração" do sistema e não depende de ninguém.

Infrastructure: Contém a tecnologia pesada (EF Core, SQLite, Contexto). É a única camada que sabe como salvar dados.

UseCases: Contém a lógica de aplicação (AppointmentService). Ele orquestra as ações.

Program (UI): Apenas inicializa e conecta as peças.

### B. Padrão Repository (Repository Pattern)
Utilizamos o padrão Repository para abstrair o acesso a dados.

O AppointmentService não sabe que existe um banco de dados ou SQL. Ele apenas chama métodos como AddAsync ou ListAllAsync.

Isso permite trocar o SQLite por SQL Server, PostgreSQL ou até JSON no futuro sem alterar uma única linha da regra de negócio.

### C. Segregação de Interfaces (ISP - Interface Segregation Principle)
Aplicamos o conceito da Fase 8, dividindo o repositório em duas facetas:

IReadRepository: Para quem só precisa ler dados (ex: relatórios).

IWriteRepository: Para quem precisa alterar dados (ex: cadastro).

Isso aumenta a segurança do código, impedindo que classes de leitura acidentalmente apaguem dados.

### D. Programação Assíncrona (Async/Await)
Evolução da Fase 9. Todas as operações de Entrada/Saída (I/O) são assíncronas (Task, async, await).

Isso evita o bloqueio da thread principal enquanto o banco de dados processa a requisição, tornando a aplicação mais performática e responsiva.

### E. ORM (Entity Framework Core)
Evolução da Fase 11. Abandonamos a manipulação manual de arquivos (CSV/JSON) e queries SQL manuais (ADO.NET).

O EF Core mapeia as classes C# diretamente para tabelas do banco.

Gerenciamento automático de conexões e transações.

Proteção contra SQL Injection nativa.

### F. Injeção de Dependência (DIP - Dependency Inversion Principle)
O AppointmentService nunca instancia o repositório (new AppointmentRepository()). Ele recebe a interface via construtor.

Isso permite que, em testes unitários, possamos injetar repositórios "Fakes" ou "Mocks" para testar a lógica sem precisar de um banco de dados real.

---

## Conclusão Técnica
O projeto AgendaBem demonstra a jornada de um código acoplado para um código profissional, utilizando as melhores práticas de mercado (.NET 8, EF Core, SOLID) para criar uma solução sustentável, testável e fácil de evoluir.

**Como executar:**
```bash
cd src/Fase11
dotnet run
