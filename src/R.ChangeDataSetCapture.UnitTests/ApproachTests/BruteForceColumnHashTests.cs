using System;
using System.Collections.Generic;
using System.Data;
using Moq;
using R.DataSetChangeDetection.Strategies.Contracts;
using R.DataSetChangeDetection.Strategies.Entities;
using R.DataSetChangeDetection.Strategies.Interfaces;
using Xunit;

namespace R.DataSetChangeDetection.Strategies.UnitTests.ApproachTests
{
    public class BruteForceColumnHashTests
    {
        private Mock<IPersistenceStore<BruteForceEntity>> _mockPersistenceStore;
        private Mock<INotificationStrategy> _mockNotifier;

        private BruteForceColumnHash _bruteForceColumnHash;

        private List<string> _hashColumnList;

        public BruteForceColumnHashTests()
        {
            var collectionName = "Employee";
            _hashColumnList = new List<string>()
                {
                    "Status"
                };

            _mockPersistenceStore = new Mock<IPersistenceStore<BruteForceEntity>>();
            _mockNotifier= new Mock<INotificationStrategy>();

            //_bruteForceColumnHash = new BruteForceColumnHash(_mockPersistenceStore.Object, _mockNotifier.Object, "ID", _hashColumnList, collectionName);
            var contract = new BruteForceContract()
                {
                    CollectionName = collectionName,
                    ChangeColumns = _hashColumnList,
                    KeyColumnName = "ID"
                };
            _bruteForceColumnHash = new BruteForceColumnHash(_mockPersistenceStore.Object, _mockNotifier.Object);


        }

        [Fact]
        public void TestCreationOfHash()
        {
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

            var resval = _bruteForceColumnHash.GetHash(_hashColumnList, dr1);
            Assert.Equal("-1273337860", resval);
        }

    }
}
