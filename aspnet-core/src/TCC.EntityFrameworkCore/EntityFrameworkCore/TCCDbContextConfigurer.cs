using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace TCC.EntityFrameworkCore
{
    public static class TCCDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<TCCDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<TCCDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
