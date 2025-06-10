using Microsoft.EntityFrameworkCore;
using WebAPIASPTemplate.API.DAL;
using WebAPIASPTemplate.API.Domain.Enums;

namespace WebAPIASPTemplate.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.AddRepositores();
            builder.AddServices();
            builder.AddODataProperty();
            builder.Services.AddDbContext<AppDBContext>(opt => opt.UseNpgsql(
                builder.Configuration.GetConnectionString(StandartConst.NameConnection)));

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();

            app.AddMiddleware();

            app.MapControllers();
            app.Run();
        }
    }
}
