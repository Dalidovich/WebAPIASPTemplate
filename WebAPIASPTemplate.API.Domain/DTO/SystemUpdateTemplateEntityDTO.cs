using WebAPIASPTemplate.API.Domain.Enums;

namespace WebAPIASPTemplate.API.Domain.DTO
{
    public class SystemUpdateTemplateEntityDTO
    {
        public Guid? Id { get; set; }
        public TemplateEntityStatus Status { get; set; }
        public bool IsExist { get; set; }
        public int Number { get; set; }
    }
}
