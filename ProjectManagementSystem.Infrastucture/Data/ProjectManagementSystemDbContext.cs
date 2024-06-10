using Microsoft.EntityFrameworkCore;
using ProjectManagementSystem.Domain.Disciplines;
using ProjectManagementSystem.Domain.Groups;
using ProjectManagementSystem.Domain.Projects;
using ProjectManagementSystem.Domain.ProjectStages;
using ProjectManagementSystem.Domain.Services;
using ProjectManagementSystem.Domain.StudentProjectStages;
using ProjectManagementSystem.Domain.Students;
using ProjectManagementSystem.Infrastucture.Helpers;

namespace ProjectManagementSystem.Infrastucture.Data;

public class ProjectManagementSystemDbContext(DbContextOptions options) : DbContext(options), IProjectManagementSystemRepository
{
    public IQueryable<Project> Projects => Set<Project>();
    public IQueryable<ProjectStage> ProjectStages => Set<ProjectStage>();
    public IQueryable<Student> Students => Set<Student>();
    public IQueryable<Discipline> Disciplines => Set<Discipline>();
    public IQueryable<Group> Groups => Set<Group>();
    public IQueryable<StudentProjectStage> StudentProjectStages => Set<StudentProjectStage>();
    public IQueryable<PinnedFile> PinnedFiles => Set<PinnedFile>();

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
        modelBuilder.ApplyConfiguration();

        base.OnModelCreating(modelBuilder);
    }
}