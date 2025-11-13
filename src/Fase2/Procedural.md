## 1. Objetivo da fase
Implementar um fluxo *procedural* (sem OO e sem interface ainda) que gere mensagens para o cliente do AgendaBem de acordo com o tipo de evento do agendamento.

A ideia é ter um único fluxo com ramificações (if / switch) que monte o texto conforme o modo escolhido.

---

## 2. Objetivo funcional (tema: AgendaBem)
“Gerar o texto que será enviado ao cliente sobre o agendamento, variando conforme o tipo de notificação.”

---

## 3. Modos previstos (mínimo 3 + padrão)

Vamos considerar 4 modos:

1. *confirmação* – quando o cliente acabou de agendar.
2. *lembrete* – algumas horas antes do horário.
3. *reagendamento* – quando o horário foi alterado.
4. *padrão* – caso venha um tipo desconhecido.

---

## 4. Fluxo procedural (descrição)

1. Receber os dados básicos: *nome do cliente, **data/hora do agendamento, **serviço*.
2. Receber também o *tipo de mensagem* (confirmação, lembrete, reagendamento, outro).
3. Fazer um if / switch em cima do tipo:
   - se for confirmação → montar mensagem de confirmação;
   - se for lembrete → montar mensagem de lembrete;
   - se for reagendamento → montar mensagem informando a troca de horário;
   - senão → montar mensagem padrão genérica.
4. Retornar o texto montado.

(Ainda não estamos escolhendo canal aqui — só o conteúdo da mensagem.)

---

## 5. Exemplos de mensagens (procedural)

- *confirmação*  
  “Olá, {nome}! Seu agendamento para *{serviço}* foi confirmado para *{dataHora}*. Qualquer dúvida, fale com a barbearia.”

- *lembrete*  
  “Olá, {nome}! Só lembrando do seu horário de *{serviço}* hoje às *{dataHora}*. Chegue com 5 min de antecedência 🙂”

- *reagendamento*  
  “Olá, {nome}! Seu agendamento de *{serviço}* foi alterado para *{dataHora}*. Se não puder, responda.”

- *padrão*  
  “Olá, {nome}! Temos uma atualização sobre o seu agendamento. Consulte o app ou a barbearia.”

---

## 6. Cenários de teste / fronteira (5 cenários)

1. *Tipo válido – confirmação*  
   - Entrada: nome = “João”, serviço = “Corte”, dataHora = “15/11 às 15:00”, tipo = “confirmação”  
   - Saída esperada: mensagem de confirmação com todos os campos preenchidos.

2. *Tipo válido – lembrete*  
   - Entrada: nome = “Marcos”, serviço = “Barba”, dataHora = “16/11 às 10:30”, tipo = “lembrete”  
   - Saída esperada: mensagem de lembrete com data/hora.

3. *Tipo válido – reagendamento*  
   - Entrada: nome = “Pedro”, serviço = “Corte e Barba”, dataHora = “20/11 às 18:00”, tipo = “reagendamento”  
   - Saída esperada: mensagem avisando que mudou o horário.

4. *Tipo desconhecido*  
   - Entrada: nome = “Lucas”, serviço = “Corte”, dataHora = “21/11 às 09:00”, tipo = “outroValor”  
   - Saída esperada: mensagem padrão (genérica), sem quebrar.

5. *Campo faltando / vazio*  
   - Entrada: nome = “”, serviço = “Corte”, dataHora = “22/11 às 14:00”, tipo = “confirmação”  
   - Saída esperada: o fluxo ainda gera mensagem, mas isso mostra que depois teremos que validar dados de entrada (ponto fraco do procedural).

---

## 7. Por que essa abordagem não escala

- Cada novo tipo de mensagem (*cancelamento, **promoção, **recuperar cliente faltante) vai obrigar a adicionar **mais um if/switch* no mesmo lugar.
- A lógica de montagem de texto fica *toda concentrada em uma função*, ficando difícil de testar pedacinhos separados.
- Se um dia quisermos ter *variação por canal* (WhatsApp tem emoji, e-mail não), o número de combinações explode.
- O cliente (quem chama essa função) *depende do nome exato do modo* — isso amarra o sistema.

→ É exatamente por isso que, nas próximas fases, a gente vai extrair esse “gerador de mensagem” para classes/contratos e deixar o cliente mais limpo.

---

## 8. Decisões de design da Fase 2
- Mantivemos *um único ponto de decisão* (procedural) para enxergar claramente onde os if/switch nascem.
- Os modos foram nomeados de forma *negócio-first* (confirmação, lembrete, reagendamento) e não técnica.
- Deixamos explícito que essa fase *ainda não tem interface* porque o objetivo é mostrar a dor de ter tudo no mesmo fluxo.

---

## 9. Checklist de qualidade aplicado
- [x] Tem pelo menos 3 modos + 1 padrão.
- [x] Cada modo gera uma saída clara.
- [x] Foram descritos 5 cenários de teste / fronteira.
- [x] Foi explicado por que a solução procedural não escala.
- [ ] Testes automatizados sem I/O (não aplicável nesta fase, só descrição).

---

## 10. Evidências de testes
- Fase com foco em descrição de fluxo.
- Cenários de teste documentados acima.
- Quando houver código, colocar exemplos de execução aqui.
