namespace gumbo.database.mssql
{
    public static class GumboTSql
    {
        public static readonly string ReadProperties = @"SELECT [Version], 
  [Key], 
  [Value]

 FROM (
  SELECT [ThingId],
    [Key], 
    [Version],
    [Value], 
    RANK() OVER (
    PARTITION BY [ThingId], [Key]
     ORDER BY [Key] ASC,[Version] DESC
    ) AS Rank
   FROM GumboProperty
   WHERE ThingId = @target_id AND [Version] <= @target_version
 ) [Rank]
 WHERE [Rank] = 1 AND ThingId = @target_id";

    }
}