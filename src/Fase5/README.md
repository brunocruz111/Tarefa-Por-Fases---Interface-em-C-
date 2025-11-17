# ✨ Fase 5 — Essenciais de Interfaces em C#

A Fase 5 aprofunda o uso de interfaces no domínio, indo além da simples alternância de implementações.
Enquanto a Fase 4 estabeleceu o contrato IMensagem e a composição plugável, agora o objetivo é:

Criar duas interfaces diferentes dentro do domínio

Implementar mais de uma interface em uma mesma classe

Explicar quando usar implementação explícita de interface

Explicar quando generics com constraints ajudam

Entender por que default interface members devem ser evitados na maioria dos designs

Essa fase é conceitual, mas com código para ilustrar boas práticas.

## 🔙 O que mudou da Fase 4 para a Fase 5

### ✔️ Na Fase 4:

Tínhamos um único contrato (IMensagem)

Uma fábrica (resolver) selecionava a implementação correta

O cliente não conhecia mais classes concretas

A injeção de dependência viabilizava dublês para testes

As classes estavam separadas adequadamente em Domain/Interfaces/Services

Foco: tornamos o sistema plugável e testável.

###✔️ Na Fase 5:

Agora o sistema evolui para um nível maior de maturidade de design, onde entendemos que uma classe pode possuir múltiplas capacidades, e cada capacidade deve ser expressa como uma interface clara.

Nesta fase vamos:

### ✔️ 1. Criar duas interfaces do domínio

Por exemplo:

IMessageGenerator → responsável por gerar mensagens

IMessageFormatter → responsável por formatar detalhes ou ajustar texto

Isso mostra que uma mesma classe pode assumir diferentes papéis.

### ✔️ 2. Criar uma classe que implementa ambas as interfaces

Por exemplo:

public class ConfirmationMessage : IMessageGenerator, IMessageFormatter


Isso demonstra o uso do múltiplo contrato em C# para reforçar capacidades distintas.

### ✔️ 3. Explicar quando usar implementação explícita de interface

A implementação explícita é útil quando:

Duas interfaces possuem métodos com nomes iguais

Você não quer expor o método diretamente no objeto público

Deseja separar "papéis" sem misturar métodos

Exemplo típico:

string IMessageFormatter.Format(...)


Isso impede que o método apareça como parte da API pública, sendo acessível apenas via cast para a interface.

### ✔️ **4. Demonstrar o uso de generics com constraints

Exemplo:

public class MessageService<T> where T : IMessageGenerator


Uso recomendado quando:

Você quer garantir em tempo de compilação que apenas classes válidas (que implementam certo contrato) podem ser usadas

Evita erros de composição

Ajuda a criar serviços mais reutilizáveis e seguros

### ✔️ 5. Explicar por que evitar default interface members

Apesar de possível no C# moderno, eles:

Podem esconder lógica dentro da interface

Criam ambiguidade ao substituir implementações

Reduzem clareza do contrato

Tornam testes menos previsíveis

Aproximam a interface de uma “classe abstrata ruim”

Por isso, seguimos o princípio:
👉 Interfaces devem declarar o que fazer — não como fazer.

## 🎯 Resultado final da Fase 5

Ao final desta fase você terá:

_Um domínio mais rico e organizado

_Interfaces que representam capacidades reais

_Uma classe que demonstra múltiplos papéis de forma controlada

_Uso adequado de explicit interface implementation

_Uso de generics com constraints aplicado ao caso

Código mais limpo, expressivo e pronto para evoluções futuras (ISP, repositórios etc.)
