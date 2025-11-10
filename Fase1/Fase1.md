# 💈 Fase 1 — Heurística antes do código (mapa mental)
(Tema: AgendaBem)

---

## 🧠 Problema escolhido (1–2 linhas)
Queremos permitir que o cliente receba confirmações e lembretes de agendamento automaticamente, escolhendo o canal mais adequado (*WhatsApp* ou *Notificação interna*) conforme disponibilidade e preferência do usuário.

---

## 🧩 Quadro 1 — Procedural (onde surgem if/switch)
- Fluxo: cliente realiza agendamento → if (possuiWhatsApp) então enviar via WhatsApp → senão enviar e-mail → retorno de sucesso/erro.  
- As decisões de canal estão *duras dentro do código*, exigindo if/switch para cada novo meio de notificação.  
- *Sinais de dor:* se quisermos incluir *SMS* ou *push notification*, o código cresce com novos if/switch, dificultando testes e manutenção.

---

## 🧱 Quadro 2 — OO sem interface (quem encapsula o quê; o que ainda fica rígido)
- Criamos classes concretas para cada canal, como WhatsAppNotifier e EmailNotifier.  
- Um serviço central (NotificationService) orquestra o envio, mas *ainda conhece as classes concretas* e decide qual chamar.  
- *Melhoras:* cada canal tem sua própria lógica (coesão por tipo de notificação); menos duplicação.  
- *Rigidez remanescente:* o cliente/orquestrador continua com a responsabilidade de escolher qual classe usar — trocar canal ainda exige alteração direta no código.

---

## ⚙️ Quadro 3 — Com interface (contrato que permite alternar + ponto de composição)
- *Contrato (o que):* “notificar cliente sobre agendamento”.  
- *Implementações (como):* WhatsAppNotifier, AppNotifier (e futuras: SMSNotifier, EmailNotifier).  
- *Ponto de composição:* escolha de implementação movida para uma *política externa* (ex.: se o cliente tiver app → notificação interna; senão → WhatsApp).  
- *Efeito:* o cliente (serviço principal) *não precisa mais mudar* quando trocamos o canal; fica possível testar com *dublês* e simular diferentes políticas sem alterar o código.

---

## 🚨 3 sinais de alerta previstos
1. Cliente mudando ao trocar o canal (*acoplamento direto* às classes concretas).  
2. Muitos if/switch espalhados no código para decidir canal de envio.  
3. *Testes frágeis* por depender de APIs externas (WhatsApp, push), sem injeção de dependência ou dublês.

--- 
