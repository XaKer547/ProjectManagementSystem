using MediatR;
using ProjectManagementSystem.Domain.Projects;

namespace ProjectManagementSystem.Application.Commands.Projects;

//TODO: а что мешало через name_record(params)?
public sealed record CompleteProjectCommand : IRequest
{
    public ProjectId ProjectId { get; init; }
}
