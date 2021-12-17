USE [db.atos.dev.skill]
GO

/****** Object: Table [dbo].[Managers] Script Date: 16/12/2021 19:56:13 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

INSERT INTO [dbo].[Managers]
           ([Nome]
           ,[Email]
           ,[Senha]
           ,[Role]
           ,[DtCriacao]
           ,[DtAtualizacao]
           ,[Status])
     VALUES
           ('Joana', 'joana@getdev.net', 'cd8c29b8deed323fe1538cfbdb46fc2a2ea61cfd67807f0629708ea2a6e13a2919def3c837c4e7f2c8e0067568e3236827defb05c9346e476b6e954440a908a7',
		   0,'2021-12-16',null,0)





