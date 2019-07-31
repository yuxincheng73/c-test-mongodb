using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using TCC.Configuration.Dto;

namespace TCC.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : TCCAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
