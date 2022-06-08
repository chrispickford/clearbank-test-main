using AutoFixture.Xunit2;
using ClearBank.DeveloperTest.Data;
using ClearBank.DeveloperTest.Types;
using Xunit;

namespace ClearBank.DeveloperTest.Tests.Data;

public class AccountDataStoreTests
{
    private readonly AccountDataStore _sut;

    public AccountDataStoreTests()
    {
        _sut = new AccountDataStore();
    }

    [Theory]
    [AutoData]
    public void GetAccount_ReturnsAccount(string accountNumber)
    {
        // Act
        var result = _sut.GetAccount(accountNumber);

        // Assert
        Assert.NotNull(result);
    }

    [Theory]
    [AutoData]
    public void UpdateAccount_DoesNotAlterAccountProperties(
        string? accountNumber,
        AllowedPaymentSchemes allowedPaymentSchemes,
        decimal balance,
        AccountStatus accountStatus)
    {
        // Arrange
        var account = new Account
        {
            AccountNumber = accountNumber,
            AllowedPaymentSchemes = allowedPaymentSchemes,
            Balance = balance,
            Status = accountStatus
        };

        // Act
        _sut.UpdateAccount(account);

        // Assert
        Assert.Equal(accountNumber, account.AccountNumber);
        Assert.Equal(allowedPaymentSchemes, account.AllowedPaymentSchemes);
        Assert.Equal(balance, account.Balance);
        Assert.Equal(accountStatus, account.Status);
    }
}