create database Dollar
go


Create table tipo_producto (
	id_tipo_producto Int not null Identity (1,1),
	descripcion varchar(50) null,
	constraint PK_tipo_producto Primary key clustered(id_tipo_producto)
	);
Create table producto(
	id_producto Int not null Identity (1,1),
	nombre nchar(50) null,
	precio money null,
	cantidad nchar(50),
	tipo_producto int,
	constraint PK_id_producto Primary key clustered(id_producto),
	Constraint Fk_tipo_producto_ Foreign key(tipo_producto) references tipo_producto(id_tipo_producto),
	);	
Create table tipo_servicio (
	id_tipo_servici Int not null Identity (1,1),
	descripcion varchar(50) null,
	constraint PK_tipo_servicio Primary key clustered(id_tipo_servici)
	);
Create table servicios (
	id_servicios Int not null Identity (1,1),
	tipo_servicio int null,
	porcentaje int,
	constraint PK_servicos Primary key clustered(id_servicios),
	Constraint Fk_sersvicios Foreign key(id_servicios) references tipo_servicio(id_tipo_servici),
	);
Create table continente (
	id_continente Int not null Identity (1,1),
	descripcion varchar(50) null,
	constraint PK_continente Primary key clustered(id_continente)
	);
Create table pais (
	id_pais Int not null Identity (1,1),
	descripcion varchar(50) null,
	constraint PK_pais Primary key clustered(id_pais)
	);
Create table ciudad (
	id_ciudad Int not null Identity (1,1),
	descripcion varchar(50) null,
	constraint PK_ciudad Primary key clustered(id_ciudad)
	);
Create table ubicacion (
	id_ubicacion Int not null Identity (1,1),
	continente int null,
	pais int null,
	ciudad  int null,
	constraint PK_ubicacion Primary key clustered(id_ubicacion),
	Constraint Fk_continente Foreign key(continente) references continente(id_continente),
	Constraint Fk_pais Foreign key(pais) references pais(id_pais),
	Constraint Fk_ciudad Foreign key(ciudad) references ciudad(id_ciudad),
	);
Create table cliente (
	id_cliente Int not null Identity (1,1),
	nombre varchar(50) null,
	apellido varchar(50) null,
	telefono varchar(50) null,
	producto int null,
	ubicacion int null,
	constraint PK_cliente Primary key clustered(id_cliente),
	Constraint Fk_producto_cliente Foreign key(producto) references producto(id_producto),
	Constraint Fk_ubicacion_ubicacion Foreign key(ubicacion) references ubicacion(id_ubicacion),
	);
	Create table reportes (
	id_reporte Int not null Identity (1,1),
	clientes int null,
	servicios int null
	constraint PK_reporte Primary key clustered(id_reporte),
	Constraint Fk_cliente_reporte Foreign key(clientes) references cliente(id_cliente),
	Constraint Fk_servicios_reporte Foreign key(servicios) references servicios(id_servicios),
	);


