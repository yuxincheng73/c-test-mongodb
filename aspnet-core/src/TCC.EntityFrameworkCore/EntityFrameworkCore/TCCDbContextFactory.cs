using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using TCC.Configuration;
using TCC.Web;

namespace TCC.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class TCCDbContextFactory : IDesignTimeDbContextFactory<TCCDbContext>
    {
        public TCCDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<TCCDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            TCCDbContextConfigurer.Configure(builder, configuration.GetConnectionString(TCCConsts.ConnectionStringName));

            return new TCCDbContext(builder.Options);
        }
    }
}
