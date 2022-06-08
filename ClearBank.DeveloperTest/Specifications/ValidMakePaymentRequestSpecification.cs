using System;
using System.Linq.Expressions;
using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.Specifications;

internal class ValidMakePaymentRequestSpecification : Specification<MakePaymentRequest>
{
    public override Expression<Func<MakePaymentRequest, bool>> ToExpression() =>
        request => !string.IsNullOrWhiteSpace(request.DebtorAccountNumber)
                   && request.Amount != default
                   && request.PaymentScheme != default;
}