using System;
using Microsoft.Extensions.DependencyInjection;

namespace PaymentProcessingOCP
{
    // Interface for payment methods
    public interface IPaymentMethod
    {
        void ProcessPayment();
    }

    // Concrete implementations
    public class CreditCard : IPaymentMethod
    {
        public void ProcessPayment()
        {
            Console.WriteLine("Paid through Credit Card");
        }
    }

    public class UPI : IPaymentMethod
    {
        public void ProcessPayment()
        {
            Console.WriteLine("Paid through UPI");
        }
    }

    // Factory interface
    public interface IPaymentFactory
    {
        IPaymentMethod GetPaymentMethod(string methodName);
    }

    // Factory implementation
    public class PaymentFactory : IPaymentFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public PaymentFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IPaymentMethod GetPaymentMethod(string methodName)
        {
            return methodName switch
            {
                "CreditCard" => _serviceProvider.GetRequiredService<CreditCard>(),
                "UPI" => _serviceProvider.GetRequiredService<UPI>(),
                _ => throw new Exception("Invalid payment method")
            };
        }
    }

    // Payment processor
    public class PaymentProcessor
    {
        private readonly IPaymentMethod _paymentMethod;

        public PaymentProcessor(IPaymentMethod paymentMethod)
        {
            _paymentMethod = paymentMethod;
        }

        public void ExecutePayment()
        {
            _paymentMethod.ProcessPayment();
        }
    }

    // Program entry point
    class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection();

            // Register concrete types
            services.AddTransient<CreditCard>();
            services.AddTransient<UPI>();
            services.AddSingleton<IPaymentFactory, PaymentFactory>();

            var serviceProvider = services.BuildServiceProvider();

            // Simulate user choice
            string userChoice = "UPI";

            var factory = serviceProvider.GetRequiredService<IPaymentFactory>();
            var method = factory.GetPaymentMethod(userChoice);

            var processor = new PaymentProcessor(method);
            processor.ExecutePayment();
        }
    }
}