using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace WebApiTest.MSSQL
{
    public class WebApiTestDBInitializer : System.Data.Entity.DropCreateDatabaseAlways<WebApiTestDB>
    {
        public override void InitializeDatabase(WebApiTestDB context)
        {
            context.Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction
            , string.Format("ALTER DATABASE [{0}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE", context.Database.Connection.Database));

            base.InitializeDatabase(context);
        }

        protected override void Seed(WebApiTestDB context)
        {
            base.Seed(context);

            var sqlFileBrand = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Brand.sql");
            context.Database.ExecuteSqlCommand(File.ReadAllText(sqlFileBrand));
            var sqlFileToolType = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ToolType.sql");
            context.Database.ExecuteSqlCommand(File.ReadAllText(sqlFileToolType));
            var sqlFileTool = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Tool.sql");
            context.Database.ExecuteSqlCommand(File.ReadAllText(sqlFileTool));
        }
    }
}
