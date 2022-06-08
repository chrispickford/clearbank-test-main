using System;
using System.Collections.Generic;
using System.Linq;
using ClearBank.DeveloperTest.Specifications;
using ClearBank.DeveloperTest.Types;
using Xunit;

namespace ClearBank.DeveloperTest.Tests.Specifications;

public class AccountAllowsPaymentSchemesSpecificationTests
{
    public static readonly IEnumerable<object[]> PaymentSchemesValues =
        Enum.GetValues<AllowedPaymentSchemes>().Select(x => new object[] { x });

    [Theory]
    [MemberData(nameof(PaymentSchemesValues))]
    public void IsSatisfiedBy_ReturnsFalse_WhenAccountDoesNotSupportPaymentScheme(AllowedPaymentSchemes allowedPaymentSchemes)
    {
        // Arrange
        var sut = new AccountAllowsPaymentSchemesSpecification(allowedPaymentSchemes);
        var account = new Account
        {
            AllowedPaymentSchemes = default
        };

        // Act
        var result = sut.IsSatisfiedBy(account);

        // Assert
        Assert.False(result);
    }

    [Theory]
    [MemberData(nameof(PaymentSchemesValues))]
    public void IsSatisfiedBy_ReturnsTrue_WhenAccountSupportsPaymentScheme(AllowedPaymentSchemes allowedPaymentSchemes)
    {
        // Arrange
        var sut = new AccountAllowsPaymentSchemesSpecification(allowedPaymentSchemes);
        var account = new Account
        {
            AllowedPaymentSchemes = allowedPaymentSchemes
        };

        // Act
        var result = sut.IsSatisfiedBy(account);

        // Assert
        Assert.True(result);
    }
}