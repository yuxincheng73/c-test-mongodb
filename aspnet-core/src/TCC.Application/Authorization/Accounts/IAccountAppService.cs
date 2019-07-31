using System.Threading.Tasks;
using Abp.Application.Services;
using TCC.Authorization.Accounts.Dto;

namespace TCC.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
