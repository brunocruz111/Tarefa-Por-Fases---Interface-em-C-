# 🧠 Projeto: AgendaBem  
### Fase 0 — Aquecimento Conceitual (Contratos de Capacidade)

---

## 👥 Equipe

| Nome completo | RA |
|----------------|--------|
| *Bruno Luiz da Cruz* | 2705974  |
| *Kaique Patrício de Sousa* | 2301520 |
| *Pablo Weber* | 1889443 |


---

## 📘 Sumário de Fases

| Fase | Descrição | Pasta |
|------|------------|--------|
| *Fase 0* | Aquecimento conceitual – contratos de capacidade | src/Fase0/Fase0.md |
| *Fase 1* | Heurística antes do código | src/Fase01/Fase1.md |

---
## FASE 0
---
## ⚙️ Como Executar e Testar

Esta fase não contém código-fonte executável.  
O objetivo é apenas *refletir sobre design e alternância de implementações*.  

---

## 🧱 Decisões de Design da Fase 0

- O *contrato* foi definido como a ação que precisa ser realizada (sem mencionar o “como”).  
- As *implementações* são independentes e podem ser alternadas sem alterar o cliente.  
- As *políticas* foram criadas de forma concreta e objetivamente aplicáveis.  
- Cada caso contém um *risco* associado, garantindo uma análise realista do cenário.

---

## ✅ Checklist de Qualidade Aplicado 

- [x] Contrato descrito de forma genérica e clara.  
- [x] Duas implementações realmente diferentes para o mesmo objetivo.  
- [x] Política objetiva e acionável.  
- [x] Risco identificado por caso.  
- [x] Estrutura e formatação conforme o guia de fases.

---

## 🧾 Evidências de Teste
(Não aplicável nesta fase, pois não há código executável.)

---
## FASE 1
---

## ⚙️ Como Executar e Testar

Esta fase não contém código-fonte executável.  
O objetivo é apenas *refletir sobre design e alternância de implementações*.  

---
## 🧱 Decisões de design da Fase 1
- Mantivemos um *contrato único*: “notificar cliente sobre agendamento”.
- A escolha do canal foi movida para *política externa* (ponto de composição), para o cliente não precisar mudar.
- Identificamos que na próxima fase será útil ter *interface de notificação* para evitar if/switch.

---

## ✅ Checklist de qualidade aplicado
- [x] Contrato descreve o “o que” e não o “como”.
- [x] Implementações alternáveis para o mesmo objetivo (WhatsApp / app).
- [x] Política concreta de escolha de canal.
- [x] Cliente não precisa mudar quando trocar o canal.
- [ ] Testes sem I/O (não se aplica nesta fase, pois não há código).

---

### 🧾 Evidências de testes
- Fase conceitual, sem código.

---
## 🗂️ Estrutura do Repositório
  repo-raiz/
 ├── README.md                # arquivo geral (índice do projeto)
 ├── src/
 │    ├── Fase0/
 │    │     └── Fase0.md     # conteúdo detalhado da Fase 0
 │    ├── Fase1/
 │    │     └── Fase1.md     # conteúdo detalhado da Fase 1

---
