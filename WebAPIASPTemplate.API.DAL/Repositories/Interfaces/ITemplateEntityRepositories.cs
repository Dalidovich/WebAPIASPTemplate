using WebAPIASPTemplate.API.Domain.Entities;

namespace WebAPIASPTemplate.API.DAL.Repositories.Interfaces
{
    public interface ITemplateEntityRepositories
    {
        public Task<TemplateEntity> AddAsync(TemplateEntity entity);
        public TemplateEntity Update(TemplateEntity entity);
        public Task<bool> Delete(Guid deleteId);
        public IQueryable<TemplateEntity> GetAll();
        public Task<bool> SaveAsync();
    }
}
