using Microsoft.EntityFrameworkCore;
using ProjectManagementSystem.Domain.Disciplines;
using ProjectManagementSystem.Domain.Groups;
using ProjectManagementSystem.Domain.Projects;
using ProjectManagementSystem.Domain.ProjectStageAnswers;
using ProjectManagementSystem.Domain.ProjectStages;
using ProjectManagementSystem.Domain.Services;
using ProjectManagementSystem.Domain.StudentProjectStages;
using ProjectManagementSystem.Domain.Students;

namespace ProjectManagementSystem.Infrastucture.Data;

public class ProjectManagementSystemDbContext(DbContextOptions options) : DbContext(options), IProjectManagementSystemRepository
{
    public IQueryable<Project> Projects => Set<Project>();
    public IQueryable<ProjectStage> ProjectStages => Set<ProjectStage>();
    public IQueryable<Student> Students => Set<Student>();
    public IQueryable<Discipline> Disciplines => Set<Discipline>();
    public IQueryable<Group> Groups => Set<Group>();
    public IQueryable<StudentProjectStage> StudentProjectStages => Set<StudentProjectStage>();

    public void AddEntity<TEntity>(TEntity entity) where TEntity : class
    {
        Add(entity);
    }
    public void DeleteEntity<TEntityId>(TEntityId entity) where TEntityId : class
    {
        Update(entity);
    }
    public void UpdateEntity<TEntity>(TEntity entity) where TEntity : class
    {
        Update(entity);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new DisciplineConfiguration());

        modelBuilder.ApplyConfiguration(new StudentConfiguration());

        modelBuilder.ApplyConfiguration(new GroupConfiguration());

        modelBuilder.ApplyConfiguration(new ProjectConfiguration());

        modelBuilder.ApplyConfiguration(new ProjectStageConfiguration());

        modelBuilder.ApplyConfiguration(new ProjectStageAnswerConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}

#region EntityConfiguration
file class ProjectConfiguration : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> builder)
    {
        builder.UsePropertyAccessMode(PropertyAccessMode.Property);

        builder.Property(e => e.Id)
            .HasConversion(e => e.Value, e => new ProjectId(e));
    }
}
file class ProjectStageConfiguration : IEntityTypeConfiguration<ProjectStage>
{
    public void Configure(EntityTypeBuilder<ProjectStage> builder)
    {
        builder.UsePropertyAccessMode(PropertyAccessMode.Property);

        builder.Property(e => e.Id)
            .HasConversion(e => e.Value, e => new ProjectStageId(e));
    }
}
file class ProjectStageAnswerConfiguration : IEntityTypeConfiguration<ProjectStageAnswer>
{
    public void Configure(EntityTypeBuilder<ProjectStageAnswer> builder)
    {
        builder.UsePropertyAccessMode(PropertyAccessMode.Property);

        builder.Property(e => e.Id)
            .HasConversion(e => e.Value, e => new ProjectStageAnswerId(e));
    }
}
file class StudentProjectStageConfiguration : IEntityTypeConfiguration<StudentProjectStage>
{
    public void Configure(EntityTypeBuilder<StudentProjectStage> builder)
    {
        builder.UsePropertyAccessMode(PropertyAccessMode.Property);

        builder.Property(e => e.Id)
            .HasConversion(e => e.Value, e => new StudentProjectStageId(e));
    }
}
file class GroupConfiguration : IEntityTypeConfiguration<Group>
{
    public void Configure(EntityTypeBuilder<Group> builder)
    {
        builder.UsePropertyAccessMode(PropertyAccessMode.Property);

        builder.Property(e => e.Id)
            .HasConversion(e => e.Value, e => new GroupId(e));
    }
}
file class DisciplineConfiguration : IEntityTypeConfiguration<Discipline>
{
    public void Configure(EntityTypeBuilder<Discipline> builder)
    {
        builder.UsePropertyAccessMode(PropertyAccessMode.Property);

        builder.Property(e => e.Id)
            .HasConversion(e => e.Value, e => new DisciplineId(e));
    }
}
file class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.UsePropertyAccessMode(PropertyAccessMode.Property);

        builder.Property(e => e.Id)
            .HasConversion(e => e.Value, e => new StudentId(e));
    }
}
file class ProjectMarkConfiguration : IEntityTypeConfiguration<ProjectMark>
{
    public void Configure(EntityTypeBuilder<ProjectMark> builder)
    {
        builder.UsePropertyAccessMode(PropertyAccessMode.Property);

        builder.Property(e => e.Id)
            .HasConversion(e => e.Value, e => new ProjectMarkId(e));
    }
}
#endregion