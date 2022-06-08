using System;
using System.Linq.Expressions;
using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.Specifications;

internal class AccountBalanceGreaterThanSpecification : Specification<Account>
{
    private readonly decimal _minBalance;

    public AccountBalanceGreaterThanSpecification(decimal minBalance)
    {
        _minBalance = minBalance;
    }

    public override Expression<Func<Account, bool>> ToExpression() =>
        account => account.Balance >= _minBalance;
}