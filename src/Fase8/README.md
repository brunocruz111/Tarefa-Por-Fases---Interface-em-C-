# Fase 8 — ISP (leitura x escrita no repositório)

A Fase 8 aplica o **Interface Segregation Principle (ISP)** ao repositório do AgendaBem, **separando consultas de mutações**. Os consumidores passam a depender **somente do que usam**, com dublês menores e testes simples. Fase conceitual, com **código executável**.

---

## 🔙 O que mudou da Fase 7 para a Fase 8

**✔️ Na Fase 7:**
- Havia um contrato único `IAgendamentoRepository` (Add/Get/List/Update/Remove/Exists).
- O serviço conhecia o **mesmo contrato** para ler e escrever.

**✔️ Na Fase 8:**
- **Segregamos por capacidade**:
  - `IReadAgendamentoRepository` (somente leitura)
  - `IWriteAgendamentoRepository` (somente escrita)
- Consumidores separados:
  - `AgendaQuery` → **leitura**
  - `AgendamentoCommands` → **escrita** (e leitura quando necessário para atualizar)

---

## 📌 Contratos / Operações

**IReadAgendamentoRepository** (consultas):
- `Get(Guid id)` — busca por id  
- `ListAll()` — lista tudo  
- `ListByDateRange(DateTime de, DateTime ate)` — por intervalo

**IWriteAgendamentoRepository** (mutações):
- `Add(Agendamento)` — cria/substitui  
- `Update(Agendamento)` — atualiza  
- `Remove(Guid id)` — remove  
- `Exists(Guid id)` — verifica existência

> Observação: cada consumidor injeta **apenas** o contrato necessário (leitura **ou** escrita). Não há dependência direta de `File`, `JsonSerializer`, etc.

---

## 🧠 Como os serviços usam (sem detalhes internos)

`AgendaQuery` (leitura):
- `PorId(id)` → `read.Get`
- `Todos()` → `read.ListAll`
- `DoDia(data)` → `read.ListByDateRange`

`AgendamentoCommands` (escrita + leitura quando precisa):
- `Criar(nome, serviço, quando)` → `write.Add`
- `Reagendar(id, novaData)` → `read.Get` + `write.Update`
- `Cancelar(id)` → `write.Remove`

---

## ✅ Ganhos principais
- **ISP aplicado** de fato (dependência mínima).
- **Testes mais simples** (dublês pequenos de leitura/escrita).
- **Baixo acoplamento** e **clareza** de responsabilidades.
- Evolução local: cache só na leitura, fila/evento só na escrita.

---

## 📁 Onde está no repositório
- Artefato: `src/Fase8/README.md` (este arquivo)  
- Código: `src/Fase8/`  
  - `Fase8.csproj`  
  - `Domain/Agendamento.cs`  
  - `Domain/Interfaces/IReadAgendamentoRepository.cs`  
  - `Domain/Interfaces/IWriteAgendamentoRepository.cs`  
  - `Infra/JsonFileStore.cs` (utilitário JSON)  
  - `Infra/JsonReadRepository.cs` (**implementa leitura**)  
  - `Infra/JsonWriteRepository.cs` (**implementa escrita**)  
  - `UseCases/AgendaQuery.cs` (**leitura**)  
  - `UseCases/AgendamentoCommands.cs` (**escrita**)  
  - `Program.cs` (demo: criar, listar, reagendar, cancelar, persistência JSON)

**Como executar:**
```bash
cd src/Fase8
dotnet run
