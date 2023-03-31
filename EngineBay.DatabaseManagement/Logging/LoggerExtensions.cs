namespace EngineBay.DatabaseManagement
{
    using EngineBay.Persistence;

    internal static class LoggerExtensions
    {
        private static readonly Action<ILogger, Exception?> InitializingDatabaseValue = LoggerMessage.Define(
            logLevel: LogLevel.Information,
            eventId: 1,
            formatString: "Initializing database...");

        private static readonly Action<ILogger, Exception?> DeletingDatabaseValue = LoggerMessage.Define(
            logLevel: LogLevel.Warning,
            eventId: 2,
            formatString: "Deleting database...");

        private static readonly Action<ILogger, Exception?> SeedingDatabaseValue = LoggerMessage.Define(
            logLevel: LogLevel.Information,
            eventId: 3,
            formatString: "Seeding database...");

        private static readonly Action<ILogger, DatabaseProviderTypes, Exception?> ApplyingDatabaseMigrationsValue = LoggerMessage.Define<DatabaseProviderTypes>(
            logLevel: LogLevel.Information,
            eventId: 4,
            formatString: "Applying {DatabaseProvider} database migrations.");

        private static readonly Action<ILogger, Exception?> DatabaseMigrationsCompleteValue = LoggerMessage.Define(
            logLevel: LogLevel.Information,
            eventId: 5,
            formatString: "Database migrations complete.");

        private static readonly Action<ILogger, Exception?> CreatingRootSystemUserValue = LoggerMessage.Define(
            logLevel: LogLevel.Information,
            eventId: 6,
            formatString: "Creating root system user.");

        public static void InitializingDatabase(this ILogger logger)
        {
            InitializingDatabaseValue(logger, null);
        }

        public static void DeletingDatabase(this ILogger logger)
        {
            DeletingDatabaseValue(logger, null);
        }

        public static void SeedingDatabase(this ILogger logger)
        {
            SeedingDatabaseValue(logger, null);
        }

        public static void ApplyingDatabaseMigrations(this ILogger logger, DatabaseProviderTypes databaseProvider)
        {
            ApplyingDatabaseMigrationsValue(logger, databaseProvider, null);
        }

        public static void DatabaseMigrationsComplete(this ILogger logger)
        {
            DatabaseMigrationsCompleteValue(logger, null);
        }

        public static void CreatingRootSystemUser(this ILogger logger)
        {
            CreatingRootSystemUserValue(logger, null);
        }
    }
}