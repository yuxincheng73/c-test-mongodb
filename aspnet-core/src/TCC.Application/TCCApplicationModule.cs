using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using TCC.Authorization;

namespace TCC
{
    [DependsOn(
        typeof(TCCCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class TCCApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<TCCAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(TCCApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddProfiles(thisAssembly)
            );
        }
    }
}
