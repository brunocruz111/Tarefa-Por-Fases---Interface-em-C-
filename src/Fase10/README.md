# Fase 10 — Cheiros e Antídotos (AgendaBem)

Nesta fase, aplicamos refatorações cirúrgicas no código do **AgendaBem** para corrigir problemas de design identificados nas fases anteriores (Fase 4 e Fase 7).

---

## 📋 Refatorações Aplicadas

### 1. Desacoplamento de I/O (Repositório)
* **Cheiro:** O `JsonAgendamentoRepository` dependia diretamente de `File.ReadAllText`, impedindo testes rápidos.
* **Onde:** `src/Fase10/Infra/JsonRepositoryRefatorado.cs`
* **Antídoto:** Introduzimos `IFileSystem`. Agora injetamos `FakeFileSystem` nos testes e `RealFileSystem` na produção.
* **Benefício:** Testes de repositório rodam em memória.

### 2. Extensibilidade (Factory de Mensagens)
* **Cheiro:** A `MensagemFactory` usava um `switch` hardcoded. Para adicionar "Promoção", tínhamos que alterar a classe.
* **Onde:** `src/Fase10/Services/MensagemFactoryRefatorada.cs`
* **Antídoto:** Substituímos o `switch` por um `Dictionary` (Catálogo).
* **Benefício:** Novos tipos de mensagem podem ser registrados dinamicamente (OCP).

---

## ▶️ Execução

O programa demonstra:
1. Um agendamento sendo salvo em memória (sem criar arquivo no disco).
2. Uma nova mensagem de "Promoção" sendo criada sem alterar a Factory original.

```bash
dotnet run