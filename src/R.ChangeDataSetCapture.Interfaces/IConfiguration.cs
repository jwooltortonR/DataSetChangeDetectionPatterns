using R.ChangeDataSetCapture.Interfaces.Enums;

namespace R.ChangeDataSetCapture.Interfaces
{
    public interface IConfiguration
    {
        PersistanceStoreType PersistanceStoreType { get; set; }
        ChangeDetectionApproachType ChangeDetectionApproachType { get; set; }
        string ConnectionString { get; set; }
    }
}
