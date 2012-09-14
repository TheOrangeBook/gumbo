CREATE TABLE gumbo_property
(
	id uniqueidentifier, --snowflake
	[object_id] uniqueidentifier, --snowflake, fk
	tenant_id uniqueidentifier, --fk

	name nvarchar(255),
	value nvarchar(255),
	[type] nvarchar(255),

	effective_on datetime
)


--postgres



CREATE TABLE gumbo_property
(
  id uuid,
  object_id uuid,
  tenant_id uuid,

  name character varying(255),
  value character varying(255),
  type character varying(255),

  effective_on timestamp without time zone
)
WITH (
  OIDS=FALSE
);
ALTER TABLE gumbo_property
  OWNER TO postgres;


  /*
  insert into gumbo_property
values('A0EEBC99-9C0B-4EF8-BB6D-6BB9BD380A11', 'A0EEBC99-9C0B-4EF8-BB6D-6BB9BD380A11', 'A0EEBC99-9C0B-4EF8-BB6D-6BB9BD380A11', 'name','bob','string', '1/1/2001');

insert into gumbo_property
values('A0EEBC99-9C0B-4EF8-BB6D-6BB9BD380A12', 'A0EEBC99-9C0B-4EF8-BB6D-6BB9BD380A11', 'A0EEBC99-9C0B-4EF8-BB6D-6BB9BD380A11', 'name','Bob','string', '1/3/2001');

insert into gumbo_property
values('A0EEBC99-9C0B-4EF8-BB6D-6BB9BD380A13', 'A0EEBC99-9C0B-4EF8-BB6D-6BB9BD380A11', 'A0EEBC99-9C0B-4EF8-BB6D-6BB9BD380A11', 'age','22','string', '1/1/2001');
  */