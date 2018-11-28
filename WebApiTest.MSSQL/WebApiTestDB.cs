namespace WebApiTest.MSSQL
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using System.Linq;
    using System.Linq.Dynamic;

    using WebApiTest.Interfaces;

    public class WebApiTestDB : DbContext, IAppDbContext
    {
        // Your context has been configured to use a 'WebApiTestDB' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'WebApiTest.MSSQL.WebApiTestDB' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'WebApiTestDB' 
        // connection string in the application configuration file.
        public WebApiTestDB()
            : base("WebApiTestDB")
        {
            Database.SetInitializer(new WebApiTestDBInitializer());
            //Database.SetInitializer(new System.Data.Entity.DropCreateDatabaseAlways<WebApiTestDB>());
        }

        #region Brands
        public int GetBrandTotalCount()
        {
            var query = this.Brands;
            var totalCount = query.Count();
            return totalCount;
        }
        public QueryResultBrand GetResultsBrand(string filterByValue, int start, int length, Dictionary<string, string> orderBy)
        {
            var query1 = this.Brands;
            var totalCount = query1.Count();
            var filteredCount = query1.Count();
            var query2 = query1.Skip(start).Take(length).ToList<Brand>();
            var sc = new QueryResultBrand(query2, filteredCount, totalCount);
            return sc;
        }

        public Guid AddBrand(Brand obj)
        {
            this.Brands.Add(obj);
            this.SaveChanges();
            return obj.ID;
        }
        public bool DeleteBrand(Guid id)
        {
            var obj = this.Brands.Find(id);
            if (obj == null)
                return false;
            this.Brands.Remove(obj);
            this.SaveChanges();
            return true;
        }
        public Brand FindBrandById(Guid id)
        {
            var dto = this.Brands.Find(id);
            return dto;
        }
        public void UpdateBrand(Brand obj)
        {
            this.Entry(obj).State = EntityState.Modified;
            this.SaveChanges();
        }

        public virtual DbSet<Brand> Brands { get; set; }
        #endregion

        #region ToolTypes

        public int GetToolTypeTotalCount()
        {
            var query = this.ToolTypes;
            var totalCount = query.Count();
            return totalCount;
        }
        public QueryResultToolType GetResultsToolType(string filterByValue, int start, int length, Dictionary<string, string> orderBy)
        {
            var query1 = this.ToolTypes;
            var totalCount = query1.Count();
            var filteredCount = query1.Count();
            var query2 = query1.Skip(start).Take(length).ToList<ToolType>();
            var sc = new QueryResultToolType(query2, filteredCount, totalCount);
            return sc;
        }
        public ToolType FindToolTypeById(Guid id)
        {
            var obj = this.ToolTypes.Find(id);
            return obj;
        }
        public Guid AddToolType(ToolType obj)
        {
            this.ToolTypes.Add(obj);
            this.SaveChanges();
            return obj.ID;
        }

        public void UpdateToolType(ToolType obj)
        {
            this.Entry(obj).State = EntityState.Modified;
            this.SaveChanges();
        }

        public bool DeleteToolType(Guid id)
        {
            var obj = this.ToolTypes.Find(id);
            if (obj == null)
                return false;
            this.ToolTypes.Remove(obj);
            this.SaveChanges();
            return true;
        }

        public virtual DbSet<ToolType> ToolTypes { get; set; }

        #endregion

        #region Tools
        public int GetToolTotalCount()
        {
            var query = this.Tools;
            var totalCount = query.Count();
            return totalCount;
        }

        public QueryResultTool GetResultsTool(string filterByValue, int start, int length, Dictionary<string, string> orderBy)
        {
            var query1 = this.Tools;
            var totalCount = query1.Count();
            var filteredCount = query1.Count();
            var query2 = query1.Skip(start).Take(length).ToList<Tool>();
            var sc = new QueryResultTool(query2, filteredCount, totalCount);
            return sc;
        }

        public Guid AddTool(Tool obj)
        {
            this.Tools.Add(obj);
            this.SaveChanges();
            return obj.ID;
        }

        public bool DeleteTool(Guid id)
        {
            var obj = this.Tools.Find(id);
            if (obj == null)
                return false;
            this.Tools.Remove(obj);
            this.SaveChanges();
            return true;
        }

        public Tool FindToolById(Guid id)
        {
            var obj = this.Tools.Find(id);
            return obj;
        }

        public void UpdateTool(Tool obj)
        {
            this.Entry(obj).State = EntityState.Modified;
            this.SaveChanges();
        }


        public virtual DbSet<Tool> Tools { get; set; }

        #endregion



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}