# 🧠 Projeto: AgendaBem  

---

## 👥 Equipe

| Nome completo | RA |
|----------------|--------|
| *Bruno Luiz da Cruz* | 2705974  |
| *Kaique Patrício de Sousa* | 2301520 |
| *Pablo Weber* | 1889443 |

---

## 📌 Resumo do Projeto

O AgendaBem é um sistema simplificado para geração de mensagens de agendamento em uma barbearia.
Ele evolui progressivamente pela abordagem recomendada em sala, seguindo as fases:

### 📘 Sumário de Fases

| Fase | Descrição | Âncora |
|------|------------|------|
| *Fase 0* | Aquecimento conceitual – contratos de capacidade | [Fase0](./src/Fase0) |
| *Fase 1* | Heurística antes do código | [Fase1](./src/Fase1)|
| *Fase 2* | Procedural mínimo (ex.: formatar texto) | [Fase2](./src/Fase2)|
| *Fase 3* | OO sem interface | [Fase3](./src/Fase3)|
| *Fase 4* | Interface plugável e testável | [Fase4](./src/Fase4)|
| *Fase 5* | Essenciais de Interfaces em C | [Fase5](./src/Fase5)|
| *Fase 6* | Repository CSV — persistência em arquivo | [Fase6](./src/Fase6)|
| *Fase 7* | Repository JSON — persistência em JSON | [Fase7](./src/Fase7)|
| *Fase 8* | ISP (Interface Segregation Principle) | [Fase8](./src/Fase8)|
| *Fase 9* | Dublês avançados e testes assíncronos | [Fase9](./src/Fase9)|
| *Fase 10* | Cheiros e antídotos (refatorações com diffs pequenos) | [Fase10](./src/Fase10)|
| *Fase 11* | Mini‑projeto de consolidação | [Fase11](./src/Phase11MiniProject)|

---

## 🗂️ Estrutura do Repositório
```
  repo-raiz/
 ├── README.md                # arquivo geral (índice do projeto)
 ├── src/
 │    ├── Fase0/
 │    │     └── Aquecimento.md     # conteúdo detalhado da Fase 0
 │    │     └── README.md         
 │    ├── Fase1/
 │    │     └── Heuristica.md     # conteúdo detalhado da Fase 1
 │    │     └── README.md         
 |    ├── Fase2/
 |    |     └── Procedural.cs     # conteúdo detalhado da Fase 2
 │    │     └── README.md
 |    |     └── AgendaBem.Fase2.csproj   
 |    ├── Fase3/
 |    |     └── MensagemAgendamento.cs
 |    |     └── MensagemConfirmacao.cs
 |    |     └── MensagemFactory.cs
 |    |     └── MensagemLembrete.cs
 |    |     └── MensagemPadrao.cs
 |    |     └── MensagemReagendamento.cs
 |    |     └── Program.cs
 |    |     └── AgendaBem.Fase3.csproj
 |    |     └── Objetivo.md      # conteúdo detalhado da Fase 3
 │    │     └── README.md
 |    ├── Fase4/
 |    |     └── Program.cs      
 |    |     └── AgendaBem.Fase4.csproj      
 │    │     └── README.md        # conteúdo detalhado da Fase 4
 |    |     ├── Domain/
 |    |     |      └── MensagemAgendamento.cs
 |    |     |      └── MensagemConfirmacao.cs
 |    |     |      └── MensagemLembrete.cs
 |    |     |      └── MensagemPadrao.cs
 |    |     |      └── MensagemReagendamento.cs
 |    |     |      ├── Interfaces/
 |    |     |      |      └── IMensagem.cs
 |    |     ├── Services/
 |    |     |      └── MensagemFactory.cs
 |    ├── Fase5/
 |    |      ├── Program.cs
 |    |      ├── README.md
 |    |      ├── AgendaBem.Fase5.csproj
 |    |      ├── Domain/
 |    |      │    ├── Interfaces/
 |    |      │    │     ├── IMessageGenerator.cs
 |    |      │    │     └── IMessageFormatter.cs
 |    |      │    ├── ConfirmationMessage.cs
 |    |      │    ├── ReminderMessage.cs
 |    |      │    └── DefaultMessage.cs
 |    |      └── Services/
 |    |            ├── MessageFactory.cs
 |    |            ├── AppointmentMessageService.cs
 |    |            └── MessageServiceOfT.cs
 |    ├── Fase6/
 |    |      ├── Program.cs
 |    |      ├── README.md
 |    |      ├── AgendaBem.Fase6.csproj
 |    |      ├── Domain/
 |    |      │    ├── Interfaces/
 |    |      │    │     ├── INotificaConfirmacao.cs
 |    |      │    │     ├── INotificaLembrete.cs
 |    |      │    │     ├── IRepository.cs
 |    |      │    │     └── INotificaReagendamento.cs
 |    |      │    ├── CSVAgendamentoRepository.cs
 |    |      │    └── Agendamento.cs
 |    |      ├── Services/
 |    |      |      ├── AppNotifier.cs
 |    |      |      ├── EmailNotifier.cs
 |    |      |      └── WhatsAppNotifier.cs
 |    |      └── UseCases/
 |    |      |      ├── ConfirmacaoService.cs
 |    |      |      ├── LembreteService.cs
 |    |      |      └── ReagendamentoService.cs
 |    ├── Fase7/
 |    |      ├── Program.cs
 |    |      ├── README.md
 |    |      ├── AgendaBem.Fase7.csproj
 |    |      ├── Domain/
 |    |      │    ├── Interfaces/
 |    |      │    │     └── IAgendamentoRepository.cs
 |    |      │    └── Agendamento.cs
 |    |      └── UseCases/
 |    |      |      └── AgendamentoService.cs
 |    ├── Fase8/
 |    |      ├── Program.cs
 |    |      ├── README.md
 |    |      ├── AgendaBem.Fase8.csproj
 |    |      ├── Domain/
 |    |      │    ├── Interfaces/
 |    |      │    │     ├── INotificaConfirmacao.cs
 |    |      │    │     ├── INotificaLembrete.cs
 |    |      │    │     ├── IRepository.cs
 |    |      │    │     └── INotificaReagendamento.cs
 |    |      │    ├── CSVAgendamentoRepository.cs
 |    |      │    └── Agendamento.cs
 |    |      ├── Services/
 |    |      |      ├── AppNotifier.cs
 |    |      |      ├── EmailNotifier.cs
 |    |      |      └── WhatsAppNotifier.cs
 |    |      └── UseCases/
 |    |      |      ├── ConfirmacaoService.cs
 |    |      |      ├── LembreteService.cs
 |    |      |      └── WhatsAppNotifier.cs
 |    ├── Fase9/
 |    |      ├── Program.cs
 |    |      ├── README.md                     # conteúdo detalhado da Fase 9
 |    |      ├── AgendaBem.Fase9.csproj
 |    |      ├── Domain/
 |    |      |      ├── Agendamento.cs
 |    |      |      └── Contracts.cs             # interfaces e contratos da fase
 |    |      ├── Doubles/
 |    |      |      └── Fakes.cs                 # mocks/fakes para testes ou simulações
 |    |      └── Services/
 |    |      └── AgendamentoService.cs    # caso de uso da fase
 |    ├── Fase10/
 |    |      ├── README.md                     # conteúdo detalhado da Fase 10
 |    ├──Fase11/
 |    |      ├── Program.cs
 |    |      ├── README.md                     # conteúdo detalhado da Fase 11
 |    |      ├── AgendaBem.Fase11.csproj
 |    |      ├── Domain/
 |    |      ├── Agendamento.cs
 |    |      └── Interfaces/
 |    |      |      ├── IReadRepository.cs
 |    |      |      └── IWriteRepository.cs
 |    |      ├── Infra/
 |    |      |      ├── InMemoryBookRepository.cs
 |    |      |      └── JsonBookRepository.cs
 |    |      ├── Services/
 |    |      |      └── AgendaService.cs
 |    |      ├── catalogo_livros.json
 └──  └──    └── agenda_db.json



```
---

## ▶️ Como Executar

As fases que possuem código C# incluem um arquivo Program.cs — o ponto de entrada da aplicação.

Para executar qualquer fase:
```
dotnet run
```

Basta acessar a pasta correspondente da fase antes de rodar o comando.

### ✔ Requisitos: apenas .NET SDK
### ✔ Nenhuma dependência externa adicional

---

## 🧱 Decisões de Design (Visão Geral)

Ao longo do projeto, o AgendaBem evolui de forma incremental, aplicando princípios fundamentais de desenvolvimento de software.

### 💡 1. Transição do Procedural para OO

Primeiro contato com mensagens de agendamento como funções simples.

Evolução para classes distintas, com responsabilidades específicas.

Uso inicial de fábricas para criar objetos concretos.

### 💡 2. Introdução de Interfaces

Permitiu que o cliente não dependesse mais de implementações concretas.

Tornou possível testar serviços de forma isolada.

Criou contratos estáveis para evolução incremental.

### 💡 3. Segregação de Responsabilidades

Princípio SRP aplicado continuamente.

Cada classe passou a representar uma única capacidade.

Redução de acoplamento e maior facilidade de manutenção.

### 💡 4. Persistência por Repositórios

Abstração de dados através de repositories.

Implementações em CSV, JSON e memória.

Permuta entre implementações sem alterar casos de uso.

### 💡 5. Testes e Dublês

Uso de Fakes, Stubs e Mocks.

Testes assíncronos e validação comportamental.

Serviços dependem apenas de interfaces → testabilidade máxima.

### 💡 6. Refatorações Progressivas

Redução de condicionais (switch/if) na regra de negócio.

Remoção de cheiros de código.

Divisão de contratos com ISP.

Aplicação de padrões como Factory, Resolver e Repository.

---

## 🧪 Evidências de Testabilidade

O projeto demonstra, ao longo da evolução:

### ✔ Inversão de Dependências

Dependências concretas substituídas por contratos (interfaces).

### ✔ Substituição Fácil por Dublês

Permite executar testes independentes de infraestrutura.

### ✔ Assinaturas Assíncronas

Comportamentos reais podem ser simulados sem bloquear a aplicação.

### ✔ Implementações Explícitas

Métodos adicionais só aparecem sob o contrato adequado, mantendo a API limpa.

### ✔ Genéricos com Constraints

Aumentam a segurança de tipos e evitam erros de design.

Esses pontos juntos garantem um domínio sólido, testável e expressivo.

---

## ☑️ Checklist Geral de Qualidade

 Uso consistente de contratos coesos

 Mudanças isoladas e seguras

 Ausência de condicionais extensas em fases avançadas

 Serviços testáveis sem dependências externas

 Estrutura de pastas clara e escalável

 Evolução incremental planejada
 
---

##🎯 Conclusão

O AgendaBem é um projeto didático que demonstra de forma progressiva:

princípios fundamentais de design orientado a objetos

crescimento incremental de arquitetura

separação clara de responsabilidades

testabilidade de ponta a ponta

boas práticas adotadas no desenvolvimento profissional em C#

Cada fase expande e melhora o código, preparando um terreno sólido para sistemas reais.
