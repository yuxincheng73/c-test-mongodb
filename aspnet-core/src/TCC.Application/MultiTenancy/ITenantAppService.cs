using Abp.Application.Services;
using Abp.Application.Services.Dto;
using TCC.MultiTenancy.Dto;

namespace TCC.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

