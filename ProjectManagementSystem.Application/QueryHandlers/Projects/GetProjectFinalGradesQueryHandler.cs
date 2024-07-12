using MediatR;
using ProjectManagementSystem.Application.Models;
using ProjectManagementSystem.Application.Queries.Projects;
using ProjectManagementSystem.Application.Services;
using ProjectManagementSystem.Domain.Services;

namespace ProjectManagementSystem.Application.QueryHandlers.Projects;

public sealed class GetProjectFinalGradesQueryHandler(IUnitOfWork unitOfWork, IReportService reportService) : IRequestHandler<GetProjectFinalGradesQuery, FileDTO>
{
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly IReportService reportService = reportService;

    public async Task<FileDTO> Handle(GetProjectFinalGradesQuery request, CancellationToken cancellationToken)
    {
        var assignment = unitOfWork.Repository.ProjectWorks
            .GroupBy(p => p.Project)
            .Select(p => new
            {
                p.Key,
                GroupName = p.Key.Group.Name,
                Assignments = p.Select(p => new StudentGradesDTO
                {
                    StudentFullName = p.Student.FullName,
                    Grade = p.Grade,
                }).ToArray()
            })
            .Single(p => p.Key.Id == request.ProjectId);

        return await reportService.GetFinalGradesReport(assignment.GroupName, assignment.Assignments);
    }
}
