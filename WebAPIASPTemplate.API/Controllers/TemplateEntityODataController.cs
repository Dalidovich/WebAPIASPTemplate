using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using WebAPIASPTemplate.API.BLL.Interfaces;
using WebAPIASPTemplate.API.Domain.Entities;

namespace WebAPIASPTemplate.API.Controllers
{
    public class TemplateEntityODataController : ODataController
    {
        private readonly ITemplateEntityService _templateEntityService;

        public TemplateEntityODataController(ITemplateEntityService templateEntityService)
        {
            _templateEntityService = templateEntityService;
        }

        [HttpGet("odata/TemplateEntity")]
        [EnableQuery]
        public IQueryable<TemplateEntity> GetTemplateEntities()
        {
            return _templateEntityService.GetTemplateEntityOData().Data;
        }
    }
}
