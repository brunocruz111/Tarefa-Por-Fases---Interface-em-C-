# Fase 11 — Mini-Projeto de Consolidação (AgendaBem Final)

Este projeto conclui a jornada do **AgendaBem**, consolidando todo o conhecimento em uma arquitetura limpa, testável e desacoplada.

---

##  Arquitetura do Projeto

1.  **Domínio (Core):**
    - Entidade `Agendamento` (imutável).
    - Interfaces Segregadas (`IReadRepository`, `IWriteRepository`) garantindo **ISP**.

2.  **Infraestrutura (Plugável):**
    - `InMemoryRepository`: Usado para testes unitários instantâneos.
    - `JsonRepository`: Usado para persistência real em arquivo.

3.  **Serviços:**
    - `AgendaService`: Contém a regra de negócio. Não sabe onde os dados são salvos, apenas consome as interfaces.

---

##  Estratégia de Testes

O `Program.cs` executa dois tipos de validação:

1.  **Testes Unitários (InMemory):**
    - Valida regras de Agendar, Reagendar e Cancelar.
    - Roda em memória RAM, sem efeitos colaterais.

2.  **Demo de Integração (JSON):**
    - Cria um arquivo `agenda_db.json`.
    - Simula o uso real do sistema (persistindo dados).

---

## 📊 Autoavaliação

| Critério | Status | Justificativa |
| :--- | :---: | :--- |
| **Domínio Coerente** | ✅ | Mantido o tema "Barbearia/Agenda" do início ao fim. |
| **Contratos (ISP)** | ✅ | Interfaces de leitura e escrita separadas. |
| **Repositórios** | ✅ | Implementação dupla (Memória e JSON) funcionando. |
| **Testabilidade** | ✅ | Testes unitários com dublês (Fake/InMemory). |

---

## ▶️ Como executar
```bash
cd src/Fase11
dotnet run