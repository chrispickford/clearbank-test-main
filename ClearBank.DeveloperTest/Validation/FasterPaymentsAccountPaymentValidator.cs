using ClearBank.DeveloperTest.Specifications;
using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.Validation;

internal class FasterPaymentsAccountPaymentValidator : SpecificationValidator<Account>
{
    public FasterPaymentsAccountPaymentValidator(decimal minBalance)
        : base(new AccountAllowsPaymentSchemesSpecification(AllowedPaymentSchemes.FasterPayments)
            .And(new AccountBalanceGreaterThanSpecification(minBalance)))
    {
    }
}