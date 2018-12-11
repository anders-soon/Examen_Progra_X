use Dollar
go
create Trigger TR_tipo_Servicio 
on tipo_servicio for insert
as
begin
CREATE TABLE #TablaTemporal(fecha date)
INSERT INTO #TablaTemporal VALUES (SYSDATETIME())
End	

create Trigger TR_servico
on servicios for insert
as
begin
CREATE TABLE #TablaTemporal(fecha date)
INSERT INTO #TablaTemporal VALUES (SYSDATETIME())
End	

create Trigger TR_cidad
on ciudad for insert
as
begin
CREATE TABLE #TablaTemporal(fecha date)
INSERT INTO #TablaTemporal VALUES (SYSDATETIME())
End	

create Trigger TR_cliente
on cliente for insert
as
begin
CREATE TABLE #TablaTemporal(fecha date)
INSERT INTO #TablaTemporal VALUES (SYSDATETIME())
End	

create Trigger TR_Pais
on pais for insert
as
begin
CREATE TABLE #TablaTemporal(fecha date)
INSERT INTO #TablaTemporal VALUES (SYSDATETIME())
End	


create Trigger TR_Producto
on producto for insert
as
begin
CREATE TABLE #TablaTemporal(fecha date)
INSERT INTO #TablaTemporal VALUES (SYSDATETIME())
End	

create Trigger TR_stipo_producto
on tipo_producto for insert
as
begin
CREATE TABLE #TablaTemporal(fecha date)
INSERT INTO #TablaTemporal VALUES (SYSDATETIME())
End	

create Trigger TR_ubicacion
on ubicacion for insert
as
begin
CREATE TABLE #TablaTemporal(fecha date)
INSERT INTO #TablaTemporal VALUES (SYSDATETIME())
End	


