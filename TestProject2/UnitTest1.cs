using Microsoft.Extensions.Configuration;

namespace TestProject2
{
    [TestClass]
    public class UnitTest1
    {
        private static string _mySection = string.Empty;

        [ClassInitialize()]
        public static void InitializeTests(TestContext testContext)
        {
            var iConfig = GetIConfigurationRoot(testContext.DeploymentDirectory);

            var myConfig = iConfig.GetSection("MySection");

            _mySection = myConfig.Value.ToString();
        }

        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(_mySection, "Test123");
        }

        private static IConfigurationRoot GetIConfigurationRoot(string outputPath)
        {
            return new ConfigurationBuilder()
                .SetBasePath(outputPath)
                .AddJsonFile("appsettings.json", optional: true)
                .AddEnvironmentVariables()
                .Build();
        }
    }
}