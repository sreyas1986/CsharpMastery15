// RecordsDemo.cs
// Demo for C# record types
using System;
public class Program{
public static void Main()
{


    var transaction1 = new Transaction(1, 100.0m, DateTime.Now);
    var transaction2 = new Transaction(1, 100.0m, DateTime.Now);

    // Value-based equality
    Console.WriteLine(transaction1 == transaction2); // True

    // Immutability
    // transaction1.Amount = 200.0m; // Compile-time error

    // With-expressions
    var transaction3 = transaction1 with { Amount = 200.0m };
    Console.WriteLine(transaction3); // Transaction { Id = 1, Amount = 200.0, Date = ... }
}
}
public record Transaction(int Id, decimal Amount, DateTime Date);