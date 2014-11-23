USE [GD2C2014]
GO

/* START TESTING ONLY */
DROP DATABASE [LOS_NORMALIZADORES]
GO

CREATE DATABASE [LOS_NORMALIZADORES]
GO

USE [LOS_NORMALIZADORES]
GO
/* END TESTING_ONLY */

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
	
	[Hotel_Ciudad] [nvarchar](255) NULL,
	[Hotel_Calle] [nvarchar](255) NULL,
	[Hotel_Nro_Calle] [numeric](18, 0) NULL,
	[Hotel_CantEstrella] [numeric](18, 0) NULL,
	[Hotel_Recarga_Estrella] [numeric](18, 0) NULL,
	
	[Habitacion_Numero] [numeric](18, 0) NULL,
	[Habitacion_Piso] [numeric](18, 0) NULL,
	[Habitacion_Frente] [nvarchar](50) NULL,
	[Habitacion_Tipo_Codigo] [numeric](18, 0) NULL,
	[Habitacion_Tipo_Descripcion] [nvarchar](255) NULL,
	[Habitacion_Tipo_Porcentual] [numeric](18, 2) NULL,
	
	[Regimen_Descripcion] [nvarchar](255) NULL,
	[Regimen_Precio] [numeric](18, 2) NULL,
	
	[Reserva_Fecha_Inicio] [datetime] NULL,
	[Reserva_Codigo] [numeric](18, 0) NULL,
	[Reserva_Cant_Noches] [numeric](18, 0) NULL,
	
	[Estadia_Fecha_Inicio] [datetime] NULL,
	[Estadia_Cant_Noches] [numeric](18, 0) NULL,
	
	[Consumible_Codigo] [numeric](18, 0) NULL,
	[Consumible_Descripcion] [nvarchar](255) NULL,
	[Consumible_Precio] [numeric](18, 2) NULL,
	
	[Item_Factura_Cantidad] [numeric](18, 0) NULL,
	[Item_Factura_Monto] [numeric](18, 2) NULL,
	
	[Factura_Nro] [numeric](18, 0) NULL,
	[Factura_Fecha] [datetime] NULL,
	[Factura_Total] [numeric](18, 2) NULL,
	
	[Cliente_Pasaporte_Nro] [numeric](18, 0) NULL,
	[Cliente_Apellido] [nvarchar](255) NULL,
	[Cliente_Nombre] [nvarchar](255) NULL,
	[Cliente_Fecha_Nac] [datetime] NULL,
	[Cliente_Mail] [nvarchar](255) NULL,
	[Cliente_Dom_Calle] [nvarchar](255) NULL,
	[Cliente_Nro_Calle] [numeric](18, 0) NULL,
	[Cliente_Piso] [numeric](18, 0) NULL,
	[Cliente_Depto] [nvarchar](50) NULL,
	[Cliente_Nacionalidad] [nvarchar](255) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO

CREATE TABLE [LOS_NORMALIZADORES].[hoteles](
	[id] INTEGER IDENTITY PRIMARY KEY,
	[ciudad] [nvarchar](255),
	[calle] [nvarchar](255),
	[nro_Calle] [numeric](18, 0),
	[cant_estrella] [numeric](18, 0),
	[recarga_estrella] [numeric](18, 0),
	[nombre] [nvarchar](255) NOT NULL,
	[mail] [nvarchar](255),
	[telefono] [nvarchar](255),
	[pais_id] INTEGER,
	[fecha_creacion] [datetime],
) ON [PRIMARY]

CREATE TABLE [LOS_NORMALIZADORES].[hoteles_bajas](
	[id] INTEGER IDENTITY PRIMARY KEY,
	[hotel_id] INTEGER NOT NULL,
	[fecha_desde] [datetime] NOT NULL,
	[fecha_hasta] [datetime] NOT NULL
) ON [PRIMARY]



CREATE TABLE [LOS_NORMALIZADORES].[habitaciones](
	[id] INTEGER IDENTITY PRIMARY KEY,
	[hotel_id] INTEGER,	
	[numero] [numeric](18, 0),
	[piso] [numeric](18, 0),
	[frente] [nvarchar](50),
	[tipo_id] INTEGER,
	[estado] [bit] NOT NULL,
	[descripcion] [nvarchar](255)
) ON [PRIMARY]


CREATE TABLE [LOS_NORMALIZADORES].[habitaciones_tipos](
	[id] INTEGER IDENTITY(1001,1) PRIMARY KEY,
	[descripcion] [nvarchar](255),
	[porcentual] [numeric](18, 2),
	[cantidad_maxima_personas]	INTEGER	DEFAULT 0	/* Hace falta? */
) ON [PRIMARY]


CREATE TABLE [LOS_NORMALIZADORES].[hoteles_regimenes](
	[id] INTEGER IDENTITY PRIMARY KEY,
	[hotel_id] INTEGER,
	[regimen_id] INTEGER
) ON [PRIMARY]


CREATE TABLE [LOS_NORMALIZADORES].[regimenes](
	[id] INTEGER IDENTITY PRIMARY KEY,
	[descripcion] [nvarchar](255),
	[precio] [numeric](18, 2),
	[estado] [bit]
) ON [PRIMARY]


CREATE TABLE [LOS_NORMALIZADORES].[reservas](

	[id] INTEGER IDENTITY(10001,1) PRIMARY KEY,
	[fecha_carga] [datetime],					/* Fecha en que se realizo la reserva, debe ser por archivo de configuración */
	[fecha_inicio] [datetime],					/* Fecha en del primer dia que se va a alojar el huesped */
	[cant_noches] [numeric](18, 0),
	[regimen_id] INTEGER,
	[cliente_id]	INTEGER,				
	[reserva_estado] INTEGER NOT NULL,
												/* Como calculo el precio?? */
) ON [PRIMARY]



CREATE TABLE [LOS_NORMALIZADORES].[reservas_habitaciones](
	[id] INTEGER IDENTITY PRIMARY KEY,
	[reserva_id]	INTEGER,
	[habitacion_id] INTEGER
) ON [PRIMARY]

CREATE TABLE [LOS_NORMALIZADORES].[reserva_estado](
	[id] INTEGER IDENTITY PRIMARY KEY,
	[descripcion] [nvarchar] (255),
) ON [PRIMARY]	

CREATE TABLE [LOS_NORMALIZADORES].[estadia_cliente](
	[id] iNTEGER IDENTITY PRIMARY KEY,
	[estadia_id] INTEGER,
	[cliente_id] INTEGER,
) ON [PRIMARY]

CREATE TABLE [LOS_NORMALIZADORES].[clientes](
	[id] INTEGER IDENTITY PRIMARY KEY,
	[apellido] [nvarchar](255),
	[nombre] [nvarchar](255),
	[fecha_nac] [datetime],
	[mail] [nvarchar](255),
	[dom_calle] [nvarchar](255),
	[nro_calle] [numeric](18, 0),
	[piso] [numeric](18, 0),
	[depto] [nvarchar](50),
	[localidad] [nvarchar](255),
	[nacionalidad_id] INTEGER NOT NULL,
	[pais_id] INTEGER,
	[documento_tipo_id] INTEGER NOT NULL,
	[documento_nro] [numeric](18, 0) NOT NULL,
	[telefono] [nvarchar](255) NULL,
	[estado] [bit] default 1,
	[nro_tarjeta] [nvarchar] (255),
	[pin] [nvarchar] (255)
) ON [PRIMARY]


CREATE TABLE [LOS_NORMALIZADORES].[estadias](
	[id] INTEGER IDENTITY PRIMARY KEY,
	[reserva_id] INTEGER,				
	[fecha_inicio] [datetime],
	[cant_noches] [numeric] (18,0),
) ON [PRIMARY]


CREATE TABLE [LOS_NORMALIZADORES].[consumibles](
	[id] INTEGER IDENTITY(2324,1) PRIMARY KEY,
	[descripcion] [nvarchar](255),
	[precio] [numeric](18, 2),
) ON [PRIMARY]


CREATE TABLE [LOS_NORMALIZADORES].[items_facturas](
	[id] INTEGER IDENTITY PRIMARY KEY,
	[factura_id] INTEGER,
	[consumible_id] INTEGER,
	[estadia_id] INTEGER,
	[monto] [numeric] (18,2),
	[unidades] INTEGER,
	[tipo] [char] (1),

) ON [PRIMARY]


CREATE TABLE [LOS_NORMALIZADORES].[facturas](
	[id] INTEGER IDENTITY PRIMARY KEY,
	[estadia_id] INTEGER NOT NULL,					
	[fecha] [datetime] NOT NULL,					
	[forma_pago_id] INTEGER NOT NULL,			/* Este dato no esta en la Maestra */
	[cliente_id] INTEGER NOT NULL
) ON [PRIMARY]

CREATE TABLE [LOS_NORMALIZADORES].[formas_de_pago](
	[id] INTEGER IDENTITY PRIMARY KEY,			
	[descripcion] [nvarchar](30) NOT NULL
) ON [PRIMARY]


CREATE TABLE [LOS_NORMALIZADORES].[paises](
	[id] INTEGER IDENTITY PRIMARY KEY,
	[nombre] [nvarchar](255) NOT NULL,					
	[gentilicio] [nvarchar](255) NOT NULL,
) ON [PRIMARY]

CREATE TABLE [LOS_NORMALIZADORES].[reservas_canceladas](
	[id] INTEGER IDENTITY PRIMARY KEY,
	[reserva_id] INTEGER NOT NULL,
	[motivo] [nvarchar](255),
	[fecha] [datetime],				/* Fecha en que se cancela la reserva */
	[usuario] [nvarchar](30),		/* Usuario que cancela */
) ON [PRIMARY]

INSERT INTO [LOS_NORMALIZADORES].[paises] (nombre, gentilicio) VALUES ('', '')
INSERT INTO [LOS_NORMALIZADORES].[paises] (nombre, gentilicio) VALUES ('ARGENTINA', 'ARGENTINO')
	

//TESTING
INSERT INTO [LOS_NORMALIZADORES].[Maestra] SELECT TOP 10000 * FROM [GD2C2014].[gd_esquema].[Maestra] ORDER BY Factura_Nro DESC
GO
  	

/* Migracion de hoteles */

INSERT [LOS_NORMALIZADORES].[hoteles] (ciudad, calle, nro_calle, cant_estrella, recarga_estrella, nombre, mail, telefono, pais_id)
SELECT DISTINCT RTRIM(Hotel_Ciudad), Hotel_Calle, Hotel_Nro_Calle, Hotel_CantEstrella, Hotel_Recarga_Estrella, Hotel_Calle+' '+LTRIM(STR(Hotel_Nro_Calle)), '', '', 1
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
	(
		SELECT id FROM [LOS_NORMALIZADORES].[hoteles] as h
		WHERE [LOS_NORMALIZADORES].[Maestra].Hotel_Ciudad = h.ciudad
		AND [LOS_NORMALIZADORES].[Maestra].Hotel_Calle = h.calle
		AND [LOS_NORMALIZADORES].[Maestra].Hotel_Nro_Calle = h.nro_calle
		AND [LOS_NORMALIZADORES].[Maestra].Hotel_CantEstrella = h.cant_estrella
		AND [LOS_NORMALIZADORES].[Maestra].Hotel_Recarga_Estrella = h.recarga_estrella
	)
GO

CREATE INDEX Maestra_hotel_id ON [LOS_NORMALIZADORES].[Maestra] (hotel_id)


/* Migracion de habitaciones */
SET IDENTITY_INSERT [LOS_NORMALIZADORES].[habitaciones_tipos] ON;
INSERT [LOS_NORMALIZADORES].[habitaciones_tipos] (id, descripcion, porcentual)
SELECT DISTINCT Habitacion_Tipo_Codigo, Habitacion_Tipo_Descripcion, Habitacion_Tipo_Porcentual  
FROM [LOS_NORMALIZADORES].[Maestra] 
WHERE Habitacion_Tipo_Codigo IS NOT NULL
AND Habitacion_Tipo_Descripcion IS NOT NULL
AND Habitacion_Tipo_Porcentual IS NOT NULL

SET IDENTITY_INSERT [LOS_NORMALIZADORES].[habitaciones_tipos] OFF;

ALTER TABLE [LOS_NORMALIZADORES].[Maestra] ADD habitacion_tipo_id INTEGER
GO

UPDATE [LOS_NORMALIZADORES].[Maestra]
SET habitacion_tipo_id = 
	(
		SELECT id FROM [LOS_NORMALIZADORES].[habitaciones_tipos] as h
		WHERE [LOS_NORMALIZADORES].[Maestra].Habitacion_Tipo_Codigo = h.id
		AND [LOS_NORMALIZADORES].[Maestra].Habitacion_Tipo_Descripcion = h.descripcion
		AND [LOS_NORMALIZADORES].[Maestra].Habitacion_Tipo_Porcentual = h.porcentual
	)
GO

UPDATE [LOS_NORMALIZADORES].[habitaciones_tipos] SET cantidad_maxima_personas = 1 WHERE [habitaciones_tipos].descripcion = 'Base Simple'
UPDATE [LOS_NORMALIZADORES].[habitaciones_tipos] SET cantidad_maxima_personas = 2 WHERE [habitaciones_tipos].descripcion = 'Base Doble'
UPDATE [LOS_NORMALIZADORES].[habitaciones_tipos] SET cantidad_maxima_personas = 3 WHERE [habitaciones_tipos].descripcion = 'Base Triple'
UPDATE [LOS_NORMALIZADORES].[habitaciones_tipos] SET cantidad_maxima_personas = 4 WHERE [habitaciones_tipos].descripcion = 'Base Cuadruple'
UPDATE [LOS_NORMALIZADORES].[habitaciones_tipos] SET cantidad_maxima_personas = 5 WHERE [habitaciones_tipos].descripcion = 'King'


INSERT [LOS_NORMALIZADORES].[habitaciones] (hotel_id, numero, piso, frente, tipo_id, estado, descripcion)
	SELECT DISTINCT hotel_id, Habitacion_Numero, Habitacion_Piso, Habitacion_Frente, habitacion_tipo_id, 1, '' 
	FROM [LOS_NORMALIZADORES].[Maestra] 
		WHERE Habitacion_Numero IS NOT NULL 
			AND Habitacion_Piso IS NOT NULL
			AND Habitacion_Frente IS NOT NULL
			AND habitacion_tipo_id IS NOT NULL

ALTER TABLE [LOS_NORMALIZADORES].[Maestra] ADD habitacion_id INTEGER
GO

UPDATE [LOS_NORMALIZADORES].[Maestra]
SET habitacion_id = 
	(
		SELECT id FROM [LOS_NORMALIZADORES].[habitaciones] as h
			WHERE [LOS_NORMALIZADORES].[Maestra].Habitacion_Numero = h.numero
				AND [LOS_NORMALIZADORES].[Maestra].hotel_id = h.hotel_id
				AND [LOS_NORMALIZADORES].[Maestra].Habitacion_Piso = h.piso
				AND [LOS_NORMALIZADORES].[Maestra].Habitacion_Frente = h.frente
				AND [LOS_NORMALIZADORES].[Maestra].habitacion_tipo_id = h.tipo_id
	)
GO

 CREATE INDEX Maestra_habitacion_id ON [LOS_NORMALIZADORES].[Maestra] (habitacion_id)


/* Migracion de regimenes */

INSERT INTO [LOS_NORMALIZADORES].[regimenes] ([descripcion], [precio], [estado])	
	SELECT DISTINCT [Regimen_Descripcion], [Regimen_Precio], 1 FROM [LOS_NORMALIZADORES].[Maestra]
	WHERE [Regimen_Descripcion] IS NOT NULL 
	AND   [Regimen_Precio] IS NOT NULL
GO

ALTER TABLE [LOS_NORMALIZADORES].[Maestra] ADD regimen_id INTEGER
GO



UPDATE [LOS_NORMALIZADORES].[Maestra]
SET regimen_id = 
	(
		SELECT id FROM [LOS_NORMALIZADORES].[regimenes] as r
		WHERE [LOS_NORMALIZADORES].[Maestra].Regimen_Descripcion = r.descripcion
		AND   [LOS_NORMALIZADORES].[Maestra].Regimen_Precio = r.precio
	)
GO

CREATE INDEX Maestra_regimen_id ON [LOS_NORMALIZADORES].[Maestra] (regimen_id)


/* Relacion entre regimenes y hoteles */
INSERT INTO [LOS_NORMALIZADORES].[hoteles_regimenes] (hotel_id, regimen_id)

	SELECT DISTINCT hotel_id, regimen_id FROM  [LOS_NORMALIZADORES].[Maestra]
	WHERE hotel_id is NOT NULL
		AND regimen_id IS NOT NULL

GO



/* Clientes */

INSERT INTO [LOS_NORMALIZADORES].[clientes] ([documento_nro], [apellido], [nombre], [fecha_nac], [mail], [dom_calle], [nro_calle], [piso], [depto], [nacionalidad_id], [documento_tipo_id], [pais_id])	
	SELECT DISTINCT [Cliente_Pasaporte_Nro], [Cliente_Apellido], [Cliente_Nombre], [Cliente_Fecha_Nac], [Cliente_Mail], [Cliente_Dom_Calle], [Cliente_Nro_Calle], [Cliente_Piso], [Cliente_Depto], 2, 4, 1 FROM [LOS_NORMALIZADORES].[Maestra]
	WHERE [Cliente_Pasaporte_Nro] IS NOT NULL 
	AND   [Cliente_Apellido] IS NOT NULL
	AND   [Cliente_Nombre] IS NOT NULL
	AND   [Cliente_Fecha_Nac] IS NOT NULL
	AND   [Cliente_Mail] IS NOT NULL
	AND   [Cliente_Dom_Calle] IS NOT NULL
	AND   [Cliente_Nro_Calle] IS NOT NULL
	AND   [Cliente_Piso] IS NOT NULL
	AND   [Cliente_Depto] IS NOT NULL
	AND   [Cliente_Nacionalidad] IS NOT NULL
GO

ALTER TABLE [LOS_NORMALIZADORES].[Maestra] ADD cliente_id INTEGER
GO

CREATE INDEX Clientes_Pasaporte_Nro_id ON [LOS_NORMALIZADORES].[clientes] (documento_nro)
CREATE INDEX Maestra_Cliente_Pasaporte_Nro_id ON [LOS_NORMALIZADORES].[Maestra] (Cliente_Pasaporte_Nro)

UPDATE [LOS_NORMALIZADORES].[Maestra]
SET cliente_id = 
	(
		SELECT id FROM [LOS_NORMALIZADORES].[clientes] as c
		WHERE [LOS_NORMALIZADORES].[Maestra].Cliente_Pasaporte_Nro = c.documento_nro
		AND   [LOS_NORMALIZADORES].[Maestra].Cliente_Apellido = c.apellido
		AND   [LOS_NORMALIZADORES].[Maestra].Cliente_Nombre = c.nombre
		AND   [LOS_NORMALIZADORES].[Maestra].Cliente_Fecha_Nac = c.fecha_nac
		AND   [LOS_NORMALIZADORES].[Maestra].Cliente_Mail = c.mail
		AND   [LOS_NORMALIZADORES].[Maestra].Cliente_Dom_Calle = c.dom_calle
		AND   [LOS_NORMALIZADORES].[Maestra].Cliente_Nro_Calle = c.nro_calle
		AND   [LOS_NORMALIZADORES].[Maestra].Cliente_Piso = c.piso
		AND   [LOS_NORMALIZADORES].[Maestra].Cliente_Depto = c.depto
	)
GO

DROP INDEX Clientes_Pasaporte_Nro_id ON [LOS_NORMALIZADORES].[clientes]
CREATE INDEX Maestra_cliente_id ON [LOS_NORMALIZADORES].[Maestra] (cliente_id)


/* Migracion de reservas */ 

/* Se toma el codigo como id */
SET IDENTITY_INSERT [LOS_NORMALIZADORES].[reservas] ON;
INSERT INTO [LOS_NORMALIZADORES].[reservas] (id, [cliente_id], [fecha_inicio], [cant_noches], [regimen_id], [reserva_estado])	
	SELECT DISTINCT [Reserva_Codigo], [cliente_id], [Reserva_Fecha_Inicio], [Reserva_Cant_Noches], [regimen_id], 1 FROM [LOS_NORMALIZADORES].[Maestra]
	WHERE [Reserva_Fecha_Inicio] IS NOT NULL 
	AND   [Reserva_Codigo] IS NOT NULL
	AND   [Reserva_Cant_Noches] IS NOT NULL
	AND   [regimen_id] IS NOT NULL
	AND   [cliente_id] IS NOT NULL
	AND	  [habitacion_id] IS NOT NULL
GO

SET IDENTITY_INSERT [LOS_NORMALIZADORES].[reservas] OFF;

ALTER TABLE [LOS_NORMALIZADORES].[Maestra] ADD reserva_id INTEGER
GO


UPDATE [LOS_NORMALIZADORES].[Maestra]
SET reserva_id = 
	(
		SELECT id FROM [LOS_NORMALIZADORES].[reservas] as r
		WHERE [LOS_NORMALIZADORES].[Maestra].Reserva_Fecha_Inicio = r.fecha_inicio
		AND   [LOS_NORMALIZADORES].[Maestra].Reserva_Codigo = r.id
		AND   [LOS_NORMALIZADORES].[Maestra].Reserva_Cant_Noches = r.cant_noches
		AND   [LOS_NORMALIZADORES].[Maestra].regimen_id = r.regimen_id
	)
GO

/* Migracion de reservas_habitaciones */
INSERT INTO [LOS_NORMALIZADORES].[reservas_habitaciones] ([reserva_id], [habitacion_id])	
	SELECT DISTINCT [reserva_id], [habitacion_id] FROM [LOS_NORMALIZADORES].[Maestra]
	WHERE [reserva_id] IS NOT NULL
	AND	  [habitacion_id] IS NOT NULL


/* Estadias */
INSERT INTO [LOS_NORMALIZADORES].[estadias] ([fecha_inicio], [cant_noches], [reserva_id])	
	SELECT DISTINCT [Estadia_Fecha_Inicio], [Estadia_Cant_Noches], [reserva_id] FROM [LOS_NORMALIZADORES].[Maestra]
	WHERE [Estadia_Fecha_Inicio] IS NOT NULL 
	AND   [Estadia_Cant_Noches] IS NOT NULL
	AND   [reserva_id] IS NOT NULL
GO

ALTER TABLE [LOS_NORMALIZADORES].[Maestra] ADD estadia_id INTEGER
GO

UPDATE [LOS_NORMALIZADORES].[Maestra]
SET estadia_id = 
	(
		SELECT id FROM [LOS_NORMALIZADORES].[estadias] as e
		WHERE [LOS_NORMALIZADORES].[Maestra].Estadia_Fecha_Inicio = e.fecha_inicio
		AND   [LOS_NORMALIZADORES].[Maestra].Estadia_Cant_Noches = e.cant_noches
		AND   [LOS_NORMALIZADORES].[Maestra].reserva_id = e.reserva_id
	)
GO

UPDATE res SET reserva_estado = 6 
	FROM [LOS_NORMALIZADORES].reservas res
	INNER JOIN [LOS_NORMALIZADORES].estadias ON estadias.reserva_id = res.id
	
	
/* Consumibles */ 
SET IDENTITY_INSERT [LOS_NORMALIZADORES].[consumibles] ON;
INSERT INTO [LOS_NORMALIZADORES].[consumibles] ([id], [descripcion], [precio])	
	SELECT DISTINCT [Consumible_Codigo], [Consumible_Descripcion], [Consumible_Precio] FROM [LOS_NORMALIZADORES].[Maestra]
	WHERE [Consumible_Codigo] IS NOT NULL 
	AND   [Consumible_Descripcion] IS NOT NULL
	AND   [Consumible_Precio] IS NOT NULL
SET IDENTITY_INSERT [LOS_NORMALIZADORES].[consumibles] OFF;
GO

ALTER TABLE [LOS_NORMALIZADORES].[Maestra] ADD consumible_id INTEGER
GO

CREATE INDEX Consumibles_codigo ON [LOS_NORMALIZADORES].[consumibles] (id)
CREATE INDEX Maestra_Consumiblse_codigo ON [LOS_NORMALIZADORES].[Maestra] (Consumible_Codigo)

UPDATE [LOS_NORMALIZADORES].[Maestra]
SET consumible_id = 
	(
		SELECT id FROM [LOS_NORMALIZADORES].[consumibles] as c
		WHERE [LOS_NORMALIZADORES].[Maestra].Consumible_Codigo = c.id
		AND   [LOS_NORMALIZADORES].[Maestra].Consumible_Descripcion = c.descripcion
		AND   [LOS_NORMALIZADORES].[Maestra].Consumible_Precio = c.precio
	)
GO

DROP INDEX  Consumibles_codigo ON [LOS_NORMALIZADORES].[consumibles]




/* Facturas */
INSERT INTO [LOS_NORMALIZADORES].[formas_de_pago] (descripcion) VALUES ('Sin especificar')
INSERT INTO [LOS_NORMALIZADORES].[formas_de_pago] (descripcion) VALUES ('Efectivo')
INSERT INTO [LOS_NORMALIZADORES].[formas_de_pago] (descripcion) VALUES ('Tarjeta de crédito')
INSERT INTO [LOS_NORMALIZADORES].[formas_de_pago] (descripcion) VALUES ('Tarjeta de débito')
GO

SET IDENTITY_INSERT [LOS_NORMALIZADORES].[facturas] ON;
INSERT INTO [LOS_NORMALIZADORES].[facturas] ([id], [estadia_id], [fecha], [forma_pago_id], [cliente_id])	
	SELECT DISTINCT [Factura_Nro], [estadia_id], [Factura_Fecha], 1, [cliente_id]  FROM [LOS_NORMALIZADORES].[Maestra]
	WHERE [Factura_Nro] IS NOT NULL 
	AND [estadia_id] IS NOT NULL
	AND [Factura_Fecha] IS NOT NULL
	AND [cliente_id] IS NOT NULL
SET IDENTITY_INSERT [LOS_NORMALIZADORES].[facturas] OFF;
GO

ALTER TABLE [LOS_NORMALIZADORES].[Maestra] ADD factura_id INTEGER
GO

UPDATE [LOS_NORMALIZADORES].[Maestra]
SET factura_id = 
	(
		SELECT id FROM [LOS_NORMALIZADORES].[facturas] as f
		WHERE [LOS_NORMALIZADORES].[Maestra].Factura_Nro = f.id
		AND   [LOS_NORMALIZADORES].[Maestra].estadia_id = f.estadia_id
		AND   [LOS_NORMALIZADORES].[Maestra].Factura_Fecha = f.fecha
	)
GO


/* Items */
INSERT INTO [LOS_NORMALIZADORES].[items_facturas] (factura_id, consumible_id, estadia_id, monto, unidades, tipo)
	SELECT DISTINCT  factura_id, consumible_id, estadia_id, Item_Factura_Monto, Item_Factura_Cantidad, 'C' FROM  [LOS_NORMALIZADORES].[Maestra]
	WHERE consumible_id is NOT NULL
	AND   estadia_id IS NOT NULL
	AND   Item_Factura_Monto IS NOT NULL
	AND   Item_Factura_Cantidad IS NOT NULL
GO

INSERT INTO [LOS_NORMALIZADORES].[items_facturas] (factura_id, estadia_id, monto, unidades, tipo)
	SELECT DISTINCT  factura_id, estadia_id, Item_Factura_Monto, Item_Factura_Cantidad, 'H' FROM  [LOS_NORMALIZADORES].[Maestra]
	WHERE Factura_Total is NOT NULL
	AND   estadia_id IS NOT NULL
	AND   habitacion_id IS NOT NULL
	AND   Item_Factura_Monto IS NOT NULL
	AND   Item_Factura_Cantidad IS NOT NULL
GO


UPDATE [LOS_NORMALIZADORES].items_facturas 
	SET monto = (((monto - (ho.cant_estrella * ho.recarga_estrella))* t.cantidad_maxima_personas) + ho.cant_estrella*ho.recarga_estrella) * e.cant_noches 
	FROM 
		LOS_NORMALIZADORES.estadias e,
		LOS_NORMALIZADORES.reservas_habitaciones r, 
		LOS_NORMALIZADORES.hoteles ho,
		LOS_NORMALIZADORES.habitaciones h, 
		LOS_NORMALIZADORES.habitaciones_tipos t
		
	WHERE estadia_id = e.id 
	AND h.hotel_id = ho.id
	AND e.reserva_id = r.reserva_id
	AND r.habitacion_id = h.id
	AND h.tipo_id = t.id
	AND tipo = 'H'

GO

/*HABITACIONES NO HOSPEDADAS*/
INSERT INTO [LOS_NORMALIZADORES].[items_facturas] (factura_id, estadia_id, monto, unidades, tipo)
SELECT DISTINCT  i.factura_id, i.estadia_id, 0, r.cant_noches - e.cant_noches , 'N' 
FROM  [LOS_NORMALIZADORES].[items_facturas] i, [LOS_NORMALIZADORES].estadias e,[LOS_NORMALIZADORES].[reservas] r
where i.estadia_id = e.id
AND (r.cant_noches - e.cant_noches) > 0
GO

/*DESCUENTOS POR ALL INCLUSIVE*/
INSERT INTO [LOS_NORMALIZADORES].[items_facturas] (factura_id, estadia_id, monto, unidades, tipo)
SELECT DISTINCT  i.factura_id, i.estadia_id, SUM(i.monto)*(-1), 0, 'D'
FROM[LOS_NORMALIZADORES].[items_facturas] i,
[LOS_NORMALIZADORES].[estadias] e,
[LOS_NORMALIZADORES].[reservas] res,
[LOS_NORMALIZADORES].[regimenes] reg
WHERE 
i.tipo = 'C'
AND i.estadia_id = e.id
AND e.reserva_id = res.id
AND res.regimen_id = reg.id
AND (reg.id = 3 OR reg.id = 4)
GROUP BY i.factura_id, i.estadia_id
GO



/* LOGIN y ROLES */
CREATE TABLE [LOS_NORMALIZADORES].[roles](
	[id] INTEGER IDENTITY PRIMARY KEY,
	[descripcion] [nvarchar](30) NOT NULL,
	[estado] [bit] NOT NULL
) ON [PRIMARY]

CREATE TABLE [LOS_NORMALIZADORES].[roles_funcionalidades](
	[id] INTEGER IDENTITY PRIMARY KEY,
	[rol_id] INTEGER NOT NULL,
	[funcionalidad_id] INTEGER NOT NULL
) ON [PRIMARY]

CREATE TABLE [LOS_NORMALIZADORES].[funcionalidades](
	[id] INTEGER IDENTITY PRIMARY KEY,
	[descripcion] [nvarchar](30) NOT NULL
) ON [PRIMARY]

CREATE TABLE [LOS_NORMALIZADORES].[rol_usuario](
	[id] INTEGER IDENTITY PRIMARY KEY,
	[usuario_id] INTEGER NOT NULL,
	[rol_id] INTEGER NOT NULL,
	[hotel_id] INTEGER NOT NULL
) ON [PRIMARY]


CREATE TABLE [LOS_NORMALIZADORES].[usuarios](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [nvarchar](30) NOT NULL,
	[password] [char](256) NOT NULL,
	[intentos_fallidos] [tinyint] NOT NULL,
	[estado] [bit] NOT NULL,
	[nombre] [nvarchar](255) NOT NULL,
	[apellido] [nvarchar](255) NOT NULL,
	[mail] [nvarchar](255) NOT NULL,
	[fecha_nac] [datetime] NOT NULL,
	[calle] [nvarchar](255) NOT NULL,
	[nro_Calle] [numeric](18, 0) NOT NULL,
	[telefono] [nvarchar](255) NOT NULL,
	[documento_tipo_id] INTEGER NOT NULL,
	[documento_nro] [numeric](18, 0) NOT NULL
 CONSTRAINT [PK_usuarios] PRIMARY KEY CLUSTERED 

([id] ASC)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]) ON [PRIMARY]

/* Agregando usuario (admin;w23e) como Administrador */
INSERT INTO [LOS_NORMALIZADORES].[usuarios] (username, password, nombre, fecha_nac,  intentos_fallidos, estado, apellido, mail, telefono, calle, nro_Calle, documento_tipo_id, documento_nro) VALUES ('admin', 'e6b87050bfcb8143fcb8db0170a4dc9ed00d904ddd3e2a4ad1b1e8dc0fdc9be7', 'admin','', '', 1, 'admin', 'admin@admin.com.ar', '1112312311', 'Corrientes', 3200, '1', '37000000')
INSERT INTO [LOS_NORMALIZADORES].[rol_usuario] (usuario_id, rol_id, hotel_id) VALUES (1,1,1)

/* tipo de documento */
CREATE TABLE [LOS_NORMALIZADORES].[documento_tipos](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [nvarchar](255) NOT NULL
 CONSTRAINT [PK_DOCUMENTO_TIPOS] PRIMARY KEY CLUSTERED 

([id] ASC)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]) ON [PRIMARY]

/* agregando tipos de documentos */
INSERT INTO [LOS_NORMALIZADORES].[documento_tipos] (descripcion) VALUES ('DNI - Documento Nacional de Identidad')
INSERT INTO [LOS_NORMALIZADORES].[documento_tipos] (descripcion) VALUES ('LC - Libreta Civica')
INSERT INTO [LOS_NORMALIZADORES].[documento_tipos] (descripcion) VALUES ('LE - Libreta de Enrolamiento')
INSERT INTO [LOS_NORMALIZADORES].[documento_tipos] (descripcion) VALUES ('Pasaporte')

/* Agregando funcionalidades */
SET IDENTITY_INSERT [LOS_NORMALIZADORES].[funcionalidades] ON;
INSERT INTO [LOS_NORMALIZADORES].[funcionalidades]([id],[descripcion]) VALUES (1,'ABM de Rol')
INSERT INTO [LOS_NORMALIZADORES].[funcionalidades]([id],[descripcion]) VALUES (2,'ABM de Habitacion')
INSERT INTO [LOS_NORMALIZADORES].[funcionalidades]([id],[descripcion]) VALUES (3,'ABM de Cliente')
INSERT INTO [LOS_NORMALIZADORES].[funcionalidades]([id],[descripcion]) VALUES (4,'ABM de Usuario')
INSERT INTO [LOS_NORMALIZADORES].[funcionalidades]([id],[descripcion]) VALUES (5,'ABM de Regimen')
INSERT INTO [LOS_NORMALIZADORES].[funcionalidades]([id],[descripcion]) VALUES (6,'ABM de Hotel')
INSERT INTO [LOS_NORMALIZADORES].[funcionalidades]([id],[descripcion]) VALUES (7,'Generar Reserva')
INSERT INTO [LOS_NORMALIZADORES].[funcionalidades]([id],[descripcion]) VALUES (8,'Cancelar Reserva')
INSERT INTO [LOS_NORMALIZADORES].[funcionalidades]([id],[descripcion]) VALUES (9,'Registrar Estadia')
INSERT INTO [LOS_NORMALIZADORES].[funcionalidades]([id],[descripcion]) VALUES (10,'Listado Estadistico')
SET IDENTITY_INSERT [LOS_NORMALIZADORES].[funcionalidades] OFF;

/* Agregando roles */
SET IDENTITY_INSERT [LOS_NORMALIZADORES].[roles] ON;
INSERT INTO [LOS_NORMALIZADORES].[roles]
           ([id],[descripcion],[estado])
     VALUES
           (1, 'Administrador',1)
INSERT INTO [LOS_NORMALIZADORES].[roles]
           ([id],[descripcion],[estado])
     VALUES
           (2, 'Recepcionista',1)

INSERT INTO [LOS_NORMALIZADORES].[roles]
           ([id],[descripcion],[estado])
     VALUES
           (3, 'Guest',1)
SET IDENTITY_INSERT [LOS_NORMALIZADORES].[roles] OFF;
GO

/* Agregando permisos a los Administradores */
INSERT INTO [LOS_NORMALIZADORES].[roles_funcionalidades] (rol_id,funcionalidad_id) VALUES (1,1)
INSERT INTO [LOS_NORMALIZADORES].[roles_funcionalidades] (rol_id,funcionalidad_id) VALUES (1,2)
INSERT INTO [LOS_NORMALIZADORES].[roles_funcionalidades] (rol_id,funcionalidad_id) VALUES (1,4)
INSERT INTO [LOS_NORMALIZADORES].[roles_funcionalidades] (rol_id,funcionalidad_id) VALUES (1,5)
INSERT INTO [LOS_NORMALIZADORES].[roles_funcionalidades] (rol_id,funcionalidad_id) VALUES (1,6)
INSERT INTO [LOS_NORMALIZADORES].[roles_funcionalidades] (rol_id,funcionalidad_id) VALUES (1,10)
/* Agregando permisos a los Recepcionistas */
INSERT INTO [LOS_NORMALIZADORES].[roles_funcionalidades] (rol_id,funcionalidad_id) VALUES (2,3)
INSERT INTO [LOS_NORMALIZADORES].[roles_funcionalidades] (rol_id,funcionalidad_id) VALUES (2,7)
INSERT INTO [LOS_NORMALIZADORES].[roles_funcionalidades] (rol_id,funcionalidad_id) VALUES (2,8)
INSERT INTO [LOS_NORMALIZADORES].[roles_funcionalidades] (rol_id,funcionalidad_id) VALUES (2,9)
/* Agregando permisos a los Guest */
INSERT INTO [LOS_NORMALIZADORES].[roles_funcionalidades] (rol_id,funcionalidad_id) VALUES (3,7)
INSERT INTO [LOS_NORMALIZADORES].[roles_funcionalidades] (rol_id,funcionalidad_id) VALUES (3,8)


/* Estados de reserva*/

INSERT INTO [LOS_NORMALIZADORES].[reserva_estado]
	([descripcion]) VALUES ('Reserva correcta')
INSERT INTO [LOS_NORMALIZADORES].[reserva_estado]
	([descripcion]) VALUES ('Reserva modificada')
INSERT INTO [LOS_NORMALIZADORES].[reserva_estado]
	([descripcion]) VALUES ('Reserva cancelada por Recepción')
INSERT INTO [LOS_NORMALIZADORES].[reserva_estado]
	([descripcion]) VALUES ('Reserva cancelada por Cliente')
INSERT INTO [LOS_NORMALIZADORES].[reserva_estado]
	([descripcion]) VALUES ('Reserva cancelada por No-Show')
INSERT INTO [LOS_NORMALIZADORES].[reserva_estado]
	([descripcion]) VALUES ('Reserva con ingreso')



/* TODO faltan las FK de consumibles estadias y facturas */
/* FKs */

ALTER TABLE [LOS_NORMALIZADORES].[habitaciones] ADD CONSTRAINT habitaciones_hotel_id FOREIGN KEY (hotel_id) REFERENCES [LOS_NORMALIZADORES].[hoteles](id)

ALTER TABLE [LOS_NORMALIZADORES].[habitaciones] ADD CONSTRAINT habitaciones_tipo_id FOREIGN KEY (tipo_id) REFERENCES [LOS_NORMALIZADORES].[habitaciones_tipos](id)

ALTER TABLE [LOS_NORMALIZADORES].[hoteles_regimenes] ADD CONSTRAINT regimenes_hotel_hotel_id FOREIGN KEY (hotel_id) REFERENCES [LOS_NORMALIZADORES].[hoteles](id)

ALTER TABLE [LOS_NORMALIZADORES].[hoteles_regimenes] ADD CONSTRAINT regimenes_hotel_regimen_id FOREIGN KEY (regimen_id) REFERENCES [LOS_NORMALIZADORES].[regimenes](id)

ALTER TABLE [LOS_NORMALIZADORES].[hoteles_regimenes] ADD CONSTRAINT regimenes_unique UNIQUE(hotel_id, regimen_id);

ALTER TABLE [LOS_NORMALIZADORES].[reservas] ADD CONSTRAINT reservas_regimen_id FOREIGN KEY (regimen_id) REFERENCES [LOS_NORMALIZADORES].[regimenes](id)

ALTER TABLE [LOS_NORMALIZADORES].[reservas_canceladas] ADD CONSTRAINT canceladas_reservas_id FOREIGN KEY (reserva_id) REFERENCES [LOS_NORMALIZADORES].[reservas](id)

ALTER TABLE [LOS_NORMALIZADORES].[estadias] ADD CONSTRAINT estadias_reserva_id FOREIGN KEY (reserva_id) REFERENCES [LOS_NORMALIZADORES].[reservas](id)

ALTER TABLE [LOS_NORMALIZADORES].[items_facturas] ADD CONSTRAINT items_factura_id FOREIGN KEY (estadia_id) REFERENCES [LOS_NORMALIZADORES].[estadias](id)

ALTER TABLE [LOS_NORMALIZADORES].[items_facturas] ADD CONSTRAINT consumibles_consumible_id FOREIGN KEY (consumible_id) REFERENCES [LOS_NORMALIZADORES].[consumibles](id)

ALTER TABLE [LOS_NORMALIZADORES].[items_facturas] ADD CHECK (tipo in ('C', 'H','N', 'D'))

ALTER TABLE [LOS_NORMALIZADORES].[facturas] ADD CONSTRAINT facturas_estadia_id FOREIGN KEY (estadia_id) REFERENCES [LOS_NORMALIZADORES].[estadias](id)

ALTER TABLE [LOS_NORMALIZADORES].[items_facturas] ADD CONSTRAINT items_facturas_id FOREIGN KEY (factura_id) REFERENCES [LOS_NORMALIZADORES].[facturas](id)

ALTER TABLE [LOS_NORMALIZADORES].[facturas] ADD CONSTRAINT facturas_forma_de_pago_id FOREIGN KEY (forma_pago_id) REFERENCES [LOS_NORMALIZADORES].[formas_de_pago](id)

ALTER TABLE [LOS_NORMALIZADORES].[usuarios] ADD CONSTRAINT documento_tipos_user_id FOREIGN KEY (documento_tipo_id) REFERENCES [LOS_NORMALIZADORES].[documento_tipos](id)

ALTER TABLE [LOS_NORMALIZADORES].[clientes] ADD CONSTRAINT documento_tipos_clientes_id FOREIGN KEY (documento_tipo_id) REFERENCES [LOS_NORMALIZADORES].[documento_tipos](id)

ALTER TABLE [LOS_NORMALIZADORES].[clientes] ADD CONSTRAINT paises_clientes_id FOREIGN KEY (pais_id) REFERENCES [LOS_NORMALIZADORES].[paises](id)

ALTER TABLE [LOS_NORMALIZADORES].[rol_usuario] ADD CONSTRAINT rol_user_id FOREIGN KEY (usuario_id) REFERENCES [LOS_NORMALIZADORES].[usuarios](id)

ALTER TABLE [LOS_NORMALIZADORES].[rol_usuario] ADD CONSTRAINT roles_id FOREIGN KEY (rol_id) REFERENCES [LOS_NORMALIZADORES].[roles](id)

ALTER TABLE [LOS_NORMALIZADORES].[reservas_habitaciones] ADD CONSTRAINT fk_reserva_id FOREIGN KEY (reserva_id) REFERENCES [LOS_NORMALIZADORES].[reservas](id)

ALTER TABLE [LOS_NORMALIZADORES].[reservas_habitaciones] ADD CONSTRAINT fk_habitacion_id FOREIGN KEY (habitacion_id) REFERENCES [LOS_NORMALIZADORES].[habitaciones](id)

ALTER TABLE [LOS_NORMALIZADORES].[estadia_cliente] ADD CONSTRAINT fk_estadia_cliente_id FOREIGN KEY (estadia_id) REFERENCES [LOS_NORMALIZADORES].[estadias](id)

ALTER TABLE [LOS_NORMALIZADORES].[estadia_cliente] ADD CONSTRAINT fk_cliente_reserva_id FOREIGN KEY (cliente_id) REFERENCES [LOS_NORMALIZADORES].[clientes](id)

ALTER TABLE [LOS_NORMALIZADORES].[reservas] ADD CONSTRAINT fk_reserva_estado_id FOREIGN KEY (reserva_estado) REFERENCES [LOS_NORMALIZADORES].[reserva_estado](id)

ALTER TABLE [LOS_NORMALIZADORES].[hoteles_bajas] ADD CONSTRAINT fk_hotel_baja_id FOREIGN KEY (hotel_id) REFERENCES [LOS_NORMALIZADORES].[hoteles](id)

GO

DROP TABLE [LOS_NORMALIZADORES].Maestra
GO

/* Creo vistas SQL */
CREATE VIEW [LOS_NORMALIZADORES].[v_reservas_hoteles]
AS
SELECT     rh.reserva_id AS id, r.id AS reserva_id, h.hotel_id AS hotel_id
FROM         [LOS_NORMALIZADORES].[reservas] AS r LEFT JOIN
                      [LOS_NORMALIZADORES].[reservas_habitaciones] AS rh ON r.id = rh.reserva_id LEFT JOIN
                      [LOS_NORMALIZADORES].[habitaciones] AS h ON rh.habitacion_id = h.id

GO

CREATE VIEW [LOS_NORMALIZADORES].[v_habitaciones] AS
SELECT habitaciones.* FROM [LOS_NORMALIZADORES].[habitaciones] habitaciones
INNER JOIN [LOS_NORMALIZADORES].[hoteles] hoteles on habitaciones.hotel_id = hoteles.id 

GO

/*
	----------------
	VISTAS PARA TOPS
	----------------
*/




CREATE VIEW [LOS_NORMALIZADORES].[gastos_estadia] AS
	SELECT estadia_id, fecha, reservas.cliente_id, 
		(SELECT ISNULL(SUM(monto), 0) FROM [LOS_NORMALIZADORES].items_facturas WHERE items_facturas.factura_id = facturas.id) as total,
		(SELECT ISNULL(SUM(monto), 0) FROM [LOS_NORMALIZADORES].items_facturas WHERE items_facturas.factura_id = facturas.id AND items_facturas.tipo = 'C') as consumidos,
		(SELECT ISNULL(SUM(monto), 0) FROM [LOS_NORMALIZADORES].items_facturas WHERE items_facturas.factura_id = facturas.id AND items_facturas.tipo = 'H') as habitaciones, 
		(SELECT ISNULL(SUM(monto), 0) FROM [LOS_NORMALIZADORES].items_facturas WHERE items_facturas.factura_id = facturas.id AND items_facturas.tipo = 'D') as descuentos, 
		(SELECT ISNULL(SUM(monto), 0) FROM [LOS_NORMALIZADORES].items_facturas WHERE items_facturas.factura_id = facturas.id AND items_facturas.tipo = 'N') as habitaciones_no_hospedadas
	FROM [LOS_NORMALIZADORES].facturas
	INNER JOIN [LOS_NORMALIZADORES].estadias ON estadias.id = estadia_id
	INNER JOIN [LOS_NORMALIZADORES].reservas ON reservas.id = estadias.reserva_id
GO


CREATE VIEW [LOS_NORMALIZADORES].[habitaciones_estadia] AS
	SELECT 
		habitaciones.id as habitacion_id, 
		reservas.reserva_estado as reserva_estado, 
		estadias.fecha_inicio as fecha_inicio, 
		(estadias.fecha_inicio + estadias.cant_noches) as fecha_fin, 
		estadias.id as estadia_id,
		estadias.cant_noches as cant_noches,
		hoteles.id as hotel_id
		
		FROM [LOS_NORMALIZADORES].habitaciones
		INNER JOIN [LOS_NORMALIZADORES].reservas_habitaciones ON reservas_habitaciones.habitacion_id = habitaciones.id
		INNER JOIN [LOS_NORMALIZADORES].reservas ON reservas_habitaciones.reserva_id = reservas.id
		INNER JOIN [LOS_NORMALIZADORES].estadias ON estadias.reserva_id = reservas.id
		INNER JOIN [LOS_NORMALIZADORES].hoteles ON habitaciones.hotel_id = hoteles.id
		
GO



/*Primer TOP posible idea futura*/
/*CREATE FUNCTION [LOS_NORMALIZADORES].[uspHotelesReservasCanceladas] (@fecha1 DATE, @fecha2 DATE)
    RETURNS @Results TABLE(id INTEGER, hotel_id INTEGER, cantidad INTEGER)
AS
BEGIN
    INSERT @Results SELECT TOP 5 0, hotel_id, COUNT(*) AS cantidad FROM [LOS_NORMALIZADORES].[reservas] LEFT JOIN [LOS_NORMALIZADORES].[reservas_habitaciones] LEFT JOIN [LOS_NORMALIZADORES].[habitaciones] ON reservas.habitacion_id = habitaciones.id WHERE (reserva_estado = 3 OR reserva_estado = 4 OR reserva_estado = 5) AND [fecha_cancelacion] BETWEEN @fecha1 AND @fecha2 GROUP BY hotel_id ORDER BY COUNT(*) DESC

    RETURN
END
GO*/
/*
CREATE VIEW [LOS_NORMALIZADORES].[v_HotelesReservasCanceladas] AS
SELECT hotel_id AS id, hotel_id, COUNT(*) AS cantidad FROM [LOS_NORMALIZADORES].[reservas] LEFT JOIN [LOS_NORMALIZADORES].[habitaciones] ON reservas.habitacion_id = habitaciones.id /*WHERE reserva_estado = 3 OR reserva_estado = 4 OR reserva_estado = 5*/ GROUP BY hotel_id
GO*/


/* Procedimientos */

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

GO

CREATE PROCEDURE [LOS_NORMALIZADORES].[uspCancelarReservasPorNoShow] 
	@fecha_sistema DATE
AS
BEGIN
	UPDATE [LOS_NORMALIZADORES].[reservas] SET reserva_estado = 5 WHERE (reserva_estado = 1 OR reserva_estado = 2) AND fecha_inicio < @fecha_sistema
END
GO


