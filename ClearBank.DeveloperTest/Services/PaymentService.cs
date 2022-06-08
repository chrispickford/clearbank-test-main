using ClearBank.DeveloperTest.Data;
using ClearBank.DeveloperTest.Types;
using ClearBank.DeveloperTest.Validation;
using Microsoft.Extensions.Logging;

namespace ClearBank.DeveloperTest.Services;

internal class PaymentService : IPaymentService
{
    private readonly IAccountDataStoreFactory _accountDataStoreFactory;
    private readonly ILogger<PaymentService> _logger;
    private readonly IValidator<MakePaymentRequest> _makePaymentRequestValidator;
    private readonly IPaymentValidatorFactory _paymentValidatorFactory;

    public PaymentService(
        IAccountDataStoreFactory accountDataStoreFactory,
        ILogger<PaymentService> logger,
        IValidator<MakePaymentRequest> makePaymentRequestValidator,
        IPaymentValidatorFactory paymentValidatorFactory
    )
    {
        _accountDataStoreFactory = accountDataStoreFactory;
        _logger = logger;
        _makePaymentRequestValidator = makePaymentRequestValidator;
        _paymentValidatorFactory = paymentValidatorFactory;
    }

    public MakePaymentResult MakePayment(MakePaymentRequest request)
    {
        if (!IsValidRequest(request))
        {
            _logger.LogWarning("Invalid request");
            return MakePaymentResult.FailureResult;
        }

        using var accountDataStore = _accountDataStoreFactory.GetAccountDataStore();
        var account = accountDataStore.GetAccount(request.DebtorAccountNumber!);

        if (account is null)
        {
            _logger.LogWarning(
                "Failed to load account {AccountNumber}",
                request.DebtorAccountNumber);
            return MakePaymentResult.FailureResult;
        }

        if (!IsValidPaymentForAccount(request, account))
        {
            _logger.LogWarning(
                "Failed to validate account {AccountNumber}",
                request.DebtorAccountNumber);
            return MakePaymentResult.FailureResult;
        }

        account.Balance -= request.Amount;

        accountDataStore.UpdateAccount(account);

        _logger.LogInformation(
            "Account {AccountNumber} succesfully debited by {Amount}",
            request.DebtorAccountNumber,
            request.Amount);

        return MakePaymentResult.SuccessResult;
    }

    private bool IsValidPaymentForAccount(MakePaymentRequest request, Account account)
    {
        using var validator = _paymentValidatorFactory.CreateValidator(request);
        return validator.IsValid(account);
    }

    private bool IsValidRequest(MakePaymentRequest request) =>
        _makePaymentRequestValidator.IsValid(request);
}