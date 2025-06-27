using System;
using System.Collections.Generic;

public interface IMediator
{
    void SendMessage(string message, User user);
}

public class ChatMediator : IMediator
{
    private List<User> _users = new();
    public void Register(User user) => _users.Add(user);
    public void SendMessage(string message, User user)
    {
        foreach (var u in _users)
        {
            if (u != user)
                u.Receive(message, user.Name);
        }
    }
}

public class User
{
    public string Name { get; }
    private IMediator _mediator;
    public User(string name, IMediator mediator)
    {
        Name = name;
        _mediator = mediator;
        if (mediator is ChatMediator chat)
            chat.Register(this);
    }
    public void SendMessage(string message) => _mediator.SendMessage(message, this);
    public void Receive(string message, string from)
        => Console.WriteLine($"{from} to {Name}: {message}");
}

public class MediatorDemo
{
    public static void Main()
    {
        var mediator = new ChatMediator();
        var user1 = new User("Alice", mediator);
        var user2 = new User("Bob", mediator);
        user1.SendMessage("Hello, Bob!");
        user2.SendMessage("Hi, Alice!");
    }
}
