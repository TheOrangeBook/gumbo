using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace gumbo.database.mssql
{
    public static class ExecuteTSql
    {
        public static void ExecuteNonQuery(string db, string sql)
        {
            var csb = new SqlConnectionStringBuilder();
            csb.DataSource = ".";
            csb.InitialCatalog = db;
            csb.IntegratedSecurity = true;

            using (IDbConnection conn = new SqlConnection(csb.ConnectionString))
            using (var cmd = conn.CreateCommand())
            {
                conn.Open();

                cmd.CommandText = sql;
                cmd.CommandType = CommandType.Text;

                cmd.ExecuteNonQuery();
            }
        }

        public static void CreateTestDatabase()
        {
            ExecuteNonQuery("master", "CREATE DATABASE [gumbo_test]");
        }

        public static void InjectDummyObj()
        {
            ExecuteNonQuery("gumbo_test", "INSERT INTO [GumboObject] (");
        }
    }

    public static class ObjectMother
    {
        public static GumboObject RandomObject()
        {
            var tenantId = Guid.NewGuid();

            var obj = new GumboObject();
            obj.Id = Guid.NewGuid();
            obj.TenantId = tenantId;
            obj.Type = "SomeType";


            
        }

        public static GumboProperty[] RandomProperty()
        {
            var rand = new Random();
            var count = rand.Next();

            var result = new List<GumboProperty>();

            for (int i = 0; i < count; i++)
            {
                
            }

            return result.ToArray();
        }
    }
}