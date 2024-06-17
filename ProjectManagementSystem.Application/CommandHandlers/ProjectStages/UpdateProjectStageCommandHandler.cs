using FluentValidation;
using MediatR;
using ProjectManagementSystem.Application.Commands.ProjectStages;
using ProjectManagementSystem.Application.Services;
using ProjectManagementSystem.Domain.ProjectStages;
using ProjectManagementSystem.Domain.Services;

namespace ProjectManagementSystem.Application.CommandHandlers.ProjectStages;

public sealed class UpdateProjectStageCommandHandler(IUnitOfWork unitOfWork, IFileManager fileManager, IValidator<UpdateProjectStageCommand> validator) : IRequestHandler<UpdateProjectStageCommand>
{
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly IFileManager fileManager = fileManager;
    private readonly IValidator<UpdateProjectStageCommand> validator = validator;

    public async Task Handle(UpdateProjectStageCommand request, CancellationToken cancellationToken)
    {
        await validator.ValidateAndThrowAsync(request, cancellationToken);

        var stage = unitOfWork.Repository.ProjectStages.Single(p => p.Id == request.ProjectStageId);

        PinnedFile[]? pinnedFiles = null;

        if (request.PinnedFiles != null)
            pinnedFiles = await fileManager.SaveFiles(stage.Id, request.PinnedFiles);

        stage.Update(request.Name ?? stage.Name,
                     request.Description ?? stage.Description,
                     request.Deadline ?? stage.Deadline,
                     pinnedFiles ?? stage.PinnedFiles);

        unitOfWork.Repository.UpdateEntity(stage);

        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
