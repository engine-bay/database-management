namespace EngineBay.DatabaseManagement
{
    using EngineBay.Persistence;
    using Microsoft.EntityFrameworkCore;

    public class DbContextOptionsFactory : IDbContextOptionsFactory
    {
        public DbContextOptions<TDbContext> GetDbContextOptions<TDbContext>()
           where TDbContext : DbContext
        {
            var databaseProvider = BaseDatabaseConfiguration.GetDatabaseProvider();
            var optionsBuilder = new DbContextOptionsBuilder<TDbContext>();

            switch (databaseProvider)
            {
                case DatabaseProviderTypes.InMemory:
                case DatabaseProviderTypes.SQLite:
                    optionsBuilder.UseSqlite();
                    break;
                case DatabaseProviderTypes.SqlServer:
                    optionsBuilder.UseSqlServer();
                    break;
                case DatabaseProviderTypes.Postgres:
                    optionsBuilder.UseNpgsql();
                    break;
            }

            return optionsBuilder.Options;
        }
    }
}