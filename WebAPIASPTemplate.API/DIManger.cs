using Microsoft.AspNetCore.OData;
using Microsoft.OData.ModelBuilder;
using WebAPIASPTemplate.API.BLL.Interfaces;
using WebAPIASPTemplate.API.BLL.Services;
using WebAPIASPTemplate.API.DAL.Repositories.Implements;
using WebAPIASPTemplate.API.DAL.Repositories.Interfaces;
using WebAPIASPTemplate.API.Domain.Entities;
using WebAPIASPTemplate.API.Midlaware;

namespace WebAPIASPTemplate.API
{
    public static class DIManger
    {
        public static void AddRepositores(this WebApplicationBuilder webApplicationBuilder)
        {
            webApplicationBuilder.Services.AddScoped<ITemplateEntityRepositories, TemplateEntityRepositories>();
        }

        public static void AddServices(this WebApplicationBuilder webApplicationBuilder)
        {
            webApplicationBuilder.Services.AddScoped<ITemplateEntityService, TemplateEntityService>();
        }

        public static void AddODataProperty(this WebApplicationBuilder webApplicationBuilder)
        {
            var odataBuilder = new ODataConventionModelBuilder();
            odataBuilder.EntitySet<TemplateEntity>("TemplateEntity");

            webApplicationBuilder.Services.AddControllers().AddOData(opt =>
            {
                opt.Count().Filter().Expand().Select().OrderBy().SetMaxTop(5000);
                opt.TimeZone = TimeZoneInfo.Utc;
            });
        }

        public static void AddMiddleware(this WebApplication webApplication)
        {
            webApplication.UseMiddleware<ExceptionHandlingMiddleware>();
            webApplication.UseMiddleware<CheckDBMiddleware>();
        }
    }
}
