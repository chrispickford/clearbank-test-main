using AutoFixture.Xunit2;
using ClearBank.DeveloperTest.Data;
using ClearBank.DeveloperTest.Services;
using ClearBank.DeveloperTest.Tests.MockExtensions;
using ClearBank.DeveloperTest.Types;
using ClearBank.DeveloperTest.Validation;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace ClearBank.DeveloperTest.Tests.Services;

public class PaymentServiceTests
{
    private readonly Mock<IAccountDataStore> _mockAccountDataStore;
    private readonly Mock<IValidator<Account>> _mockAccountValidator;
    private readonly Mock<IValidator<MakePaymentRequest>> _mockMakePaymentRequestValidator;

    private readonly PaymentService _sut;

    public PaymentServiceTests()
    {
        _mockAccountDataStore = new Mock<IAccountDataStore>(MockBehavior.Strict)
            .SetupDispose();
        _mockAccountValidator = new Mock<IValidator<Account>>(MockBehavior.Strict)
            .SetupDispose();
        _mockMakePaymentRequestValidator = new Mock<IValidator<MakePaymentRequest>>(MockBehavior.Strict)
            .SetupDispose();


        var mockAccountDataStoreFactory = new Mock<IAccountDataStoreFactory>(MockBehavior.Strict)
            .GetAccountDataStoreReturns(_mockAccountDataStore.Object);
        var mockPaymentValidatorFactory = new Mock<IPaymentValidatorFactory>(MockBehavior.Strict)
            .CreateValidatorReturns(_mockAccountValidator.Object);
        var mockLogger = new Mock<ILogger<PaymentService>>();

        _sut = new PaymentService(
            mockAccountDataStoreFactory.Object,
            mockLogger.Object,
            _mockMakePaymentRequestValidator.Object,
            mockPaymentValidatorFactory.Object);
    }

    [Theory]
    [AutoData]
    public void MakePayment_DebitsAccountBalanceCorrectly(MakePaymentRequest request, Account account)
    {
        // Arrange
        _mockMakePaymentRequestValidator.IsValidReturns(true);
        _mockAccountDataStore
            .GetAccountReturns(account)
            .SetupUpdateAccount();
        _mockAccountValidator.IsValidReturns(true);

        var expectedBalance = account.Balance - request.Amount;

        // Act
        _sut.MakePayment(request);

        // Assert
        Assert.Equal(expectedBalance, account.Balance);
    }

    [Theory]
    [AutoData]
    public void MakePayment_ReturnsFailure_WhenAccountNumberNotFound(MakePaymentRequest request)
    {
        // Arrange
        _mockMakePaymentRequestValidator.IsValidReturns(true);
        _mockAccountDataStore.GetAccountReturns(null);

        // Act
        var result = _sut.MakePayment(request);

        // Assert
        Assert.NotNull(result);
        Assert.False(result.Success);
    }

    [Theory]
    [AutoData]
    public void MakePayment_ReturnsFailure_WhenAccountValidationFails(MakePaymentRequest request, Account account)
    {
        // Arrange
        _mockMakePaymentRequestValidator.IsValidReturns(true);
        _mockAccountDataStore.GetAccountReturns(account);
        _mockAccountValidator.IsValidReturns(false);

        // Act
        var result = _sut.MakePayment(request);

        // Assert
        Assert.NotNull(result);
        Assert.False(result.Success);
    }

    [Theory]
    [AutoData]
    public void MakePayment_ReturnsFailure_WhenInvalidRequest(MakePaymentRequest request)
    {
        // Arrange
        _mockMakePaymentRequestValidator.IsValidReturns(false);

        // Act
        var result = _sut.MakePayment(request);

        // Assert
        Assert.NotNull(result);
        Assert.False(result.Success);
    }

    [Theory]
    [AutoData]
    public void MakePayment_ReturnsSuccess_WhenValidRequest(MakePaymentRequest request, Account account)
    {
        // Arrange
        _mockMakePaymentRequestValidator.IsValidReturns(true);
        _mockAccountDataStore
            .GetAccountReturns(account)
            .SetupUpdateAccount();
        _mockAccountValidator.IsValidReturns(true);

        // Act
        var result = _sut.MakePayment(request);

        // Assert
        Assert.NotNull(result);
        Assert.True(result.Success);
    }
}