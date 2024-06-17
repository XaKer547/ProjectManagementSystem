using MassTransit;
using Microsoft.EntityFrameworkCore;
using ProjectManagementSystem.Domain.Groups;
using ProjectManagementSystem.Domain.Students;
using ProjectManagementSystem.Infrastucture.Data;
using SmartCollege.RabbitMQ.Contracts.Students;

namespace ProjectManagementSystem.Infrastucture.Consumers.Students;

public class StudentCreatedConsumer(ProjectManagementSystemDbContext dbContext) : IConsumer<IStudentCreated>
{
    private readonly ProjectManagementSystemDbContext dbContext = dbContext;

    public async Task Consume(ConsumeContext<IStudentCreated> context)
    {
        var message = context.Message;

        var groupId = new GroupId(message.GroupId);

        var group = await dbContext.Groups.SingleAsync(g => g.Id == groupId);

        var studentId = new StudentId(message.Id);

        var student = Student.Create(studentId, message.FirstName, message.MiddleName, message.LastName, group);

        dbContext.Add(student);

        await dbContext.SaveChangesAsync();
    }
}
