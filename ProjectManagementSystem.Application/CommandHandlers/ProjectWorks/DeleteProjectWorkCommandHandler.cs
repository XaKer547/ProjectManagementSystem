using FluentValidation;
using MediatR;
using ProjectManagementSystem.Application.Commands.ProjectWorks;
using ProjectManagementSystem.Domain.Services;

namespace ProjectManagementSystem.Application.CommandHandlers.ProjectWorks;

public sealed class DeleteProjectWorkCommandHandler(IUnitOfWork unitOfWork, IValidator<DeleteProjectWorkCommand> validator) : IRequestHandler<DeleteProjectWorkCommand>
{
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly IValidator<DeleteProjectWorkCommand> validator = validator;

    public async Task Handle(DeleteProjectWorkCommand request, CancellationToken cancellationToken)
    {
        await validator.ValidateAsync(request, cancellationToken);

        var work = unitOfWork.Repository.ProjectWorks.Single(p => p.Project.Id == request.ProjectId && p.Student.Id == request.StudentId);

        work.Delete();

        unitOfWork.Repository.UpdateEntity(work);

        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
