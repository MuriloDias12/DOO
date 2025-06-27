using System;

public interface IState
{
    void Handle(VendingMachine context);
}

public class NoCoinState : IState
{
    public void Handle(VendingMachine context)
    {
        Console.WriteLine("Coin inserted.");
        context.SetState(new HasCoinState());
    }
}
public class HasCoinState : IState
{
    public void Handle(VendingMachine context)
    {
        Console.WriteLine("Product selected.");
        context.SetState(new SoldState());
    }
}
public class SoldState : IState
{
    public void Handle(VendingMachine context)
    {
        Console.WriteLine("Product dispensed.");
        context.SetState(new NoCoinState());
    }
}

public class VendingMachine
{
    private IState _state = new NoCoinState();
    public void SetState(IState state) => _state = state;
    public void InsertCoin() => _state.Handle(this);
    public void SelectProduct() => _state.Handle(this);
    public void DispenseProduct() => _state.Handle(this);
}

public class StateDemo
{
    public static void Main()
    {
        var vendingMachine = new VendingMachine();
        vendingMachine.InsertCoin();
        vendingMachine.SelectProduct();
        vendingMachine.DispenseProduct();
    }
}
