using System.Threading.Tasks;
using Abp.Application.Services;
using TCC.Sessions.Dto;

namespace TCC.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
