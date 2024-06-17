using ProjectManagementSystem.Infrastucture.Validators.Models;

namespace ProjectManagementSystem.Infrastucture.Validators.Exceptions;

public sealed class ValidationException(List<ValidationError> errors) : Exception
{
    public List<ValidationError> Errors { get; } = errors;
}
