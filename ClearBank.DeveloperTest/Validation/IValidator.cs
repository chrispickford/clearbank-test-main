using System;

namespace ClearBank.DeveloperTest.Validation;

internal interface IValidator<in T> : IDisposable
    where T : class
{
    bool IsValid(T model);
}