// PaymentTests.cs
// Unit tests for payment processing
// PaymentTests.cs
// xUnit tests for payment processing logic in a BFSI-grade system

using Xunit;
using Moq;

public class PaymentTests
{
    private readonly Mock<IPaymentGateway> _gatewayMock;
    private readonly PaymentProcessor _processor;

    public PaymentTests()
    {
        _gatewayMock = new Mock<IPaymentGateway>();
        _processor = new PaymentProcessor(_gatewayMock.Object);
    }

    [Fact]
    public void ProcessPayment_ShouldSucceed_ForValidTransaction()
    {
        var txn = new PaymentTransaction { Amount = 1000, AccountNumber = "1234567890" };
        _gatewayMock.Setup(g => g.Charge(txn)).Returns(true);

        var result = _processor.Process(txn);

        Assert.True(result.IsSuccess);
        Assert.Equal("Payment successful", result.Message);
    }

    [Fact]
    public void ProcessPayment_ShouldFail_ForInsufficientBalance()
    {
        var txn = new PaymentTransaction { Amount = 50000, AccountNumber = "1234567890" };
        _gatewayMock.Setup(g => g.Charge(txn)).Returns(false);

        var result = _processor.Process(txn);

        Assert.False(result.IsSuccess);
        Assert.Equal("Payment failed", result.Message);
    }

    [Fact]
    public void ProcessPayment_ShouldThrow_ForNullTransaction()
    {
        Assert.Throws<ArgumentNullException>(() => _processor.Process(null));
    }
}