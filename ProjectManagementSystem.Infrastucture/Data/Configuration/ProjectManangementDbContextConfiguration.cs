using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ProjectManagementSystem.Domain.Disciplines;
using ProjectManagementSystem.Domain.ProjectMarks;
using ProjectManagementSystem.Domain.Projects;
using ProjectManagementSystem.Domain.ProjectStageAnswers;
using ProjectManagementSystem.Domain.ProjectStages;
using ProjectManagementSystem.Domain.StudentProjectStages;
using ProjectManagementSystem.Domain.Students;
using ProjectManagementSystem.Domain.Groups;

namespace ProjectManagementSystem.Infrastucture.Data.Configuration;

internal class ProjectConfiguration : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> builder)
    {
        builder.UsePropertyAccessMode(PropertyAccessMode.Property);

        builder.Property(e => e.Id)
            .HasConversion(e => e.Value, e => new ProjectId(e));
    }
}
internal class ProjectStageConfiguration : IEntityTypeConfiguration<ProjectStage>
{
    public void Configure(EntityTypeBuilder<ProjectStage> builder)
    {
        builder.UsePropertyAccessMode(PropertyAccessMode.Property);

        builder.Property(e => e.Id)
            .HasConversion(e => e.Value, e => new ProjectStageId(e));
    }
}
internal class ProjectStageAnswerConfiguration : IEntityTypeConfiguration<ProjectStageAnswer>
{
    public void Configure(EntityTypeBuilder<ProjectStageAnswer> builder)
    {
        builder.UsePropertyAccessMode(PropertyAccessMode.Property);

        builder.Property(e => e.Id)
            .HasConversion(e => e.Value, e => new ProjectStageAnswerId(e));
    }
}
internal class StudentProjectStageConfiguration : IEntityTypeConfiguration<StudentProjectStage>
{
    public void Configure(EntityTypeBuilder<StudentProjectStage> builder)
    {
        builder.UsePropertyAccessMode(PropertyAccessMode.Property);

        builder.Property(e => e.Id)
            .HasConversion(e => e.Value, e => new StudentProjectStageId(e));
    }
}
internal class GroupConfiguration : IEntityTypeConfiguration<Group>
{
    public void Configure(EntityTypeBuilder<Group> builder)
    {
        builder.UsePropertyAccessMode(PropertyAccessMode.Property);

        builder.Property(e => e.Id)
            .HasConversion(e => e.Value, e => new GroupId(e));
    }
}
internal class DisciplineConfiguration : IEntityTypeConfiguration<Discipline>
{
    public void Configure(EntityTypeBuilder<Discipline> builder)
    {
        builder.UsePropertyAccessMode(PropertyAccessMode.Property);

        builder.Property(e => e.Id)
            .HasConversion(e => e.Value, e => new DisciplineId(e));
    }
}
internal class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.UsePropertyAccessMode(PropertyAccessMode.Property);

        builder.Property(e => e.Id)
            .HasConversion(e => e.Value, e => new StudentId(e));
    }
}
internal class ProjectMarkConfiguration : IEntityTypeConfiguration<ProjectMark>
{
    public void Configure(EntityTypeBuilder<ProjectMark> builder)
    {
        builder.UsePropertyAccessMode(PropertyAccessMode.Property);

        builder.Property(e => e.Id)
            .HasConversion(e => e.Value, e => new ProjectMarkId(e));
    }
}