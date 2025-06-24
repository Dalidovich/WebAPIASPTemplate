using Microsoft.EntityFrameworkCore;
using WebAPIASPTemplate.API.BLL.Services;
using WebAPIASPTemplate.API.DAL;

namespace WebAPIASPTemplate.API.HostedServices
{
    public class EnterSeedDataHostedService : IHostedService
    {
        private readonly IServiceProvider _serviceProvider;

        public EnterSeedDataHostedService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using var scope = _serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<AppDBContext>();
            var registrationService = scope.ServiceProvider.GetRequiredService<TemplateEntityService>();
            if (!await context.TemplateEntities.AnyAsync())
            {
                var clientId1 = await registrationService.CreateTemplateEntity(new()
                {
                    Title = "First title",
                    Content = "First content",
                    Status = Domain.Enums.TemplateEntityStatus.created
                });
            }
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }
}
