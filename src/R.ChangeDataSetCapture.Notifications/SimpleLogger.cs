using System.Data;
using Common.Logging;
using R.ChangeDataSetCapture.Interfaces;

namespace R.ChangeDataSetCapture.Notifications
{
    public class SimpleLogger : INotifier
    {
        private readonly ILog _log;

        public SimpleLogger(ILog log)
        {
            _log = log;
        }

        public void Insert(DataRow dataRow)
        {
            _log.Info("Insert");
        }

        public void Amend(DataRow dataRow)
        {
            _log.Info("Amend");
        }

        public void Cancel(DataRow dataRow)
        {
            _log.Info("Cancel");
        }

        public void NoChange(DataRow dataRow)
        {
            _log.Info("No Change");
        }
    }
}
