using NUnit.Framework;
using gumbo.database.mssql;

namespace gumbo.specs
{
    [TestFixture]
    public class Stuff
    {
        [Test]
        public void CreateMsSqlDatabase()
        {
            ExecuteTSql.CreateTestDatabase();
            ExecuteTSql.ExecuteNonQuery("gumbo_test", GumboTSql.CreateObjectsTable);
            ExecuteTSql.ExecuteNonQuery("gumbo_test", GumboTSql.CreatePropertiesTable);
            ExecuteTSql.ExecuteNonQuery("gumbo_test", GumboTSql.CreatePropertyNamesTable);
        }

        [Test, Repeat(10)]
        public void InjectTestData()
        {
            ExecuteTSql.InjectDummyObj();
        }
    }
}