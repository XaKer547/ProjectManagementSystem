using MassTransit;
using Microsoft.EntityFrameworkCore;
using ProjectManagementSystem.Domain.Students;
using ProjectManagementSystem.Infrastucture.Data;
using SmartCollege.RabbitMQ.Contracts.Students;

namespace ProjectManagementSystem.API.Consumers.Students;

public class StudentDeletedConsumer(ProjectManagementSystemDbContext dbContext) : IConsumer<IStudentDeleted>
{
    private readonly ProjectManagementSystemDbContext dbContext = dbContext;

    public async Task Consume(ConsumeContext<IStudentDeleted> context)
    {
        var message = context.Message;

        var studentId = new StudentId(message.Id);

        var student = await dbContext.Students.SingleAsync(s => s.Id == studentId);

        student.Delete();

        dbContext.Update(student);

        await dbContext.SaveChangesAsync();
    }
}
