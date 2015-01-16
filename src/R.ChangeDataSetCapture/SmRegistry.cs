using R.ChangeDataSetCapture.Interfaces;
using R.ChangeDataSetCapture.Persistence;
using StructureMap.Configuration.DSL;

namespace R.ChangeDataSetCapture
{
    public class SmRegistry : Registry
    {
        public SmRegistry()
        {
            //For<ISchedulerCore>().Use<SchedulerCore>();
            //For<IScheduler>().Use(Scheduler.Instance);
            // Default that my be overriden (using Sm TypeInterceptor) to use 
            // data store implementation selected in Scheduler Configuration
            For<IPersistenceStore>().Use<MongoStore>();
        }
    }
}
