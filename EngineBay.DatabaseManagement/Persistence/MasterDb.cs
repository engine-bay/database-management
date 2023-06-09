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
            var dbContexts = new List<IModuleDbContext>();

            dbContexts.Add(new ActorEngineDbContext(dbOptions));
            dbContexts.Add(new BlueprintsDbContext(dbOptions));
            dbContexts.Add(new AuthenticationDbContext(dbOptions));

            foreach (var dbContext in dbContexts)
            {
                dbContext.MasterOnModelCreating(modelBuilder);
                dbContext.Dispose();
            }
        }
    }
}