// SOLIDExamples.cs
// Demonstrates SOLID principles in a BFSI-style .NET Core application

using System;
using System.Collections.Generic;

// S — Single Responsibility Principle
public class CustomerOnboardingService
{
    private readonly ICustomerRepository _repository;
    public CustomerOnboardingService(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public void Onboard(Customer customer)
    {
        _repository.Save(customer);
        Console.WriteLine("Customer onboarded.");
    }
}

public interface ICustomerRepository
{
    void Save(Customer customer);
}

public class SqlCustomerRepository : ICustomerRepository
{
    public void Save(Customer customer)
    {
        // Save to SQL DB
    }
}

// O — Open/Closed Principle
public abstract class TransactionProcessor
{
    public abstract void Process(Transaction txn);
}

public class UPIProcessor : TransactionProcessor
{
    public override void Process(Transaction txn)
    {
        Console.WriteLine("Processing UPI transaction.");
    }
}

public class NEFTProcessor : TransactionProcessor
{
    public override void Process(Transaction txn)
    {
        Console.WriteLine("Processing NEFT transaction.");
    }
}

// L — Liskov Substitution Principle
public class TransactionSBanking
{
    public decimal Amount { get; set; }
}

public class SecureTransaction : TransactionSBanking
{
    public string OTP { get; set; }
}

// I — Interface Segregation Principle
public interface IAuditLogger
{
    void LogAction(string action);
}

public interface IErrorLogger
{
    void LogError(string error);
}

public class FileLogger : IAuditLogger, IErrorLogger
{
    public void LogAction(string action)
    {
        Console.WriteLine($"Audit: {action}");
    }

    public void LogError(string error)
    {
        Console.WriteLine($"Error: {error}");
    }
}

// D — Dependency Inversion Principle
public interface INotificationService
{
    void Notify(string message);
}

public class EmailNotification : INotificationService
{
    public void Notify(string message)
    {
        Console.WriteLine($"Email sent: {message}");
    }
}

public class AlertManager
{
    private readonly INotificationService _notifier;
    public AlertManager(INotificationService notifier)
    {
        _notifier = notifier;
    }

    public void RaiseAlert(string msg)
    {
        _notifier.Notify(msg);
    }
}
public class Customer
{
    public string Name { get; set; }
    public string Email { get; set; }
}