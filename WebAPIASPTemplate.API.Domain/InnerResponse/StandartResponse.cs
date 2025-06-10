using WebAPIASPTemplate.API.Domain.Enums;

namespace WebAPIASPTemplate.API.Domain.InnerResponse
{
    public class StandartResponse<T> : BaseResponse<T>
    {
        public override string Message { get; set; } = null!;
        public override InnerStatusCode InnerStatusCode { get; set; }
        public override T Data { get; set; }
    }
}
