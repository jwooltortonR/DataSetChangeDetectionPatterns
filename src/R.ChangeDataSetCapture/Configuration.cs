using R.ChangeDataSetCapture.Interfaces;
using R.ChangeDataSetCapture.Interfaces.Enums;

namespace R.ChangeDataSetCapture
{
    public class Configuration : IConfiguration
    {
        public Configuration()
        {
            PersistanceStoreType = PersistanceStoreType.Mongo;
            ChangeDetectionApproachType = ChangeDetectionApproachType.BruteForce;            
        }

        public PersistanceStoreType PersistanceStoreType { get; set; }
        public ChangeDetectionApproachType ChangeDetectionApproachType { get; set; }
        public string ConnectionString { get; set; }
    }
}
