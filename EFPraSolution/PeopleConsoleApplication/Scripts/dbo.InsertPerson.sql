CREATE PROCEDURE [dbo].[InsertPerson]
	@personName nvarchar(255),
	@registredOn	datetime,
	@personId int output
AS
	INSERT INTO dbo.People
	(Name, RegistredOn)
	VALUES
	(@personName,
	@registredOn)

	SELECT @personId = SCOPE_IDENTITY()
RETURN 0