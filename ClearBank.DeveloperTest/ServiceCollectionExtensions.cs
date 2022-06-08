using ClearBank.DeveloperTest.Data;
using ClearBank.DeveloperTest.Options;
using ClearBank.DeveloperTest.Services;
using ClearBank.DeveloperTest.Types;
using ClearBank.DeveloperTest.Validation;
using JetBrains.Annotations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ClearBank.DeveloperTest;

[PublicAPI]
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddClearBankDeveloperTestServices(
        this IServiceCollection services,
        IConfiguration clearBankDeveloperTestConfigurationSection)
    {
        services
            .Configure<AccountDataStoreOptions>(clearBankDeveloperTestConfigurationSection);

        services
            .AddSingleton<IAccountDataStoreFactory, AccountDataStoreFactory>()
            .AddSingleton<IPaymentValidatorFactory, PaymentValidatorFactory>()
            .AddSingleton<IValidator<MakePaymentRequest>, MakePaymentRequestValidator>();

        services
            .AddTransient<IPaymentService, PaymentService>();

        return services;
    }
}