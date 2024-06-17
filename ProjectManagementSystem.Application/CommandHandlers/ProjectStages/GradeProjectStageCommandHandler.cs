using FluentValidation;
using MediatR;
using ProjectManagementSystem.Application.Commands.ProjectStages;
using ProjectManagementSystem.Domain.Services;

namespace ProjectManagementSystem.Application.CommandHandlers.ProjectStages;

public sealed class GradeProjectStageCommandHandler(IUnitOfWork unitOfWork, IValidator<GradeProjectStageCommand> validator) : IRequestHandler<GradeProjectStageCommand>
{
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly IValidator<GradeProjectStageCommand> validator = validator;

    public async Task Handle(GradeProjectStageCommand request, CancellationToken cancellationToken)
    {
        await validator.ValidateAndThrowAsync(request, cancellationToken);

        var stage = unitOfWork.Repository.StudentProjectStages.Single(s => s.Id == request.ProjectStageId);

        stage.Graduate(request.Grade);

        unitOfWork.Repository.UpdateEntity(stage);

        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}