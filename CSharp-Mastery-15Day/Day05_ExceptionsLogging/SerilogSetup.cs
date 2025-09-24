// SerilogSetup.cs
// Serilog logging setup
/*
basic console logging works, and for small apps or quick debugging, it's often enough. 
But when you're building enterprise-grade systems (especially BFSI), 
Serilog offers serious advantages that go far beyond Console.WriteLine or ILogger<T> alone.
Structured Logging :- Key-value pairs, JSON, searchable
Multiple Sinks :-  File, SQL, Seq, Elasticsearch, Azure, etc.

*/
using Serilog;
using Serilog.Events;

public static class SerilogSetup
{
    public static void ConfigureLogger()
    {
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Information()
            .Enrich.FromLogContext()
            .Enrich.WithProperty("Application", "BFSI-KYC-Portal")
            .WriteTo.Console()
            .WriteTo.File("Logs/kyc_log.txt", rollingInterval: RollingInterval.Day)
            .WriteTo.MSSqlServer(
                connectionString: "Server=.;Database=AuditLogs;Trusted_Connection=True;",
                sinkOptions: new Serilog.Sinks.MSSqlServer.MSSqlServerSinkOptions
                {
                    TableName = "KYCLog",
                    AutoCreateSqlTable = true
                })
            .CreateLogger();
    }
}

/*
How to Use It in Program.cs
SerilogSetup.ConfigureLogger();

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog();

var app = builder.Build();
// app.UseSerilogRequestLogging(); // Optional middleware

*/