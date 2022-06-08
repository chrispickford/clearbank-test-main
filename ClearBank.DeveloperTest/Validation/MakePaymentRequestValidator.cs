using ClearBank.DeveloperTest.Specifications;
using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.Validation;

internal class MakePaymentRequestValidator : SpecificationValidator<MakePaymentRequest>
{
    public MakePaymentRequestValidator()
        : base(new ValidMakePaymentRequestSpecification())
    {
    }
}