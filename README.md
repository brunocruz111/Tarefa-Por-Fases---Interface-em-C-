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

---

## ☑️ Checklist de Qualidade

 Contratos coesos

 Alternância sem alterar o cliente

 Sem switch/if nas regras de negócio das fases avançadas

 Testes independentes de infraestrutura

 Mudanças pequenas e localizadas por fase
 
---

## 🧪 Evidências de testes (quando aplicável)

Serão incluídas a partir da Fase 5/6 quando começarem os testes com dublês.

---

## 🎯 Conclusão

O AgendaBem está sendo construído de maneira incremental, com foco em boas práticas de design, interfaces, testabilidade e arquitetura limpa — exatamente como proposto pelo professor.
