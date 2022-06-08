using AutoFixture.Xunit2;
using ClearBank.DeveloperTest.Specifications;
using ClearBank.DeveloperTest.Types;
using Xunit;

namespace ClearBank.DeveloperTest.Tests.Specifications;

public class AccountBalanceGreaterThanSpecificationTests
{
    [Theory]
    [AutoData]
    public void IsSatisfiedBy_ReturnsFalse_WhenAccountBalanceLessThanMinBalance(decimal accountBalance)
    {
        // Arrange
        var sut = new AccountBalanceGreaterThanSpecification(accountBalance + 1M);
        var account = new Account
        {
            Balance = accountBalance
        };

        // Act
        var result = sut.IsSatisfiedBy(account);

        // Assert
        Assert.False(result);
    }

    [Theory]
    [AutoData]
    public void IsSatisfiedBy_ReturnsTrue_WhenAccountBalanceGreaterThanMinBalance(decimal accountBalance)
    {
        // Arrange
        var sut = new AccountBalanceGreaterThanSpecification(accountBalance - 1M);
        var account = new Account
        {
            Balance = accountBalance
        };

        // Act
        var result = sut.IsSatisfiedBy(account);

        // Assert
        Assert.True(result);
    }
}