using MassTransit;
using Microsoft.EntityFrameworkCore;
using ProjectManagementSystem.Domain.Groups;
using ProjectManagementSystem.Infrastucture.Data;
using SmartCollege.RabbitMQ.Contracts.Groups;

namespace ProjectManagementSystem.Infrastucture.Consumers.Groups;

public class GroupUpdatedConsumer(ProjectManagementSystemDbContext dbContext) : IConsumer<IGroupUpdated>
{
    private readonly ProjectManagementSystemDbContext dbContext = dbContext;

    public async Task Consume(ConsumeContext<IGroupUpdated> context)
    {
        var message = context.Message;

        var groupId = new GroupId(message.Id);

        var group = await dbContext.Groups.SingleAsync(g => g.Id == groupId);

        group.Update(message.Name);

        dbContext.Update(group);

        await dbContext.SaveChangesAsync();
    }
}