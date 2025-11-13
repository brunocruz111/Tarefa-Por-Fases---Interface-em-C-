# 💈 Fase 3 — OO sem interface (AgendaBem)

## Enunciado (resumo)
Transformar a solução anterior em uma *hierarquia OO sem usar interface* (C#), com *base comum* e *variações concretas. Substituir decisões por **polimorfismo* (override). Descrever o que *melhorou* e o que *permanece rígido*.

## Objetivo (1–2 linhas)
Gerar o texto da mensagem de agendamento usando *classe base* (MensagemAgendamento) e *subclasses* que encapsulam as variações: confirmação, lembrete, reagendamento e padrão.

## Base comum + variações
- *Base:* MensagemAgendamento (dados: nome, serviço, data/hora; Gerar() chama MontarTexto()).
- *Concretas:* MensagemConfirmacao, MensagemLembrete, MensagemReagendamento, MensagemPadrao (cada uma implementa MontarTexto()).

## Fluxo com polimorfismo
1) Cliente chama uma *fábrica* (MensagemFactory.Criar(tipo, ...))  
2) Recebe uma instância de MensagemAgendamento (subtipo correto)  
3) Chama Gerar() e obtém o texto — *sem if/switch no cliente*.

## Melhorou
- *Coesão*: cada variação tem sua própria classe (texto isolado).  
- *Testabilidade*: testar cada classe concreta de forma independente.  
- *Leitura*: cliente não conhece o “como” — só usa Gerar().

## Continua rígido (sem interface)
- A *fábrica ainda conhece concretos* (há um switch centralizado).  
- *Adicionar nova variação* exige tocar a fábrica.  
- Entrada por *string* (“tipo”) é frágil a typos.  
- Falta *injeção de dependência* (vai melhorar na próxima fase).

## Checklist aplicado
- [x] Base comum + variações concretas  
- [x] Cliente sem if/switch (polimorfismo)  
- [x] O que melhorou vs. o que ficou rígido  
- [x] Código simples, legível e coerente com a Fase 2

## Evidências
- Executar Program.cs para ver as 5 mensagens (mesmos cenários da Fase 2).
