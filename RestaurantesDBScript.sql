CREATE DATABASE Restaurantes
GO

USE Restaurantes
GO

CREATE LOGIN adminRestaurante WITH PASSWORD = 'password01'
GO

sp_adduser adminRestaurante, adminRestaurante

CREATE TABLE Departamento
(DepartamentoID int primary key identity(1, 1),
NombreDepartamento varchar(50))

CREATE TABLE LocalidadMunicipio
(LocalidadID int primary key identity(1, 1),
DepartamentoID int FOREIGN KEY REFERENCES Departamento(DepartamentoID),
Municipio varchar(50))
GO

CREATE PROCEDURE AgregarDepartamento @Departamento varchar(50)
AS
	INSERT INTO Departamento(NombreDepartamento) VALUES(@Departamento)

GO

EXEC AgregarDepartamento 'Boaco'
EXEC  AgregarDepartamento 'Carazo'
EXEC  AgregarDepartamento 'Chinandega'
EXEC  AgregarDepartamento 'Chontales'
EXEC  AgregarDepartamento 'Costa Caribe Norte'
EXEC  AgregarDepartamento 'Costa Caribe Sur'
EXEC  AgregarDepartamento 'Esteli'
EXEC  AgregarDepartamento 'Granada'
EXEC  AgregarDepartamento 'Jinotega'
EXEC  AgregarDepartamento 'Leon'
EXEC  AgregarDepartamento 'Madriz'
EXEC  AgregarDepartamento 'Managua'
EXEC  AgregarDepartamento 'Masaya'
EXEC  AgregarDepartamento 'Matagalpa'
EXEC  AgregarDepartamento 'Nueva Segovia'
EXEC  AgregarDepartamento 'Rio San Juan'
EXEC  AgregarDepartamento 'Rivas'

GO

CREATE PROCEDURE AgregarLocalidad @DepartamentoID int, @Municipio varchar(50)
AS
	INSERT INTO LocalidadMunicipio(DepartamentoID, Municipio) VALUES(@DepartamentoID, @Municipio)
	
GO

EXEC AgregarLocalidad 1, 'Boaco'
EXEC AgregarLocalidad 1, 'Camoapa'
EXEC AgregarLocalidad 1, 'San Jose de los Remates'
EXEC AgregarLocalidad 1, 'San Lorenzo'
EXEC AgregarLocalidad 1, 'Santa Lucia'
EXEC AgregarLocalidad 1, 'Teustepe'

EXEC AgregarLocalidad 2, 'Diriamba'
EXEC AgregarLocalidad 2, 'Dolores'
EXEC AgregarLocalidad 2, 'El Rosario'
EXEC AgregarLocalidad 2, 'Jinotepe'
EXEC AgregarLocalidad 2, 'La Conquista'
EXEC AgregarLocalidad 2, 'La Paz de Oriente'
EXEC AgregarLocalidad 2, 'San Marcos'
EXEC AgregarLocalidad 2, 'Santa Teresa'

EXEC AgregarLocalidad 3, 'Chichigalpa'
EXEC AgregarLocalidad 3, 'Chinandega'
EXEC AgregarLocalidad 3, 'Cinco Pinos'
EXEC AgregarLocalidad 3, 'Corinto'
EXEC AgregarLocalidad 3, 'El Realejo'
EXEC AgregarLocalidad 3, 'El Viejo'
EXEC AgregarLocalidad 3, 'Posoltega'
EXEC AgregarLocalidad 3, 'Puerto Morazan'
EXEC AgregarLocalidad 3, 'San Francisco del Norte'
EXEC AgregarLocalidad 3, 'San Pedro del Norte'
EXEC AgregarLocalidad 3, 'Santo Tomas del Norte'
EXEC AgregarLocalidad 3, 'Somotillo'
EXEC AgregarLocalidad 3, 'Villanueva'

EXEC AgregarLocalidad 4, 'Acoyapa'
EXEC AgregarLocalidad 4, 'Comalapa'
EXEC AgregarLocalidad 4, 'Cuapa'
EXEC AgregarLocalidad 4, 'El Coral'
EXEC AgregarLocalidad 4, 'Juigalpa'
EXEC AgregarLocalidad 4, 'La Libertad'
EXEC AgregarLocalidad 4, 'San Pedro de Lovago'
EXEC AgregarLocalidad 4, 'Santo Domingo'
EXEC AgregarLocalidad 4, 'Santo Tomas'
EXEC AgregarLocalidad 4, 'Villa Sandino'

EXEC AgregarLocalidad 5, 'Bonanza'
EXEC AgregarLocalidad 5, 'Mulukkuku'
EXEC AgregarLocalidad 5, 'Prinzapolka'
EXEC AgregarLocalidad 5, 'Puerto Cabezas'
EXEC AgregarLocalidad 5, 'Rosita'
EXEC AgregarLocalidad 5, 'Siuna'
EXEC AgregarLocalidad 5, 'Waslala'
EXEC AgregarLocalidad 5, 'Waspan'

EXEC AgregarLocalidad 6, 'Bluefields'
EXEC AgregarLocalidad 6, 'Desembocadura de Rio Grande'
EXEC AgregarLocalidad 6, 'El Ayote'
EXEC AgregarLocalidad 6, 'El Rama'
EXEC AgregarLocalidad 6, 'El Tortuguero'
EXEC AgregarLocalidad 6, 'Islas del Maiz'
EXEC AgregarLocalidad 6, 'Kukra Hill'
EXEC AgregarLocalidad 6, 'La Cruz de Rio Grande'
EXEC AgregarLocalidad 6, 'Laguna de Perlas'
EXEC AgregarLocalidad 6, 'Muelle de los Bueyes'
EXEC AgregarLocalidad 6, 'Nueva Guinea'
EXEC AgregarLocalidad 6, 'Paiwas'

EXEC AgregarLocalidad 7, 'Condega'
EXEC AgregarLocalidad 7, 'Esteli'
EXEC AgregarLocalidad 7, 'La Trinidad'
EXEC AgregarLocalidad 7, 'Pueblo Nuevo'
EXEC AgregarLocalidad 7, 'San Juan de Limay'
EXEC AgregarLocalidad 7, 'San Nicolas'

EXEC AgregarLocalidad 8, 'Diria'
EXEC AgregarLocalidad 8, 'Diriomo'
EXEC AgregarLocalidad 8, 'Granada'
EXEC AgregarLocalidad 8, 'Nandaime'

EXEC AgregarLocalidad 9, 'El Cua'
EXEC AgregarLocalidad 9, 'Jinotega'
EXEC AgregarLocalidad 9, 'La Concordia'
EXEC AgregarLocalidad 9, 'San Jose de Bocay'
EXEC AgregarLocalidad 9, 'San Rafael del Norte'
EXEC AgregarLocalidad 9, 'San Sebastian de Yali'
EXEC AgregarLocalidad 9, 'Santa Maria de Pantasma'
EXEC AgregarLocalidad 9, 'Wiwili de Jinotega'

EXEC AgregarLocalidad 10, 'Achuapa'
EXEC AgregarLocalidad 10, 'El Jicaral'
EXEC AgregarLocalidad 10, 'El Sauce'
EXEC AgregarLocalidad 10, 'La Paz Centro'
EXEC AgregarLocalidad 10, 'Larreynaga'
EXEC AgregarLocalidad 10, 'Leon'
EXEC AgregarLocalidad 10, 'Nagarote'
EXEC AgregarLocalidad 10, 'Quezalguaque'
EXEC AgregarLocalidad 10, 'Santa Rosa del Penon'
EXEC AgregarLocalidad 10, 'Telica'

EXEC AgregarLocalidad 11, 'Las Sabanas'
EXEC AgregarLocalidad 11, 'Palacaguina'
EXEC AgregarLocalidad 11, 'San Jose de Cusmapa'
EXEC AgregarLocalidad 11, 'San Juan de Rio Coco'
EXEC AgregarLocalidad 11, 'San Lucas'
EXEC AgregarLocalidad 11, 'Somoto'
EXEC AgregarLocalidad 11, 'Telpaneca'
EXEC AgregarLocalidad 11, 'Totogalpa'
EXEC AgregarLocalidad 11, 'Yalaguina'

EXEC AgregarLocalidad 12, 'Ciudad Sandino'
EXEC AgregarLocalidad 12, 'El Crucero'
EXEC AgregarLocalidad 12, 'Managua'
EXEC AgregarLocalidad 12, 'Mateare'
EXEC AgregarLocalidad 12, 'San Francisco Libre'
EXEC AgregarLocalidad 12, 'San Francisco del Sur'
EXEC AgregarLocalidad 12, 'Ticuantepe'
EXEC AgregarLocalidad 12, 'Tipitapa'
EXEC AgregarLocalidad 12, 'Villa El Carmen'

EXEC AgregarLocalidad 13, 'Catarina'
EXEC AgregarLocalidad 13, 'La Concepcion'
EXEC AgregarLocalidad 13, 'Masatepe'
EXEC AgregarLocalidad 13, 'Masaya'
EXEC AgregarLocalidad 13, 'Nandasmo'
EXEC AgregarLocalidad 13, 'Nindiri'
EXEC AgregarLocalidad 13, 'Niquinohomo'
EXEC AgregarLocalidad 13, 'San Juan de Oriente'
EXEC AgregarLocalidad 13, 'Tisma'

EXEC AgregarLocalidad 14, 'Ciudad Dario'
EXEC AgregarLocalidad 14, 'El Tuma - La Dalia'
EXEC AgregarLocalidad 14, 'Esquipulas'
EXEC AgregarLocalidad 14, 'Matagalpa'
EXEC AgregarLocalidad 14, 'Matiguas'
EXEC AgregarLocalidad 14, 'Muy Muy'
EXEC AgregarLocalidad 14, 'Rancho Grande'
EXEC AgregarLocalidad 14, 'Rio Blanco'
EXEC AgregarLocalidad 14, 'San Dionisio'
EXEC AgregarLocalidad 14, 'San Isidro'
EXEC AgregarLocalidad 14, 'San Ramon'
EXEC AgregarLocalidad 14, 'Sebaco'
EXEC AgregarLocalidad 14, 'Terrabona'

EXEC AgregarLocalidad 15, 'Ciudad Antigua'
EXEC AgregarLocalidad 15, 'Dipilto'
EXEC AgregarLocalidad 15, 'El Jicaro'
EXEC AgregarLocalidad 15, 'Jalapa'
EXEC AgregarLocalidad 15, 'Macuelizo'
EXEC AgregarLocalidad 15, 'Mozonte'
EXEC AgregarLocalidad 15, 'Murra'
EXEC AgregarLocalidad 15, 'Ocotal'
EXEC AgregarLocalidad 15, 'Quilali'
EXEC AgregarLocalidad 15, 'San Fernando'
EXEC AgregarLocalidad 15, 'Santa Maria'
EXEC AgregarLocalidad 15, 'Wiwili'

EXEC AgregarLocalidad 16, 'El Almendro'
EXEC AgregarLocalidad 16, 'El Castillo'
EXEC AgregarLocalidad 16, 'Morrito'
EXEC AgregarLocalidad 16, 'San Carlos'
EXEC AgregarLocalidad 16, 'San Juan del Norte'
EXEC AgregarLocalidad 16, 'San Miguelito'

EXEC AgregarLocalidad 17, 'Altagracia'
EXEC AgregarLocalidad 17, 'Belen'
EXEC AgregarLocalidad 17, 'Buenos Aires'
EXEC AgregarLocalidad 17, 'Cardenas'
EXEC AgregarLocalidad 17, 'Moyogalpa'
EXEC AgregarLocalidad 17, 'Potosi'
EXEC AgregarLocalidad 17, 'Rivas'
EXEC AgregarLocalidad 17, 'San Jorge'
EXEC AgregarLocalidad 17, 'San Juan del Sur'
EXEC AgregarLocalidad 17, 'Tola'

GO
CREATE PROCEDURE MostrarLocalidad
AS
	SELECT LM.Municipio + ', ' + O.NombreDepartamento AS [Cuidad-Departamento], LM.LocalidadID
	FROM LocalidadMunicipio LM
	JOIN Departamento O ON O.DepartamentoID = LM.DepartamentoID
	ORDER BY LM.Municipio + ', ' + O.NombreDepartamento ASC

EXEC MostrarLocalidad

CREATE TABLE Sucursal
(SucursalID int primary key identity(1,1),
Nombre varchar(50),
ResponsableID int,
Telefono varchar(24),
LocalidadID int not null FOREIGN KEY REFERENCES LocalidadMunicipio(LocalidadID),
Direccion varchar(100))

INSERT INTO Sucursal(Nombre, Telefono, LocalidadID, Direccion) VALUES('Centroamerica', '18001024', 97, 'Modulo 24 multicentro')

CREATE TABLE Empleado
(EmpleadoID int primary key identity(1, 1),
Cedula varchar(15),
Nombres varchar(50),
Apellidos varchar(50),
Telefono varchar(24),
Direccion varchar(100),
SucursalID int FOREIGN KEY REFERENCES Sucursal(SucursalID))

ALTER TABLE Sucursal
ADD CONSTRAINT FK_Empleado_ResponsableID FOREIGN KEY (ResponsableID)
    REFERENCES Empleado(EmpleadoID)

INSERT INTO Empleado(Cedula, Nombres, Apellidos, Telefono, Direccion, SucursalID) VALUES('4503010001000L', 'Uziel Jose', 'Duarte Guillen', '83811309', 'Via Reconciliacion Norte', 1)
INSERT INTO Empleado(Cedula, Nombres, Apellidos, Telefono, Direccion) VALUES('0010000000000C', 'Harbey Caleb', 'Vilchez Tapia', '88888888', 'Masaya')
INSERT INTO Empleado(Cedula, Nombres, Apellidos, Telefono, Direccion) VALUES('1000000000000M', 'Rodian Josue', 'Matey Martinez', '12345678', 'Managua')

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

GO
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
GRANT EXEC ON dbo.MostrarLocalidad TO adminRestaurante

CREATE TABLE Mesa
(MesaID int primary key identity(1, 1),
CantidadAsiento int,
Area varchar(30),
SucursalID int not null FOREIGN KEY REFERENCES Sucursal(SucursalID))

CREATE TABLE Proveedor
(ProveedorID int primary key identity(1, 1),
NombreCompania varchar(100),
Telefono varchar (24),
LocalidadID int not null FOREIGN KEY REFERENCES LocalidadMunicipio(LocalidadID),
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
Telefono varchar(24))

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
GO

CREATE PROC MostrarSucuarsal
AS
	SELECT S.SucursalID, E.Nombres Responsable, S.Nombre [Nombre de sucursal], S.Telefono, LC.Municipio + ', ' + D.NombreDepartamento Ubicacion, S.Direccion
	FROM Sucursal S
	INNER JOIN Empleado E ON S.ResponsableID = E.EmpleadoID
	INNER JOIN LocalidadMunicipio LC ON LC.LocalidadID = S.LocalidadID 
	INNER JOIN Departamento D ON D.DepartamentoID = LC.DepartamentoID

GRANT EXEC ON dbo.MostrarSucuarsal TO adminRestaurante
GO

CREATE PROC MostrarEmpleado
AS
	SELECT Nombres, EmpleadoID
	FROM Empleado

GRANT EXEC ON dbo.MostrarEmpleado TO adminRestaurante
GO

CREATE PROC AgregarSucursal @Nombre varchar(50), @ResponsableID int, @Telefono varchar(24), @LocalidadID int, @Direccion varchar(100)
AS
	INSERT INTO Sucursal(Nombre, ResponsableID, Telefono, LocalidadID, Direccion) VALUES(@Nombre, @ResponsableID, @Telefono, @LocalidadID, @Direccion)

GRANT EXEC ON dbo.AgregarSucursal TO adminRestaurante
GO

CREATE PROC ElimanarSucursal @SucursalID int
AS
	DELETE
	FROM Sucursal
	WHERE SucursalID = @SucursalID

GRANT EXEC ON dbo.ElimanarSucursal TO adminRestaurante
GO

CREATE PROC ActualizarSucursal @SucursalID int, @Nombre varchar(50), @ResponsableID int, @Telefono varchar(24), @LocalidadID int, @Direccion varchar(100)
AS
	UPDATE Sucursal	SET Nombre = @Nombre, ResponsableID = @ResponsableID, Telefono = @Telefono, LocalidadID = @LocalidadID, Direccion = @Direccion
	WHERE SucursalID = @SucursalID

GRANT EXEC ON dbo.ActualizarSucursal TO adminRestaurante
GO

exec ActualizarSucursal 1, "Centroamerica", 1, "123456789", 97, "Modulo 24 multicentro"
exec MostrarLocalidad