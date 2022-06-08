using ClearBank.DeveloperTest.Specifications;

namespace ClearBank.DeveloperTest.Validation;

internal abstract class SpecificationValidator<T> : IValidator<T>
    where T : class
{
    private readonly Specification<T> _specification;

    protected SpecificationValidator(Specification<T> specification)
    {
        _specification = specification;
    }

    public void Dispose()
    {
    }

    public bool IsValid(T model) =>
        _specification.IsSatisfiedBy(model);
}