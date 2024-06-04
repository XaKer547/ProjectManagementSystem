using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManagementSystem.Domain.Disciplines;
using ProjectManagementSystem.Domain.Groups;
using ProjectManagementSystem.Domain.Projects;
using ProjectManagementSystem.Domain.ProjectStages;
using ProjectManagementSystem.Domain.Services;
using ProjectManagementSystem.Domain.Students;

namespace ProjectManagementSystem.Infrastucture.Data;

public class ProjectManagementSystemDbContext(DbContextOptions options) : DbContext(options), IProjectManagementSystemRepository
{
    public IQueryable<Project> Projects => Set<Project>();
    public IQueryable<ProjectStage> ProjectStages => Set<ProjectStage>();
    public IQueryable<Student> Students => Set<Student>();
    public IQueryable<Discipline> Disciplines => Set<Discipline>();
    public IQueryable<Group> Groups => Set<Group>();

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




        base.OnModelCreating(modelBuilder);
    }
}

file class DisciplineConfiguration : IEntityTypeConfiguration<Discipline>
{
    public void Configure(EntityTypeBuilder<Discipline> builder)
    {
        builder.Property(e => e.Id)
            .HasConversion(e => e.Value, e => new DisciplineId(e))
            .ValueGeneratedNever();

        builder.UsePropertyAccessMode(PropertyAccessMode.Property);
    }
}