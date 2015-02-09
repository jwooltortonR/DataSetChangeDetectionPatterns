using System;
using System.Data;
using DataSetChangeDetectionPatterns;
using DataSetChangeDetectionPatterns.Entities;
using DataSetChangeDetectionPatterns.Interfaces;
using DataSetChangeDetectionPatterns.Interfaces.Contracts;
using DataSetChangeDetectionPatterns.Interfaces.Persistence;
using DataSetChangeDetectionPatterns.Interfaces.Strategies;

namespace SimpleChangingStatus
{
    class Program
    {
        static void Main(string[] args)
        {            
            Console.WriteLine("Beginning Simple Changing Status Strategy");

            //Setup persistence store.  I'm using Mongo because it's quick.
            IPersistenceStore<ChangingStatusContractEntity> persistanceStore = new MongoPersistenceStore("mongodb://localhost", "SimpleChangingStatus");

            //This Notifier simple writes to the Console.
            INotificationStrategy notificationStrategy = new SimpleNotificationStrategy();

            var config = new ChangingStatusConfiguration<ChangingStatusContractEntity>()
            {
                NotificationStrategy = notificationStrategy,
                PersistenceStore = persistanceStore,
                ColumnList =  new[] {"Status"},
                PersistenceStoreCollectionName = "StatusCollection",
               TableKeyColumnName = "ID"
            };


            //Setup the Strategy            
            var strategy = new ChangingStatusStrategy(config);                       

            //Execute
            strategy.Process(GetDataTable());            
            
            Console.ReadLine();
            Console.WriteLine("Finished Simple Changing Status Strategy");
        }



        private static DataTable GetDataTable()
        {
            //Build a Sample DataSet 
            var dt = new DataTable();
            dt.Columns.Add("ID", Type.GetType("System.Int32"));
            dt.Columns.Add("Name", Type.GetType("System.String"));
            dt.Columns.Add("Amount", Type.GetType("System.Int32"));
            dt.Columns.Add("Status", Type.GetType("System.String"));
            var dr1 = dt.NewRow();
            dr1["ID"] = 1;
            dr1["Name"] = "Bob";
            dr1["Amount"] = 1.00;
            dr1["Status"] = "New";
            dt.Rows.Add(dr1);
            return dt;
        }
    }
}
