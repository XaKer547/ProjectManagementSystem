﻿using MediatR;
using ProjectManagementSystem.Application.Queries.Projects;
using ProjectManagementSystem.Domain.Helpers;
using ProjectManagementSystem.Domain.Services;
using SharedKernel.DTOs.Projects;

namespace ProjectManagementSystem.Application.QueryHandlers.Projects;

public sealed class GetProjectsQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetProjectsQuery, IReadOnlyCollection<ProjectDTO>>
{
    private readonly IUnitOfWork unitOfWork = unitOfWork;

    public Task<IReadOnlyCollection<ProjectDTO>> Handle(GetProjectsQuery request, CancellationToken cancellationToken)
    {
        IReadOnlyCollection<ProjectDTO> projects = [.. unitOfWork.Repository.ProjectWorks.Select(p => new ProjectDTO
        {
            Id = p.Id.Value,
            Name = p.Name,
            SubjectArea = p.SubjectArea,
            ProjectType = p.Project.Type.GetDisplayName()!,
            ProjectTypeId = (int)p.Project.Type,
            DisciplineId = p.Project.Discipline.Id.Value,
            DisciplineName = p.Project.Discipline.Name,
        })];

        return Task.FromResult(projects);
    }
}