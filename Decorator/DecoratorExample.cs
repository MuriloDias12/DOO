using System;

public interface INotification
{
    void Send(string message);
}

public class BaseNotification : INotification
{
    public void Send(string message) => Console.WriteLine($"Mensagem base: {message}");
}

public abstract class NotificationDecorator : INotification
{
    protected INotification wrappee;
    public NotificationDecorator(INotification notification) { wrappee = notification; }
    public virtual void Send(string message) => wrappee.Send(message);
}

public class EmailDecorator : NotificationDecorator
{
    public EmailDecorator(INotification notification) : base(notification) { }
    public override void Send(string message)
    {
        base.Send(message);
        Console.WriteLine($"Enviando Email: {message}");
    }
}
public class SMSDecorator : NotificationDecorator
{
    public SMSDecorator(INotification notification) : base(notification) { }
    public override void Send(string message)
    {
        base.Send(message);
        Console.WriteLine($"Enviando SMS: {message}");
    }
}
public class PushDecorator : NotificationDecorator
{
    public PushDecorator(INotification notification) : base(notification) { }
    public override void Send(string message)
    {
        base.Send(message);
        Console.WriteLine($"Enviando Push: {message}");
    }
}

public class DecoratorDemo
{
    public static void Main()
    {
        INotification notification = new EmailDecorator(
            new SMSDecorator(
                new PushDecorator(
                    new BaseNotification()
                )
            )
        );
        notification.Send("Olá, usuário!");
    }
}
