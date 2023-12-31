USE [TestApplicationDB]
GO
/****** Object:  Table [dbo].[PersonalTb]    Script Date: 23/09/2023 1:50:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PersonalTb](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](250) NOT NULL,
	[Address] [nvarchar](300) NULL,
	[PhoneNumber] [nvarchar](10) NULL,
	[Email] [nvarchar](100) NULL,
 CONSTRAINT [PK_ID_PersonalTb] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[PersonalTb] ON 

INSERT [dbo].[PersonalTb] ([Id], [FullName], [Address], [PhoneNumber], [Email]) VALUES (2, N'Eduardo Villamil', N'Panamá 133, Gaviotas Sur Sección San José', N'9932138977', N'eduardo.villamilp@hotmail.com')
INSERT [dbo].[PersonalTb] ([Id], [FullName], [Address], [PhoneNumber], [Email]) VALUES (4, N'Antonio', N'Circuito Mediterráneo 3 Manzana 8, Residencial Mediterraneo, Nacajuca , Tabasco, CP 86247', N'9932894690', N'eduardo.villamilp@hotmail.com')
INSERT [dbo].[PersonalTb] ([Id], [FullName], [Address], [PhoneNumber], [Email]) VALUES (6, N'Reyna Villamil Hernandez', N'Panamá 133, Villahermosa tabasco', N'9932894690', N'reynachdez@gmail.com')
INSERT [dbo].[PersonalTb] ([Id], [FullName], [Address], [PhoneNumber], [Email]) VALUES (7, N'javier', N'pafnasfun', N'9931072013', N'javier@g.com')
SET IDENTITY_INSERT [dbo].[PersonalTb] OFF
GO
/****** Object:  StoredProcedure [dbo].[AddPersonal]    Script Date: 23/09/2023 1:50:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Eduardo Villamil
-- Create date: 22/09/2023
-- Description:	Insert new record into PersonalTb table
-- =============================================
CREATE PROCEDURE [dbo].[AddPersonal]
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
		tb.Id AS PersonId,
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
/****** Object:  StoredProcedure [dbo].[DeletePersonal]    Script Date: 23/09/2023 1:50:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Eduardo Villamil
-- Create date: 22/09/2023
-- Description:	Delete record filtering by id
-- =============================================
CREATE PROCEDURE [dbo].[DeletePersonal]
	-- Add the parameters for the stored procedure here
	@id INT
AS
BEGIN

	DELETE FROM dbo.PersonalTb WHERE Id = @id

	SELECT @@ROWCOUNT AS RowAffected; 
END
GO
/****** Object:  StoredProcedure [dbo].[GetPersonalList]    Script Date: 23/09/2023 1:50:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Eduardo Villamil
-- Create date: 22/09/2023
-- Description:	Get record
-- =============================================
CREATE PROCEDURE [dbo].[GetPersonalList]
	-- Add the parameters for the stored procedure here
AS
BEGIN

	SELECT
		tb.Id AS PersonId,
		tb.FullName AS Name,
		tb.Address AS FullAddress,
		tb.PhoneNumber AS Phone,
		tb.Email AS EmailAddress
	FROM
		dbo.PersonalTb tb
END
GO
/****** Object:  StoredProcedure [dbo].[UpdatePersonal]    Script Date: 23/09/2023 1:50:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Eduardo Villamil
-- Create date: 22/09/2023
-- Description:	Update record filtering by id
-- =============================================
CREATE PROCEDURE [dbo].[UpdatePersonal]
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
