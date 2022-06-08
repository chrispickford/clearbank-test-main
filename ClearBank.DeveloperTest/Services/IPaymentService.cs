using ClearBank.DeveloperTest.Types;
using JetBrains.Annotations;

namespace ClearBank.DeveloperTest.Services;

[PublicAPI]
public interface IPaymentService
{
    MakePaymentResult MakePayment(MakePaymentRequest request);
}