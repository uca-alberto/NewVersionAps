                                                                                                                                                                           USE [CBM]
GO
/****** Object:  Table [dbo].[T_Audit_Orden]    Script Date: 12/3/2019 16:17:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[T_Audit_Orden](
	[Id_audit_orden] [int] NOT NULL,
	[Id_orden] [int] NOT NULL,
	[Id_usuario] [int] NOT NULL,
	[Accion] [varchar](25) NOT NULL,
	[Fecha_accion] [date] NOT NULL,
 CONSTRAINT [PK_T_Audit_Orden150] PRIMARY KEY CLUSTERED 
(
	[Id_audit_orden] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[T_Audit_Resultado]    Script Date: 12/3/2019 16:17:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
/*Parametros*/
GO
CREATE TABLE [dbo].[T_Parametros](
	[Id_parametros] [int] IDENTITY(1,1) NOT NULL,
	[Id_examenes] [int] NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
 CONSTRAINT [PK_T_Parametros236] PRIMARY KEY CLUSTERED 
(
	[Id_parametros] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
/*terminar tabla*/
GO
CREATE TABLE [dbo].[T_Audit_Resultado](
	[Id_audit_resultado] [int] NOT NULL,
	[Id_resultado] [int] NOT NULL,
	[Id_usuario] [int] NOT NULL,
	[Accion] [varchar](20) NOT NULL,
	[Fecha_accion] [date] NOT NULL,
 CONSTRAINT [PK_T_Audit_Resultado151] PRIMARY KEY CLUSTERED 
(
	[Id_audit_resultado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[T_Clientes]    Script Date: 12/3/2019 16:17:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[T_Clientes](
	[Id_municipio] [int] NULL,
	[Id_cliente] [int] IDENTITY(1,1) NOT NULL,
	[Id_departamento] [int] NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Activo] [smallint] NOT NULL,
	[Apellido] [varchar](50) NOT NULL,
	[Cedula] [varchar](18) NOT NULL,
	[Direccion] [varchar](120) NOT NULL,
	[Num_telefono] [varchar](15) NOT NULL,
	[Sexo] [varchar](12) NOT NULL,
	[Email] [varchar](60) NOT NULL,
 CONSTRAINT [PK_T_Clientes140] PRIMARY KEY CLUSTERED 
(
	[Id_cliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[T_Departamento]    Script Date: 12/3/2019 16:17:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[T_Departamento](
	[Id_departamento] [int] IDENTITY(1,1) NOT NULL,
	[Departamento] [varchar](55) NOT NULL,
 CONSTRAINT [PK_T_Departamento153] PRIMARY KEY CLUSTERED 
(
	[Id_departamento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[T_Empleados]    Script Date: 12/3/2019 16:17:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
/*Tabla nueva*/
GO
CREATE TABLE [dbo].[T_Opcion_resultado](
	[Id_opcion] [int] NOT NULL, 
	[Resultado] [varchar](55) NOT NULL,
 CONSTRAINT [PK_T_Id_opcion] PRIMARY KEY CLUSTERED 
(
	[Id_opcion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[T_Empleados](
	[Id_empleado] [int] IDENTITY(1,1) NOT NULL,
	[Nombre_empleado] [varchar](50) NULL,
	[Apellido] [varchar](40) NULL,
	[Cargo] [varchar](30) NULL,
	[Cedula] [varchar](18) NULL,
	[Activo] [int] NOT NULL,
 CONSTRAINT [PK_T_Empleados162] PRIMARY KEY CLUSTERED 
(
	[Id_empleado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[T_Examenes]    Script Date: 12/3/2019 16:17:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[T_Examenes](
	[Id_examenes] [int] IDENTITY(1,1) NOT NULL,
	[Precio_examen] [decimal](6, 2) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
        [Estado] [int],
 CONSTRAINT [PK_T_Examenes152] PRIMARY KEY CLUSTERED 
(
	[Id_examenes] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[T_Municipio]    Script Date: 12/3/2019 16:17:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[T_Municipio](
	[Id_municipio] [int] IDENTITY(1,1) NOT NULL,
	[Id_departamento] [int] NOT NULL,
	[Municipio] [varchar](60) NOT NULL,
 CONSTRAINT [PK_T_Municipio154] PRIMARY KEY CLUSTERED 
(
	[Id_municipio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[T_Notificacion]    Script Date: 12/3/2019 16:17:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[T_Notificacion](
	[Id_notificacion] [int] IDENTITY(1,1) NOT NULL,
	[Id_empleado] [int] NOT NULL,
	[Id_resultado] [int] NOT NULL,
	[Fecha_Recepcion] [date] NOT NULL,
	[Fecha_Noti_L] [date] NOT NULL,
	[Fecha_Noti_C] [date] NOT NULL,
	[Id_tipo_muestra] [int] NOT NULL,
	[Id_cliente] [int] NOT NULL,
	[Observacion] [varchar](255) NULL,
 CONSTRAINT [PK_T_Notificacion] PRIMARY KEY CLUSTERED 
(
	[Id_notificacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[T_Opciones]    Script Date: 12/3/2019 16:17:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[T_Opciones](
	[Id_opciones] [int] NOT NULL,
	[Opciones] [varchar](85) NOT NULL,
 CONSTRAINT [PK_T_Opciones146] PRIMARY KEY CLUSTERED 
(
	[Id_opciones] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[T_Opciones_permiso]    Script Date: 12/3/2019 16:17:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[T_Opciones_permiso](
	[Id_opciones_permiso] [int] NOT NULL,
	[Id_opciones] [int] NOT NULL,
	[opciones_permiso] [varchar](50) NOT NULL,
 CONSTRAINT [PK_T_Opciones_permiso147] PRIMARY KEY CLUSTERED 
(
	[Id_opciones_permiso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[T_Orden]    Script Date: 12/3/2019 16:17:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[T_Orden](
	[Id_orden] [int] IDENTITY(1,1) NOT NULL,
	[Id_codigo] [varchar](25) NULL,
	[Tipo_caso] [varchar](25) NULL,
	[Id_examenes] [int] NOT NULL,
	[Id_tipo_muestra] [int] NULL,
	[Id_cliente] [int] NOT NULL,
	[Id_usuario] [int] NOT NULL,
	[Id_empleado] [int] NULL,
	[Nombre_pareja] [varchar](50) NULL,
	[Nombre_menor] [varchar](55) NULL,
	[fec_nac] [varchar](255) NULL,
	[Observaciones] [varchar](300) NOT NULL,
	[Baucher] [varchar](25) NOT NULL,
	[Estado] [varchar](25) NOT NULL,
	[Activo] [int] NOT NULL,
	[Fecha] [date] NOT NULL,
 CONSTRAINT [PK_T_Orden137] PRIMARY KEY CLUSTERED 
(
	[Id_orden] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[T_Orden_detalle]    Script Date: 12/3/2019 16:17:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[T_Orden_detalle](
	[Id_orden_detalle] [int] IDENTITY(1,1) NOT NULL,
	[Id_orden] [int] NOT NULL,
	[Id_analisis] [int] NULL,
	[Muestra_adn] [varchar](35) NULL,
	[Estado_orden] [varchar](25) NOT NULL,
 CONSTRAINT [PK_T_Orden_detalle149] PRIMARY KEY CLUSTERED 
(
	[Id_orden_detalle] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[T_Resultado_Detalle]    Script Date: 12/3/2019 16:17:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[T_Resultado_Detalle](
	[Id_resultado_detalle] [int] IDENTITY(1,1) NOT NULL,
	[Id_resultado] [int] NOT NULL,
	[Id_analisis][int] NOT NULL,
	[Resultado] [varchar](20) NOT NULL,
 CONSTRAINT [PK_T_Resultado_Detalle155] PRIMARY KEY CLUSTERED 
(
	[Id_resultado_detalle] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[T_Resultados]    Script Date: 12/3/2019 16:17:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[T_Resultados](
	[Id_resultado] [int] IDENTITY(1,1) NOT NULL,
	[Id_Orden] [int] NOT NULL,
	[Validacion] [int],
	[Fecha_procesamiento] [date] NOT NULL,
	[Hora] [time] NOT NULL,
	[Usuario_valida] [varchar](55),
	[Usuario_procesa] [varchar](55) NOT NULL,
	[Estado] [varchar](35) NOT NULL,
	[Observaciones] [varchar](300) NOT NULL,
	[imagen] [varchar](50),
	[Activo] [int] NOT NULL,
 CONSTRAINT [PK_T_Resultados141] PRIMARY KEY CLUSTERED 
(
	[Id_resultado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[T_Rol]    Script Date: 12/3/2019 16:17:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[T_Rol](
	[Id_rol] [int] NOT NULL,
	[Rol] [varchar](255) NOT NULL,
 CONSTRAINT [PK_T_Rol144] PRIMARY KEY CLUSTERED 
(
	[Id_rol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[T_Rol_opciones]    Script Date: 12/3/2019 16:17:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[T_Rol_opciones](
	[Id_rol_opciones] [int] NOT NULL,
	[Id_rol] [int] NOT NULL,
	[Id_opciones] [int] NOT NULL,
	[rol_opciones] [varchar](35) NOT NULL,
 CONSTRAINT [PK_T_Rol_opciones145] PRIMARY KEY CLUSTERED 
(
	[Id_rol_opciones] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[T_Rol_opciones_permiso]    Script Date: 12/3/2019 16:17:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[T_Rol_opciones_permiso](
	[Id_rol_opciones_permiso] [int] NOT NULL,
	[Id_opciones_permiso] [int] NOT NULL,
	[rol_opciones_permiso] [varchar](255) NOT NULL,
 CONSTRAINT [PK_T_Rol_opciones_permiso148] PRIMARY KEY CLUSTERED 
(
	[Id_rol_opciones_permiso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[T_Tipo_Analisis]    Script Date: 12/3/2019 16:17:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[T_Tipo_Analisis](
	[Id_analisis] [int] IDENTITY(1,1) NOT NULL,
	[analisis] [varchar](60) NOT NULL,

 CONSTRAINT [PK_T_Tipo_Analisis] PRIMARY KEY CLUSTERED 
(
	[Id_analisis] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[T_Tipo_muestra]    Script Date: 12/3/2019 16:17:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[T_Tipo_muestra](
	[Id_tipo_muestra] [int] IDENTITY(1,1) NOT NULL,
	[muestra] [varchar](50) NOT NULL,
        [estado] [int],
 CONSTRAINT [PK_T_Tipo_muestra157] PRIMARY KEY CLUSTERED 
(
	[Id_tipo_muestra] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[T_Usuario]    Script Date: 12/3/2019 16:17:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[T_Usuario](
	[Id_usuario] [int] NOT NULL,
	[Id_empleado] [int] NOT NULL,
	[Id_rol] [int] NOT NULL,
	[Nombre_Usuario] [varchar](55) NOT NULL,
	[Contrasena] [varchar](120) NOT NULL,
	[Activo] [smallint] NOT NULL,
 CONSTRAINT [PK_T_Usuario138] PRIMARY KEY CLUSTERED 
(
	[Id_usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[T_Clientes] ON 

GO
INSERT [dbo].[T_Clientes] ([Id_municipio], [Id_cliente], [Id_departamento], [Nombre], [Activo], [Apellido], [Cedula], [Direccion], [Num_telefono], [Sexo], [Email]) VALUES (2, 1, 2, N'Daniela', 1, N'Reyes', N'111-081098-1000H', N'La concha', N'87541236', N'0', N'Daniela@gmail.com')
GO
SET IDENTITY_INSERT [dbo].[T_Clientes] OFF
GO
SET IDENTITY_INSERT [dbo].[T_Departamento] ON 

GO
INSERT [dbo].[T_Departamento] ([Id_departamento], [Departamento]) VALUES (1, N'Managua')
GO
INSERT [dbo].[T_Departamento] ([Id_departamento], [Departamento]) VALUES (2, N'Masaya')
GO
INSERT [dbo].[T_Departamento] ([Id_departamento], [Departamento]) VALUES (3, N'Carazo')
GO
INSERT [dbo].[T_Departamento] ([Id_departamento], [Departamento]) VALUES (4, N'León')
GO
INSERT [dbo].[T_Departamento] ([Id_departamento], [Departamento]) VALUES (5, N'Granada')
GO
INSERT [dbo].[T_Departamento] ([Id_departamento], [Departamento]) VALUES (6, N'Rivas')
GO
SET IDENTITY_INSERT [dbo].[T_Departamento] OFF
GO
SET IDENTITY_INSERT [dbo].[T_Empleados] ON 

GO
INSERT [dbo].[T_Empleados] ([Id_empleado], [Nombre_empleado], [Apellido], [Cargo], [Cedula], [Activo]) VALUES (1, N'Wilgen', N'Sanchez', N'Administrador', N'1323', 1)
GO
SET IDENTITY_INSERT [dbo].[T_Empleados] OFF
GO
SET IDENTITY_INSERT [dbo].[T_Examenes] ON 

GO
INSERT [dbo].[T_Examenes] ([Id_examenes], [Nombre], [Precio_examen],[Estado]) VALUES (1, N'Paternidad', 200,1)
GO
INSERT [dbo].[T_Examenes] ([Id_examenes], [Nombre], [Precio_examen],[Estado]) VALUES (2, N'Maternidad', 200,1)
GO
INSERT [dbo].[T_Examenes] ([Id_examenes], [Nombre], [Precio_examen],[Estado]) VALUES (3, N'Abuelidad', 200,1)
GO
INSERT [dbo].[T_Examenes] ([Id_examenes], [Nombre], [Precio_examen],[Estado]) VALUES (4, N'Hermandad', 200,1)
GO
INSERT [dbo].[T_Examenes] ([Id_examenes], [Nombre], [Precio_examen],[Estado]) VALUES (5, N'Alzhaimer', 150,1)
GO
INSERT [dbo].[T_Examenes] ([Id_examenes], [Nombre], [Precio_examen],[Estado]) VALUES (6, N'Papiloma Humano', 100,1)
GO
INSERT [dbo].[T_Examenes] ([Id_examenes], [Nombre], [Precio_examen],[Estado]) VALUES (7, N'OGM', 150,1)
GO
INSERT [dbo].[T_Examenes] ([Id_examenes], [Nombre], [Precio_examen],[Estado]) VALUES (8, N'Patogeno', 150,1)
GO

SET IDENTITY_INSERT [dbo].[T_Examenes] OFF
GO
SET IDENTITY_INSERT [dbo].[T_Municipio] ON 

GO
INSERT [dbo].[T_Municipio] ([Id_municipio], [Id_departamento], [Municipio]) VALUES (1, 1, N'Managua')
GO
INSERT [dbo].[T_Municipio] ([Id_municipio], [Id_departamento], [Municipio]) VALUES (2, 2, N'Masaya')
GO
INSERT [dbo].[T_Municipio] ([Id_municipio], [Id_departamento], [Municipio]) VALUES (3, 3, N'Jinotepe')
GO
INSERT [dbo].[T_Municipio] ([Id_municipio], [Id_departamento], [Municipio]) VALUES (4, 4, N'Leon')
GO
INSERT [dbo].[T_Municipio] ([Id_municipio], [Id_departamento], [Municipio]) VALUES (5, 5, N'Granada')
GO
INSERT [dbo].[T_Municipio] ([Id_municipio], [Id_departamento], [Municipio]) VALUES (6, 6, N'Rivas')
GO
SET IDENTITY_INSERT [dbo].[T_Municipio] OFF
GO
INSERT [dbo].[T_Opciones] ([Id_opciones], [Opciones]) VALUES (1, N'/Views/ViewUsuario/AgregarUsuario.aspx')
GO
INSERT [dbo].[T_Opciones] ([Id_opciones], [Opciones]) VALUES (2, N'/Views/ViewCliente/AgregarCliente.aspx')
GO
INSERT [dbo].[T_Opciones] ([Id_opciones], [Opciones]) VALUES (3, N'/Views/ViewOrden/AgregarOrdenOgm.aspx')
GO
INSERT [dbo].[T_Rol] ([Id_rol], [Rol]) VALUES (1, N'Administrador')
GO
INSERT [dbo].[T_Rol] ([Id_rol], [Rol]) VALUES (2, N'Laboratorista')
GO
INSERT [dbo].[T_Rol] ([Id_rol], [Rol]) VALUES (3, N'Recepcionista')
GO
INSERT [dbo].[T_Opcion_resultado] ([Id_opcion], [Resultado]) VALUES (0, N'Negativo')
GO
INSERT [dbo].[T_Opcion_resultado] ([Id_opcion], [Resultado]) VALUES (1, N'Positivo')
GO
INSERT [dbo].[T_Rol_opciones] ([Id_rol_opciones], [Id_rol], [Id_opciones], [rol_opciones]) VALUES (1, 1, 1, N'Agregar Usuario')
GO
INSERT [dbo].[T_Rol_opciones] ([Id_rol_opciones], [Id_rol], [Id_opciones], [rol_opciones]) VALUES (2, 3, 2, N'Agregar Cliente')
GO
INSERT [dbo].[T_Rol_opciones] ([Id_rol_opciones], [Id_rol], [Id_opciones], [rol_opciones]) VALUES (3, 2, 3, N'Agregar Orden')
GO
SET IDENTITY_INSERT [dbo].[T_Tipo_Analisis] ON 

GO
INSERT [dbo].[T_Tipo_Analisis] ([Id_analisis], [analisis]) VALUES (1, N'Detección OGM por PCR')
GO
INSERT [dbo].[T_Tipo_Analisis] ([Id_analisis], [analisis]) VALUES (2, N'Detección OGM por test Inmunológico')
GO
INSERT [dbo].[T_Tipo_Analisis] ([Id_analisis], [analisis]) VALUES (3, N'Zebra Chip')
GO
INSERT [dbo].[T_Tipo_Analisis] ([Id_analisis], [analisis]) VALUES (4, N'Burkholderiaglumae')
GO
SET IDENTITY_INSERT [dbo].[T_Tipo_Analisis] OFF
GO

INSERT [dbo].[T_Usuario] ([Id_usuario], [Id_empleado], [Id_rol], [Nombre_Usuario], [Contrasena], [Activo]) VALUES (2, 1, 1, N'UCA', N'uAboyJ3UzUEoeOxeYP96UDjfFW32YBtiBCFYKpa9WlBSZGZTSWUEtLrhJpq5v3utaVDDdTJnl/eNqumFMloeQg==', 1)
GO
ALTER TABLE [dbo].[T_Audit_Orden]  WITH CHECK ADD  CONSTRAINT [FK_T_Audit_Orden114] FOREIGN KEY([Id_orden])
REFERENCES [dbo].[T_Orden] ([Id_orden])
GO
ALTER TABLE [dbo].[T_Audit_Orden] CHECK CONSTRAINT [FK_T_Audit_Orden114]
GO
ALTER TABLE [dbo].[T_Audit_Resultado]  WITH CHECK ADD  CONSTRAINT [FK_T_Audit_Resultado122] FOREIGN KEY([Id_resultado])
REFERENCES [dbo].[T_Resultados] ([Id_resultado])
GO
ALTER TABLE [dbo].[T_Audit_Resultado] CHECK CONSTRAINT [FK_T_Audit_Resultado122]
GO
ALTER TABLE [dbo].[T_Clientes]  WITH CHECK ADD  CONSTRAINT [FK_T_Clientes130] FOREIGN KEY([Id_municipio])
REFERENCES [dbo].[T_Municipio] ([Id_municipio])
GO
ALTER TABLE [dbo].[T_Clientes] CHECK CONSTRAINT [FK_T_Clientes130]
GO
ALTER TABLE [dbo].[T_Clientes]  WITH CHECK ADD  CONSTRAINT [FK_T_Clientes135] FOREIGN KEY([Id_departamento])
REFERENCES [dbo].[T_Departamento] ([Id_departamento])
GO
ALTER TABLE [dbo].[T_Clientes] CHECK CONSTRAINT [FK_T_Clientes135]
GO
ALTER TABLE [dbo].[T_Municipio]  WITH CHECK ADD  CONSTRAINT [FK_T_Municipio129] FOREIGN KEY([Id_departamento])
REFERENCES [dbo].[T_Departamento] ([Id_departamento])
GO
ALTER TABLE [dbo].[T_Municipio] CHECK CONSTRAINT [FK_T_Municipio129]
GO
ALTER TABLE [dbo].[T_Notificacion]  WITH CHECK ADD  CONSTRAINT [FK_T_Notificacion195] FOREIGN KEY([Id_cliente])
REFERENCES [dbo].[T_Clientes] ([Id_cliente])
GO
ALTER TABLE [dbo].[T_Notificacion] CHECK CONSTRAINT [FK_T_Notificacion195]
GO
ALTER TABLE [dbo].[T_Notificacion]  WITH CHECK ADD  CONSTRAINT [FK_T_Notificacion196] FOREIGN KEY([Id_tipo_muestra])
REFERENCES [dbo].[T_Tipo_muestra] ([Id_tipo_muestra])
GO
ALTER TABLE [dbo].[T_Notificacion] CHECK CONSTRAINT [FK_T_Notificacion196]
GO
ALTER TABLE [dbo].[T_Notificacion]  WITH CHECK ADD  CONSTRAINT [FK_T_Notificacion198] FOREIGN KEY([Id_resultado])
REFERENCES [dbo].[T_Resultados] ([Id_resultado])
GO
ALTER TABLE [dbo].[T_Notificacion] CHECK CONSTRAINT [FK_T_Notificacion198]
GO
ALTER TABLE [dbo].[T_Notificacion]  WITH CHECK ADD  CONSTRAINT [FK_T_Notificacion199] FOREIGN KEY([Id_empleado])
REFERENCES [dbo].[T_Empleados] ([Id_empleado])
GO
ALTER TABLE [dbo].[T_Notificacion] CHECK CONSTRAINT [FK_T_Notificacion199]
GO
ALTER TABLE [dbo].[T_Opciones_permiso]  WITH CHECK ADD  CONSTRAINT [FK_T_Opciones_permiso126] FOREIGN KEY([Id_opciones])
REFERENCES [dbo].[T_Opciones] ([Id_opciones])
GO
ALTER TABLE [dbo].[T_Opciones_permiso] CHECK CONSTRAINT [FK_T_Opciones_permiso126]
GO
ALTER TABLE [dbo].[T_Orden]  WITH CHECK ADD  CONSTRAINT [FK_T_Orden115] FOREIGN KEY([Id_tipo_muestra])
REFERENCES [dbo].[T_Tipo_muestra] ([Id_tipo_muestra])
GO
ALTER TABLE [dbo].[T_Orden] CHECK CONSTRAINT [FK_T_Orden115]
GO
ALTER TABLE [dbo].[T_Orden]  WITH CHECK ADD  CONSTRAINT [FK_T_Orden121] FOREIGN KEY([Id_examenes])
REFERENCES [dbo].[T_Examenes] ([Id_examenes])
GO
ALTER TABLE [dbo].[T_Orden] CHECK CONSTRAINT [FK_T_Orden121]
GO
ALTER TABLE [dbo].[T_Orden]  WITH CHECK ADD  CONSTRAINT [FK_T_Orden126] FOREIGN KEY([Id_usuario])
REFERENCES [dbo].[T_Usuario] ([Id_usuario])
GO
ALTER TABLE [dbo].[T_Orden] CHECK CONSTRAINT [FK_T_Orden126]
GO
ALTER TABLE [dbo].[T_Orden]  WITH CHECK ADD  CONSTRAINT [FK_T_Orden128] FOREIGN KEY([Id_cliente])
REFERENCES [dbo].[T_Clientes] ([Id_cliente])
GO
ALTER TABLE [dbo].[T_Orden] CHECK CONSTRAINT [FK_T_Orden128]
GO
ALTER TABLE [dbo].[T_Orden]  WITH CHECK ADD  CONSTRAINT [FK_T_Orden170] FOREIGN KEY([Id_empleado])
REFERENCES [dbo].[T_Empleados] ([Id_empleado])
GO
ALTER TABLE [dbo].[T_Orden] CHECK CONSTRAINT [FK_T_Orden170]
GO
ALTER TABLE [dbo].[T_Orden_detalle]  WITH CHECK ADD  CONSTRAINT [FK_T_Orden_detalle113] FOREIGN KEY([Id_orden])
REFERENCES [dbo].[T_Orden] ([Id_orden])
GO
ALTER TABLE [dbo].[T_Orden_detalle] CHECK CONSTRAINT [FK_T_Orden_detalle113]
GO
ALTER TABLE [dbo].[T_Orden_detalle]  WITH CHECK ADD  CONSTRAINT [FK_T_Orden_detalle199] FOREIGN KEY([Id_analisis])
REFERENCES [dbo].[T_Tipo_Analisis] ([Id_analisis])
GO
ALTER TABLE [dbo].[T_Orden_detalle] CHECK CONSTRAINT [FK_T_Orden_detalle199]

GO
ALTER TABLE [dbo].[T_Resultado_Detalle]  WITH CHECK ADD  CONSTRAINT [FK_T_Resultado_Detalle197] FOREIGN KEY([Id_resultado])
REFERENCES [dbo].[T_Resultados] ([Id_resultado])
GO
ALTER TABLE [dbo].[T_Resultado_Detalle] CHECK CONSTRAINT [FK_T_Resultado_Detalle197]
GO
ALTER TABLE [dbo].[T_Resultados]  WITH CHECK ADD  CONSTRAINT [FK_T_Resultados153] FOREIGN KEY([Id_Orden])
REFERENCES [dbo].[T_Orden] ([Id_orden])
GO
ALTER TABLE [dbo].[T_Rol_opciones]  WITH CHECK ADD  CONSTRAINT [FK_T_Rol_opciones124] FOREIGN KEY([Id_rol])
REFERENCES [dbo].[T_Rol] ([Id_rol])
GO
ALTER TABLE [dbo].[T_Rol_opciones] CHECK CONSTRAINT [FK_T_Rol_opciones124]
GO
ALTER TABLE [dbo].[T_Rol_opciones]  WITH CHECK ADD  CONSTRAINT [FK_T_Rol_opciones125] FOREIGN KEY([Id_opciones])
REFERENCES [dbo].[T_Opciones] ([Id_opciones])
GO
ALTER TABLE [dbo].[T_Rol_opciones] CHECK CONSTRAINT [FK_T_Rol_opciones125]
GO
ALTER TABLE [dbo].[T_Rol_opciones_permiso]  WITH CHECK ADD  CONSTRAINT [FK_T_Rol_opciones_permiso127] FOREIGN KEY([Id_opciones_permiso])
REFERENCES [dbo].[T_Opciones_permiso] ([Id_opciones_permiso])
GO
ALTER TABLE [dbo].[T_Rol_opciones_permiso] CHECK CONSTRAINT [FK_T_Rol_opciones_permiso127]
GO
ALTER TABLE [dbo].[T_Usuario]  WITH CHECK ADD  CONSTRAINT [FK_T_Usuario121] FOREIGN KEY([Id_rol])
REFERENCES [dbo].[T_Rol] ([Id_rol])
GO
ALTER TABLE [dbo].[T_Parametros]  WITH CHECK ADD  CONSTRAINT [PK_T_Parametros161] FOREIGN KEY([Id_examenes])
REFERENCES [dbo].[T_Examenes] ([Id_examenes])
GO
ALTER TABLE [dbo].[T_Usuario] CHECK CONSTRAINT [FK_T_Usuario121]
GO
ALTER TABLE [dbo].[T_Usuario]  WITH CHECK ADD  CONSTRAINT [FK_T_Usuario122] FOREIGN KEY([Id_empleado])
REFERENCES [dbo].[T_Empleados] ([Id_empleado])
GO
ALTER TABLE [dbo].[T_Usuario] CHECK CONSTRAINT [FK_T_Usuario122]
GO
/****** Object:  StoredProcedure [dbo].[AgregarUsuario]    Script Date: 12/3/2019 16:17:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AgregarUsuario] 
	-- Add the parameters for the stored procedure here
	@id_rol int, @Id_empleado int, @nombre_usuario varchar(60), @contrasena varchar(250), @activo int 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @id_usuario int = 1+(SELECT MAX(Id_usuario) from T_Usuario)
	insert into T_Usuario(Id_usuario, Id_empleado, Id_rol, Nombre_Usuario, Contrasena, Activo)
	values (@id_usuario, @Id_empleado, @id_rol, @nombre_usuario, @contrasena, 1)
END


GO

ALTER DATABASE CBM SET ENABLE_BROKER WITH ROLLBACK IMMEDIATE 

