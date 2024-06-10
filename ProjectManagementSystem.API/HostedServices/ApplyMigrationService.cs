using Microsoft.EntityFrameworkCore;
using ProjectManagementSystem.Infrastucture.Data;

namespace ProjectManagementSystem.Infrastucture.HostedServices
{
    public class ApplyMigrationService : IHostedService
    {
        private readonly IServiceProvider _serviceProvider;

        public ApplyMigrationService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var service = scope.ServiceProvider;
                var dbContext = service.GetRequiredService<ProjectManagementSystemDbContext>();

                var pendingMigration = await dbContext.Database.GetPendingMigrationsAsync(cancellationToken);

                if (pendingMigration.Any())
                    await dbContext.Database.MigrateAsync(cancellationToken);
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
