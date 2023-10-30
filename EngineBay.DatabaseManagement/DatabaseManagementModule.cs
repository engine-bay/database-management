namespace EngineBay.DatabaseManagement
{
    using System;
    using EngineBay.Core;
    using EngineBay.Persistence;

    public class DatabaseManagementModule : BaseModule
    {
        public override IServiceCollection RegisterModule(IServiceCollection services, IConfiguration configuration)
        {
            // register persistence services
            var commonDbConfiguration = new CQRSDatabaseConfiguration<ModuleDbContext, ModuleQueryDbContext, ModuleWriteDbContext>();
            commonDbConfiguration.RegisterDatabases(services);

            var masterDbConfiguration = new CQRSDatabaseConfiguration<MasterDb, MasterQueryDb, MasterWriteDb>();
            masterDbConfiguration.RegisterDatabases(services);

            // register healthchecks
            services.AddHealthChecks().AddDbContextCheck<ModuleQueryDbContext>();

            return services;
        }
    }
}