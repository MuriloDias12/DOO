using System;
using System.Reflection;

// Interface para operações
public interface IOperation
{
    double Execute(double a, double b);
}

// Operações concretas
public class Add : IOperation
{
    public double Execute(double a, double b) => a + b;
}
public class Subtract : IOperation
{
    public double Execute(double a, double b) => a - b;
}
public class Multiply : IOperation
{
    public double Execute(double a, double b) => a * b;
}
public class Divide : IOperation
{
    public double Execute(double a, double b) => b != 0 ? a / b : throw new DivideByZeroException();
}

// Fábrica usando Reflection
public static class OperationFactory
{
    public static IOperation Create(string operationName)
    {
        var type = Type.GetType(operationName, false, true);
        if (type == null)
        {
            // Tenta buscar pelo nome simples
            type = Assembly.GetExecutingAssembly().GetType(operationName, false, true);
        }
        if (type == null)
        {
            // Tenta buscar pelo namespace atual
            string ns = typeof(OperationFactory).Namespace;
            type = Assembly.GetExecutingAssembly().GetType($"{ns}.{operationName}", false, true);
        }
        if (type == null || !typeof(IOperation).IsAssignableFrom(type))
            throw new ArgumentException($"Operação '{operationName}' não encontrada.");
        return (IOperation)Activator.CreateInstance(type)!;
    }
}

// Programa principal
public class FactoryReflectionCalculatorDemo
{
    public static void Main()
    {
        Console.WriteLine("Calculadora com Fábrica e Reflection");
        Console.WriteLine("Operações disponíveis: Add, Subtract, Multiply, Divide");
        Console.Write("Digite a operação: ");
        string op = Console.ReadLine();
        Console.Write("Digite o primeiro número: ");
        double a = double.Parse(Console.ReadLine());
        Console.Write("Digite o segundo número: ");
        double b = double.Parse(Console.ReadLine());
        try
        {
            var operation = OperationFactory.Create(op);
            double result = operation.Execute(a, b);
            Console.WriteLine($"Resultado: {result}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }
    }
}
