# Calculadora com Fábrica e Reflection

Este exemplo demonstra o uso do padrão Factory Method combinado com Reflection para criar operações matemáticas dinamicamente.

## Como funciona
- O usuário informa o nome da operação (Add, Subtract, Multiply, Divide).
- A fábrica usa Reflection para instanciar a operação correspondente.
- O resultado é exibido no console.

## Como executar
1. Compile o projeto:
   ```
   dotnet build
   ```
2. Execute:
   ```
   dotnet run --project PadroesCriacionais/FactoryReflectionCalculator/FactoryReflectionCalculator.csproj
   ```
