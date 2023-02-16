CREATE TABLE dbo.Usuario (
  [id] int NOT NULL IDENTITY,
  [Nome_Usuario] varchar(50) NOT NULL DEFAULT '0',
  [Senha] varchar(130) NOT NULL DEFAULT '0',
  [Nome_Completo] varchar(120) NOT NULL,
  [refresh_token] varchar(500) DEFAULT '0',
  [refresh_token_expiry_time] datetime2(0) DEFAULT NULL,
  PRIMARY KEY ([id]),
  CONSTRAINT [Nome_Usuario] UNIQUE ([Nome_Usuario])
)
GO