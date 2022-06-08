using ClearBank.DeveloperTest.Specifications;
using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.Validation;

internal class BacsAccountPaymentValidator : SpecificationValidator<Account>
{
    public BacsAccountPaymentValidator()
        : base(new AccountAllowsPaymentSchemesSpecification(AllowedPaymentSchemes.Bacs))
    {
    }
}