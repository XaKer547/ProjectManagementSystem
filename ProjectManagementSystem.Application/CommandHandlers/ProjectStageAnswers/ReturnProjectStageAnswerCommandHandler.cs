using FluentValidation;
using MediatR;
using ProjectManagementSystem.Application.Commands.ProjectStageAnswers;
using ProjectManagementSystem.Application.Services;
using ProjectManagementSystem.Domain.ProjectStages;
using ProjectManagementSystem.Domain.Services;

namespace ProjectManagementSystem.Application.CommandHandlers.ProjectStageAnswers;

public class ReturnProjectStageAnswerCommandHandler(IUnitOfWork unitOfWork, IFileManager fileManager, IValidator<ReturnProjectStageAnswerCommand> validator) : IRequestHandler<ReturnProjectStageAnswerCommand>
{
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly IFileManager fileManager = fileManager;
    private readonly IValidator<ReturnProjectStageAnswerCommand> validator = validator;

    public async Task Handle(ReturnProjectStageAnswerCommand request, CancellationToken cancellationToken)
    {
        await validator.ValidateAndThrowAsync(request, cancellationToken);

        var stage = unitOfWork.Repository.StudentProjectStages
            .Select(s => new
            {
                s.Id,
                StageId = s.Stage.Id,
                Answer = s.Answers.Last()
            })
            .Single(s => s.Id == request.ProjectStageId);

        PinnedFile pinnedFile = null;

        if (request.PinnedFile is not null)
            pinnedFile = await fileManager.SaveFile(stage.StageId, request.PinnedFile);

        stage.Answer.Return(request.Remark, pinnedFile);

        unitOfWork.Repository.UpdateEntity(stage.Answer);

        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}