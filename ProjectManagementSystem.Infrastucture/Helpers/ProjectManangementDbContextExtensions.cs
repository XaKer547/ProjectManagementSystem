using Microsoft.EntityFrameworkCore;
using ProjectManagementSystem.Infrastucture.Data.Configuration;

namespace ProjectManagementSystem.Infrastucture.Helpers;

public static class ProjectManangementDbContextExtensions
{
    public static void ApplyConfiguration(this ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new DisciplineConfiguration());

        modelBuilder.ApplyConfiguration(new StudentConfiguration());

        modelBuilder.ApplyConfiguration(new GroupConfiguration());

        modelBuilder.ApplyConfiguration(new ProjectConfiguration());

        modelBuilder.ApplyConfiguration(new ProjectStageConfiguration());

        modelBuilder.ApplyConfiguration(new ProjectStageAnswerConfiguration());

        modelBuilder.ApplyConfiguration(new StudentProjectStageConfiguration());
    }
}
