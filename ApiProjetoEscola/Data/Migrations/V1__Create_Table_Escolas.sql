CREATE TABLE [dbo].[Escolas](
	[EscolaId] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[Nome] [varchar](max) NULL,
	[Endereco] [varchar](max) NULL
)