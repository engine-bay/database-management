namespace EngineBay.DatabaseManagement
{
    public static class SeedingConfiguration
    {
        public static string GetSeedDataPath()
        {
            var seedDataPathEnvironmentVariable = Environment.GetEnvironmentVariable(EnvironmentVariableConstants.DATABASESEEDDATAPATH);

            if (string.IsNullOrEmpty(seedDataPathEnvironmentVariable))
            {
                return DefaultSeedingConstants.DefaultSeedDataPath;
            }

            return seedDataPathEnvironmentVariable;
        }
    }
}