using System.Threading.Tasks;
using TCC.Configuration.Dto;

namespace TCC.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
