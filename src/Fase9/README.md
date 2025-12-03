# Fase 9 — Dublês Avançados e Testes Assíncronos

A Fase 9 foca na criação de **testes determinísticos para cenários assíncronos**, utilizando injeção de dependência avançada para abstrair tempo e I/O. O objetivo é validar fluxos complexos (streams, retentativas, cancelamento) sem depender de recursos reais. Fase conceitual, com **código executável**.

---

## 🔙 O que mudou da Fase 8 para a Fase 9

**✔️ Na Fase 8:**
- O foco era **estrutural** (ISP): separar interfaces de leitura e escrita.
- Os testes e operações dependiam de execução síncrona ou simples, sem controle fino de tempo ou falhas intermitentes.

**✔️ Na Fase 9:**
- Introduzimos **Costuras (Seams)** para isolar infraestrutura volátil:
  - `IClock` (abstração de tempo)
  - `IAsyncReader` / `IAsyncWriter` (abstração de I/O)
- Implementamos um **serviço resiliente** (`DataPumpService`):
  - Consome dados via **Stream** (`IAsyncEnumerable`).
  - Aplica políticas de **Retentativa** (Retry).

---

## 📌 Contratos / Operações

**IClock** (Tempo):
- `Now` — retorna o momento atual (permite avançar o tempo em testes sem `Thread.Sleep`).

**IAsyncReader\<T>** (Entrada):
- `ReadAllAsync(CancellationToken ct)` — retorna um fluxo de dados (`IAsyncEnumerable`) que pode ser infinito, vazio ou falhar no meio.

**IAsyncWriter\<T>** (Saída):
- `WriteAsync(T item, CancellationToken ct)` — persiste um item, permitindo simular falhas transientes para testar resiliência.

> Observação: O serviço injeta **apenas** estes contratos. Não há dependência direta de `DateTime.Now`, `FileStream` ou rede.

---

## 🧠 Como os serviços usam (sem detalhes internos)

`DataPumpService` (processador):
- `RunAsync(ct)` → Inicia o consumo do stream.
- **Leitura** → Itera sobre `_reader.ReadAllAsync`.
- **Escrita** → Chama `_writer.WriteAsync` para cada item.
- **Falha** → Se o writer falhar, captura a exceção, verifica o `_clock` (ou contador) e tenta novamente (Retry).
- **Cancelamento** → Se `ct` for cancelado, interrompe o loop graciosamente.

---

## ✅ Ganhos principais
- **Testes determinísticos** (controle total de cenários de sucesso e erro).
- **Simulação de falhas** (validar lógica de retry sem desligar banco de dados real).
- **Assincronismo real** (suporte a Cancelamento e Streams).
- **Performance de testes** (sem `Thread.Sleep` ou I/O de disco).

---

## 📁 Onde está no repositório
- Artefato: `src/Fase9/README.md` (este arquivo)
- Código: `src/Fase9/`
  - `AgendaBem.Fase9.csproj`
  - `Domain/Contracts.cs` (**Costuras**: Clock, Reader, Writer)
  - `Domain/Agendamento.cs`
  - `Services/DataPumpService.cs` (**Lógica de Retry e Stream**)
  - `Doubles/Fakes.cs` (**Dublês**: FakeClock, FakeReader, StubBrokenWriter)
  - `Program.cs` (demo: cenários de sucesso, erro, retry e cancelamento)

**Como executar:**
```bash
cd src/Fase9
dotnet run