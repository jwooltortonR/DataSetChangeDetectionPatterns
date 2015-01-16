using System.Data;
using R.ChangeDataSetCapture.ChangeDetectionApproach;
using R.ChangeDataSetCapture.Interfaces;
using R.ChangeDataSetCapture.Interfaces.Enums;
using R.ChangeDataSetCapture.Persistence;

namespace R.ChangeDataSetCapture
{
    public sealed class ChangeSetCapture
    {        
        public IConfiguration Configuration { get; set; }

        public ChangeSetCapture(IConfiguration configuration)
        {
            Configuration = configuration;            
        }

        public void Process(DataSet dataSet)
        {            
            //Load Persitance Store
            var persistenceStore = LoadPersistanceStore();

            //Load ApproachType
            var apprachType = LoadApproachType();

            //Create 


        }

        public IPersistenceStore LoadPersistanceStore()
        {
            IPersistenceStore retval = null;

            switch (Configuration.PersistanceStoreType)
            {
                case PersistanceStoreType.Mongo:
                    retval = new MongoStore(Configuration.ConnectionString);
                    break;
                case PersistanceStoreType.InMemory:
                    retval = new InMemoryStore();
                    break;
            }
            return retval;
        }

        public IChangeDetectionApproach LoadApproachType()
        {
            IChangeDetectionApproach retval = null;

            switch (Configuration.ChangeDetectionApproachType)
            {
                case ChangeDetectionApproachType.BruteForce:
                    retval = new BruteForceApproach();
                    break;
            }
            return retval;
        }
    }
}
