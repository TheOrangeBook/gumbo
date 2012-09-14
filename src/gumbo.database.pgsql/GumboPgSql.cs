namespace gumbo.database.pgsql
{
    public class GumboPgSql
    {
        public static readonly string ReadProperties = @"SELECT [version], 
  [key], 
  [value]

 FROM (
  SELECT [object_id],
    [key], 
    [version],
    [value], 
    RANK() OVER (
    PARTITION BY [object_id], [key]
     ORDER BY [key] ASC,[version] DESC
    ) AS rank
   FROM gumbo_property
   WHERE object_id = @target_id AND [version] <= @target_version
 ) [Rank]
 WHERE [rank] = 1 AND object_id = @target_id"; 
    }
}