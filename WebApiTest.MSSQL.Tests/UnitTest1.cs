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
            //SqlConnection.ClearAllPools();
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
    }
}
