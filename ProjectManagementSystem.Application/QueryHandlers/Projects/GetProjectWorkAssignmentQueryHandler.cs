using MediatR;
using ProjectManagementSystem.Application.Models;
using ProjectManagementSystem.Application.Queries.Projects;
using ProjectManagementSystem.Application.Services;
using ProjectManagementSystem.Domain.Services;

namespace ProjectManagementSystem.Application.QueryHandlers.Projects;

public sealed class GetProjectWorkAssignmentQueryHandler(IUnitOfWork unitOfWork, IReportService reportService) : IRequestHandler<GetProjectWorkAssignmentQuery, FileDTO>
{
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly IReportService reportService = reportService;

    public async Task<FileDTO> Handle(GetProjectWorkAssignmentQuery request, CancellationToken cancellationToken)
    {
        var assignment = unitOfWork.Repository.ProjectWorks
            .GroupBy(p => p.Project)
            .Select(p => new
            {
                p.Key,
                GroupName = p.Key.Group.Name,
                Assignments = p.Select(p => new StudentWorkAssignmentDTO
                {
                    StudentFullName = p.Student.FullName,
                    WorkName = p.Name,
                }).ToArray()
            })
            .Single(p => p.Key.Id == request.ProjectId);

        return await reportService.GetWorkAssignmentReport(assignment.GroupName, assignment.Assignments);
    }
}
