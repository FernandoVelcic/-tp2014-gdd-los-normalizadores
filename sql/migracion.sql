USE [GD1C2014]
GO

DROP DATABASE [LOS_NORMALIZADORES]
GO

CREATE DATABASE [LOS_NORMALIZADORES];
GO 


USE [LOS_NORMALIZADORES] 
GO

CREATE SCHEMA [gd_esquema]
GO

/****** Object:  Table [gd_esquema].[Maestra]    Script Date: 13/09/2014 20:15:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [gd_esquema].[Maestra](
	
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


INSERT INTO [LOS_NORMALIZADORES].[gd_esquema].[Maestra] SELECT TOP 1000 * FROM [GD1C2014].[gd_esquema].[Maestra]
GO
  	

CREATE TABLE [gd_esquema].[hoteles](
	[id] INTEGER IDENTITY PRIMARY KEY,
	[ciudad] [varchar](255),
	[calle] [varchar](255),
	[nro_Calle] [numeric](18, 0),
	[cant_estrella] [numeric](18, 0),
	[recarga_estrella] [numeric](18, 0)
) ON [PRIMARY]


CREATE TABLE [gd_esquema].[habitaciones](
	[id] INTEGER IDENTITY PRIMARY KEY,
	[hotel_id] INTEGER,						/* A obtener de forma dificil */
	[numero] [numeric](18, 0),
	[piso] [numeric](18, 0),
	[frente] [varchar](50),
	[tipo_codigo] [numeric](18, 0),
	[tipo_descripcion] [varchar](255),
	[tipo_porcentual] [numeric](18, 2)
) ON [PRIMARY]


CREATE TABLE [gd_esquema].[regimenes](
	[id] INTEGER IDENTITY PRIMARY KEY,
	[hotel_id] INTEGER,						/* Es a hotel??? Leer la consigna y averiguar */
	[descripcion] [varchar](255),
	[precio] [numeric](18, 2),
) ON [PRIMARY]


CREATE TABLE [gd_esquema].[reservas](
	[id] INTEGER IDENTITY PRIMARY KEY,
	[habitacion_id] INTEGER,				/* Esto sopongo que hay que obtenerlo */
	[fecha_inicio] [datetime],
	[codigo] [numeric](18, 0),
	[cant_noches] [numeric](18, 0)
) ON [PRIMARY]


CREATE TABLE [gd_esquema].[estadias](
	[id] INTEGER IDENTITY PRIMARY KEY,
	[habitacion_id] INTEGER,				/* Me imagino que hay que obtenerlo */
	[fecha_inicio] [datetime],
	[cant_noches] [numeric](18, 0),
) ON [PRIMARY]


CREATE TABLE [gd_esquema].[consumibles](
	[id] INTEGER IDENTITY PRIMARY KEY,
	[habitacion_id] INTEGER,				/* Supongo que es a habitacion, pero confirmar con el enunciado */
	[codigo] [numeric](18, 0),
	[descripcion] [varchar](255),
	[precio] [numeric](18, 2),
) ON [PRIMARY]


CREATE TABLE [gd_esquema].[items](
	[id] INTEGER IDENTITY PRIMARY KEY,
	[factura_id] INTEGER,					/* Me lo imagino pero no estoy seguro */
	[factura_cantidad] [numeric](18, 0),
	[monto] [numeric](18, 2),
) ON [PRIMARY]


CREATE TABLE [gd_esquema].[facturas](
	[id] INTEGER IDENTITY PRIMARY KEY,
	[cliente_id] INTEGER,					/* Me lo imagino pero no estoy seguro */
	[hotel_id] INTEGER,						/* Me lo imagino pero no estoy seguro */
	[nro] [numeric](18, 0),
	[fecha] [datetime],
	[total] [numeric](18, 2),
) ON [PRIMARY]


CREATE TABLE [gd_esquema].[clientes](
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

INSERT [gd_esquema].[hoteles] (ciudad, calle, nro_calle, cant_estrella, recarga_estrella)
SELECT DISTINCT Hotel_Ciudad, Hotel_Calle, Hotel_Nro_Calle, Hotel_CantEstrella, Hotel_Recarga_Estrella  
FROM [gd_esquema].[Maestra] 
WHERE Hotel_Ciudad IS NOT NULL 
AND Hotel_Calle IS NOT NULL
AND Hotel_Nro_Calle IS NOT NULL
AND Hotel_CantEstrella IS NOT NULL
AND Hotel_Recarga_Estrella IS NOT NULL

ALTER TABLE [gd_esquema].[Maestra] ADD hotel_id INTEGER
GO

UPDATE [gd_esquema].[Maestra]
SET hotel_id = 
	(SELECT id FROM [gd_esquema].[hoteles] as h
	WHERE [gd_esquema].[Maestra].Hotel_Ciudad = h.ciudad
	AND [gd_esquema].[Maestra].Hotel_Calle = h.calle
	AND [gd_esquema].[Maestra].Hotel_Nro_Calle = h.nro_calle
	AND [gd_esquema].[Maestra].Hotel_CantEstrella = h.cant_estrella
	AND [gd_esquema].[Maestra].Hotel_Recarga_Estrella = h.recarga_estrella)
GO


/* Migracion de habitaciones */

TRUNCATE TABLE [gd_esquema].[habitaciones]
GO

INSERT [gd_esquema].[habitaciones] (hotel_id, numero, piso, frente, tipo_codigo, tipo_descripcion, tipo_porcentual)
SELECT DISTINCT hotel_id, Habitacion_Numero, Habitacion_Piso, Habitacion_Frente, Habitacion_Tipo_Codigo, Habitacion_Tipo_Descripcion, Habitacion_Tipo_Porcentual  
FROM [gd_esquema].[Maestra] 
WHERE Habitacion_Numero IS NOT NULL 
AND Habitacion_Piso IS NOT NULL
AND Habitacion_Frente IS NOT NULL
AND Habitacion_Tipo_Codigo IS NOT NULL
AND Habitacion_Tipo_Descripcion IS NOT NULL
AND Habitacion_Tipo_Porcentual IS NOT NULL


ALTER TABLE [gd_esquema].[Maestra] ADD habitacion_id INTEGER
GO

UPDATE [gd_esquema].[Maestra]
SET habitacion_id = 
	(SELECT id FROM [gd_esquema].[habitaciones] as h
	WHERE [gd_esquema].[Maestra].Habitacion_Numero = h.numero
	AND [gd_esquema].[Maestra].Habitacion_Piso = h.piso
	AND [gd_esquema].[Maestra].Habitacion_Frente = h.frente
	AND [gd_esquema].[Maestra].Habitacion_Tipo_Codigo = h.tipo_codigo
	AND [gd_esquema].[Maestra].Habitacion_Tipo_Descripcion = h.tipo_descripcion
	AND [gd_esquema].[Maestra].Habitacion_Tipo_Porcentual = h.tipo_porcentual)
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
