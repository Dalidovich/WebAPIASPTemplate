using System.Linq.Expressions;
using WebAPIASPTemplate.API.Domain.DTO;
using WebAPIASPTemplate.API.Domain.Entities;
using WebAPIASPTemplate.API.Domain.InnerResponse;

namespace WebAPIASPTemplate.API.BLL.Interfaces
{
    public interface ITemplateEntityService
    {
        public Task<BaseResponse<TemplateEntity>> GetTemplateEntity(Expression<Func<TemplateEntity, bool>> expression);
        public Task<BaseResponse<IEnumerable<TemplateEntity>>> GetTemplateEntities(Expression<Func<TemplateEntity, bool>> expression);
        public Task<BaseResponse<TemplateEntity>> CreateTemplateEntity(CreateTemplateEntityDTO templateEntity);
        public Task<BaseResponse<TemplateEntity>> UpdateTemplateEntity(UserUpdateTemplateEntityDTO updateTemplateEntityDTO);
        public Task<BaseResponse<bool>> DeleteTemplateEntity(Guid deleteId);
        public BaseResponse<IQueryable<TemplateEntity>> GetTemplateEntityOData();
    }
}
