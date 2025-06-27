using System;

public abstract class DocumentHandler
{
    protected DocumentHandler next;
    public DocumentHandler SetNext(DocumentHandler handler)
    {
        next = handler;
        return handler;
    }
    public virtual void Handle(string docType)
    {
        if (next != null)
            next.Handle(docType);
        else
            Console.WriteLine($"Cannot process {docType}.");
    }
}

public class InvoiceHandler : DocumentHandler
{
    public override void Handle(string docType)
    {
        if (docType == "Invoice")
            Console.WriteLine("Processing Invoice...");
        else
            base.Handle(docType);
    }
}
public class ReceiptHandler : DocumentHandler
{
    public override void Handle(string docType)
    {
        if (docType == "Receipt")
            Console.WriteLine("Processing Receipt...");
        else
            base.Handle(docType);
    }
}
public class BillHandler : DocumentHandler
{
    public override void Handle(string docType)
    {
        if (docType == "Bill")
            Console.WriteLine("Processing Bill...");
        else
            base.Handle(docType);
    }
}

public class ChainOfResponsibilityDemo
{
    public static void Main()
    {
        var handler = new InvoiceHandler();
        handler.SetNext(new ReceiptHandler()).SetNext(new BillHandler());
        handler.Handle("Invoice");
        handler.Handle("Unknown");
    }
}
