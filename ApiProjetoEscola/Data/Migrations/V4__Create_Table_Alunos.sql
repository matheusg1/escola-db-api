CREATE TABLE [dbo].[Alunos](
	[AlunoId] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[Matricula] [uniqueidentifier] NULL,
	[Nome] [varchar](max) NULL,
	[Sobrenome] [varchar](max) NULL,
	[CPF] [varchar](max) NULL,
	[Data_Nascimento] [date] NULL
)