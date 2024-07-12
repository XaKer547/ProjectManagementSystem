using FluentValidation;
using MediatR;
using ProjectManagementSystem.Application.Commands.ProjectWorks;
using ProjectManagementSystem.Domain.ProjectWorks;
using ProjectManagementSystem.Domain.Services;

namespace ProjectManagementSystem.Application.CommandHandlers.ProjectWorks;

public sealed class CreateProjectWorkCommandHandler(IUnitOfWork unitOfWork, IValidator<CreateProjectWorkCommand> validator) : IRequestHandler<CreateProjectWorkCommand, ProjectWorkId>
{
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly IValidator<CreateProjectWorkCommand> validator = validator;

    public async Task<ProjectWorkId> Handle(CreateProjectWorkCommand request, CancellationToken cancellationToken)
    {
        await validator.ValidateAndThrowAsync(request, cancellationToken);

        var project = unitOfWork.Repository.Projects.Single(p => p.Id == request.ProjectId);

        var student = unitOfWork.Repository.Students.Single(s => s.Id == request.StudentId);

        var work = ProjectWork.Create(project, student, request.Name, request.SubjectArea);

        unitOfWork.Repository.AddEntity(work);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return work.Id;
    }
}
