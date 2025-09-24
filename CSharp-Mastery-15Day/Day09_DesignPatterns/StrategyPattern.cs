// StrategyPattern.cs
// Strategy design pattern example for BFSI-grade payment processing

using System;

namespace BFSI.StrategyPattern
{
    // Strategy Interface
    public interface IPaymentStrategy
    {
        void ProcessPayment(decimal amount);
    }

    // Concrete Strategy: UPI
    public class UPIPayment : IPaymentStrategy
    {
        public void ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Processing ₹{amount} via UPI.");
        }
    }

    // Concrete Strategy: NetBanking
    public class NetBankingPayment : IPaymentStrategy
    {
        public void ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Processing ₹{amount} via NetBanking.");
        }
    }

    // Concrete Strategy: Card
    public class CardPayment : IPaymentStrategy
    {
        public void ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Processing ₹{amount} via Card.");
        }
    }

    // Context
    public class PaymentContext
    {
        private IPaymentStrategy _strategy;

        public void SetPaymentStrategy(IPaymentStrategy strategy)
        {
            _strategy = strategy;
        }

        public void ExecutePayment(decimal amount)
        {
            _strategy?.ProcessPayment(amount);
        }
    }

    // Demo
    class ProgramStrategy
    {
        static void Main()
        {
            var context = new PaymentContext();

           
            context.SetPaymentStrategy(new UPIPayment());
            context.ExecutePayment(1500);

            context.SetPaymentStrategy(new NetBankingPayment());
            context.ExecutePayment(2500);

            context.SetPaymentStrategy(new CardPayment());
            context.ExecutePayment(5000);
            
        }
         // The above method can be moved to factory if needed .Fcatory is for object creation basically 
        class ProgramStrageyFactory
        {
            static void Main()
            {
                string userSelectedMethod = "UPI"; // could come from UI or API
                decimal amount = 2500;

                IPaymentStrategy strategy = PaymentStrategyFactory.GetStrategy(userSelectedMethod);
                var context = new PaymentContext(strategy);

                context.ExecutePayment(amount);
            }
        }
        public static class PaymentStrategyFactory
        {
            public static IPaymentStrategy GetStrategy(string method)
            {
                return method.ToLower() switch
                {
                "upi" => new UPIPayment(),
                "netbanking" => new NetBankingPayment(),
                "card" => new CardPayment(),
                _ => throw new NotSupportedException($"Payment method '{method}' is not supported.")
                };
            }
        }

    }
}