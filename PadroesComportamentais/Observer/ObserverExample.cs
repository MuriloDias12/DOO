using System;
using System.Collections.Generic;

public interface IObserver
{
    void Update(string status);
}

public class EmailNotifier : IObserver
{
    public void Update(string status) => Console.WriteLine($"Email: Your order is now {status}.");
}
public class SmsNotifier : IObserver
{
    public void Update(string status) => Console.WriteLine($"SMS: Your order is now {status}.");
}

public class Order
{
    private List<IObserver> _observers = new();
    public void Attach(IObserver observer) => _observers.Add(observer);
    public void Detach(IObserver observer) => _observers.Remove(observer);
    public void UpdateStatus(string status)
    {
        foreach (var obs in _observers)
            obs.Update(status);
    }
}

public class ObserverDemo
{
    public static void Main()
    {
        var order = new Order();
        order.Attach(new EmailNotifier());
        order.Attach(new SmsNotifier());
        order.UpdateStatus("Shipped");
    }
}
