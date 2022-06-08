using System;
using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.Validation;

internal class PaymentValidatorFactory : IPaymentValidatorFactory
{
    public IValidator<Account> CreateValidator(MakePaymentRequest request)
    {
        return request.PaymentScheme switch
        {
            PaymentScheme.Bacs => new BacsAccountPaymentValidator(),
            PaymentScheme.Chaps => new ChapsAccountPaymentValidator(),
            PaymentScheme.FasterPayments => new FasterPaymentsAccountPaymentValidator(request.Amount),
            _ => throw new ArgumentOutOfRangeException(nameof(request.PaymentScheme), request.PaymentScheme, "Unknown PaymentScheme")
        };
    }
}