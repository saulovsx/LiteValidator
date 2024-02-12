# LiteValidator

### Sobre o Projeto
LiteValidator pode ser utilizado como uma biblioteca de validação C# leve e flexível, desenvolvida com foco na simplicidade e eficiência. Inspirada em padrões de design como Builder, Strategy e Chain of Responsibility, esta classe oferece uma abordagem intuitiva e fluente para construir e executar validações de regras de negócio.

### Características
- Fluente e Intuitivo: Fácil de usar com uma API fluente.
- Flexível: Suporta validações simples e complexas.
- Reutilizável: Ideal para usar em vários contextos dentro do seu projeto.
- Padrões de Design: Incorpora ideias dos padrões Builder, Strategy e Chain of Responsibility.

### Exemplo Básico
```csharp
var yourObject = new YourObject();

var validator = new LiteValidator<YourObject>()
    .AddRule(obj => obj.Property1 > 0)
    .AddError("Property1 must be greater than zero.")
    .Validate(yourObject);

if (!validator.IsValid)
{
    foreach (var message in validator.Messages)
    {
        Console.WriteLine(message);
    }
}
```

### Contribuições
Contribuições são bem-vindas! Se você tiver sugestões ou melhorias, sinta-se à vontade para criar uma issue ou um pull request.
