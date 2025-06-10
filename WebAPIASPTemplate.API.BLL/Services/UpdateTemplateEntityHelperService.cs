using WebAPIASPTemplate.API.Domain.DTO;
using WebAPIASPTemplate.API.Domain.Entities;

namespace WebAPIASPTemplate.API.BLL.Services
{
    public static class UpdateTemplateEntityHelperService
    {
        public static TemplateEntity PutUpdateData(this TemplateEntity templateEntity, UserUpdateTemplateEntityDTO updateData)
        {
            return new UpdateTemplateEntityBuilder(templateEntity)
                .BuildContent(updateData.Content)
                .BuildTitle(updateData.Title)
                .Build();
        }
    }
}
