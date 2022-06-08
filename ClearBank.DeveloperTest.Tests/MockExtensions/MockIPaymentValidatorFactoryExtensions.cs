using ClearBank.DeveloperTest.Types;
using ClearBank.DeveloperTest.Validation;
using Moq;

namespace ClearBank.DeveloperTest.Tests.MockExtensions;

internal static class MockIPaymentValidatorFactoryExtensions
{
    public static Mock<IPaymentValidatorFactory> CreateValidatorReturns(
        this Mock<IPaymentValidatorFactory> mock,
        IValidator<Account> accountValidator)
    {
        mock
            .Setup(x =>
                x.CreateValidator(It.IsAny<MakePaymentRequest>()))
            .Returns(accountValidator);

        return mock;
    }
}