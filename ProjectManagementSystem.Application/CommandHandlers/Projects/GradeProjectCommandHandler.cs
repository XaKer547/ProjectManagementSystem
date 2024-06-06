using FluentValidation;
using MediatR;
using ProjectManagementSystem.Application.Commands.Projects;
using ProjectManagementSystem.Domain.ProjectMarks;
using ProjectManagementSystem.Domain.Services;

namespace ProjectManagementSystem.Application.CommandHandlers.Projects;

public class GradeProjectCommandHandler(IUnitOfWork unitOfWork, IValidator<GradeProjectCommand> validator) : IRequestHandler<GradeProjectCommand>
{
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly IValidator<GradeProjectCommand> validator = validator;

    public async Task Handle(GradeProjectCommand request, CancellationToken cancellationToken)
    {
        await validator.ValidateAndThrowAsync(request, cancellationToken);

        var student = unitOfWork.Repository.Students.Single(s => s.Id == request.StudentId);

        var project = unitOfWork.Repository.Projects.Single(p => p.Id == request.ProjectId);

        var mark = ProjectMark.Create(student, project, request.Grade);

        unitOfWork.Repository.AddEntity(mark);

        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}