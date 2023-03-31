namespace EngineBay.DatabaseManagement
{
    using EngineBay.Core;
    using EngineBay.Persistence;

    public class DatabaseManagementModule : IModule
    {
        /// <inheritdoc/>
        public IServiceCollection RegisterModule(IServiceCollection services, IConfiguration configuration)
        {
            // Register database schema management and initialisation
            services.AddTransient<DbInitialiser>();

            // register persistence services
            var commonDbConfiguration = new CQRSDatabaseConfiguration<ModuleDbContext, ModuleQueryDbContext, ModuleWriteDbContext>();
            commonDbConfiguration.RegisterDatabases(services);

            var masterDbConfiguration = new CQRSDatabaseConfiguration<MasterDb, MasterQueryDb, MasterWriteDb>();
            masterDbConfiguration.RegisterDatabases(services);

            // register technology specific services for migrations
            var masterSqliteDbConfiguration = new DatabaseConfiguration<MasterSqliteDb>();
            masterSqliteDbConfiguration.RegisterDatabases(services);

            var masterSqlServerDbConfiguration = new DatabaseConfiguration<MasterSqlServerDb>();
            masterSqlServerDbConfiguration.RegisterDatabases(services);

            var masterPostgresDbConfiguration = new DatabaseConfiguration<MasterPostgresDb>();
            masterPostgresDbConfiguration.RegisterDatabases(services);

            // register healthchecks
            services.AddHealthChecks().AddDbContextCheck<ModuleQueryDbContext>();

            return services;
        }

        /// <inheritdoc/>
        public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
        {
            return endpoints;
        }

        public WebApplication AddMiddleware(WebApplication app)
        {
            return app;
        }
    }
}