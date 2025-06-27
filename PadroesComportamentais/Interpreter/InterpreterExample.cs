using System;

public interface IExpression
{
    int Interpret();
}

public class NumberExpression : IExpression
{
    private int _number;
    public NumberExpression(int number) { _number = number; }
    public int Interpret() => _number;
}

public class AddExpression : IExpression
{
    private IExpression _left, _right;
    public AddExpression(IExpression left, IExpression right)
    {
        _left = left;
        _right = right;
    }
    public int Interpret() => _left.Interpret() + _right.Interpret();
}

public class SubtractExpression : IExpression
{
    private IExpression _left, _right;
    public SubtractExpression(IExpression left, IExpression right)
    {
        _left = left;
        _right = right;
    }
    public int Interpret() => _left.Interpret() - _right.Interpret();
}

public class InterpreterDemo
{
    public static void Main()
    {
        var expression = new AddExpression(
            new NumberExpression(5),
            new SubtractExpression(new NumberExpression(10), new NumberExpression(3))
        );
        Console.WriteLine(expression.Interpret());
    }
}
