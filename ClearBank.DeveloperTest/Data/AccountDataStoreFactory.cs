using ClearBank.DeveloperTest.Options;
using Microsoft.Extensions.Options;

namespace ClearBank.DeveloperTest.Data;

internal class AccountDataStoreFactory : IAccountDataStoreFactory
{
    private readonly IOptions<AccountDataStoreOptions> _dataStoreOptions;

    public AccountDataStoreFactory(
        IOptions<AccountDataStoreOptions> dataStoreOptions)
    {
        _dataStoreOptions = dataStoreOptions;
    }

    public IAccountDataStore GetAccountDataStore() =>
        _dataStoreOptions.Value.UseBackupDataStore
            ? new BackupAccountDataStore()
            : new AccountDataStore();
}