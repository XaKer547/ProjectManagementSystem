using FluentValidation;
using MediatR;
using ProjectManagementSystem.Application.Commands.ProjectStageAnswers;
using ProjectManagementSystem.Domain.Services;

namespace ProjectManagementSystem.Application.CommandHandlers.ProjectStageAnswers;

public sealed class UpdateProjectStageAnswerCommandHandler(IUnitOfWork unitOfWork, IValidator<UpdateProjectStageAnswerCommand> validator) : IRequestHandler<UpdateProjectStageAnswerCommand>
{
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly IValidator<UpdateProjectStageAnswerCommand> validator = validator;

    public async Task Handle(UpdateProjectStageAnswerCommand request, CancellationToken cancellationToken)
    {
        await validator.ValidateAndThrowAsync(request, cancellationToken);

        

    }
}