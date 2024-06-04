using MassTransit;
using Microsoft.EntityFrameworkCore;
using ProjectManagementSystem.Domain.Disciplines;
using ProjectManagementSystem.Infrastucture.Data;
using SmartCollege.RabbitMQ.Contracts.Disciplines;

namespace ProjectManagementSystem.API.Consumers.Disciplines;

public class DisciplineDeletedConsumer(ProjectManagementSystemDbContext dbContext) : IConsumer<IDisciplineDeleted>
{
    private readonly ProjectManagementSystemDbContext dbContext = dbContext;

    public async Task Consume(ConsumeContext<IDisciplineDeleted> context)
    {
        var message = context.Message;

        var disciplineId = new DisciplineId(message.Id);

        var discipline = await dbContext.Disciplines.SingleAsync(d => d.Id == disciplineId);

        discipline.Delete();

        dbContext.Update(discipline);

        await dbContext.SaveChangesAsync();
    }
}