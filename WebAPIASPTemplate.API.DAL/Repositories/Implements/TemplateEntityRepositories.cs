using Microsoft.EntityFrameworkCore;
using WebAPIASPTemplate.API.DAL.Repositories.Interfaces;
using WebAPIASPTemplate.API.Domain.Entities;

namespace WebAPIASPTemplate.API.DAL.Repositories.Implements
{
    public class TemplateEntityRepositories : ITemplateEntityRepositories
    {
        private readonly AppDBContext _db;

        public TemplateEntityRepositories(AppDBContext db)
        {
            _db = db;
        }

        public async Task<TemplateEntity> AddAsync(TemplateEntity entity)
        {
            var createdEntity = await _db.TemplateEntities.AddAsync(entity);

            return createdEntity.Entity;
        }

        public async Task<bool> Delete(Guid deleteId)
        {
            await _db.TemplateEntities.Where(x => x.Id == deleteId).ExecuteDeleteAsync();

            return true;
        }

        public IQueryable<TemplateEntity> GetAll()
        {
            return _db.TemplateEntities;
        }

        public async Task<bool> SaveAsync()
        {
            await _db.SaveChangesAsync();

            return true;
        }

        public TemplateEntity Update(TemplateEntity entity)
        {
            var updatedEntity = _db.TemplateEntities.Update(entity);

            return updatedEntity.Entity;
        }
    }
}
