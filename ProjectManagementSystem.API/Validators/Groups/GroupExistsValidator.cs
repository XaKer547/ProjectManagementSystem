using ProjectManagementSystem.API.Validators;
using ProjectManagementSystem.Domain.Groups;
using ProjectManagementSystem.Infrastucture.Data;

namespace ProjectManagementSystem.API.Validators.Grops;

public class GroupExistsValidator(ProjectManagementSystemDbContext context) : EntityExistsValidator<GroupId, Group>(context)
{

}