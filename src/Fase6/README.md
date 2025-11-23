# Fase 6 — ISP na prática (segregação por capacidade)

A Fase 6 aplica o **ISP (Interface Segregation Principle)** no domínio. Se antes havia contratos “onipotentes”, agora o objetivo é **segregar em interfaces coesas por capacidade** (ex.: confirmar, lembrar, reagendar) e **ajustar os consumidores** para dependerem só do que usam. Fase conceitual, com código simples para ilustrar.

---

## 🔙 O que mudou da Fase 5 para a Fase 6

**✔️ Na Fase 5:**
- Trabalhamos com **múltiplas interfaces por classe** e **generics com constraints**.
- Vimos **implementação explícita** e por que evitar **default interface members**.
- Foco: papéis claros e composição plugável.

**✔️ Na Fase 6:**
- Identificamos interfaces “gordas” e **segregamos por capacidade**:
  - `INotificaConfirmacao`, `INotificaLembrete`, `INotificaReagendamento`.
- **Consumidores** (casos de uso) agora injetam **apenas** a interface necessária.
- Canais (WhatsApp/App/Email) podem **implementar várias capacidades** sem acoplar o cliente.

---

## 📌 Antes / Depois (texto curto)

**Antes (exemplo):**  
`INotificador` com vários métodos (confirmar, lembrar, reagendar, cancelar, promoções, e até detalhes de canal), forçando clientes a dependerem do que não usam.

**Depois:**  
Interfaces pequenas, orientadas ao evento do domínio:  
- `INotificaConfirmacao.EnviarConfirmacao(Agendamento)`  
- `INotificaLembrete.EnviarLembrete(Agendamento)`  
- `INotificaReagendamento.EnviarReagendamento(Agendamento)`  

Consumidores:  
- `ConfirmacaoService` → `INotificaConfirmacao`  
- `LembreteService` → `INotificaLembrete`  
- `ReagendamentoService` → `INotificaReagendamento`

---

## 🧭 Sinais para segregar
- Cliente **não usa** parte dos métodos do contrato.  
- **Motivos de mudança** diferentes no mesmo arquivo (evento x canal).  
- **Mocks grandes** e testes verbosos.  
- Qualquer nova capacidade “puxa” mudanças em todo lugar.

---

## ✅ Ganhos principais
- **ISP aplicado**: dependência mínima.  
- **Baixo acoplamento** e **maior coesão**.  
- **Testes simples** (dublês pequenos).  
- **Evolução local** (nova capacidade não quebra o resto).

---

## 📁 Onde está no repositório
- Artefato: `src/Fase6/README.md` (este arquivo)  
- Código de exemplo (ilustrativo): `src/Fase6/`  
  - `Contracts/` (`INotificaConfirmacao`, `INotificaLembrete`, `INotificaReagendamento`)  
  - `UseCases/` (serviços que consomem só o necessário)  
  - `Channels/` (WhatsApp/Email/App implementando capacidades)  
  - `Domain/Agendamento.cs` e `Program.cs` (demonstração)

**Como executar:**
```bash
cd src/Fase06
dotnet run
