# FASE 1
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
## 🧾 Evidências de testes
- Fase conceitual, sem código.
