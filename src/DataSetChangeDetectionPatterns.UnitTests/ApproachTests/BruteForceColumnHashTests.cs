using System;
using System.Collections.Generic;
using System.Data;
using DataSetChangeDetectionPatterns.Contracts;
using DataSetChangeDetectionPatterns.Entities;
using DataSetChangeDetectionPatterns.Interfaces;
using Moq;
using Xunit;

namespace DataSetChangeDetectionPatterns.UnitTests.ApproachTests
{
    public class BruteForceColumnHashTests
    {
        private Mock<IPersistenceStore<ChangingStatusContractEntity>> _mockPersistenceStore;
        private Mock<INotificationStrategy> _mockNotifier;

        private ChangingStatusStrategy _changingStatusStrategy;

        private List<string> _hashColumnList;

        public BruteForceColumnHashTests()
        {
            var collectionName = "Employee";
            _hashColumnList = new List<string>()
                {
                    "Status"
                };

            _mockPersistenceStore = new Mock<IPersistenceStore<ChangingStatusContractEntity>>();
            _mockNotifier= new Mock<INotificationStrategy>();

            //_changingStatusStrategy = new ChangingStatusStrategy(_mockPersistenceStore.Object, _mockNotifier.Object, "ID", _hashColumnList, collectionName);
            var contract = new ChangingStatusContract()
                {
                    CollectionName = collectionName,
                    ChangeColumns = _hashColumnList,
                    KeyColumnName = "ID"
                };
            _changingStatusStrategy = new ChangingStatusStrategy(_mockPersistenceStore.Object, _mockNotifier.Object);


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

            var resval = _changingStatusStrategy.GetHash(_hashColumnList, dr1);
            Assert.Equal("-1273337860", resval);
        }

    }
}
