using System;
using System.Data;
using DataSetChangeDetectionPatterns.Entities;
using DataSetChangeDetectionPatterns.Interfaces;
using DataSetChangeDetectionPatterns.Interfaces.Contracts;

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

            //Setup the Strategy
            var strategy = new DataSetChangeDetectionPatterns.ChangingStatusStrategy(persistanceStore,
                notificationStrategy);                       

            //Build the contract 
            IChangingStatusContract contract = new DataSetChangeDetectionPatterns.Contracts.ChangingStatusContract()
            {
                ChangeColumns = new[] {"Status"},
                CollectionName = "StatusCollection",
                KeyColumnName = "Status"
            };
                  
            //Execute
            strategy.Process(GetDataTable(), contract);            
            
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
