using FluentValidation;
using MediatR;
using ProjectManagementSystem.Application.Commands.ProjectWorks;
using ProjectManagementSystem.Domain.Services;

namespace ProjectManagementSystem.Application.CommandHandlers.ProjectWorks;

public sealed class UpdateProjectWorkCommandHandler(IUnitOfWork unitOfWork, IValidator<UpdateProjectWorkCommand> validator) : IRequestHandler<UpdateProjectWorkCommand>
{
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly IValidator<UpdateProjectWorkCommand> validator = validator;

    public async Task Handle(UpdateProjectWorkCommand request, CancellationToken cancellationToken)
    {
        await validator.ValidateAndThrowAsync(request, cancellationToken);

        var work = unitOfWork.Repository.ProjectWorks.Single(p => p.Project.Id == request.ProjectId && p.Student.Id == request.StudentId);

        work.Update(request.Name ?? work.Name, request.SubjectArea ?? work.SubjectArea);

        unitOfWork.Repository.UpdateEntity(work);

        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}