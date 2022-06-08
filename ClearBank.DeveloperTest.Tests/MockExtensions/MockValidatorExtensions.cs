using ClearBank.DeveloperTest.Validation;
using Moq;

namespace ClearBank.DeveloperTest.Tests.MockExtensions;

internal static class MockValidatorExtensions
{
    public static Mock<IValidator<T>> IsValidReturns<T>(
        this Mock<IValidator<T>> mock,
        bool result)
        where T : class
    {
        mock
            .Setup(x =>
                x.IsValid(It.IsAny<T>()))
            .Returns(result);

        return mock;
    }

    public static Mock<IValidator<T>> SetupDispose<T>(
        this Mock<IValidator<T>> mock)
        where T : class
    {
        mock
            .Setup(x => x.Dispose())
            .Verifiable();

        return mock;
    }
}