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




        public static readonly string CreateObjectsTable = @"
CREATE TABLE GumboObject
(
    Id uniqueidentifier, --pk, snowflake
    [Type] nvarchar(max), --could be keyed as well
    
    --possible extension fields?
    
    [TenantId] uniqueidentifier
)
";

        public static readonly string CreatePropertiesTable = @"
CREATE TABLE GumboProperty 
(
    Id uniqueidentifier, --pk, snowflake
    [ObjectId] uniqueidentifier, --conceptual fk, snowflake
    [Version] bigint, --snowflake timestamp

    [Key] bigint,
    [Type] nvarchar(max), --prolly key this too
    [Value] varchar(max),
    
    [TenantId] uniqueidentifier
)
";

        public static readonly string CreatePropertyNamesTable = @"
CREATE TABLE GumboPropertyNames
(
    [Type] nvarchar(max),
    [Key] bigint,
    [Description] nvarchar(max)
)
";
        //add primary key code
        //add indexes
    }
}