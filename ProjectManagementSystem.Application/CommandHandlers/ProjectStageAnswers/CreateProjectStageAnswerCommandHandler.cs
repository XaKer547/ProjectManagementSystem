using FluentValidation;
using MediatR;
using ProjectManagementSystem.Application.Commands.ProjectStageAnswers;
using ProjectManagementSystem.Application.Services;
using ProjectManagementSystem.Domain.ProjectStageAnswers;
using ProjectManagementSystem.Domain.Services;

namespace ProjectManagementSystem.Application.CommandHandlers.ProjectStageAnswers;

public class CreateProjectStageAnswerCommandHandler(IUnitOfWork unitOfWork, IFileManager fileManager, IValidator<CreateProjectStageAnswerCommand> validator) : IRequestHandler<CreateProjectStageAnswerCommand, ProjectStageAnswerId>
{
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly IFileManager fileManager = fileManager;
    private readonly IValidator<CreateProjectStageAnswerCommand> validator = validator;

    public async Task<ProjectStageAnswerId> Handle(CreateProjectStageAnswerCommand request, CancellationToken cancellationToken)
    {
        await validator.ValidateAndThrowAsync(request, cancellationToken);

        var projectStage = unitOfWork.Repository.StudentProjectStages
              .Select(s => new
              {
                  s.Id,
                  StageId = s.Stage.Id,
                  Stage = s,
              })
              .Single(s => s.Id == request.ProjectStageId);

        var stage = projectStage.Stage;

        var pinnedFile = await fileManager.SaveFile(projectStage.StageId, request.PinnedFile);

        var answer = ProjectStageAnswer.Create(pinnedFile);

        stage.Answers.Add(answer);

        unitOfWork.Repository.UpdateEntity(stage);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return answer.Id;
    }
}
