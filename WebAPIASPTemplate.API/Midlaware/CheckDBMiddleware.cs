using Microsoft.EntityFrameworkCore;
using Npgsql;
using WebAPIASPTemplate.API.DAL;

namespace WebAPIASPTemplate.API.Midlaware
{
    public class CheckDBMiddleware
    {
        private readonly RequestDelegate _next;

        public CheckDBMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                if (!await httpContext.RequestServices.GetService<AppDBContext>().TemplateEntities.AnyAsync())
                {
                    httpContext.RequestServices.GetService<AppDBContext>().UpdateDatabase();
                }
            }
            catch (PostgresException ex)
            {
                if (ex.SqlState == "42P01")
                {
                    httpContext.RequestServices.GetService<AppDBContext>().UpdateDatabase();
                }
                throw ex;
            }
            await _next.Invoke(httpContext);
        }
    }
}
