# Fase 7 — Repository progressivo (JSON)

A Fase 7 introduz um **repositório de agendamentos com persistência em JSON** no domínio AgendaBem. O serviço consome **apenas o contrato** do repositório (sem conhecer arquivo/coleção), permitindo trocar a persistência futuramente. Fase conceitual, com **código simples e executável**.

---

## 🔙 O que mudou da Fase 6 para a Fase 7

**✔️ Na Fase 6:**
- Aplicamos **ISP** (interfaces pequenas por capacidade).
- Consumidores dependiam **só do necessário** (Confirmar/Lembrar/Reagendar).

**✔️ Na Fase 7:**
- Introduzimos **Repository** para acesso a dados do domínio.
- Definimos **contrato mínimo** e uma implementação **JSON** usando `System.Text.Json`.
- O serviço usa o repositório por **injeção**, sem conhecer detalhes de arquivo.

---

## 📌 Contrato / Operações

**IAgendamentoRepository** (contrato do domínio):
- `Add(Agendamento)` — cria/substitui
- `Get(Guid id)` — busca por id
- **`ListAll()` — lista tudo**
- `ListByDateRange(DateTime de, DateTime ate)` — intervalo
- `Update(Agendamento)` — atualiza
- `Remove(Guid id)` — remove
- `Exists(Guid id)` — verifica existência

> Observação: o **serviço** só conhece este contrato — **não** sabe de `File`, `Dictionary`, `JsonSerializer`, etc.

---

## 🧠 Como o serviço usa (sem detalhes internos)

`AgendamentoService`:
- `Criar(nome, serviço, quando)` → `repo.Add(...)`
- `Reagendar(id, novaData)` → `repo.Get` + `repo.Update`
- `Cancelar(id)` → `repo.Remove`
- `ListarDia(data)` → `repo.ListByDateRange`
- **`ListarTodos()`** → `repo.ListAll()`

---

## ✅ Ganhos principais
- **Desacoplamento** entre domínio e persistência (troca fácil de backend).
- **Testabilidade** (mock do repositório).
- **Clareza** de responsabilidades (serviço orquestra, repositório persiste).

---

## 📁 Onde está no repositório
- Artefato: `src/Fase7/README.md` (este arquivo)  
- Código: `src/Fase7/`  
  - `Domain/Interfaces/IAgendamentoRepository.cs`  
  - `Infra/JsonAgendamentoRepository.cs` (persistência JSON, `camelCase`, ignora `null`, trata arquivo ausente/vazio)  
  - `UseCases/AgendamentoService.cs`  
  - `Domain/Agendamento.cs`  
  - `Program.cs` (demonstração: criar, listar, reagendar, cancelar, **ListAll**, reabrir arquivo e listar)

**Como executar:**
```bash
cd src/Fase7
dotnet run
