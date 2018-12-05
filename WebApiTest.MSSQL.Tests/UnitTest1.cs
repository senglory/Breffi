using System;
using System.Data.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApiTest.Interfaces;
using WebApiTest.MSSQL;

namespace WebApiTest.MSSQL.Tests
{
    [TestClass]
    public class UnitTest1
    {
        WebApiTestDB dbContext;


        [TestInitialize]
        public void Init()
        {
            //Database.SetInitializer(new WebApiTestDBInitializer());
            dbContext = new WebApiTestDB();
            dbContext.Database.Initialize(true);
        }

        [TestCleanup]
        public void CleanUp()
        {
            dbContext.Database.ExecuteSqlCommand(@"DELETE FROM dbo.Tool");
            dbContext.Database.ExecuteSqlCommand(@"DELETE FROM dbo.ToolType");
            dbContext.Database.ExecuteSqlCommand(@"DELETE FROM dbo.Brand");

            dbContext.Dispose();
        }

        [TestMethod]
        public void TestGetToolTotalCount()
        {
            try
            {
                var qty = dbContext.GetToolTotalCount();
                Assert.IsTrue(qty == 2);
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        [TestMethod]
        public void TestToolType()
        {
            try
            {
                var obj = dbContext.FindToolById(Guid .Parse ("4E89CD54-92B3-4013-A14E-AE2A34BFDB6A"));
                Assert.IsTrue(obj.ToolType.Name == "Pliers");
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [TestMethod]
        public void TestToolReadAll()
        {
            try
            {
                var obj = dbContext.GetResultsTool( null, 0, 10, null );
                Assert.IsTrue(obj.TotalCount == 2);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
