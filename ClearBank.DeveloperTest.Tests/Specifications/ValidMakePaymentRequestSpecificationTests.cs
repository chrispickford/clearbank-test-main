using AutoFixture.Xunit2;
using ClearBank.DeveloperTest.Specifications;
using ClearBank.DeveloperTest.Types;
using Xunit;

namespace ClearBank.DeveloperTest.Tests.Specifications;

public class ValidMakePaymentRequestSpecificationTests
{
    private readonly ValidMakePaymentRequestSpecification _sut = new();

    [Theory]
    [AutoData]
    public void IsSatisfiedBy_ReturnsFalse_WhenAmountIsDefault(MakePaymentRequest request)
    {
        // Arrange
        request.Amount = default;

        // Act
        var result = _sut.IsSatisfiedBy(request);

        // Assert
        Assert.False(result);
    }

    [Theory]
    [AutoData]
    public void IsSatisfiedBy_ReturnsFalse_WhenDebtorAccountNumberIsNull(MakePaymentRequest request)
    {
        // Arrange
        request.DebtorAccountNumber = null;

        // Act
        var result = _sut.IsSatisfiedBy(request);

        // Assert
        Assert.False(result);
    }

    [Theory]
    [AutoData]
    public void IsSatisfiedBy_ReturnsFalse_WhenPaymentSchemeIsDefault(MakePaymentRequest request)
    {
        // Arrange
        request.PaymentScheme = default;

        // Act
        var result = _sut.IsSatisfiedBy(request);

        // Assert
        Assert.False(result);
    }


    [Theory]
    [AutoData]
    public void IsSatisfiedBy_ReturnsTrue_WhenValidRequest(MakePaymentRequest request)
    {
        // Act
        var result = _sut.IsSatisfiedBy(request);

        // Assert
        Assert.True(result);
    }
}