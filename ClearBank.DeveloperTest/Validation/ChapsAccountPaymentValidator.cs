using ClearBank.DeveloperTest.Specifications;
using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.Validation;

internal class ChapsAccountPaymentValidator : SpecificationValidator<Account>
{
    public ChapsAccountPaymentValidator()
        : base(new AccountAllowsPaymentSchemesSpecification(AllowedPaymentSchemes.Chaps)
            .And(new AccountStatusOfSpecification(AccountStatus.Live)))
    {
    }
}