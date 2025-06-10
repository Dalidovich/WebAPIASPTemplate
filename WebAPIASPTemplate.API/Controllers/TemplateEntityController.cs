using Microsoft.AspNetCore.Mvc;
using WebAPIASPTemplate.API.BLL.Interfaces;
using WebAPIASPTemplate.API.Domain.DTO;

namespace WebAPIASPTemplate.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TemplateEntityController : ControllerBase
    {
        private readonly ITemplateEntityService _templateEntityService;

        public TemplateEntityController(ITemplateEntityService templateEntityService)
        {
            _templateEntityService = templateEntityService;
        }

        [HttpPost("create/")]
        public async Task<IActionResult> CreateTemplateEntity([FromQuery] CreateTemplateEntityDTO templateEntityDTO)
        {
            if (templateEntityDTO == null)
            {

                return BadRequest();
            }
            var resourse = await _templateEntityService.CreateTemplateEntity(templateEntityDTO);
            if (resourse.InnerStatusCode == Domain.Enums.InnerStatusCode.TemplateEntityCreate)
            {
                return Ok(resourse.Data);
            }

            return StatusCode(500);
        }

        [HttpGet("read/")]
        public async Task<IActionResult> ReadTemplateEntities()
        {
            var resourse = await _templateEntityService.GetTemplateEntities(x => x.Id != null);
            if (resourse.InnerStatusCode == Domain.Enums.InnerStatusCode.TemplateEntityRead)
            {
                return Ok(resourse.Data);
            }

            return StatusCode(500);
        }

        [HttpDelete("delete/")]
        public async Task<IActionResult> DeleteTemplateEntities([FromQuery] Guid deleteId)
        {
            var resourse = await _templateEntityService.DeleteTemplateEntity(deleteId);
            if (resourse.InnerStatusCode == Domain.Enums.InnerStatusCode.TemplateEntityDelete)
            {
                return Ok(resourse.Data);
            }

            return StatusCode(500);
        }

        [HttpPut("update/")]
        public async Task<IActionResult> UpdateTemplateEntities([FromQuery] UserUpdateTemplateEntityDTO userUpdateTemplateEntityDTO)
        {
            var resourse = await _templateEntityService.UpdateTemplateEntity(userUpdateTemplateEntityDTO);
            if (resourse.InnerStatusCode == Domain.Enums.InnerStatusCode.TemplateEntityUpdate)
            {
                return Ok(resourse.Data);
            }

            return StatusCode(500);
        }
    }
}
