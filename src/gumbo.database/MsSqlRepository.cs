using System;
using System.Data;
using System.Data.SqlClient;

namespace gumbo.database.mssql
{
    public class MsSqlRepository : GumboRepository
    {
        readonly GumboMsSqlSettings _settings;

        public MsSqlRepository(GumboMsSqlSettings settings)
        {
            _settings = settings;
        }

        public GumboBag GetBagFor(Guid id, Guid version)
        {
            var result = new GumboBag();
            using (IDbConnection conn = new SqlConnection(_settings.ConnectionString))
            using (var cmd = conn.CreateCommand())
            {
                conn.Open();

                cmd.CommandText = GumboTSql.ReadProperties;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.Add(new SqlParameter("@target_id", id));
                cmd.Parameters.Add(new SqlParameter("@target_version", version));

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var prop = new GumboProperty();
                        prop.Version = reader.GetGuid(0);
                        prop.Name = reader.GetString(1);
                        prop.Value = reader[2];

                        result.Add(prop);
                    }
                }
            }

            return result;
        }

        public GumboBag GetBagFor(Guid id)
        {
            throw new NotImplementedException();
        }

        public GumboObject GetObject(Guid id, Guid version)
        {
            throw new NotImplementedException();
        }

        public GumboObject GetObject(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}