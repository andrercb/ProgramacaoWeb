USE [ProgramacaoWeb]
GO
/****** Object:  Table [dbo].[TB_UF]    Script Date: 11/19/2020 16:04:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TB_UF](
	[uf_codigo] [char](2) NOT NULL,
	[uf_sigla] [char](2) NOT NULL,
	[uf_nome] [varchar](150) NOT NULL,
	[uf_dt_cadastro] [datetime] NOT NULL,
	[uf_deletado] [bit] NOT NULL,
 CONSTRAINT [PK_UF] PRIMARY KEY CLUSTERED 
(
	[uf_codigo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TB_PERFIL]    Script Date: 11/19/2020 16:04:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TB_PERFIL](
	[pfl_id] [int] IDENTITY(1,1) NOT NULL,
	[pfl_nome] [varchar](50) NOT NULL,
	[pfl_descricao] [varchar](100) NOT NULL,
	[pfl_dt_cadastro] [datetime] NOT NULL,
	[pfl_dt_atualizacao] [datetime] NOT NULL,
	[pfl_deletado] [bit] NOT NULL,
 CONSTRAINT [PK_PERFIL] PRIMARY KEY CLUSTERED 
(
	[pfl_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TB_MUNICIPIO]    Script Date: 11/19/2020 16:04:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TB_MUNICIPIO](
	[mnp_codigo_ibge] [varchar](50) NOT NULL,
	[mnp_nome] [varchar](100) NOT NULL,
	[mnp_dt_cadastro] [datetime] NOT NULL,
	[mnp_deletado] [bit] NOT NULL,
 CONSTRAINT [PK_MUNICIPIO] PRIMARY KEY CLUSTERED 
(
	[mnp_codigo_ibge] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TB_EMPRESA]    Script Date: 11/19/2020 16:04:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TB_EMPRESA](
	[emp_id] [int] IDENTITY(1,1) NOT NULL,
	[emp_nm_fantasia] [varchar](100) NOT NULL,
	[emp_logradouro] [varchar](150) NOT NULL,
	[emp_complemento] [varchar](150) NULL,
	[emp_bairro] [varchar](50) NOT NULL,
	[emp_municipio] [varchar](50) NOT NULL,
	[emp_uf] [char](2) NOT NULL,
	[emp_cep] [char](8) NOT NULL,
	[emp_telefone] [char](11) NOT NULL,
	[emp_dt_cadastro] [datetime] NOT NULL,
	[emp_dt_atualizacao] [datetime] NOT NULL,
	[emp_deletado] [bit] NOT NULL,
 CONSTRAINT [PK_EMPRESA] PRIMARY KEY CLUSTERED 
(
	[emp_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TB_BAIRRO]    Script Date: 11/19/2020 16:04:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TB_BAIRRO](
	[brr_codigo] [varchar](50) NOT NULL,
	[brr_descricao] [varchar](50) NOT NULL,
	[brr_dt_cadastro] [datetime] NOT NULL,
	[brr_deletado] [bit] NOT NULL,
 CONSTRAINT [PK_BAIRRO] PRIMARY KEY CLUSTERED 
(
	[brr_codigo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TB_USUARIO]    Script Date: 11/19/2020 16:04:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TB_USUARIO](
	[usr_id] [int] IDENTITY(1,1) NOT NULL,
	[usr_nome] [varchar](100) NOT NULL,
	[usr_cpf] [char](11) NOT NULL,
	[usr_sexo] [char](1) NOT NULL,
	[usr_dt_nascimento] [date] NOT NULL,
	[usr_telefone] [char](11) NOT NULL,
	[usr_email] [varchar](100) NOT NULL,
	[usr_senha] [varchar](15) NOT NULL,
	[usr_logradouro] [varchar](150) NOT NULL,
	[usr_complemento_logradouro] [varchar](150) NULL,
	[usr_bairro] [varchar](50) NOT NULL,
	[usr_municipio] [varchar](50) NOT NULL,
	[usr_cep] [char](8) NOT NULL,
	[usr_uf] [char](2) NOT NULL,
	[emp_id] [int] NOT NULL,
	[pfl_id] [int] NOT NULL,
	[usr_dt_cadastro] [datetime] NOT NULL,
	[usr_dt_atualizacao] [datetime] NOT NULL,
	[usr_deletado] [bit] NOT NULL,
 CONSTRAINT [PK_USUARIO] PRIMARY KEY CLUSTERED 
(
	[usr_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  ForeignKey [FK_USUARIO_PERFIL]    Script Date: 11/19/2020 16:04:15 ******/
ALTER TABLE [dbo].[TB_USUARIO]  WITH CHECK ADD  CONSTRAINT [FK_USUARIO_PERFIL] FOREIGN KEY([pfl_id])
REFERENCES [dbo].[TB_PERFIL] ([pfl_id])
GO
ALTER TABLE [dbo].[TB_USUARIO] CHECK CONSTRAINT [FK_USUARIO_PERFIL]
GO
