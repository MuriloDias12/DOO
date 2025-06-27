using System;

// Interface de cor
public interface IColor
{
    void ApplyColor();
}

public class RedColor : IColor
{
    public void ApplyColor() => Console.WriteLine("Cor: Vermelho");
}
public class BlueColor : IColor
{
    public void ApplyColor() => Console.WriteLine("Cor: Azul");
}

// Abstração
public abstract class Shape
{
    protected IColor color;
    public Shape(IColor color) { this.color = color; }
    public abstract void Draw();
}

public class Circle : Shape
{
    public Circle(IColor color) : base(color) { }
    public override void Draw()
    {
        Console.Write("Desenhando Círculo - ");
        color.ApplyColor();
    }
}
public class Square : Shape
{
    public Square(IColor color) : base(color) { }
    public override void Draw()
    {
        Console.Write("Desenhando Quadrado - ");
        color.ApplyColor();
    }
}

// Demonstração
public class BridgeDemo
{
    public static void Main()
    {
        Shape[] shapes = new Shape[]
        {
            new Circle(new RedColor()),
            new Square(new BlueColor()),
            new Circle(new BlueColor()),
            new Square(new RedColor())
        };
        foreach (var shape in shapes)
            shape.Draw();
    }
}
