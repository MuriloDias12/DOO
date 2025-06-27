using System;
using System.Collections.Generic;

public class TreeType
{
    public string Name { get; }
    public string Color { get; }
    public string Texture { get; }
    public TreeType(string name, string color, string texture)
    {
        Name = name; Color = color; Texture = texture;
    }
    public void Draw(int x, int y)
    {
        Console.WriteLine($"Desenhando {Name} na cor {Color} e textura {Texture} na posição ({x},{y})");
    }
}

public class TreeFactory
{
    private static Dictionary<string, TreeType> _types = new();
    public static TreeType GetTreeType(string name, string color, string texture)
    {
        string key = name + color + texture;
        if (!_types.ContainsKey(key))
            _types[key] = new TreeType(name, color, texture);
        return _types[key];
    }
}

public class Tree
{
    private int x, y;
    private TreeType type;
    public Tree(int x, int y, TreeType type)
    {
        this.x = x; this.y = y; this.type = type;
    }
    public void Draw() => type.Draw(x, y);
}

public class FlyweightDemo
{
    public static void Main()
    {
        var trees = new List<Tree>();
        var pineType = TreeFactory.GetTreeType("Pine", "Green", "Rough");
        var oakType = TreeFactory.GetTreeType("Oak", "DarkGreen", "Smooth");
        trees.Add(new Tree(1, 2, pineType));
        trees.Add(new Tree(3, 4, pineType));
        trees.Add(new Tree(5, 6, oakType));
        trees.Add(new Tree(7, 8, oakType));
        foreach (var tree in trees)
            tree.Draw();
    }
}
