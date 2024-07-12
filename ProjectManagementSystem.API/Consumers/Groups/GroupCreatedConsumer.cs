using MassTransit;
using ProjectManagementSystem.Domain.Groups;
using ProjectManagementSystem.Infrastucture.Data;
using SmartCollege.RabbitMQ.Contracts.Groups;

namespace ProjectManagementSystem.API.Consumers.Groups;

public class GroupCreatedConsumer(ProjectManagementSystemDbContext dbContext) : IConsumer<IGroupCreated>
{
    private readonly ProjectManagementSystemDbContext dbContext = dbContext;

    public async Task Consume(ConsumeContext<IGroupCreated> context)
    {
        var message = context.Message;

        var groupId = new GroupId(message.Id);

        var group = Group.Create(groupId, message.Name);

        dbContext.Add(group);

        await dbContext.SaveChangesAsync();
    }
}