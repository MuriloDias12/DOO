using System;

public interface IVisitor
{
    void Visit(ElementA element);
    void Visit(ElementB element);
}

public class ValidationVisitor : IVisitor
{
    public void Visit(ElementA element) => Console.WriteLine("Validating ElementA...");
    public void Visit(ElementB element) => Console.WriteLine("Validating ElementB...");
}

public interface IElement
{
    void Accept(IVisitor visitor);
}

public class ElementA : IElement
{
    public void Accept(IVisitor visitor) => visitor.Visit(this);
}
public class ElementB : IElement
{
    public void Accept(IVisitor visitor) => visitor.Visit(this);
}

public class VisitorDemo
{
    public static void Main()
    {
        var visitor = new ValidationVisitor();
        var elementA = new ElementA();
        elementA.Accept(visitor);
    }
}
