using MassTransit;
using ProjectManagementSystem.Domain.Disciplines;
using ProjectManagementSystem.Infrastucture.Data;
using SmartCollege.RabbitMQ.Contracts.Disciplines;

namespace ProjectManagementSystem.Infrastucture.Consumers.Disciplines;

public class DisciplineCreatedConsumer(ProjectManagementSystemDbContext dbContext) : IConsumer<IDisciplineCreated>
{
    private readonly ProjectManagementSystemDbContext dbContext = dbContext;

    public async Task Consume(ConsumeContext<IDisciplineCreated> context)
    {
        var message = context.Message;

        var disciplineId = new DisciplineId(message.Id);

        var discipline = Discipline.Create(disciplineId, message.Name);

        dbContext.Add(discipline);

        await dbContext.SaveChangesAsync();
    }
}