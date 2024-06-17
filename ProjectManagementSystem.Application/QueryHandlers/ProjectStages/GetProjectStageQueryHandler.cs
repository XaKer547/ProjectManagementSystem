using FluentValidation;
using MediatR;
using ProjectManagementSystem.Application.Queries.ProjectStages;
using ProjectManagementSystem.Domain.Services;
using SharedKernel.DTOs.ProjectStageAnswers;
using SharedKernel.DTOs.ProjectStages;

namespace ProjectManagementSystem.Application.QueryHandlers.ProjectStages;

public sealed class GetProjectStageQueryHandler(IUnitOfWork unitOfWork, IValidator<GetProjectStageQuery> validator) : IRequestHandler<GetProjectStageQuery, ProjectStageDTO>
{
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly IValidator<GetProjectStageQuery> validator = validator;

    public async Task<ProjectStageDTO> Handle(GetProjectStageQuery request, CancellationToken cancellationToken)
    {
        await validator.ValidateAndThrowAsync(request, cancellationToken);

        var projectStage = unitOfWork.Repository.StudentProjectStages.Where(p => p.Id == request.ProjectStageId)
            .Select(p => new ProjectStageDTO
            {
                Id = p.Id.Value,
                Name = p.Stage.Name,
                Description = p.Stage.Description,
                Deadline = p.Stage.Deadline,
                Answers = p.Answers.Select(a => new ProjectStageAnswerDTO()
                {
                    Id = a.Id.Value,
                    StudentWork = a.Answer.FilePath,
                    AdditionalResponseFiles = a.AdditionalResponseFiles != null ? a.AdditionalResponseFiles.FilePath : null,
                    Remark = a.Remark,
                    Returned = a.Returned,
                }).ToArray()
            }).Single();

        return projectStage;
    }
}