using ProjectManagementSystem.Domain.Disciplines;
using ProjectManagementSystem.Infrastucture.Data;

namespace ProjectManagementSystem.Infrastucture.Validators.Disciplines;

public class DisciplineExistsValidator(ProjectManagementSystemDbContext context) : EntityExistsValidator<DisciplineId, Discipline>(context)
{

}
