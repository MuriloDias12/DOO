using System;
using System.Collections.Generic;

public interface IMenuComponent
{
    void Display(string indent = "");
    void Add(IMenuComponent component);
}

public class MenuItem : IMenuComponent
{
    private string _name;
    public MenuItem(string name) { _name = name; }
    public void Display(string indent = "") => Console.WriteLine($"{indent}- {_name}");
    public void Add(IMenuComponent component) => throw new NotSupportedException();
}

public class Menu : IMenuComponent
{
    private string _name;
    private List<IMenuComponent> _items = new List<IMenuComponent>();
    public Menu(string name) { _name = name; }
    public void Display(string indent = "")
    {
        Console.WriteLine($"{indent}{_name}:");
        foreach (var item in _items)
            item.Display(indent + "  ");
    }
    public void Add(IMenuComponent component) => _items.Add(component);
}

public class CompositeDemo
{
    public static void Main()
    {
        var menu = new Menu("Menu Principal");
        var prato1 = new MenuItem("Arroz com Feijão");
        var prato2 = new MenuItem("Bife Acebolado");
        var submenu = new Menu("Pratos Especiais");
        submenu.Add(new MenuItem("Lasanha"));
        submenu.Add(new MenuItem("Feijoada"));
        menu.Add(prato1);
        menu.Add(prato2);
        menu.Add(submenu);
        menu.Display();
    }
}
