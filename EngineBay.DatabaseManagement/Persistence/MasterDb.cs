namespace EngineBay.DatabaseManagement
{
    using EngineBay.ActorEngine;
    using EngineBay.Authentication;
    using EngineBay.Blueprints;
    using EngineBay.Persistence;
    using Microsoft.EntityFrameworkCore;

    public class MasterDb : ModuleWriteDbContext
    {
        public MasterDb(DbContextOptions<ModuleWriteDbContext> options)
            : base(options)
        {
        }

        protected virtual IReadOnlyCollection<IModuleDbContext> GetRegisteredDbContexts(DbContextOptions<ModuleWriteDbContext> dbOptions)
        {
            return new List<IModuleDbContext>();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var dbOptionsBuilder = new DbContextOptionsBuilder<ModuleWriteDbContext>();

            var databaseProvider = BaseDatabaseConfiguration.GetDatabaseProvider();

            switch (databaseProvider)
            {
                case DatabaseProviderTypes.InMemory:
                case DatabaseProviderTypes.SQLite:
                    dbOptionsBuilder.UseSqlite();
                    break;
                case DatabaseProviderTypes.SqlServer:
                    dbOptionsBuilder.UseSqlServer();
                    break;
                case DatabaseProviderTypes.Postgres:
                    dbOptionsBuilder.UseNpgsql();
                    break;
                default:
                    throw new ArgumentException($"Unhandled {EngineBay.Persistence.EnvironmentVariableConstants.DATABASEPROVIDER} configuration of '{databaseProvider}'.");
            }

            var dbOptions = dbOptionsBuilder.Options;

            var dbContexts = this.GetRegisteredDbContexts(dbOptions);

            foreach (var dbContext in dbContexts)
            {
                dbContext.MasterOnModelCreating(modelBuilder);
                dbContext.Dispose();
            }
        }
    }
}