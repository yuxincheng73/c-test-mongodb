using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace TCC.Controllers
{
    public abstract class TCCControllerBase: AbpController
    {
        protected TCCControllerBase()
        {
            LocalizationSourceName = TCCConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
