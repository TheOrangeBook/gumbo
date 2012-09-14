SELECT [Version], 
  [Key], 
  [Value]

 FROM (
  SELECT [ThingId],
    [Key], 
    [Version],
    [Value], 
    RANK() OVER (
    PARTITION BY [ThingId], [Key]
     ORDER BY [Version] DESC, [Key] DESC
    ) AS Rank
   FROM GumboProperty
 ) [Rank]
 WHERE [Rank] = 1 AND ThingId = @target_id