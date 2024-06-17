using ProjectManagementSystem.Domain.Groups;
using ProjectManagementSystem.Infrastucture.Data;

namespace ProjectManagementSystem.Infrastucture.Validators.Grops;

public class GroupExistsValidator(ProjectManagementSystemDbContext context) : EntityExistsValidator<GroupId, Group>(context)
{

}