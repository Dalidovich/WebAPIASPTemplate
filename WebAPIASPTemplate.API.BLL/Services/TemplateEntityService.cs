using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using WebAPIASPTemplate.API.BLL.Interfaces;
using WebAPIASPTemplate.API.DAL.Repositories.Interfaces;
using WebAPIASPTemplate.API.Domain.DTO;
using WebAPIASPTemplate.API.Domain.Entities;
using WebAPIASPTemplate.API.Domain.Enums;
using WebAPIASPTemplate.API.Domain.InnerResponse;

namespace WebAPIASPTemplate.API.BLL.Services
{
    public class TemplateEntityService : ITemplateEntityService
    {
        private readonly ITemplateEntityRepositories _templateEntityRepositories;

        public TemplateEntityService(ITemplateEntityRepositories templateEntityRepositories)
        {
            _templateEntityRepositories = templateEntityRepositories;
        }

        public async Task<BaseResponse<TemplateEntity>> CreateTemplateEntity(CreateTemplateEntityDTO templateEntity)
        {
            var createdTemplateEntity = await _templateEntityRepositories.AddAsync(new TemplateEntity(templateEntity));
            await _templateEntityRepositories.SaveAsync();

            return new StandartResponse<TemplateEntity>()
            {
                Data = createdTemplateEntity,
                InnerStatusCode = InnerStatusCode.TemplateEntityCreate
            };
        }

        public async Task<BaseResponse<bool>> DeleteTemplateEntity(Guid deleteId)
        {
            var response = await _templateEntityRepositories.Delete(deleteId);

            return new StandartResponse<bool>()
            {
                Data = response,
                InnerStatusCode = InnerStatusCode.TemplateEntityDelete
            };
        }

        public async Task<BaseResponse<TemplateEntity>> GetTemplateEntity(Expression<Func<TemplateEntity, bool>> expression)
        {
            var entity = await _templateEntityRepositories.GetAll().SingleOrDefaultAsync(expression);
            if (entity == null)
            {
                return new StandartResponse<TemplateEntity>()
                {
                    InnerStatusCode = InnerStatusCode.EntityNotFound
                };
            }

            return new StandartResponse<TemplateEntity>()
            {
                Data = entity,
                InnerStatusCode = InnerStatusCode.TemplateEntityRead
            };
        }

        public BaseResponse<IQueryable<TemplateEntity>> GetTemplateEntityOData()
        {
            var contents = _templateEntityRepositories.GetAll();

            return new StandartResponse<IQueryable<TemplateEntity>>()
            {
                Data = contents,
                InnerStatusCode = InnerStatusCode.TemplateEntityRead
            };
        }

        public async Task<BaseResponse<IEnumerable<TemplateEntity>>> GetTemplateEntities(Expression<Func<TemplateEntity, bool>> expression)
        {
            var entities = await _templateEntityRepositories.GetAll().Where(expression).ToListAsync();

            return new StandartResponse<IEnumerable<TemplateEntity>>()
            {
                Data = entities,
                InnerStatusCode = InnerStatusCode.TemplateEntityRead
            };
        }

        public async Task<BaseResponse<TemplateEntity>> UpdateTemplateEntity(UserUpdateTemplateEntityDTO updateTemplateEntityDTO)
        {
            var updateEntity = await _templateEntityRepositories.GetAll().Where(x => x.Id == updateTemplateEntityDTO.Id).SingleOrDefaultAsync();

            if (updateEntity == null)
            {
                return new StandartResponse<TemplateEntity>()
                {
                    Data = updateEntity,
                    InnerStatusCode = InnerStatusCode.EntityNotFound
                };
            }

            updateEntity.PutUpdateData(updateTemplateEntityDTO);
            _templateEntityRepositories.Update(updateEntity);
            await _templateEntityRepositories.SaveAsync();

            return new StandartResponse<TemplateEntity>()
            {
                Data = updateEntity,
                InnerStatusCode = InnerStatusCode.TemplateEntityUpdate
            };
        }
    }
}
