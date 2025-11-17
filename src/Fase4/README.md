# 💡 Fase 4 — Interface Plugável e Testável

Nesta fase damos o passo mais importante da migração conceitual do projeto:
sair de um modelo OO rígido (Fase 3) e entrar em um design baseado em contratos, permitindo alternância real entre implementações sem modificar o cliente.

## 🎯 Objetivo da Fase

Definir uma interface clara e coesa para geração de mensagens do AgendaBem e refatorar o código para que o cliente dependa apenas desse contrato, e não de classes concretas.

Isso traz:

_baixo acoplamento

_facilidade de troca de comportamento

_testabilidade (injeção de dependência)

_código mais limpo e fácil de evoluir

## 🔙 O que mudou da Fase 3 para a Fase 4?
Na Fase 3 (OO sem interface):

Criamos uma classe por tipo de mensagem:
MensagemConfirmacao, MensagemLembrete, MensagemReagendamento, etc.

Usamos herança ou estrutura comum, mas o cliente ainda dependia de classes concretas.

A fábrica (MensagemFactory) ainda possuía a responsabilidade de decidir qual classe instanciar, criando um novo acoplamento interno.

### ➡️ Problema: sempre que surge um novo tipo de mensagem, tanto a fábrica quanto o cliente podem precisar mudar.

Agora, na Fase 4 (com interface):

Criamos um contrato único, por exemplo:

public interface IMensagem
{
    string Gerar(string nome, string servico, DateTime dataHora);
}


E então cada tipo de mensagem passa a implementar o contrato:
```
public class MensagemConfirmacao : IMensagem { ... }
public class MensagemLembrete : IMensagem { ... }
public class MensagemReagendamento : IMensagem { ... }
public class MensagemPadrao : IMensagem { ... }
```

A grande mudança:
➡️ O cliente não sabe e não quer saber qual classe concreta está sendo usada.
Ele recebe um IMensagem, e apenas isso importa.

## 🔧 Como alternar implementações sem mudar o cliente

Agora, a decisão de qual mensagem usar é totalmente deslocada para o ponto de composição, que pode ser:

a fábrica

um serviço

um container de DI

ou até uma escolha manual em testes

Isso permite trocar a implementação sem tocar no cliente.

Exemplo:
```
IMensagem msg = politica.Escolher(tipo);
Console.WriteLine(msg.Gerar(nome, servico, dataHora));
```

➡️ Agora somente a política muda quando queremos adicionar novos tipos.
➡️ O cliente continua 100% estável.

## 🧪 Testabilidade (o ganho principal)

Antes, testar era difícil porque:

o cliente instanciava classes concretas

mudanças exigiam alterar código real

não era possível simular mensagens falsas

Agora, com o contrato IMensagem, podemos injetar um dublê:
```
public class MensagemFake : IMensagem
{
    public string UltimaEntrada;
    public string Gerar(string n, string s, DateTime d)
    {
        UltimaEntrada = n;
        return "ok";
    }
}
```

E no teste:
```
var fake = new MensagemFake();
var servico = new AgendaService(fake);
servico.Enviar("João", "Corte", DateTime.Now);

// validar comportamento sem depender de texto real
Assert.Equal("João", fake.UltimaEntrada);
```

💡 Isso mostra o principal valor desta fase: dobrar a dependência em teste por meio da injeção.

## 📌 Benefícios conquistados na Fase 4

Cliente não muda mais ao trocar o tipo de mensagem

Redução de acoplamento e maior reuso

Possibilidade de múltiplas políticas de escolha

Testes unitários sem depender de strings reais

Código preparado para ISP, repositorios e políticas futuras

A partir daqui o projeto já entra em um padrão profissional de extensibilidade.
