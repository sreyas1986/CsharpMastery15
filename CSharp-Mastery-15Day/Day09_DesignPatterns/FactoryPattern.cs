// FactoryPattern.cs
// Factory Design Pattern Example for BFSI-grade transaction processors

using System;

// Product Interface
public interface ITransactionProcessor
{
    void Process(decimal amount);
}

// Concrete Products
public class UPIProcessor2 : ITransactionProcessor
{
    public void Process(decimal amount)
    {
        Console.WriteLine($"Processing ₹{amount} via UPI.");
    }
}

public class NEFTProcessor2 : ITransactionProcessor
{
    public void Process(decimal amount)
    {
        Console.WriteLine($"Processing ₹{amount} via NEFT.");
    }
}

public class RTGSProcessor : ITransactionProcessor
{
    public void Process(decimal amount)
    {
        Console.WriteLine($"Processing ₹{amount} via RTGS.");
    }
}

// Factory Class
public static class TransactionProcessorFactory
{
    public static ITransactionProcessor GetProcessor(string type)
    {
        return type switch
        {
            "UPI" => new UPIProcessor2(),
            "NEFT" => new NEFTProcessor2(),
            "RTGS" => new RTGSProcessor(),
            _ => throw new ArgumentException("Invalid transaction type")
        };
    }
}

// Client Code
public class TransactionService
{
    public void Execute(string txnType, decimal amount)
    {
        var processor = TransactionProcessorFactory.GetProcessor(txnType);
        processor.Process(amount);
    }
}