using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.Validation;

internal interface IPaymentValidatorFactory
{
    public IValidator<Account> CreateValidator(MakePaymentRequest request);
}