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

```
---

## ▶️ Como executar

As fases que possuem código C# têm um Program.cs.
Para rodar:
```
dotnet run
```

Em cada pasta de fase, execute o comando dentro dela.

Não há dependências externas além do SDK .NET.

---
## 🧱 Decisões de Design por Fase
### Fase 2 (procedural)

_Uso de switch/if expõe rigidez

_Modos adicionam complexidade no mesmo método

_Sem testabilidade independente

### Fase 3 (OO sem interface)

_Separação em classes específicas aumenta coesão

_Fábrica ainda cria acoplamento concreto

_Cliente continua dependente de classes reais

### Fase 4 (interface plugável)

_Introdução de IMensagem como contrato

_Cliente recebe dependência via injeção (direta ou via fábrica)

_Testes agora aceitam dublês

_Mudanças passam a acontecer em um único ponto
### Fase 5 (Decisões de Design)

A Fase 5 aprofunda o uso de interfaces no domínio, introduzindo conceitos essenciais para projetos profissionais em C#. O foco da fase foi compreender capacidades diferentes expressas por múltiplas interfaces e formas corretas de implementá-las. As principais decisões de design foram:

- **Criação de múltiplas interfaces** no domínio (`IMessageGenerator` e `IMessageFormatter`), representando capacidades distintas.
- **Implementação de múltiplas interfaces em uma mesma classe**, permitindo separar responsabilidades sem duplicar código.
- **Uso de implementação explícita de interface**, evitando poluir a API pública da classe e separando claramente papéis (ex.: `IMessageFormatter` em `ConfirmationMessage`).
- **Aplicação de generics com constraints** (`MessageServiceOfT<T> where T : IMessageGenerator, new()`), reforçando segurança de tipos e composição flexível.
- Continuidade do padrão definido na Fase 4: **resolver pattern (B1)**, garantindo flexibilidade e testabilidade da composição de serviços.
- Organização do código em pastas adequadas (`Domain`, `Interfaces`, `Services`, `Messages`), garantindo escalabilidade do projeto.

Essas escolhas reforçam princípios de coesão, testabilidade e clareza arquitetural, preparando o domínio para fases mais avançadas como ISP, segregação de responsabilidades e repositórios.

---

## ☑️ Checklist de Qualidade

 Contratos coesos

 Alternância sem alterar o cliente

 Sem switch/if nas regras de negócio das fases avançadas

 Testes independentes de infraestrutura

 Mudanças pequenas e localizadas por fase
 
---

## 🧪 Evidências de testes (quando aplicável)

### 🔹 Fase 5 — Evidência de Testes

Na Fase 5, o objetivo principal foi aprofundar o uso de interfaces e demonstrar como o design baseado em contratos facilita a testabilidade. Como parte da evidência, foram realizados testes conceituais usando:

#### ✔️ 1. **Resolver Pattern (B1) com dublê**
Foi criado um `FakeMessageGenerator` e injetado no serviço `AppointmentMessageService`, demonstrando que:
- Não é necessário instanciar classes concretas reais.
- O serviço depende apenas do contrato (`IMessageGenerator`).
- O comportamento pode ser totalmente controlado em teste.

**Resultado esperado exibido no console:**
```
[FAKE] Mensagem para Teste - Serviço
```
Isso prova que o dublê substituiu com sucesso a implementação real.

#### ✔️ 2. **Teste de implementação explícita**
Para validar o uso correto da implementação explícita, foi feito um cast:
```
if (confirmation is IMessageFormatter formatter)
{
    Console.WriteLine(formatter.FormatDetails(...));
}
```
O resultado mostra que:

_O método FormatDetails não aparece na API pública da classe.

_A capacidade só é acessível enquanto IMessageFormatter, como esperado.

#### ✔️ 3. Teste com genéricos e constraints

Usando MessageServiceOfT<ReminderMessage>:

_O compilador garante que apenas tipos válidos podem ser usados.

_O serviço funciona tanto com:

_uma instância existente (CreateFor)

_quanto criando uma nova (CreateUsingNew).

Saídas demonstram consistência:
```
Olá, Carlos! Lembrando do seu horário de Corte em 20/11 às 14:00.
Olá, Ana! Lembrando do seu horário de Corte em 21/11 às 09:00.
```
#### ✔️ 4. Evidência de funcionamento integrado (Program.cs)

Toda a integração das classes é exibida no terminal:

_Mensagens geradas por fábrica

_Resolver com fake

_Implementação explícita funcionando

_Serviços genéricos funcionando

Essas execuções representam a evidência funcional da fase.

## 📌 Conclusão dos testes da Fase 5

A fase demonstra claramente que:

_Interfaces bem definidas aumentam a testabilidade.

_Múltiplas interfaces e implementações explícitas funcionam conforme esperado.

_O uso de genéricos com constraints garante segurança de tipos.

_O resolver pattern continua garantindo desacoplamento e flexibilidade.

Assim, a Fase 5 cumpre seu objetivo ao mostrar designs que são fáceis de testar, evoluir e validar.

---

## 🎯 Conclusão

O AgendaBem está sendo construído de maneira incremental, com foco em boas práticas de design, interfaces, testabilidade e arquitetura limpa — exatamente como proposto pelo professor.
