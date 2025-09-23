// Abstract Factory
/*
“Create factories that produce related objects, and let the client use the abstract factory interface to get them.”

Real-World Analogy:
Imagine a Banking App that supports multiple regions:
- IndiaFactory → creates UPIPayment, RBICompliance
- USFactory → creates ACHTransfer, FDICCompliance

The app uses the abstract factory to get region-specific components without knowing their concrete classes.

In the below example, IPayment and ICompliance are two separate interfaces grouped under IBankingFactory.
Another Scenario is
     IEmployeeFactory => CreateEmployee,CreateEmplyeeBefits 
    UsEmployee:IEmployeeFactory,
    IndiaEmployee: IEmployeeFactory
*/

public interface IBankingFactory
{
    IPayment CreatePayment();
    ICompliance CreateCompliance();
}

// Concrete Factory: India
public class IndiaFactory : IBankingFactory
{
    public IPayment CreatePayment() => new UPIPayment();
    public ICompliance CreateCompliance() => new RBICompliance();
}

// Concrete Factory: US
public class USFactory : IBankingFactory
{
    public IPayment CreatePayment() => new ACHTransfer();
    public ICompliance CreateCompliance() => new FDICCompliance();
}

// Abstract Products
public interface IPayment { void Pay(); }
public interface ICompliance { void Audit(); }

// Concrete Products
public class UPIPayment : IPayment { public void Pay() => Console.WriteLine("Paid via UPI"); }
public class RBICompliance : ICompliance { public void Audit() => Console.WriteLine("Audited by RBI rules"); }

public class ACHTransfer : IPayment { public void Pay() => Console.WriteLine("Paid via ACH"); }
public class FDICCompliance : ICompliance { public void Audit() => Console.WriteLine("Audited by FDIC rules"); }


IBankingFactory factory = new IndiaFactory(); // or USFactory
var payment = factory.CreatePayment();
var compliance = factory.CreateCompliance();

payment.Pay();
compliance.Audit();