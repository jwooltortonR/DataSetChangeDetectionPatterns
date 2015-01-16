using R.ChangeDataSetCapture.Interfaces;
using R.ChangeDataSetCapture.Interfaces.Enums;
using Xunit;

namespace R.ChangeDataSetCapture.IntegrationTests
{
    public class ApplicationTest
    {
        public ApplicationTest()
        {
            
        }

        [Fact]
        public void TestWeDefaultInitialisatioOfTheApplication()
        {
            IConfiguration config = new Configuration();
            var app = new ChangeSetCapture(config);
            //Assert.Equal(PersistanceStoreType.Mongo, app.Configuration.PersistanceStoreType);
            Assert.Equal(ChangeDetectionApproachType.BruteForce, app.Configuration.ChangeDetectionApproachType);
        }

        [Fact]
        public void DummyRun()
        {
            
        }
    }
}
