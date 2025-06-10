using System.Reflection;
using Microsoft.EntityFrameworkCore;
using WebAPIASPTemplate.API.Domain.Entities;

namespace WebAPIASPTemplate.API.DAL
{
    public class AppDBContext : DbContext
    {
        public DbSet<TemplateEntity> TemplateEntities { get; set; }

        public void UpdateDatabase()
        {
            //add-migration create -context AppDBContext
            //update - database

            Database.EnsureDeleted();
            Database.Migrate();
        }

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }

        public AppDBContext()
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
