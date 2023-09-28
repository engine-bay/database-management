namespace EngineBay.DatabaseManagement
{
    using System;
    using EngineBay.Core;
    using EngineBay.Persistence;

    public class DatabaseManagementModule : BaseModule
    {
        public override IServiceCollection RegisterModule(IServiceCollection services, IConfiguration configuration)
        {
            // Register database schema management and initialization
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
    }
}