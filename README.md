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

_Procedural

_OO

_Interfaces

_Repository

_Testabilidade

_ISP
… e assim por diante.

O repositório único garante rastreabilidade e permite observar de forma clara como o design amadurece fase após fase.

---

## Links Âncoras

[Fase0](./src/Fase0)|
[Fase1](./src/Fase1)|
[Fase2](./src/Fase2)|
[Fase3](./src/Fase3)|
[Fase3](./src/Fase4)|

---

## 📘 Sumário de Fases

| Fase | Descrição |
|------|------------|
| *Fase 0* | Aquecimento conceitual – contratos de capacidade |
| *Fase 1* | Heurística antes do código | 
| *Fase 2* | Procedural mínimo (ex.: formatar texto) | 
| *Fase 3* | OO sem interface | 
| *Fase 4* | Interface plugável e testável | 

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
 |    ├── Fase3/
 |    |     └── MensagemAgendamento.cs
 |    |     └── MensagemConfirmacao.cs
 |    |     └── MensagemFactory.cs
 |    |     └── MensagemLembrete.cs
 |    |     └── MensagemPadrao.cs
 |    |     └── MensagemReagendamento.cs
 |    |     └── Program.cs
 |    |     └── Objetivo.md      # conteúdo detalhado da Fase 3
 │    │     └── README.md
 |    ├── Fase4/
 |    |     └── MensagemAgendamento.cs
 |    |     └── MensagemConfirmacao.cs
 |    |     └── MensagemFactory.cs
 |    |     └── MensagemLembrete.cs
 |    |     └── MensagemPadrao.cs
 |    |     └── MensagemReagendamento.cs
 |    |     └── Program.cs
 |    |     └── AgendaBem.Fase4.csproj      # conteúdo detalhado da Fase 3
 │    │     └── README.md      
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
Fase 2 (procedural)

Uso de switch/if expõe rigidez

Modos adicionam complexidade no mesmo método

Sem testabilidade independente

Fase 3 (OO sem interface)

Separação em classes específicas aumenta coesão

Fábrica ainda cria acoplamento concreto

Cliente continua dependente de classes reais

Fase 4 (interface plugável)

Introdução de IMensagem como contrato

Cliente recebe dependência via injeção (direta ou via fábrica)

Testes agora aceitam dublês

Mudanças passam a acontecer em um único ponto

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
