// SwitchExpressions.cs
// Demo for C# switch expressions
using System;
public class  Program2
{
public static void Main2()
{

    string transactionType="IMPS";
    string processingStrategy = transactionType  switch
    {

        "NEFT" => "Batch based Settlement",
         "IMPS" => "Real time Processing",
         _ => "Unknown Type"
    };
    Console.WriteLine($"Transaction type :{transactionType}");
    Console.WriteLine($"processingStrategy:{processingStrategy}");

}

}