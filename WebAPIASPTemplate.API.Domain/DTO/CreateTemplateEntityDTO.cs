using WebAPIASPTemplate.API.Domain.Enums;

namespace WebAPIASPTemplate.API.Domain.DTO
{
    public class CreateTemplateEntityDTO
    {
        public string? Title { get; set; }
        public string? Content { get; set; }
        public TemplateEntityStatus Status { get; set; }
    }
}
