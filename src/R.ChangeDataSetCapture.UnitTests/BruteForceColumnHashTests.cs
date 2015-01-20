using System;
using System.Collections.Generic;
using System.Data;
using Moq;
using R.ChangeDataSetCapture.ChangeDetectionApproach;
using R.ChangeDataSetCapture.Interfaces;
using Xunit;

namespace R.ChangeDataSetCapture.UnitTests
{
    public class BruteForceColumnHashTests
    {
        private Mock<IPersistenceStore> _mockPersistenceStore;
        private Mock<INotifier> _mockNotifier;

        private BruteForceColumnHash _bruteForceColumnHash;

        private List<string> _hashColumnList;

        public BruteForceColumnHashTests()
        {
            _hashColumnList = new List<string>()
                {
                    "Status"
                };

            _mockPersistenceStore = new Mock<IPersistenceStore>();
            _mockNotifier= new Mock<INotifier>();
            _bruteForceColumnHash = new BruteForceColumnHash(_mockPersistenceStore.Object, _mockNotifier.Object, "ID", _hashColumnList);

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
