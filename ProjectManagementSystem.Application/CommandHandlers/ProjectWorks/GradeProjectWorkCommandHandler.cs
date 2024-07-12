using FluentValidation;
using MediatR;
using ProjectManagementSystem.Application.Commands.ProjectWorks;
using ProjectManagementSystem.Domain.Services;

namespace ProjectManagementSystem.Application.CommandHandlers.ProjectWorks;

public sealed class GradeProjectWorkCommandHandler(IUnitOfWork unitOfWork, IValidator<GradeProjectWorkCommand> validator) : IRequestHandler<GradeProjectWorkCommand>
{
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly IValidator<GradeProjectWorkCommand> validator = validator;

    public async Task Handle(GradeProjectWorkCommand request, CancellationToken cancellationToken)
    {
        await validator.ValidateAndThrowAsync(request, cancellationToken);

        var work = unitOfWork.Repository.ProjectWorks.Single(p => p.Project.Id == request.ProjectId && p.Student.Id == request.StudentId);

        work.Graduate(request.Grade);

        unitOfWork.Repository.UpdateEntity(work);

        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}