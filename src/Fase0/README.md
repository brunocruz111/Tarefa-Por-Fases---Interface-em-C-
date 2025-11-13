# Fase 0 — AgendaBem
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
