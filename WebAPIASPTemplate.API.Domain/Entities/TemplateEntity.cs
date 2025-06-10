using WebAPIASPTemplate.API.Domain.DTO;
using WebAPIASPTemplate.API.Domain.Enums;

namespace WebAPIASPTemplate.API.Domain.Entities
{
    public class TemplateEntity
    {
        public Guid? Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreateDate { get; set; }
        public TemplateEntityStatus Status { get; set; }
        public bool IsExist { get; set; }
        public int Number { get; set; }

        public TemplateEntity()
        {
        }

        public TemplateEntity(CreateTemplateEntityDTO createTemplateEntityDTO)
        {
            Title = createTemplateEntityDTO.Title ?? "";
            Content = createTemplateEntityDTO.Content ?? "";
            CreateDate = DateTime.Now;
            Status = createTemplateEntityDTO.Status;
            IsExist = true;
            Number = 0;
        }
    }
}
