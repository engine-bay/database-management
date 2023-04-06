namespace EngineBay.DatabaseManagement.Tests
{
    using Xunit;

    public class SeedDataPathTests
    {
        [Fact]
        public void TheDefaultInMemoryConnectionStringIsValid()
        {
            var path = SeedingConfiguration.GetSeedDataPath();

            Assert.Equal(DefaultSeedingConstants.DefaultSeedDataPath, path);
        }
    }
}
