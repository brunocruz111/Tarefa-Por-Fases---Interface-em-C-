# Fase 10 — Cheiros e Antídotos (refatoração guiada por princípios)

A Fase 10 foca na identificação de **Cheiros de Código (Code Smells)** acumulados nas fases anteriores e na aplicação de **Antídotos (Refatorações)**. O objetivo é melhorar o design e a testabilidade guiando-se por princípios **SOLID** (como DIP, OCP e ISP), sem alterar o comportamento do sistema.

---

## 🔙 O que mudou da Fase 9 para a Fase 10

**✔️ Na Fase 9:**
- O foco era **comportamental**: garantir que o sistema lide com assincronismo, falhas e retentativas usando dublês avançados.
- Aceitávamos certo acoplamento estrutural em favor da funcionalidade.

**✔️ Na Fase 10:**
- O foco é **estrutural**: olhamos para o código existente para sanar dívidas técnicas.
- Identificamos pontos rígidos (como `switchs` ou I/O estático) e aplicamos correções cirúrgicas:
  - **I/O Estático** → Substituído por Abstração (`IFileSystem`).
  - **Decisões Espalhadas** → Substituídas por Catálogos Dinâmicos (Dicionários).

---

## 📌 Cheiros Identificados & Antídotos

**1. [cite_start]Acoplamento com I/O Estático (Testes Lentos)** [cite: 100, 101]
- *Cheiro:* Uso direto de `File.ReadAllText` impede testes rápidos em memória.
- *Antídoto:* **DIP + Seams (Costuras)**. Extração de `IFileSystem` para permitir uso de `FakeFileSystem`.

**2. [cite_start]Switch/Decisão Espalhada (Violação OCP)** [cite: 99, 100]
- *Cheiro:* `switch` na Factory exige alteração da classe para cada novo tipo.
- *Antídoto:* **Replace Conditional with Map**. Uso de Dicionário para registrar tipos dinamicamente (Extensibilidade).

**3. [cite_start]Lista Longa de Parâmetros** [cite: 102]
- *Cheiro:* Métodos recebendo `(nome, serviço, data)` individualmente.
- *Antídoto:* **Preserve Whole Object**. Passagem do objeto `Agendamento` completo.

**4. [cite_start]Interface Gorda (Fat Interface)** [cite: 96, 97]
- *Cheiro:* Clientes dependendo de métodos que não usam (ex: Leitura dependendo de `Add`).
- *Antídoto:* **ISP** (Segregação em `IRead` e `IWrite`, consolidada na Fase 8).

---

## 🧠 Como validamos (Prova de Segurança)

**Teste de I/O (Sem disco):**
- O `RepositorioRefatorado` persiste dados no `FakeFileSystem` (dicionário em memória).
- *Resultado:* Teste roda em milissegundos e prova o desacoplamento do disco físico.

**Teste de Factory (Extensibilidade):**
- Injetamos uma nova regra (`MsgPromo`) no catálogo da `FactoryRefatorada` em tempo de execução.
- *Resultado:* O sistema cria o novo tipo sem que o código fonte da Factory tenha sido tocado (respeitando OCP).

---

## ✅ Ganhos principais
- **Manutenibilidade:** Código aberto para extensão, fechado para modificação (OCP).
- **Testabilidade:** Fim da dependência de disco/rede em testes unitários (DIP).
- **Clareza:** Contratos focados e explícitos (ISP).
- **Segurança:** Refatorações pequenas que mantêm o comportamento original.

---

## 📁 Onde está no repositório
- Artefato: `src/Fase10/README.md` (este arquivo)
- Código: `src/Fase10/`
  - `AgendaBem.Fase10.csproj`
  - `Refactorings.cs` (**Antídotos**: `IFileSystem`, `FakeFileSystem`, `FactoryRefatorada`)
  - `Program.cs` (demonstração: prova que o repositório funciona sem disco e a factory aceita novos tipos)

**Como executar:**
```bash
cd src/Fase10
dotnet run