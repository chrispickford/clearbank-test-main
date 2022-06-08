using ClearBank.DeveloperTest.Data;
using ClearBank.DeveloperTest.Types;
using Moq;

namespace ClearBank.DeveloperTest.Tests.MockExtensions;

internal static class MockIAccountDataStoreExtensions
{
    public static Mock<IAccountDataStore> GetAccountReturns(
        this Mock<IAccountDataStore> mock,
        Account? account)
    {
        mock
            .Setup(x =>
                x.GetAccount(It.IsAny<string>()))
            .Returns(account)
            .Verifiable();

        return mock;
    }

    public static Mock<IAccountDataStore> SetupDispose(
        this Mock<IAccountDataStore> mock)
    {
        mock
            .Setup(x => x.Dispose())
            .Verifiable();

        return mock;
    }

    public static Mock<IAccountDataStore> SetupUpdateAccount(
        this Mock<IAccountDataStore> mock)
    {
        mock
            .Setup(x =>
                x.UpdateAccount(It.IsAny<Account>()))
            .Verifiable();

        return mock;
    }
}