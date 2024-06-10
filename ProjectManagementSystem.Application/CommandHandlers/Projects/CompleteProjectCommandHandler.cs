using FluentValidation;
using MediatR;
using ProjectManagementSystem.Application.Commands.Projects;
using ProjectManagementSystem.Domain.Services;

namespace ProjectManagementSystem.Application.CommandHandlers.Projects;

public class CompleteProjectCommandHandler(IUnitOfWork unitOfWork, IValidator<CompleteProjectCommand> validator) : IRequestHandler<CompleteProjectCommand>
{
    //TODO: А где нижнее подчеркивание в наименовании переменных
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly IValidator<CompleteProjectCommand> validator = validator;

    public async Task Handle(CompleteProjectCommand request, CancellationToken cancellationToken)
    {
        await validator.ValidateAndThrowAsync(request, cancellationToken);

        var project = unitOfWork.Repository.Projects.Single(p => p.Id == request.ProjectId);

        project.Complete();

        unitOfWork.Repository.UpdateEntity(project);

        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
