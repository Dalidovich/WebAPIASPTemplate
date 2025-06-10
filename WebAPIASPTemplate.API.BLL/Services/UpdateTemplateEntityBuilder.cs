using WebAPIASPTemplate.API.Domain.Entities;
using WebAPIASPTemplate.API.Domain.Enums;

namespace WebAPIASPTemplate.API.BLL.Services
{
    public class UpdateTemplateEntityBuilder
    {
        private TemplateEntity _Instance;
        private UpdateTemplateEntityBuilder _InstanceBuilder;

        public UpdateTemplateEntityBuilder(TemplateEntity templateEntity)
        {
            _Instance = templateEntity;
            _InstanceBuilder = this;
        }

        public UpdateTemplateEntityBuilder BuildTitle(string? title)
        {
            _Instance.Title = title ?? _Instance.Title;

            return _InstanceBuilder;
        }

        public UpdateTemplateEntityBuilder BuildContent(string? content)
        {
            _Instance.Content = content ?? _Instance.Content;

            return _InstanceBuilder;
        }

        public UpdateTemplateEntityBuilder BuildStatus(TemplateEntityStatus? status)
        {
            _Instance.Status = status ?? _Instance.Status;

            return _InstanceBuilder;
        }

        public UpdateTemplateEntityBuilder BuildIsIncludedInResponseProcessing(bool? isExist)
        {
            _Instance.IsExist = isExist ?? _Instance.IsExist;

            return _InstanceBuilder;
        }

        public UpdateTemplateEntityBuilder BuildNumber(int? number)
        {
            _Instance.Number = number ?? _Instance.Number;

            return _InstanceBuilder;
        }

        public TemplateEntity Build() => _Instance;
    }
}
