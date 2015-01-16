using System.Collections.Generic;
using R.ChangeDataSetCapture.Interfaces.Enums;

namespace R.ChangeDataSetCapture.Interfaces
{
    public interface IConfiguration
    {
        IPersistenceStore PersistanceStore { get; set; }
        INotifier Notifier { get; set; }

        ChangeDetectionApproachType ChangeDetectionApproachType { get; set; }

        string KeyColumnName { get; set; }
        IList<string> HashColumnList { get; set; }
    }
}
