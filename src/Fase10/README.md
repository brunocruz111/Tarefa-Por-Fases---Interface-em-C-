# Fase 10 — Cheiros e Antídotos (AgendaBem)

Nesta fase, identificamos padrões de projeto problemáticos (Code Smells) que poderiam surgir (ou surgiram) durante a evolução do sistema e aplicamos os devidos antídotos baseados nos princípios SOLID.

---

## 1. Cheiro: Interface Gorda (Fat Interface)
**Princípio Violado:** ISP (Interface Segregation Principle).

**Contexto:**
Na Fase 7, tínhamos um único `IRepository` que obrigava qualquer consumidor a conhecer métodos de escrita (`Add`, `Remove`), mesmo que só precisasse ler dados (ex: Relatórios).

**Antes (Problemático):**
```
public interface IRepository<T>
{
    void Add(T entity);      // Escrita
    void Remove(int id);     // Escrita
    List<T> ListAll();       // Leitura
    T GetById(int id);       // Leitura
}
// Um serviço de Relatório era obrigado a depender de Add/Remove.
```
Depois (Antídoto Aplicado): Segregamos em capacidades específicas.
```
public interface IReadRepository<T> { List<T> ListAll(); }
public interface IWriteRepository<T> { void Add(T entity); }

// O serviço de relatório agora depende apenas de IReadRepository.
```
---
## 2. Cheiro: Dependência Oculta / Acoplamento Concreto

Princípio Violado: DIP (Dependency Inversion Principle).

Contexto: Seria comum instanciar dependências diretamente dentro dos Casos de Uso (Services), tornando o código difícil de testar e rígido.

Antes (Problemático):
```
public class ConfirmationService
{
    public void Execute(Appointment app)
    {
        // Acoplamento direto com a implementação concreta (WhatsApp)
        var notifier = new WhatsAppNotifier(); 
        notifier.Send(app);
    }
}
```
Depois (Antídoto Aplicado): Injeção de Dependência via Construtor.
```
public class ConfirmationService
{
    private readonly INotifier _notifier;

    // Recebe qualquer implementação (WhatsApp, Email, Mock)
    public ConfirmationService(INotifier notifier)
    {
        _notifier = notifier;
    }
}
```
---

## 3. Cheiro: Testes Frágeis com I/O Real (Slow Tests)
Princípio Violado: Testability / Seams.

Contexto: Na Fase 9, para testar a retentativa (retry), poderíamos ter usado Thread.Sleep, o que tornaria os testes lentos e não determinísticos.

Antes (Problemático):
```
public async Task Retry()
{
    // Trava a thread de verdade. O teste demora segundos para rodar.
    await Task.Delay(2000); 
    TryAgain();
}
```
Depois (Antídoto Aplicado): Criamos uma "Costura" (Seam) com a abstração IClock.
```
// No código:
await _clock.Delay(TimeSpan.FromSeconds(2));

// No Teste (FakeClock):
// Apenas avança o tempo simulado, execução imediata.
```
---

## 4. Cheiro: Obsessão por Primitivos (Primitive Obsession)
Princípio Violado: Encapsulation / Information Expert.

Contexto: A lógica de formatação de data (Brasileira) estava sendo repetida em vários Console.WriteLine espalhados pelo código.

Antes (Problemático):
```
// Repetido em todo lugar
Console.WriteLine(date.ToString("dd/MM 'às' HH:mm", new CultureInfo("pt-BR")));
```
Depois (Antídoto Aplicado): Movemos a lógica para o especialista na informação (o Domínio).
```
// No Domain/Appointment.cs
public string FormatToPtBr() => Date.ToString("...", ...);

// No uso:
Console.WriteLine(app.FormatToPtBr());
```
---

## 5. Cheiro: Números Mágicos / Lista de Parâmetros (Magic Numbers)
Princípio Violado: OCP (Open/Closed) e Expressividade.

Contexto: O ResilientImporter tinha o número de tentativas e o tempo de espera "chumbados" no código. Para alterar, precisávamos modificar a classe e recompilar (violação do OCP).

Antes (Problemático):

```
public async Task ImportAsync(...)
{
    int maxRetries = 3; // Número mágico
    // ... lógica ...
}
```
Depois (Antídoto Aplicado - Fase 10): Introduzimos um Policy Object.
```
public record ImportPolicy(int MaxRetries, TimeSpan InitialDelay);

// A classe recebe a política e não precisa mudar se a configuração mudar.
public ResilientImporter(..., ImportPolicy policy) { ... }
```
