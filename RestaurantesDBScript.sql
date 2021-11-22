-- 1. Crear la base de datos y un usario de ella
CREATE DATABASE Restaurantes
GO
USE Restaurantes
GO
CREATE LOGIN adminRestaurante WITH PASSWORD = 'password01'
GO
sp_adduser adminRestaurante, adminRestaurante

-- 2. Crear tablas
CREATE TABLE Departamento
(DepartamentoID int primary key identity(1, 1),
NombreDepartamento varchar(50))

CREATE TABLE LocalidadMunicipio
(LocalidadID int primary key identity(1, 1),
DepartamentoID int FOREIGN KEY REFERENCES Departamento(DepartamentoID),
Municipio varchar(50))

CREATE TABLE Sucursal
(SucursalID int primary key identity(1,1),
Nombre varchar(50),
ResponsableID int,
Telefono varchar(24),
LocalidadID int not null FOREIGN KEY REFERENCES LocalidadMunicipio(LocalidadID),
Direccion varchar(100))

CREATE TABLE Empleado
(EmpleadoID int primary key identity(1, 1),
Cedula varchar(15),
Nombres varchar(50),
Apellidos varchar(50),
Cargo varchar(50),
Telefono varchar(24),
Direccion varchar(100),
SucursalID int FOREIGN KEY REFERENCES Sucursal(SucursalID))

ALTER TABLE Sucursal
ADD CONSTRAINT FK_Empleado_ResponsableID FOREIGN KEY (ResponsableID)
    REFERENCES Empleado(EmpleadoID)

CREATE TABLE Usuario
(EmpleadoID int FOREIGN KEY REFERENCES Empleado(EmpleadoID),
usuario varchar(80),
contrasena varchar(80),
rol varchar(80),
estado varchar(80))

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
ALTER TABLE Orden ALTER COLUMN ClienteID int NULL

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

-- 3. Generar resgistros (a traves de proc) iniciales y necesarios para testear el programa
GO
CREATE PROCEDURE AgregarDepartamento @Departamento varchar(50)
AS
	INSERT INTO Departamento(NombreDepartamento) VALUES(@Departamento)
-- Inserto los departamentos de Nicaragua
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
-- Inserto los municipios de los departamentos	
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
-- Esta tabla se usara para cargar los comboboxes Ubicacion
CREATE PROCEDURE MostrarLocalidad
AS
	SELECT LM.Municipio + ', ' + O.NombreDepartamento AS [Cuidad-Departamento], LM.LocalidadID
	FROM LocalidadMunicipio LM
	JOIN Departamento O ON O.DepartamentoID = LM.DepartamentoID
	ORDER BY LM.Municipio + ', ' + O.NombreDepartamento ASC

-- EXEC MostrarLocalidad
-- De aqui en adelante GRANT se usara para dar permiso al usuario de la base de ejecutar proc o consultas
GRANT EXEC ON dbo.MostrarLocalidad TO adminRestaurante
-- Registro los tres primeros empleados
INSERT INTO Empleado(Cedula, Nombres, Apellidos, Cargo, Telefono, Direccion) VALUES('4503010001000L', 'Uziel Jose', 'Duarte Guillen', 'Administrador', '83811309', 'Via Reconciliacion')
INSERT INTO Empleado(Cedula, Nombres, Apellidos, Cargo, Telefono, Direccion) VALUES('0010000000000C', 'Harbey Caleb', 'Vilchez Tapia', 'Administrador', '88888888', 'Masaya')
INSERT INTO Empleado(Cedula, Nombres, Apellidos, Cargo, Telefono, Direccion) VALUES('1000000000000M', 'Rodian Josue', 'Matey Martinez', 'Administrador', '12345678', 'Managua')
-- Resgistro las tres primeras sucursales y hago administradores a los primeros tres empleados
INSERT INTO Sucursal(Nombre, ResponsableID, Telefono, LocalidadID, Direccion) VALUES('Asados', 1, '18001024', 116, 'Pista Principal')
INSERT INTO Sucursal(Nombre, ResponsableID, Telefono, LocalidadID, Direccion) VALUES('Vigoron', 2, '88888888', 107, 'Parque Central')
INSERT INTO Sucursal(Nombre, ResponsableID, Telefono, LocalidadID, Direccion) VALUES('Fritanga', 3, '87543211', 97, 'Rubenia')
-- Asignarle una sucursal a cada empleado
UPDATE Empleado SET SucursalID = 1 WHERE EmpleadoID = 1
UPDATE Empleado SET SucursalID = 2 WHERE EmpleadoID = 2
UPDATE Empleado SET SucursalID = 3 WHERE EmpleadoID = 3
-- Agregar empleados dependientes, cinco en cada sucursal
INSERT INTO Empleado(Cedula, Nombres, Apellidos, Cargo, Telefono, Direccion, SucursalID) VALUES('4503010001000L', 'Alex', 'Guitierrez', 'Chef', '83876979', 'San Judas', 1)
INSERT INTO Empleado(Cedula, Nombres, Apellidos, Cargo, Telefono, Direccion, SucursalID) VALUES('6516510001000L', 'Celeste', 'Miranda', 'Chef', '86516516', 'Dimitrov', 1)
INSERT INTO Empleado(Cedula, Nombres, Apellidos, Cargo, Telefono, Direccion, SucursalID) VALUES('5465456546000L', 'Victor', 'Galo', 'Mesero', '86625599', 'Via Libertad', 1)
INSERT INTO Empleado(Cedula, Nombres, Apellidos, Cargo, Telefono, Direccion, SucursalID) VALUES('4506546549878L', 'Jose', 'Moreno', 'Mesero', '83819879', 'Primero de Mayo', 1)
INSERT INTO Empleado(Cedula, Nombres, Apellidos, Cargo, Telefono, Direccion, SucursalID) VALUES('7658765656756L', 'Rigo', 'Castillo', 'Mesero', '87811356', 'Rafaela', 1)

INSERT INTO Empleado(Cedula, Nombres, Apellidos, Cargo, Telefono, Direccion, SucursalID) VALUES('4503016546546L', 'Scarlette', 'Galo', 'Chef', '84696979', 'San Judas', 2)
INSERT INTO Empleado(Cedula, Nombres, Apellidos, Cargo, Telefono, Direccion, SucursalID) VALUES('6526526554698U', 'Ethan', 'Larios', 'Chef', '82326526', 'Dimitrov', 2)
INSERT INTO Empleado(Cedula, Nombres, Apellidos, Cargo, Telefono, Direccion, SucursalID) VALUES('5465456576876M', 'Eliseo', 'Lara', 'Mesero', '86740599', 'Via Libertad', 2)
INSERT INTO Empleado(Cedula, Nombres, Apellidos, Cargo, Telefono, Direccion, SucursalID) VALUES('4506546549878I', 'Mario', 'Moreno', 'Mesero', '84279879', 'Primero de Mayo', 2)
INSERT INTO Empleado(Cedula, Nombres, Apellidos, Cargo, Telefono, Direccion, SucursalID) VALUES('7658765656756P', 'Melvin', 'Diaz', 'Mesero', '87086356', 'Rafaela', 2)

INSERT INTO Empleado(Cedula, Nombres, Apellidos, Cargo, Telefono, Direccion, SucursalID) VALUES('2666010001000O', 'Nishmi', 'Duarte', 'Chef', '838000979', 'San Judas', 3)
INSERT INTO Empleado(Cedula, Nombres, Apellidos, Cargo, Telefono, Direccion, SucursalID) VALUES('9879830003000E', 'Oscar', 'Cabrera', 'Chef', '8656336', 'Dimitrov', 3)
INSERT INTO Empleado(Cedula, Nombres, Apellidos, Cargo, Telefono, Direccion, SucursalID) VALUES('8798986546000S', 'Javier', 'Ampie', 'Mesero', '89075599', 'Via Libertad', 3)
INSERT INTO Empleado(Cedula, Nombres, Apellidos, Cargo, Telefono, Direccion, SucursalID) VALUES('9898656549878N', 'Osneilin', 'Matey', 'Mesero', '82849879', 'Primero de Mayo', 3)
INSERT INTO Empleado(Cedula, Nombres, Apellidos, Cargo, Telefono, Direccion, SucursalID) VALUES('9853256652756W', 'Raquel', 'Vilchez', 'Mesero', '87833000', 'Rafaela', 3)
--select * from Empleado
-- Agregar Mesas
INSERT INTO Mesa(CantidadAsiento, Area, SucursalID) VALUES(4, 'Terraza', 1)
INSERT INTO Mesa(CantidadAsiento, Area, SucursalID) VALUES(8, 'Salon NO fumadores', 1)
INSERT INTO Mesa(CantidadAsiento, Area, SucursalID) VALUES(12, 'Terraza', 1)
INSERT INTO Mesa(CantidadAsiento, Area, SucursalID) VALUES(6, 'Salon fumadores', 1)
INSERT INTO Mesa(CantidadAsiento, Area, SucursalID) VALUES(9, 'Salon NO fumadores', 1)
INSERT INTO Mesa(CantidadAsiento, Area, SucursalID) VALUES(6, 'Terraza', 1)
INSERT INTO Mesa(CantidadAsiento, Area, SucursalID) VALUES(6, 'Solo NO fumadores', 1)
INSERT INTO Mesa(CantidadAsiento, Area, SucursalID) VALUES(8, 'Terraza', 1)
INSERT INTO Mesa(CantidadAsiento, Area, SucursalID) VALUES(10, 'Salon fumadores', 1)
INSERT INTO Mesa(CantidadAsiento, Area, SucursalID) VALUES(5, 'Salon NO fumadores', 1)

INSERT INTO Mesa(CantidadAsiento, Area, SucursalID) VALUES(4, 'Terraza', 2)
INSERT INTO Mesa(CantidadAsiento, Area, SucursalID) VALUES(8, 'Salon NO fumadores', 2)
INSERT INTO Mesa(CantidadAsiento, Area, SucursalID) VALUES(9, 'Terraza', 2)
INSERT INTO Mesa(CantidadAsiento, Area, SucursalID) VALUES(6, 'Salon fumadores', 2)
INSERT INTO Mesa(CantidadAsiento, Area, SucursalID) VALUES(9, 'Salon NO fumadores', 2)
INSERT INTO Mesa(CantidadAsiento, Area, SucursalID) VALUES(6, 'Terraza', 2)
INSERT INTO Mesa(CantidadAsiento, Area, SucursalID) VALUES(6, 'Solo NO fumadores', 2)
INSERT INTO Mesa(CantidadAsiento, Area, SucursalID) VALUES(8, 'Terraza', 2)
INSERT INTO Mesa(CantidadAsiento, Area, SucursalID) VALUES(6, 'Salon fumadores', 2)
INSERT INTO Mesa(CantidadAsiento, Area, SucursalID) VALUES(5, 'Salon NO fumadores', 2)

INSERT INTO Mesa(CantidadAsiento, Area, SucursalID) VALUES(4, 'Terraza', 3)
INSERT INTO Mesa(CantidadAsiento, Area, SucursalID) VALUES(8, 'Salon NO fumadores', 3)
INSERT INTO Mesa(CantidadAsiento, Area, SucursalID) VALUES(12, 'Terraza', 3)
INSERT INTO Mesa(CantidadAsiento, Area, SucursalID) VALUES(6, 'Salon fumadores', 3)
INSERT INTO Mesa(CantidadAsiento, Area, SucursalID) VALUES(9, 'Salon NO fumadores', 3)
INSERT INTO Mesa(CantidadAsiento, Area, SucursalID) VALUES(6, 'Terraza', 3)
INSERT INTO Mesa(CantidadAsiento, Area, SucursalID) VALUES(6, 'Solo NO fumadores', 3)
INSERT INTO Mesa(CantidadAsiento, Area, SucursalID) VALUES(8, 'Terraza', 3)
INSERT INTO Mesa(CantidadAsiento, Area, SucursalID) VALUES(10, 'Salon fumadores', 3)
INSERT INTO Mesa(CantidadAsiento, Area, SucursalID) VALUES(5, 'Salon NO fumadores', 3)
--SELECT * FROM Mesa
--SELECT * FROM Empleado
GO
-- Procediento de almacenado para insertar el usuario
CREATE PROCEDURE dbo.[Insertar usuario]
@EmpleadoID int,
@usuario varchar(50),
@contrasena varchar(50),
@rol varchar(50)
AS
	INSERT INTO Usuario(EmpleadoID, usuario, contrasena, rol, estado)
	VALUES(@EmpleadoID, @usuario, ENCRYPTBYPASSPHRASE(@contrasena, @contrasena), @rol, 'Habilitado')

EXEC dbo.[Insertar usuario] 1, 'Uziel', 'duarte', 'ADMIN'
EXEC dbo.[Insertar usuario] 2, 'Caleb', 'vilchez', 'ADMIN'
EXEC dbo.[Insertar usuario] 3, 'Rodian', 'matey', 'ADMIN'
EXEC dbo.[Insertar usuario]  39,'Samantha','cruz','Recepcionista'
EXEC dbo.[Insertar usuario]  26,'Eliseo','lara','Chef'
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
--EXEC dbo.[Validar acceso]  'Uziel', 'duarte'
GRANT EXEC ON dbo.[Validar acceso] TO adminRestaurante
GO
-- Procedimiento de almacenado para mostrar datos de las sucursales
CREATE PROC MostrarSucuarsal
AS
	SELECT S.SucursalID, E.Nombres Responsable, S.Nombre [Nombre de sucursal], S.Telefono, LC.Municipio + ', ' + D.NombreDepartamento Ubicacion, S.Direccion
	FROM Sucursal S
	INNER JOIN Empleado E ON S.ResponsableID = E.EmpleadoID
	INNER JOIN LocalidadMunicipio LC ON LC.LocalidadID = S.LocalidadID 
	INNER JOIN Departamento D ON D.DepartamentoID = LC.DepartamentoID

GRANT EXEC ON dbo.MostrarSucuarsal TO adminRestaurante
GO
-- Procedimiento de almacenado para mostral los empleados con sus ID, esta consulta se usa para cargar comboboxes
CREATE PROC MostrarEmpleado
AS
	SELECT Nombres, EmpleadoID
	FROM Empleado

GRANT EXEC ON dbo.MostrarEmpleado TO adminRestaurante
GO
-- Procedimiento de almacenado para guardar sucursales desde el programa
CREATE PROC AgregarSucursal @Nombre varchar(50), @ResponsableID int, @Telefono varchar(24), @LocalidadID int, @Direccion varchar(100)
AS
	INSERT INTO Sucursal(Nombre, ResponsableID, Telefono, LocalidadID, Direccion) VALUES(@Nombre, @ResponsableID, @Telefono, @LocalidadID, @Direccion)

GRANT EXEC ON dbo.AgregarSucursal TO adminRestaurante
GO
-- Procedimiento de almacenado para eliminar sucursales desde el programa
CREATE PROC ElimanarSucursal @SucursalID int
AS
	DELETE
	FROM Sucursal
	WHERE SucursalID = @SucursalID

GRANT EXEC ON dbo.ElimanarSucursal TO adminRestaurante
GO
-- Procedimiento de almacenado para actulizar sucursales desde el programa
CREATE PROC ActualizarSucursal @SucursalID int, @Nombre varchar(50), @ResponsableID int, @Telefono varchar(24), @LocalidadID int, @Direccion varchar(100)
AS
	UPDATE Sucursal	SET Nombre = @Nombre, ResponsableID = @ResponsableID, Telefono = @Telefono, LocalidadID = @LocalidadID, Direccion = @Direccion
	WHERE SucursalID = @SucursalID

GRANT EXEC ON dbo.ActualizarSucursal TO adminRestaurante
GO
/*PROCEDIMIENTOS DE ALMACENADOS DE DATOS QUE SOLO RESGISTRARE DESDE EL PROGRAMA*/
CREATE PROC AgregarProveedor @NombreCompania varchar(100), @Telefono varchar (24), @LocalidadID int, @Direccion varchar(150)
AS
	INSERT INTO Proveedor(NombreCompania, Telefono, LocalidadID, Direccion) VALUES(@NombreCompania, @Telefono, @LocalidadID, @Direccion)

GRANT EXEC ON dbo.AgregarProveedor TO adminRestaurante
GO

CREATE PROC AgregarCliente @Cedula varchar(15), @Nombres varchar(50), @Apellidos varchar(50), @Telefono varchar(24)
AS
	INSERT INTO Cliente(Cedula, Nombres, Apellidos, Telefono) VALUES (@Cedula, @Nombres, @Apellidos, @Telefono)

GRANT EXEC ON dbo.AgregarCliente TO adminRestaurante
GO

CREATE PROC CargarSucursal
AS
	SELECT S.Nombre + ', ' + LM.Municipio + ', ' + D.NombreDepartamento [Sucursal y Ubicacion], S.SucursalID
	FROM Sucursal S
	INNER JOIN LocalidadMunicipio LM ON LM.LocalidadID = S.LocalidadID
	INNER JOIN Departamento D ON D.DepartamentoID = LM.DepartamentoID

GRANT EXEC ON dbo.CargarSucursal TO adminRestaurante
GO

CREATE PROC CargarMeseroPorSucursal @SucursalID int
AS
	SELECT E.Nombres, E.EmpleadoID
	FROM Empleado E
	INNER JOIN Sucursal S ON S.SucursalID = E.SucursalID
	WHERE E.SucursalID = @SucursalID AND E.Cargo = 'Mesero'

GRANT EXEC ON dbo.CargarMeseroPorSucursal TO adminRestaurante
GO

CREATE PROC CargarMesasPorSucursal @SucursalID int
AS
	SELECT M.Area + ', ' + CONCAT(M.CantidadAsiento, ' asientos'), M.MesaID
	FROM Mesa M
	INNER JOIN Sucursal S ON S.SucursalID = M.SucursalID
	WHERE M.SucursalID = @SucursalID

GRANT EXEC ON dbo.CargarMesasPorSucursal TO adminRestaurante
GO

CREATE PROC MostrarClientes
AS
	SELECT * FROM Cliente

GRANT EXEC ON dbo.MostrarClientes TO adminRestaurante
GO

CREATE PROC AgregarOrden @EmpleadoID int, @MesaID int, @ClienteID int, @FechaRealizacion datetime
AS
	IF @ClienteID = 0
		INSERT INTO Orden(EmpleadoID, MesaID, FechaRealizacion) VALUES(@EmpleadoID, @MesaID, CONVERT(VARCHAR(30), @FechaRealizacion, 121))
	ELSE
		INSERT INTO Orden(EmpleadoID, MesaID, ClienteID, FechaRealizacion) VALUES(@EmpleadoID, @MesaID, @ClienteID, CONVERT(VARCHAR(30), @FechaRealizacion, 121))

GRANT EXEC ON dbo.AgregarOrden TO adminRestaurante
GO

CREATE PROC MostrarOrdenFKPorSucursal @SucursalID int
AS
	SELECT O.OrdenID, E.EmpleadoID, M.MesaID, C.ClienteID
	FROM Orden O
	INNER JOIN Mesa M ON M.MesaID = O.MesaID
	INNER JOIN Sucursal S ON S.SucursalID = M.SucursalID
	INNER JOIN Empleado E ON E.EmpleadoID = O.EmpleadoID
	INNER JOIN Cliente C ON C.ClienteID = O.ClienteID
	WHERE S.SucursalID = @SucursalID AND M.SucursalID = @SucursalID
	UNION ALL
	SELECT O.OrdenID, E.EmpleadoID, M.MesaID, 0 Cliente
	FROM Orden O
	INNER JOIN Mesa M ON M.MesaID = O.MesaID
	INNER JOIN Sucursal S ON S.SucursalID = M.SucursalID
	INNER JOIN Empleado E ON E.EmpleadoID = O.EmpleadoID
	WHERE S.SucursalID = @SucursalID AND O.ClienteID IS NULL

GRANT EXEC ON dbo.MostrarOrdenFKPorSucursal TO adminRestaurante
GO

--EXEC AgregarOrden 1, 1, 1, '2021-11-08 11:18:11.96'
-- Actualizar un cliente
CREATE PROC ActualizarCliente @ClienteID int, @Cedula varchar(15), @Nombres varchar(50), @Apellidos varchar(50), @Telefono varchar(24)
AS
	UPDATE Cliente	SET Nombres = @Nombres, Cedula = @Cedula, Telefono = @Telefono, Apellidos = @Apellidos
	WHERE ClienteID = @ClienteID

GRANT EXEC ON dbo.ActualizarCliente TO adminRestaurante
GO

-- Eliminar un cliente
-- exec MostrarOrdenFKPorSucursal 1
-- Actualizar Orden
CREATE PROC ActualizarOrden @OrdenID int, @EmpleadoID int, @MesaID int, @ClienteID int, @FechaRealizacion datetime
AS
	IF @ClienteID = 0
		UPDATE Orden SET EmpleadoID = @EmpleadoID, MesaID = @MesaID, ClienteID = Null, FechaRealizacion = CONVERT(VARCHAR(30), @FechaRealizacion, 121)
		WHERE OrdenID = @OrdenID
	ELSE
		UPDATE Orden SET EmpleadoID = @EmpleadoID, MesaID = @MesaID, ClienteID = @ClienteID, FechaRealizacion = CONVERT(VARCHAR(30), @FechaRealizacion, 121)
		WHERE OrdenID = @OrdenID

GRANT EXEC ON dbo.ActualizarOrden TO adminRestaurante
GO

--exec MostrarOrdenPorSucursal 1
-- Eliminar Orden
-- Mostraremos solo la informacion importante de las ordenes (sin ID)
CREATE PROC MostrarOrdenBasicoPorSucursal @SucursalID int
AS
	SELECT * FROM
	(SELECT O.OrdenID, E.Nombres Mesero, M.Area + CONCAT(M.CantidadAsiento, ' asientos, ')+ S.Nombre Mesa,
	C.Nombres + ' ' + C.Apellidos Cliente, O.FechaRealizacion, 0 Monto
	FROM Orden O
	INNER JOIN Mesa M ON M.MesaID = O.MesaID
	INNER JOIN Sucursal S ON S.SucursalID = M.SucursalID
	INNER JOIN Empleado E ON E.EmpleadoID = O.EmpleadoID
	INNER JOIN Cliente C ON C.ClienteID = O.ClienteID OR O.ClienteID = NULL
	WHERE S.SucursalID = @SucursalID
	UNION ALL
	SELECT O.OrdenID, E.Nombres Mesero, M.Area + CONCAT(M.CantidadAsiento, ' asientos, ')+ S.Nombre Mesa,
	'Contado' Cliente, O.FechaRealizacion, 0 Monto
	FROM Orden O
	INNER JOIN Mesa M ON M.MesaID = O.MesaID
	INNER JOIN Sucursal S ON S.SucursalID = M.SucursalID
	INNER JOIN Empleado E ON E.EmpleadoID = O.EmpleadoID
	WHERE S.SucursalID = @SucursalID AND O.ClienteID IS NULL) Ordenes
	ORDER BY Ordenes.FechaRealizacion

GRANT EXEC ON dbo.MostrarOrdenBasicoPorSucursal TO adminRestaurante
GO

CREATE PROC MostrarSucursalFK
AS
		SELECT SucursalID, ResponsableID, LocalidadID
		FROM Sucursal

GRANT EXEC ON dbo.MostrarSucursalFK TO adminRestaurante
GO
-- exec MostrarSucursalFK
-- select * from Orden, SELECT * FROM Mesa, select * from Sucursal, select * from Empleado
-- exec MostrarOrdenBasicoPorSucursal
-- exec MostrarOrdenFKPorSucursal 1

CREATE PROC AgregarEmpleado @Cedula varchar(15), @Nombres varchar(50), @Apellidos varchar(50), @Cargo varchar(50), @Telefono varchar(24), @Direccion varchar(100), @SucursalID int
AS
	INSERT INTO Empleado(Cedula, Nombres, Apellidos, Cargo, Telefono, Direccion, SucursalID)
	VALUES(@Cedula, @Nombres, @Apellidos, @Cargo, @Telefono, @Direccion, @SucursalID)

GRANT EXEC ON dbo.AgregarEmpleado TO adminRestaurante
GO

--exec AgregarEmpleado '23213213H', 'Simon', 'Miranda', 'Chef', '65235665', 'Polanco', 4
--exec AgregarEmpleado '23213213H', 'Aniseto', 'Prieto', 'Mesero', '89555665', 'Polanco', 4

CREATE PROC ActualizarEmpleado @EmpleadoID int, @Cedula varchar(15), @Nombres varchar(50), @Apellidos varchar(50), @Cargo varchar(50), @Telefono varchar(24), @Direccion varchar(100), @SucursalID int
AS
	UPDATE Empleado
	SET Cedula = @Cedula, Nombres = @Nombres, Apellidos = @Apellidos, Cargo = @Cargo, Telefono = @Telefono, Direccion = @Direccion, SucursalID = @SucursalID
	WHERE EmpleadoID = @EmpleadoID

GRANT EXEC ON dbo.ActualizarEmpleado TO adminRestaurante
GO
--exec ActualizarEmpleado 23, '12345678901234', 'Gilberto', 'del Calabozo', 'Mesero', '88888888', 'Farmaton', 1

CREATE PROC AgregarMesa @CantidadAsiento int, @Area varchar(30), @SucursalID int
AS
	INSERT INTO Mesa(CantidadAsiento, Area, SucursalID) VALUES(@CantidadAsiento, @Area, @SucursalID)

GRANT EXEC ON dbo.AgregarMesa TO adminRestaurante
GO

CREATE PROC ActualizarMesa @MesaID int, @CantidadAsiento int, @Area varchar(30), @SucursalID int
AS
	UPDATE Mesa
	SET CantidadAsiento = @CantidadAsiento, Area = @Area, SucursalID = @SucursalID
	WHERE MesaID = @MesaID

GRANT EXEC ON dbo.ActualizarMesa TO adminRestaurante
GO
--exec AgregarMesa 2, 'Teraza', 4
-- select * from Mesa
-- EXEC ActualizarMesa 25, 4, 'Terraza', 4

CREATE PROC MostrarEmpleadoPorSucursal @SucursalID int
AS
	SELECT EmpleadoID, Cedula, Nombres, Apellidos, Cargo, Telefono, Direccion
	FROM Empleado
	WHERE SucursalID = @SucursalID

GRANT EXEC ON dbo.MostrarEmpleadoPorSucursal TO adminRestaurante
GO

CREATE PROC MostrarMesaPorSucursal @SucursalID int
AS
	SELECT MesaID, CantidadAsiento, Area
	FROM Mesa
	WHERE SucursalID = @SucursalID

GRANT EXEC ON dbo.MostrarMesaPorSucursal TO adminRestaurante
GO
-- exec MostrarMesaPorSucursal 1

-- exec AgregarProveedor 'Leterago', '223321233', 97, 'Enec Central'
CREATE PROC MostrarProveedor
AS
	SELECT P.ProveedorID, P.NombreCompania , LM.Municipio + ', ' + D.NombreDepartamento Ubicacion, P.Telefono, P.Direccion
	FROM Proveedor P
	INNER JOIN LocalidadMunicipio LM
	ON LM.LocalidadID = P.LocalidadID
	INNER JOIN Departamento D
	ON D.DepartamentoID = LM.DepartamentoID

GRANT EXEC ON dbo.MostrarProveedor TO adminRestaurante
GO
