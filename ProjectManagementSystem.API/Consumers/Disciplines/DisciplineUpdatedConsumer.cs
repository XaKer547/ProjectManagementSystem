using MassTransit;
using Microsoft.EntityFrameworkCore;
using ProjectManagementSystem.Domain.Disciplines;
using ProjectManagementSystem.Infrastucture.Data;
using SmartCollege.RabbitMQ.Contracts.Disciplines;

namespace ProjectManagementSystem.Infrastucture.Consumers.Disciplines;

public class DisciplineUpdatedConsumer(ProjectManagementSystemDbContext dbContext) : IConsumer<IDisciplineUpdated>
{
    private readonly ProjectManagementSystemDbContext dbContext = dbContext;

    public async Task Consume(ConsumeContext<IDisciplineUpdated> context)
    {
        var message = context.Message;

        var disciplineId = new DisciplineId(message.Id);

        var discipline = await dbContext.Disciplines.SingleOrDefaultAsync(d => d.Id == disciplineId);

        if (discipline == null)
            return;

        discipline.Update(message.Name);

        dbContext.Update(discipline);

        await dbContext.SaveChangesAsync();
    }
}