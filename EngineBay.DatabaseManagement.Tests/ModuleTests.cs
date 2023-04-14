namespace EngineBay.DatabaseManagement.Tests
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Routing;
    using Moq;
    using Xunit;

    public class ModuleTests
    {
        [Fact]
        public void TheModuleCanRegisterItsef()
        {
            var builder = WebApplication.CreateBuilder();

            var module = new DatabaseManagementModule();

            var exception = Record.Exception(() => module.RegisterModule(builder.Services, builder.Configuration));

            Assert.Null(exception);
        }

        [Fact]
        public void TheModuleCanMapItsEndpoints()
        {
            var mockEndpoints = new Mock<IEndpointRouteBuilder>();
            var endpoints = mockEndpoints.Object;

            var module = new DatabaseManagementModule();

            var exception = Record.Exception(() => module.MapEndpoints(endpoints));

            Assert.Null(exception);
        }

        [Fact]
        public void TheModuleCanAddItsMiddleware()
        {
            var builder = WebApplication.CreateBuilder();

            var module = new DatabaseManagementModule();

            module.RegisterModule(builder.Services, builder.Configuration);

            var app = builder.Build();

            var exception = Record.Exception(() => module.AddMiddleware(app));

            Assert.Null(exception);
        }
    }
}
