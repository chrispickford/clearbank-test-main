using System;
using System.Linq.Expressions;
using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.Specifications;

internal class AccountAllowsPaymentSchemesSpecification : Specification<Account>
{
    private readonly AllowedPaymentSchemes _allowedPaymentSchemes;

    public AccountAllowsPaymentSchemesSpecification(AllowedPaymentSchemes allowedPaymentSchemes)
    {
        _allowedPaymentSchemes = allowedPaymentSchemes;
    }

    public override Expression<Func<Account, bool>> ToExpression() =>
        account => account.AllowedPaymentSchemes.HasFlag(_allowedPaymentSchemes);
}