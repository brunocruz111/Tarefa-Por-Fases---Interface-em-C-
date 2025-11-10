# 🧠 Projeto: AgendaBem  
### Fase 0 — Aquecimento Conceitual (Contratos de Capacidade)

---

## 👥 Equipe

| Nome completo | Função |
|----------------|--------|
| *Kaique Patrício de Sousa* | Desenvolvedor |
| *Bruno Luiz da Cruz* | Desenvolvedor |

---

## 📘 Sumário de Fases

| Fase | Descrição | Pasta |
|------|------------|--------|
| *Fase 0* | Aquecimento conceitual – contratos de capacidade (sem código) | src/fase-00-aquecimento/ |
| *Fase 1* | Heurística antes do código (mapa mental) | src/fase-01-procedural/ |
| *Fase 2* | Procedural mínimo (modos simples e fronteiras) | src/fase-02-oo-sem-interface/ |
| *Fase 3* | OO sem interface | src/fase-03-com-interfaces/ |
| *Fase 4* | Interface plugável e testável | src/fase-04-repository-inmemory/ |
| *Fase 5* | Essenciais de interfaces em C# | src/fase-05-repository-csv/ |
| *Fase 6* | ISP na prática (segregação por capacidade) | src/fase-06-repository-json/ |
| *Fase 7* | Repository InMemory | src/fase-07-isp/ |
| *Fase 8* | Repository CSV | src/fase-08-testes-dubles/ |
| *Fase 9* | Repository JSON | src/fase-09-cheiros-antidotos/ |
| *Fase 10* | Testabilidade: dublês e costuras | src/fase-10-eixos-opcional/ |
| *Fase 11* | Cheiros e antídotos | src/fase-11-mini-projeto/ |

---

## 🧩 Fase 0 — Aquecimento Conceitual: Contratos de Capacidade (sem código)

### Caso 1 – Confirmação de Agendamento

*Objetivo:* Garantir que o cliente receba a confirmação do serviço agendado na barbearia.  
*Contrato:* Confirmar o agendamento do cliente.  
*Implementação A:* Envio automático de mensagem via *WhatsApp* com os dados do serviço e horário.  
*Implementação B:* Envio de *e-mail* com as mesmas informações do agendamento.  
*Política:* Se o cliente possuir número de WhatsApp válido, enviar mensagem por WhatsApp; caso contrário, enviar e-mail.  
*Risco/Observação:* A mensagem por WhatsApp pode não ser entregue em caso de número incorreto ou conexão instável; o e-mail pode ir para a caixa de spam.

---

### Caso 2 – Lembrete de Horário

*Objetivo:* Reduzir o número de faltas, lembrando o cliente sobre o horário do agendamento.  
*Contrato:* Enviar lembrete de horário ao cliente.  
*Implementação A:* Envio de *notificação dentro do aplicativo AgendaBem* algumas horas antes do atendimento.  
*Implementação B:* Envio de *mensagem via WhatsApp* lembrando o horário marcado.  
*Política:* Se o cliente tiver o aplicativo instalado e com notificações ativas, usar a notificação interna; caso contrário, enviar mensagem pelo WhatsApp.  
*Risco/Observação:* O uso de notificações depende da permissão ativa no celular; o WhatsApp pode ser ignorado caso o cliente não veja a mensagem a tempo.

---

## ⚙️ Como Executar e Testar

Esta fase não contém código-fonte executável.  
O objetivo é apenas *refletir sobre design e alternância de implementações*.  
A partir da *Fase 1*, cada pasta incluirá:
- Um arquivo README.md com instruções específicas;  
- Código C# referente à fase;  
- Exemplos de execução e testes unitários.

---

## 🧱 Decisões de Design da Fase 0

- O *contrato* foi definido como a ação que precisa ser realizada (sem mencionar o “como”).  
- As *implementações* são independentes e podem ser alternadas sem alterar o cliente.  
- As *políticas* foram criadas de forma concreta e objetivamente aplicáveis.  
- Cada caso contém um *risco* associado, garantindo uma análise realista do cenário.

---

## ✅ Checklist de Qualidade Aplicado (interno à equipe)

- [x] Contrato descrito de forma genérica e clara.  
- [x] Duas implementações realmente diferentes para o mesmo objetivo.  
- [x] Política objetiva e acionável.  
- [x] Risco identificado por caso.  
- [x] Estrutura e formatação conforme o guia de fases.

---

## 🧾 Evidências de Teste
(Não aplicável nesta fase, pois não há código executável. As evidências serão incluídas a partir da Fase 2.)

---

📍 *Status da Fase:* Finalizada  
📅 *Data de entrega:* 10/11/2025

---
