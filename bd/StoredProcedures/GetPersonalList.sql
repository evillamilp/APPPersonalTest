-- =============================================
-- Author:		Eduardo Villamil
-- Create date: 22/09/2023
-- Description:	Get record
-- =============================================
CREATE PROCEDURE GetPersonalList
	-- Add the parameters for the stored procedure here
AS
BEGIN

	SELECT
		tb.FullName AS Name,
		tb.Address AS FullAddress,
		tb.PhoneNumber AS Phone,
		tb.Email AS EmailAddress
	FROM
		dbo.PersonalTb tb
END
GO
