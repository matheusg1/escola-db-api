CREATE TABLE [dbo].[Aluno](
	[Id] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[Matricula] [uniqueidentifier] NULL,
	[Nome_Completo] [varchar](max) NULL,
	[CPF] [varchar](max) NULL,
	[Data_Nascimento] [date] NULL
)