namespace EngineBay.DatabaseManagement
{
    using EngineBay.Authentication;
    using EngineBay.Blueprints;
    using EngineBay.Persistence;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

    public class DbInitialiser
    {
        private readonly ILogger<DbInitialiser> logger;
        private readonly MasterDb masterDb;
        private readonly MasterSqliteDb masterSqliteDb;
        private readonly MasterSqlServerDb masterSqlServerDb;

        private readonly MasterPostgresDb masterPostgresDb;

        public DbInitialiser(
            ILogger<DbInitialiser> logger,
            MasterDb masterDb,
            MasterSqliteDb masterSqliteDb,
            MasterSqlServerDb masterSqlServerDb,
            MasterPostgresDb masterPostgresDb)
        {
            this.logger = logger;
            this.masterDb = masterDb;
            this.masterSqliteDb = masterSqliteDb;
            this.masterSqlServerDb = masterSqlServerDb;
            this.masterPostgresDb = masterPostgresDb;
        }

        public void Run(ICollection<string>? seedFilePaths)
        {
            this.logger.InitializingDatabase();

            var databaseProvider = BaseDatabaseConfiguration.GetDatabaseProvider();
            var shouldResetDatabase = BaseDatabaseConfiguration.IsDatabaseReset();
            var shouldReseedDatabase = BaseDatabaseConfiguration.IsDatabaseReseeded();

            if (shouldResetDatabase)
            {
                // For development and testing we want to be able to delete and recreate each time on startup for a deterministc state.
                this.logger.DeletingDatabase();

                this.masterDb.Database.EnsureDeleted();
            }

            this.ApplyMigrations(databaseProvider);

            if (shouldResetDatabase || shouldReseedDatabase)
            {
                this.logger.CreatingRootSystemUser();

                var systemUser = new SystemUser();
                this.masterDb.ApplicationUsers.Add(systemUser);
                this.masterDb.SaveChanges(systemUser);

                this.logger.SeedingDatabase();

                // Seed initial data from JSON files
                var settings = new JsonSerializerSettings
                {
                    ContractResolver = new PrivateSetterContractResolver(),
                };

                if (seedFilePaths is not null)
                {
                    foreach (var filePath in seedFilePaths)
                    {
                        List<Workbook>? workbooks = JsonConvert.DeserializeObject<List<Workbook>>(File.ReadAllText(filePath));
                        if (workbooks is not null)
                        {
                            this.masterDb.AddRange(workbooks);
                        }
                    }

                    this.masterDb.SaveChanges(systemUser);
                }
            }
        }

        private void ApplyMigrations(DatabaseProviderTypes databaseProvider)
        {
            this.logger.ApplyingDatabaseMigrations(databaseProvider);

            switch (databaseProvider)
            {
                case DatabaseProviderTypes.InMemory:
                case DatabaseProviderTypes.SQLite:
                    this.masterSqliteDb.Database.Migrate();
                    break;
                case DatabaseProviderTypes.SqlServer:
                    this.masterSqlServerDb.Database.Migrate();
                    break;
                case DatabaseProviderTypes.Postgres:
                    this.masterPostgresDb.Database.Migrate();
                    break;
                default:
                    throw new ArgumentException($"Unhandled {EngineBay.Persistence.EnvironmentVariableConstants.DATABASEPROVIDER} configuration of '{databaseProvider}'.");
            }

            this.logger.DatabaseMigrationsComplete();
        }
    }
}