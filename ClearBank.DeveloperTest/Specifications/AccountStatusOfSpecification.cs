using System;
using System.Linq.Expressions;
using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.Specifications;

internal class AccountStatusOfSpecification : Specification<Account>
{
    private readonly AccountStatus _accountStatus;

    public AccountStatusOfSpecification(AccountStatus accountStatus)
    {
        _accountStatus = accountStatus;
    }

    public override Expression<Func<Account, bool>> ToExpression() =>
        account => account.Status.Equals(_accountStatus);
}