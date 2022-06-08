using System;
using System.Collections.Generic;
using System.Linq;
using ClearBank.DeveloperTest.Specifications;
using ClearBank.DeveloperTest.Types;
using Xunit;

namespace ClearBank.DeveloperTest.Tests.Specifications;

public class AccountStatusOfSpecificationTests
{
    public static readonly IEnumerable<object[]> AccountStatusValues =
        Enum.GetValues<AccountStatus>().Select(x => new object[] { x });

    [Theory]
    [MemberData(nameof(AccountStatusValues))]
    public void IsSatisfiedBy_ReturnsFalse_WhenIncorrectAccountStatus(AccountStatus accountStatus)
    {
        // Arrange
        var sut = new AccountStatusOfSpecification(accountStatus);
        var account = new Account
        {
            Status = default
        };

        // Act
        var result = sut.IsSatisfiedBy(account);

        // Assert
        Assert.False(result);
    }

    [Theory]
    [MemberData(nameof(AccountStatusValues))]
    public void IsSatisfiedBy_ReturnsTrue_WhenCorrectAccountStatus(AccountStatus accountStatus)
    {
        // Arrange
        var sut = new AccountStatusOfSpecification(accountStatus);
        var account = new Account
        {
            Status = accountStatus
        };

        // Act
        var result = sut.IsSatisfiedBy(account);

        // Assert
        Assert.True(result);
    }
}