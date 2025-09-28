// KeyedDIExample.cs
// Keyed Dependency Injection example
// KeyedDIExample.cs
// Keyed Dependency Injection example for BFSI-grade alert routing

using Microsoft.Extensions.DependencyInjection;
using System;
namespace KeyedDIExample {
    public interface INotificationService
    {
        void Notify(string message);
    }

    public class EmailNotification : INotificationService
    {
        public void Notify(string message)
        {
            Console.WriteLine($"📧 Email: {message}");
        }
    }

    public class SmsNotification : INotificationService
    {
        public void Notify(string message)
        {
            Console.WriteLine($"📱 SMS: {message}");
        }
    }

    public class PushNotification : INotificationService
    {
        public void Notify(string message)
        {
            Console.WriteLine($"🔔 Push: {message}");
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
class Program
{
        public static void Main()
        { 
            var services = new ServiceCollection();

// Register keyed services
services.AddKeyedSingleton<INotificationService, EmailNotification>("email");
services.AddKeyedSingleton<INotificationService, SmsNotification>("sms");
services.AddKeyedSingleton<INotificationService, PushNotification>("push");

var provider = services.BuildServiceProvider();

    // Resolve by key
    var emailNotifier = provider.GetRequiredKeyedService<INotificationService>("email");
    var smsNotifier = provider.GetRequiredKeyedService<INotificationService>("sms");

    var alert1 = new AlertManager(emailNotifier);
    alert1.RaiseAlert("Transaction ₹10L approved.");

var alert2 = new AlertManager(smsNotifier);
    alert2.RaiseAlert("OTP: 123456");
        }
    }
// Program.cs or DI Setup

}