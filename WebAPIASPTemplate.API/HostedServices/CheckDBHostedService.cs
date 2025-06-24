﻿using Microsoft.EntityFrameworkCore;
using Npgsql;
using WebAPIASPTemplate.API.DAL;

namespace WebAPIASPTemplate.API.HostedServices
{
    public class CheckDBHostedService : IHostedService
    {
        private readonly IServiceProvider _serviceProvider;

        public CheckDBHostedService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using var scope = _serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<AppDBContext>();
            try
            {
                await context.TemplateEntities.AnyAsync();
            }
            catch (PostgresException ex)
            {
                if (ex.SqlState == "42P01" || ex.SqlState == "3D000")
                {
                    context.Database.Migrate();
                }
            }
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }
}
