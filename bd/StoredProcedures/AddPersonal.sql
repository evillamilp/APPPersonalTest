-- =============================================
-- Author:		Eduardo Villamil
-- Create date: 22/09/2023
-- Description:	Insert new record into PersonalTb table
-- =============================================
CREATE PROCEDURE AddPersonal
	-- Add the parameters for the stored procedure here
	@fullName NVARCHAR(250),
	@address NVARCHAR(300) = NULL,
	@phoneNumber NVARCHAR(10) = NULL,
	@email NVARCHAR(100) = NULL
AS
BEGIN

	INSERT INTO dbo.PersonalTb(
						FullName, 
						[Address],
						PhoneNumber, 
						Email)
					VALUES
						(
							@fullName,
							@address,
							@phoneNumber,
							@email
						)

	DECLARE @id INT = 0
	SELECT @id = SCOPE_IDENTITY();

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
