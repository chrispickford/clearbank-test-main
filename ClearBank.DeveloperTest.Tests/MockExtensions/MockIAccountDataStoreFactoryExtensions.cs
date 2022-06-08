using ClearBank.DeveloperTest.Data;
using Moq;

namespace ClearBank.DeveloperTest.Tests.MockExtensions;

internal static class MockIAccountDataStoreFactoryExtensions
{
    public static Mock<IAccountDataStoreFactory> GetAccountDataStoreReturns(
        this Mock<IAccountDataStoreFactory> mock,
        IAccountDataStore accountDataStore)
    {
        mock
            .Setup(x => x.GetAccountDataStore())
            .Returns(accountDataStore);

        return mock;
    }
}