using System;
using System.Data;
using DataSetChangeDetectionPatterns.Interfaces.Strategies;

namespace SimpleChangingStatus
{
    public class SimpleNotificationStrategy : INotificationStrategy
    {
        public void Insert(DataRow dataRow)
        {
            Console.WriteLine("Inserted DataRow");
        }

        public void Amend(DataRow dataRow)
        {
            Console.WriteLine("Amended DataRow");
        }

        public void Cancel(DataRow dataRow)
        {
            Console.WriteLine("Cancelled DataRow");
        }

        public void NoChange(DataRow dataRow)
        {
            Console.WriteLine("No Change to DataRow");
        }
    }
}
