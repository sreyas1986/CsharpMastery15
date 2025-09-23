// CustomExceptions.cs
// Custom exception examples
// CustomExceptions.cs
// Custom exception examples for BFSI-grade systems

using System;

namespace Banking.Exceptions
{
    // Thrown when a transaction amount is invalid
    public class InvalidTransactionAmountException : Exception
    {
        public InvalidTransactionAmountException(decimal amount)
            : base($"Transaction amount ₹{amount} is invalid.") { }
    }


    // Thrown when a user tries to access a restricted module
    public class UnauthorizedAccessException : Exception
    {
        public UnauthorizedAccessException(string module)
            : base($"Access denied to module: {module}") { }
    }

    // Thrown when compliance rules are violated
    public class ComplianceViolationException : Exception
    {
        public ComplianceViolationException(string rule)
            : base($"Compliance violation detected: {rule}") { }
    }

    // Thrown when an employee record is not found
    public class EmployeeNotFoundException : Exception
    {
        public EmployeeNotFoundException(int employeeId)
            : base($"Employee with ID {employeeId} not found.") { }
    }
}
/*
Global Exception Handling (Web API)
app.UseExceptionHandler(errorApp =>
{
    errorApp.Run(async context =>
    {
        var exception = context.Features.Get<IExceptionHandlerFeature>()?.Error;

        if (exception is EmployeeNotFoundException)
        {
            context.Response.StatusCode = 404;
            await context.Response.WriteAsync(exception.Message);
        }
        else if (exception is InvalidTransactionAmountException)
        {
            context.Response.StatusCode = 400;
            await context.Response.WriteAsync(exception.Message);
        }
        // Add more cases as needed
    });
});*/