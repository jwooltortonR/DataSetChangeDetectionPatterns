using System.Collections.Generic;
using R.ChangeDataSetCapture.Interfaces;
using R.ChangeDataSetCapture.Interfaces.Enums;

namespace R.ChangeDataSetCapture
{
    public class Configuration : IConfiguration
    {
        public Configuration()
        {            
            ChangeDetectionApproachType = ChangeDetectionApproachType.BruteForce;            
        }

        public IPersistenceStore PersistanceStore { get; set; }
        public ChangeDetectionApproachType ChangeDetectionApproachType { get; set; }
        public string KeyColumnName { get; set; }
        public IList<string> HashColumnList { get; set; }
        public INotifier Notifier { get; set; }        
    }
}
