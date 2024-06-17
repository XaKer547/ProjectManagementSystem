using FluentValidation;
using MediatR;
using ProjectManagementSystem.Application.Queries.ProjectStages;
using ProjectManagementSystem.Domain.Services;
using SharedKernel.DTOs.ProjectStages;

namespace ProjectManagementSystem.Application.QueryHandlers.ProjectStages;

public sealed class GetProjectStagesQueryHandler(IUnitOfWork unitOfWork, IValidator<GetProjectStagesQuery> validator) : IRequestHandler<GetProjectStagesQuery, IReadOnlyCollection<ProjectStagePreviewDTO>>
{
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly IValidator<GetProjectStagesQuery> validator = validator;

    public async Task<IReadOnlyCollection<ProjectStagePreviewDTO>> Handle(GetProjectStagesQuery request, CancellationToken cancellationToken)
    {
        await validator.ValidateAndThrowAsync(request, cancellationToken);

        IReadOnlyCollection<ProjectStagePreviewDTO> projectStages = [.. unitOfWork.Repository.ProjectStages.Select(p => new ProjectStagePreviewDTO
        {
            Id = p.Id.Value,
            Name = p.Name,
            Description = p.Description,
            Deadline = p.Deadline,
        })];

        return projectStages;
    }
}
