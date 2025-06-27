using System;
using System.Collections.Generic;

public class Player
{
    public int Position { get; set; }
    public int Health { get; set; }
    public PlayerMemento SaveState() => new PlayerMemento(Position, Health);
    public void RestoreState(PlayerMemento memento)
    {
        Position = memento.Position;
        Health = memento.Health;
    }
}

public class PlayerMemento
{
    public int Position { get; }
    public int Health { get; }
    public PlayerMemento(int position, int health)
    {
        Position = position;
        Health = health;
    }
}

public class Caretaker
{
    private Stack<PlayerMemento> _history = new();
    public void Save(PlayerMemento memento) => _history.Push(memento);
    public void Restore(Player player)
    {
        if (_history.Count > 0)
            player.RestoreState(_history.Pop());
    }
}

public class MementoDemo
{
    public static void Main()
    {
        var player = new Player { Position = 5, Health = 100 };
        var caretaker = new Caretaker();
        caretaker.Save(player.SaveState());
        player.Position = 10;
        caretaker.Restore(player);
        Console.WriteLine(player.Position);
    }
}
