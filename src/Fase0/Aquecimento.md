# FASE 0
---
## 🧩 Caso 1 – Confirmação de agendamento

**Objetivo:** Garantir que o cliente receba a confirmação do serviço agendado na barbearia.  
**Contrato:** Confirmar o agendamento do cliente.  
**Implementação A:** Envio automático de mensagem via **WhatsApp** com os dados do serviço e horário.  
**Implementação B:** Envio de **e-mail** com as mesmas informações do agendamento.  
**Política:** Se o cliente possuir número de WhatsApp válido, enviar mensagem por WhatsApp; caso contrário, enviar e-mail.  
**Risco/Observação:** A mensagem por WhatsApp pode não ser entregue em caso de número incorreto ou conexão instável; o e-mail pode ir para a caixa de spam.

---

## 🧩 Caso 2 – Lembrete de horário

**Objetivo:** Reduzir o número de faltas, lembrando o cliente sobre o horário do agendamento.  
**Contrato:** Enviar lembrete de horário ao cliente.  
**Implementação A:** Envio de **notificação dentro do aplicativo AgendaBem** algumas horas antes do atendimento.  
**Implementação B:** Envio de **mensagem via WhatsApp** lembrando o horário marcado.  
**Política:** Se o cliente tiver o aplicativo instalado e com notificações ativas, usar a notificação interna; caso contrário, enviar mensagem pelo WhatsApp.  
**Risco/Observação:** O uso de notificações depende da permissão ativa no celular; o WhatsApp pode ser ignorado caso o cliente não veja a mensagem a tempo.
