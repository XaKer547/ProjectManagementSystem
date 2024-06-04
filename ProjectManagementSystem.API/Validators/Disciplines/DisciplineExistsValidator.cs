using ProjectManagementSystem.Domain.Disciplines;
using ProjectManagementSystem.Infrastucture.Data;

namespace ProjectManagementSystem.API.Validators.Disciplines;

public class DisciplineExistsValidator(ProjectManagementSystemDbContext context) : EntityExistsValidator<DisciplineId, Discipline>(context)
{

}
