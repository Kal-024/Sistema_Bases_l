CREATE DATABASE Restaurantes
GO

CREATE LOGIN adminRestaurante WITH PASSWORD = 'password01'
GO

sp_adduser adminRestaurante, adminRestaurante

CREATE TABLE Sucursal
(SucursalID int primary key identity(1,1),
Nombre varchar(50),
ResponsableID int,
Telefono varchar(24),
Departamento varchar(50),
Direccion varchar(100))

INSERT INTO Sucursal(Nombre, Telefono, Departamento, Direccion) VALUES('Centroamerica', '18001024', 'Managua', 'Modulo 24 multicentro')

CREATE TABLE Empleado
(EmpleadoID int primary key identity(1, 1),
Cedula varchar(15),
Nombres varchar(50),
Apellidos varchar(50),
Telefono varchar(24),
Direccion varchar(100),
SucursalID int not null FOREIGN KEY REFERENCES Sucursal(SucursalID))

ALTER TABLE Sucursal
ADD CONSTRAINT FK_Empleado_ResponsableID FOREIGN KEY (ResponsableID)
    REFERENCES Empleado(EmpleadoID)

INSERT INTO Empleado(Cedula, Nombres, Apellidos, Telefono, Direccion, SucursalID) VALUES('4503010001000L', 'Uziel Jose', 'Duarte Guillen', '83811309', 'Via Reconciliacion Norte', 1)

UPDATE Sucursal SET ResponsableID = 1 WHERE SucursalID = 1

SELECT * FROM Sucursal
SELECT * FROM Empleado

CREATE TABLE Usuario
(EmpleadoID int FOREIGN KEY REFERENCES Empleado(EmpleadoID),
usuario varchar(80),
contrasena varchar(80),
rol varchar(80),
estado varchar(80))

-- Procediento de almacenado para insertar el usuario
CREATE PROCEDURE dbo.[Insertar usuario]
@EmpleadoID int,
@usuario varchar(50),
@contrasena varchar(50),
@rol varchar(50)
AS
	INSERT INTO Usuario(EmpleadoID, usuario, contrasena, rol, estado)
	VALUES(@EmpleadoID, @usuario, ENCRYPTBYPASSPHRASE(@contrasena, @contrasena), @rol, 'Habilitado')

EXEC dbo.[Insertar usuario] 1, 'CMU', 'TareaCurso', 'ADMIN'

SELECT * FROM Empleado

-- Procedimiento de almacenado para validar el acceso al sistema
CREATE PROCEDURE dbo.[Validar acceso]
@usuario varchar(50),
@contrasena varchar(50)
AS
	IF EXISTS(SELECT usuario FROM Usuario
	WHERE CAST(DECRYPTBYPASSPHRASE(@contrasena, contrasena) AS varchar(100)) = @contrasena
	AND usuario = @usuario AND estado = 'Habilitado')
		BEGIN
		SELECT 'Acceso exitoso' Resultado,
		(SELECT rol FROM Usuario
		WHERE CAST(DECRYPTBYPASSPHRASE(@contrasena, contrasena) AS varchar(100)) = @contrasena
		AND usuario = @usuario AND estado = 'Habilitado') Rol,
		(SELECT E.Nombres FROM Usuario U
		JOIN Empleado E ON E.EmpleadoID = U.EmpleadoID
		WHERE CAST(DECRYPTBYPASSPHRASE(@contrasena, U.contrasena) AS varchar(100)) = @contrasena
		AND U.usuario = @usuario AND U.estado = 'Habilitado') [Nombre de empleado],
		(SELECT usuario FROM Usuario
		WHERE CAST(DECRYPTBYPASSPHRASE(@contrasena, contrasena) AS varchar(100)) = @contrasena
		AND usuario = @usuario AND estado = 'Habilitado') Usuario
		END
		ELSE
		SELECT 'Acceso denegado' Resultado

EXEC dbo.[Validar acceso]  'CMU', 'TareaCurso'

GRANT EXEC ON dbo.[Validar acceso] TO adminRestaurante

CREATE TABLE Mesa
(MesaID int primary key identity(1, 1),
CantidadAsiento int,
Area varchar(30),
SucursalID int not null FOREIGN KEY REFERENCES Sucursal(SucursalID))

CREATE TABLE Proveedor
(ProveedorID int primary key identity(1, 1),
NombreCompania varchar(100),
Telefono varchar (24),
Departamento varchar(50),
Direccion varchar(150))

CREATE TABLE Insumo
(InsumoId int primary key identity(1, 1),
NombreIngrediente varchar(50),
ProveedorID int not null FOREIGN KEY REFERENCES Proveedor(ProveedorID))

CREATE TABLE Plato
(PlatoID int primary key identity(1, 1),
Nombre varchar(100),
Categoria varchar(100),
Descripcion varchar(150),
Precio money,
IngredienteID int not null FOREIGN KEY REFERENCES Insumo(InsumoId))

CREATE TABLE Bebida
(BebidaID int primary key identity(1, 1),
Nombre varchar(100),
ProveedorID int not null FOREIGN KEY REFERENCES Proveedor(ProveedorID),
Precio money)

CREATE TABLE Cliente
(ClienteID int primary key identity(1, 1),
Cedula varchar(15),
Nombres varchar(50),
Apellidos varchar(50),
Telefono varchar(24),
PrecioCompra money)

CREATE TABLE Orden
(OrdenID int primary key identity(1, 1),
EmpleadoID int not null FOREIGN KEY REFERENCES Empleado(EmpleadoID),
MesaID int not null FOREIGN KEY REFERENCES Mesa(MesaID),
ClienteID int not null FOREIGN KEY REFERENCES Cliente(ClienteID),
FechaRealizacion datetime)

CREATE TABLE OrdenDetalleComida
(OrdenID int not null,
PlatoID int not null,
Cantidad int,
CONSTRAINT PK_OrdenDetalleComida PRIMARY KEY (OrdenID, PlatoID),
CONSTRAINT FK_OrdenDetalleComida_Orden FOREIGN KEY (OrdenID) REFERENCES Orden(OrdenID),
CONSTRAINT FK_OrdenDetalleComida_PlatoID FOREIGN KEY (PlatoID) REFERENCES Plato(PlatoID))

CREATE TABLE OrdenDetalleBebida
(OrdenID int not null,
BebidaID int not null,
Cantidad int,
CONSTRAINT PK_OrdenDetalleBebida PRIMARY KEY (OrdenID, BebidaID),
CONSTRAINT FK_OrdenDetalleBebida_Orden FOREIGN KEY (OrdenID) REFERENCES Orden(OrdenID),
CONSTRAINT FK_OrdenDetalleBebida_BebidaID FOREIGN KEY (BebidaID) REFERENCES Bebida(BebidaID))

CREATE TABLE Reserva
(ReservaID int primary key identity(1, 1),
MesaID int not null FOREIGN KEY REFERENCES Mesa(MesaID),
ClienteID int not null FOREIGN KEY REFERENCES Cliente(ClienteID),
CantidadAsistente int,
FechaReserva datetime,
FechaLlegada datetime,
AtencionEspecial int)
