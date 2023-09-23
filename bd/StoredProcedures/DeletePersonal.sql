-- =============================================
-- Author:		Eduardo Villamil
-- Create date: 22/09/2023
-- Description:	Delete record filtering by id
-- =============================================
CREATE PROCEDURE DeletePersonal
	-- Add the parameters for the stored procedure here
	@id INT
AS
BEGIN

	DELETE FROM dbo.PersonalTb WHERE Id = @id

	SELECT
		tb.FullName AS Name,
		tb.Address AS FullAddress,
		tb.PhoneNumber AS Phone,
		tb.Email AS EmailAddress
	FROM
		dbo.PersonalTb tb
	WHERE
		tb.Id = @id
END
GO
