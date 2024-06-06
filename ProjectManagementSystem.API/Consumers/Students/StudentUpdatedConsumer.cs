using MassTransit;
using Microsoft.EntityFrameworkCore;
using ProjectManagementSystem.API.Validators.Models;
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

        var group = await dbContext.Groups.SingleAsync(g => g.Id == groupId);

        var student = await dbContext.Students.SingleAsync(s => s.Id == studentId);

        student.Update(message.FirstName, message.MiddleName, message.LastName, group);
    }
}