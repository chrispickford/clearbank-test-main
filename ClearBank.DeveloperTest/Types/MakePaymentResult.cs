using JetBrains.Annotations;

namespace ClearBank.DeveloperTest.Types;

[PublicAPI]
public sealed class MakePaymentResult
{
    private MakePaymentResult(bool success)
    {
        Success = success;
    }

    internal static MakePaymentResult SuccessResult => new(true);
    internal static MakePaymentResult FailureResult => new(false);

    public bool Success { get; }
}