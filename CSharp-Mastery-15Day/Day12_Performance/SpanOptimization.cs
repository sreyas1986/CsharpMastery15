// SpanOptimization.cs
// Performance optimization using Span<T>
using System;
public class SpanOptimization
{
    public void ProcessSpanData()
    {
        int[] numbers = { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 };
        // Using Span<T> for efficient memory access
        Span<int> spanInt = numbers.AsSpan();
        for (int i = 0; i < spanInt.Length; i++)
        {
            spanInt[i] += 5; // Simple operation
        }
        Console.WriteLine("Processed Numbers: " + string.Join(", ", spanInt.ToArray()));

    }
    /*** Span Different ways to initialize ***/
    public void DifferentWaysToInitializeSpan()
    {
        // From array
        int[] arr = { 1, 2, 3, 4, 5 };
        Span<int> spanFromArray = arr.AsSpan();

        // From stackalloc
        Span<int> spanFromStack = stackalloc int[5] { 10, 20, 30, 40, 50 };

        // From string
        ReadOnlySpan<char> spanFromString = "Hello, Span!".AsSpan();

        //From a slice of an array
        int[] slicearr = { 100, 200, 300, 400, 500 };
        Span<int> slice = slicearr.AsSpan(1, 3); // [200, 300, 400]

        Console.WriteLine("Span from Array: " + string.Join(", ", spanFromArray.ToArray()));
        Console.WriteLine("Span from StackAlloc: " + string.Join(", ", spanFromStack.ToArray()));
        Console.WriteLine("Span from String: " + spanFromString.ToString());
    }
}