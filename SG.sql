USE [master]
GO
/****** Object:  Database [SG]    Script Date: 15/8/2024 17:36:24 ******/
CREATE DATABASE [SG]
GO

USE [SG]
GO
/****** Object:  Table [dbo].[Cuenta]    Script Date: 15/8/2024 17:36:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cuenta](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Cuenta] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CuentaMovimiento]    Script Date: 15/8/2024 17:36:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CuentaMovimiento](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[CuentaId] [bigint] NOT NULL,
	[Importe] [decimal](18, 2) NOT NULL,
	[Saldo] [decimal](18, 2) NOT NULL,
	[FechaHora] [datetime] NOT NULL,
 CONSTRAINT [PK_CuentaMovimiento] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[CuentaMovimiento] ADD  CONSTRAINT [DF_Cuenta_Saldo]  DEFAULT ((0)) FOR [Saldo]
GO
ALTER TABLE [dbo].[CuentaMovimiento] ADD  CONSTRAINT [DF_CuentaMovimiento_Importe]  DEFAULT ((0)) FOR [Importe]
GO
ALTER TABLE [dbo].[CuentaMovimiento] ADD  CONSTRAINT [DF_CuentaMovimiento_FechaHora]  DEFAULT (getdate()) FOR [FechaHora]
GO
ALTER TABLE [dbo].[CuentaMovimiento]  WITH CHECK ADD  CONSTRAINT [FK_CuentaMovimiento_Cuenta_Id] FOREIGN KEY([CuentaId])
REFERENCES [dbo].[Cuenta] ([Id])
GO
ALTER TABLE [dbo].[CuentaMovimiento] CHECK CONSTRAINT [FK_CuentaMovimiento_Cuenta_Id]
GO
USE [master]
GO
ALTER DATABASE [SG] SET  READ_WRITE 
GO
