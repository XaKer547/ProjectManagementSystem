using FluentValidation;
using MediatR;
using ProjectManagementSystem.Application.Commands.ProjectStages;
using ProjectManagementSystem.Domain.ProjectStageMarks;
using ProjectManagementSystem.Domain.Services;

namespace ProjectManagementSystem.Application.CommandHandlers.ProjectStages;

public sealed class GradeProjectStageCommandHandler(IUnitOfWork unitOfWork, IValidator<GradeProjectStageCommand> validator) : IRequestHandler<GradeProjectStageCommand>
{
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly IValidator<GradeProjectStageCommand> validator = validator;

    public async Task Handle(GradeProjectStageCommand request, CancellationToken cancellationToken)
    {
        await validator.ValidateAndThrowAsync(request, cancellationToken);

        var student = unitOfWork.Repository.Students.Single(s => s.Id == request.StudentId);

        var projectStage = unitOfWork.Repository.ProjectStages.Single(p => p.Id == request.ProjectStageId);

        var mark = ProjectStageMark.Create(student, projectStage, request.Grade);

        unitOfWork.Repository.AddEntity(mark);

        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}