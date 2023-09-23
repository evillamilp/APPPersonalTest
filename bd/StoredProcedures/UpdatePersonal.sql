-- =============================================
-- Author:		Eduardo Villamil
-- Create date: 22/09/2023
-- Description:	Update record filtering by id
-- =============================================
CREATE PROCEDURE UpdatePersonal
	-- Add the parameters for the stored procedure here
	@id INT,
	@phoneNumber NVARCHAR(10) = NULL,
	@email NVARCHAR(100) = NULL
AS
BEGIN

	UPDATE tb
	SET
		tb.PhoneNumber = @phoneNumber,
		tb.Email = @email
	FROM
		dbo.PersonalTb tb
	WHERE
		tb.Id = @id

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
