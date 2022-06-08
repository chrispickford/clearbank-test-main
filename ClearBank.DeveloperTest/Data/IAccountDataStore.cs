using System;
using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.Data;

internal interface IAccountDataStore : IDisposable
{
    public Account? GetAccount(string accountNumber);

    public void UpdateAccount(Account account);
}