USE [GD2C2014]
GO

CREATE SCHEMA [LOS_NORMALIZADORES]
GO

/****** Object:  Table [LOS_NORMALIZADORES].[Maestra]    Script Date: 13/09/2014 20:15:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [LOS_NORMALIZADORES].[Maestra](
	
	[Hotel_Ciudad] [varchar](255) NULL,
	[Hotel_Calle] [varchar](255) NULL,
	[Hotel_Nro_Calle] [numeric](18, 0) NULL,
	[Hotel_CantEstrella] [numeric](18, 0) NULL,
	[Hotel_Recarga_Estrella] [numeric](18, 0) NULL,
	
	[Habitacion_Numero] [numeric](18, 0) NULL,
	[Habitacion_Piso] [numeric](18, 0) NULL,
	[Habitacion_Frente] [varchar](50) NULL,
	[Habitacion_Tipo_Codigo] [numeric](18, 0) NULL,
	[Habitacion_Tipo_Descripcion] [varchar](255) NULL,
	[Habitacion_Tipo_Porcentual] [numeric](18, 2) NULL,
	
	[Regimen_Descripcion] [varchar](255) NULL,
	[Regimen_Precio] [numeric](18, 2) NULL,
	
	[Reserva_Fecha_Inicio] [datetime] NULL,
	[Reserva_Codigo] [numeric](18, 0) NULL,
	[Reserva_Cant_Noches] [numeric](18, 0) NULL,
	
	[Estadia_Fecha_Inicio] [datetime] NULL,
	[Estadia_Cant_Noches] [numeric](18, 0) NULL,
	
	[Consumible_Codigo] [numeric](18, 0) NULL,
	[Consumible_Descripcion] [varchar](255) NULL,
	[Consumible_Precio] [numeric](18, 2) NULL,
	
	[Item_Factura_Cantidad] [numeric](18, 0) NULL,
	[Item_Factura_Monto] [numeric](18, 2) NULL,
	
	[Factura_Nro] [numeric](18, 0) NULL,
	[Factura_Fecha] [datetime] NULL,
	[Factura_Total] [numeric](18, 2) NULL,
	
	[Cliente_Pasaporte_Nro] [numeric](18, 0) NULL,
	[Cliente_Apellido] [varchar](255) NULL,
	[Cliente_Nombre] [varchar](255) NULL,
	[Cliente_Fecha_Nac] [datetime] NULL,
	[Cliente_Mail] [varchar](255) NULL,
	[Cliente_Dom_Calle] [varchar](255) NULL,
	[Cliente_Nro_Calle] [numeric](18, 0) NULL,
	[Cliente_Piso] [numeric](18, 0) NULL,
	[Cliente_Depto] [varchar](50) NULL,
	[Cliente_Nacionalidad] [varchar](255) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO


INSERT INTO [GD2C2014].[LOS_NORMALIZADORES].[Maestra] SELECT TOP 1000 * FROM [GD2C2014].[LOS_NORMALIZADORES].[Maestra]
GO
  	

CREATE TABLE [LOS_NORMALIZADORES].[hoteles](
	[id] INTEGER IDENTITY PRIMARY KEY,
	[ciudad] [varchar](255),
	[calle] [varchar](255),
	[nro_Calle] [numeric](18, 0),
	[cant_estrella] [numeric](18, 0),
	[recarga_estrella] [numeric](18, 0)
) ON [PRIMARY]


CREATE TABLE [LOS_NORMALIZADORES].[habitaciones](
	[id] INTEGER IDENTITY PRIMARY KEY,
	[hotel_id] INTEGER,						/* A obtener de forma dificil */
	[numero] [numeric](18, 0),
	[piso] [numeric](18, 0),
	[frente] [varchar](50),
	[tipo_codigo] [numeric](18, 0),
	[tipo_descripcion] [varchar](255),
	[tipo_porcentual] [numeric](18, 2)
) ON [PRIMARY]


CREATE TABLE [LOS_NORMALIZADORES].[regimenes](
	[id] INTEGER IDENTITY PRIMARY KEY,
	[hotel_id] INTEGER,						/* Es a hotel??? Leer la consigna y averiguar */
	[descripcion] [varchar](255),
	[precio] [numeric](18, 2),
) ON [PRIMARY]


CREATE TABLE [LOS_NORMALIZADORES].[reservas](
	[id] INTEGER IDENTITY PRIMARY KEY,
	[habitacion_id] INTEGER,				/* Esto sopongo que hay que obtenerlo */
	[fecha_inicio] [datetime],
	[codigo] [numeric](18, 0),
	[cant_noches] [numeric](18, 0)
) ON [PRIMARY]


CREATE TABLE [LOS_NORMALIZADORES].[estadias](
	[id] INTEGER IDENTITY PRIMARY KEY,
	[habitacion_id] INTEGER,				/* Me imagino que hay que obtenerlo */
	[fecha_inicio] [datetime],
	[cant_noches] [numeric](18, 0),
) ON [PRIMARY]


CREATE TABLE [LOS_NORMALIZADORES].[consumibles](
	[id] INTEGER IDENTITY PRIMARY KEY,
	[habitacion_id] INTEGER,				/* Supongo que es a habitacion, pero confirmar con el enunciado */
	[codigo] [numeric](18, 0),
	[descripcion] [varchar](255),
	[precio] [numeric](18, 2),
) ON [PRIMARY]


CREATE TABLE [LOS_NORMALIZADORES].[items](
	[id] INTEGER IDENTITY PRIMARY KEY,
	[factura_id] INTEGER,					/* Me lo imagino pero no estoy seguro */
	[factura_cantidad] [numeric](18, 0),
	[monto] [numeric](18, 2),
) ON [PRIMARY]


CREATE TABLE [LOS_NORMALIZADORES].[facturas](
	[id] INTEGER IDENTITY PRIMARY KEY,
	[cliente_id] INTEGER,					/* Me lo imagino pero no estoy seguro */
	[hotel_id] INTEGER,						/* Me lo imagino pero no estoy seguro */
	[nro] [numeric](18, 0),
	[fecha] [datetime],
	[total] [numeric](18, 2),
) ON [PRIMARY]


CREATE TABLE [LOS_NORMALIZADORES].[clientes](
	[id] INTEGER IDENTITY PRIMARY KEY,
	[pasaporte_rro] [numeric](18, 0),
	[apellido] [varchar](255),
	[nombre] [varchar](255),
	[fecha_nac] [datetime],
	[mail] [varchar](255),
	[dom_calle] [varchar](255),
	[nro_calle] [numeric](18, 0),
	[piso] [numeric](18, 0),
	[depto] [varchar](50),
	[nacionalidad] [varchar](255)
) ON [PRIMARY]



/* Aca agregan las FKs */






/* Migracion de hoteles */

INSERT [LOS_NORMALIZADORES].[hoteles] (ciudad, calle, nro_calle, cant_estrella, recarga_estrella)
SELECT DISTINCT Hotel_Ciudad, Hotel_Calle, Hotel_Nro_Calle, Hotel_CantEstrella, Hotel_Recarga_Estrella  
FROM [LOS_NORMALIZADORES].[Maestra] 
WHERE Hotel_Ciudad IS NOT NULL 
AND Hotel_Calle IS NOT NULL
AND Hotel_Nro_Calle IS NOT NULL
AND Hotel_CantEstrella IS NOT NULL
AND Hotel_Recarga_Estrella IS NOT NULL

ALTER TABLE [LOS_NORMALIZADORES].[Maestra] ADD hotel_id INTEGER
GO

UPDATE [LOS_NORMALIZADORES].[Maestra]
SET hotel_id = 
	(SELECT id FROM [LOS_NORMALIZADORES].[hoteles] as h
	WHERE [LOS_NORMALIZADORES].[Maestra].Hotel_Ciudad = h.ciudad
	AND [LOS_NORMALIZADORES].[Maestra].Hotel_Calle = h.calle
	AND [LOS_NORMALIZADORES].[Maestra].Hotel_Nro_Calle = h.nro_calle
	AND [LOS_NORMALIZADORES].[Maestra].Hotel_CantEstrella = h.cant_estrella
	AND [LOS_NORMALIZADORES].[Maestra].Hotel_Recarga_Estrella = h.recarga_estrella)
GO


/* Migracion de habitaciones */

TRUNCATE TABLE [LOS_NORMALIZADORES].[habitaciones]
GO

INSERT [LOS_NORMALIZADORES].[habitaciones] (hotel_id, numero, piso, frente, tipo_codigo, tipo_descripcion, tipo_porcentual)
SELECT DISTINCT hotel_id, Habitacion_Numero, Habitacion_Piso, Habitacion_Frente, Habitacion_Tipo_Codigo, Habitacion_Tipo_Descripcion, Habitacion_Tipo_Porcentual  
FROM [LOS_NORMALIZADORES].[Maestra] 
WHERE Habitacion_Numero IS NOT NULL 
AND Habitacion_Piso IS NOT NULL
AND Habitacion_Frente IS NOT NULL
AND Habitacion_Tipo_Codigo IS NOT NULL
AND Habitacion_Tipo_Descripcion IS NOT NULL
AND Habitacion_Tipo_Porcentual IS NOT NULL


ALTER TABLE [LOS_NORMALIZADORES].[Maestra] ADD habitacion_id INTEGER
GO

UPDATE [LOS_NORMALIZADORES].[Maestra]
SET habitacion_id = 
	(SELECT id FROM [LOS_NORMALIZADORES].[habitaciones] as h
	WHERE [LOS_NORMALIZADORES].[Maestra].Habitacion_Numero = h.numero
	AND [LOS_NORMALIZADORES].[Maestra].Habitacion_Piso = h.piso
	AND [LOS_NORMALIZADORES].[Maestra].Habitacion_Frente = h.frente
	AND [LOS_NORMALIZADORES].[Maestra].Habitacion_Tipo_Codigo = h.tipo_codigo
	AND [LOS_NORMALIZADORES].[Maestra].Habitacion_Tipo_Descripcion = h.tipo_descripcion
	AND [LOS_NORMALIZADORES].[Maestra].Habitacion_Tipo_Porcentual = h.tipo_porcentual)
GO



/* Migracion de regimenes */

/* Migracion de reservas */ 

/* Estadias */

/* Consumibles */ 

/* Items */

/* Facturas */

/* Clientes */



/* TODO:
	- Normalizar calles, descripciones, ubicaciones y todo lo repetido
 */


/* LOGIN y ROLES */
CREATE TABLE [LOS_NORMALIZADORES].[usuarios](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [nvarchar](30) NOT NULL,
	[password] [nvarchar](30) NOT NULL,
	[rol] [tinyint] NOT NULL,
	[intentos_fallidos] [tinyint] NOT NULL,
	[estado] [bit] NOT NULL,
	[nombre] [nvarchar](255) NOT NULL,
	[apellido] [nvarchar](255) NOT NULL,
	[mail] [nvarchar](255) NOT NULL,
	[fecha_nac] [datetime] NOT NULL
 CONSTRAINT [PK_usuarios] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

CREATE PROCEDURE [LOS_NORMALIZADORES].[uspLogin]
	@username varchar(30),
	@password varchar(30),
	@intentos_fallidos int OUTPUT
AS
BEGIN
	SET NOCOUNT ON;
	
	DECLARE @password_ret varchar(30)
	DECLARE @estado bit
	
	SELECT @intentos_fallidos = intentos_fallidos, @password_ret = password, @estado = estado FROM usuarios WHERE username = @username
	
	IF (@intentos_fallidos IS NOT NULL) AND @password = @password_ret
	BEGIN
		IF @intentos_fallidos < 3
			UPDATE usuarios SET intentos_fallidos = 0 WHERE username = @username AND estado = 1
		ELSE
			SET @intentos_fallidos = -2
		IF @estado = 0
			SET @intentos_fallidos = -3
		RETURN
	END
	

	IF (@intentos_fallidos IS NOT NULL)
	BEGIN
		SET @intentos_fallidos = @intentos_fallidos+1
		UPDATE usuarios SET intentos_fallidos = intentos_fallidos+1 WHERE username = @username
		RETURN
	END
	SET @intentos_fallidos = -1
	RETURN
END