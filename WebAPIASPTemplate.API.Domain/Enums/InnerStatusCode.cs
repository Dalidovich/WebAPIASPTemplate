namespace WebAPIASPTemplate.API.Domain.Enums
{
    public enum InnerStatusCode
    {
        EntityNotFound = 0,

        TemplateEntityCreate = 1,
        TemplateEntityUpdate = 2,
        TemplateEntityDelete = 3,
        TemplateEntityRead = 4,
        TemplateEntityExist = 5,

        OK = 200,
        OKNoContent = 204,
        InternalServerError = 500,
    }
}
