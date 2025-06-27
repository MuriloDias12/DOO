using System;

public interface IShippingStrategy
{
    double Calculate(double value);
}

public class EconomyShipping : IShippingStrategy
{
    public double Calculate(double value) => 10;
}
public class ExpressShipping : IShippingStrategy
{
    public double Calculate(double value) => 25;
}

public class ShippingCalculator
{
    private IShippingStrategy _strategy;
    public ShippingCalculator(IShippingStrategy strategy) { _strategy = strategy; }
    public void SetStrategy(IShippingStrategy strategy) => _strategy = strategy;
    public double Calculate(double value) => _strategy.Calculate(value);
}

public class StrategyDemo
{
    public static void Main()
    {
        var calculator = new ShippingCalculator(new EconomyShipping());
        Console.WriteLine(calculator.Calculate(100));
        calculator.SetStrategy(new ExpressShipping());
        Console.WriteLine(calculator.Calculate(100));
    }
}
