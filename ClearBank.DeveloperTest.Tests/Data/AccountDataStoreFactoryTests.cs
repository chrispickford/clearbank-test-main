using ClearBank.DeveloperTest.Data;
using ClearBank.DeveloperTest.Options;
using Microsoft.Extensions.Options;
using Moq;
using Xunit;

namespace ClearBank.DeveloperTest.Tests.Data;

public class AccountDataStoreFactoryTests
{
    public AccountDataStoreFactoryTests()
    {
        var mockOptions = new Mock<IOptions<AccountDataStoreOptions>>();
        mockOptions
            .SetupGet(x => x.Value)
            .Returns(_accountDataStoreOptions);

        _sut = new AccountDataStoreFactory(mockOptions.Object);
    }

    private readonly AccountDataStoreOptions _accountDataStoreOptions = new();
    private readonly AccountDataStoreFactory _sut;

    [Fact]
    public void GetAccountDataStore_ReturnsAccountDataStore_WhenUseBackupDataStoreNotSet()
    {
        // Arrange
        _accountDataStoreOptions.UseBackupDataStore = false;

        // Act
        var result = _sut.GetAccountDataStore();

        // Assert
        Assert.NotNull(result);
        Assert.IsType<AccountDataStore>(result);
    }

    [Fact]
    public void GetAccountDataStore_ReturnsBackupAccountDataStore_WhenUseBackupDataStoreSet()
    {
        // Arrange
        _accountDataStoreOptions.UseBackupDataStore = true;

        // Act
        var result = _sut.GetAccountDataStore();

        // Assert
        Assert.NotNull(result);
        Assert.IsType<BackupAccountDataStore>(result);
    }
}