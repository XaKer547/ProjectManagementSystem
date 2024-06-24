using MassTransit;
using Microsoft.EntityFrameworkCore;
using ProjectManagementSystem.Domain.Groups;
using ProjectManagementSystem.Domain.Students;
using ProjectManagementSystem.Infrastucture.Data;
using SmartCollege.RabbitMQ.Contracts.Students;

namespace ProjectManagementSystem.API.Consumers.Students;

public class StudentUpdatedConsumer(ProjectManagementSystemDbContext dbContext) : IConsumer<IStudentUpdated>
{
    private readonly ProjectManagementSystemDbContext dbContext = dbContext;

    public async Task Consume(ConsumeContext<IStudentUpdated> context)
    {
        var message = context.Message;

        var studentId = new StudentId(message.Id);

        var groupId = new GroupId(message.GroupId);

        var group = await dbContext.Groups.SingleOrDefaultAsync(g => g.Id == groupId);

        if (group is null)
            return;

        var student = await dbContext.Students.SingleOrDefaultAsync(s => s.Id == studentId);

        if (student is null)
            return;

        student.Update(message.FirstName, message.MiddleName, message.LastName, group);

        dbContext.Update(student);

        await dbContext.SaveChangesAsync();
    }
}