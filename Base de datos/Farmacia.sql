USE master
GO

IF EXISTS(SELECT * FROM Sysdatabases WHERE name='Farmacia')
BEGIN
	DROP DATABASE Farmacia
END
GO

CREATE DATABASE Farmacia
GO

USE Farmacia
GO

--TABLAS
--FARMACEUTICA
CREATE TABLE Farmaceutica(
RUC VARCHAR(13) PRIMARY KEY,
Nombre VARCHAR(50) NOT NULL,
CorreoElectronico VARCHAR(50) NOT NULL,
Direccion VARCHAR(50) NOT NULL
);
GO

--MEDICAMENTO
CREATE TABLE Medicamento(
Codigo INT NOT NULL,
Farmaceutica VARCHAR(13) FOREIGN KEY REFERENCES Farmaceutica(RUC) NOT NULL,
Descripcion VARCHAR(50) NOT NULL,
Precio FLOAT NOT NULL,
Nombre VARCHAR(50) NOT NULL,
PRIMARY KEY(Codigo,Farmaceutica)
);
GO

--USUARIO
CREATE TABLE Usuario(
Usuario VARCHAR(20) PRIMARY KEY NOT NULL,
Pass VARCHAR(10) NOT NULL,
Nombre VARCHAR(50) NOT NULL
);
GO

--CLIENTE
CREATE TABLE Cliente(
Usuario VARCHAR(20) PRIMARY KEY FOREIGN KEY REFERENCES Usuario(Usuario), 
DireccionFacturacion VARCHAR(50) NOT NULL,
Telefono VARCHAR(15) NOT NULL
);
GO

--EMPLEADO
CREATE TABLE Empleado(
Usuario VARCHAR(20) PRIMARY KEY FOREIGN KEY REFERENCES Usuario(Usuario),
InicioJornada VARCHAR(5) NOT NULL,
FinJornada VARCHAR(5) NOT NULL
);
GO

--PEDIDO
CREATE TABLE Pedido(
Numero INT PRIMARY KEY,
Cliente VARCHAR(20) FOREIGN KEY REFERENCES Cliente(Usuario),
MedicamentoCodigo INT,
MedicamentoFarmaceutica VARCHAR(13),
CantidadMedicamento INT NOT NULL,
Estado VARCHAR(50) NOT NULL,
FOREIGN KEY (MedicamentoCodigo,MedicamentoFarmaceutica) REFERENCES Medicamento(Codigo,Farmaceutica)
);
GO

--STORED PROCEDURES
--FARMACEUTICA
--ABM
--LISTAR/BUSCAR
--ALTA
CREATE PROCEDURE AltaFarmaceutica
@RUC VARCHAR(13),
@Nombre VARCHAR(50),
@CorreoElectronico VARCHAR(50),
@Direccion VARCHAR (50)
AS BEGIN
	--VERIFICAR EXITENCIA FARMACEUTICA 
	IF NOT EXISTS(SELECT * FROM Farmaceutica WHERE RUC=@RUC)
	BEGIN
		INSERT Farmaceutica (RUC,Nombre,CorreoElectronico,Direccion) VALUES (@RUC,@Nombre,@CorreoElectronico,@Direccion) 
		RETURN 1
	END	
	ELSE 
	BEGIN
		RETURN -1
	END	
END
GO

--BAJA
CREATE PROCEDURE BajaFarmacecutica
@RUC VARCHAR(13)
AS BEGIN
	--VERIFICAR EXISTENCIA FARMACEUTICA
	IF EXISTS (SELECT * FROM Farmaceutica WHERE RUC=@RUC)
	BEGIN
		DELETE Farmaceutica WHERE RUC=@RUC
		RETURN 1
	END	
	ELSE
	BEGIN
		RETURN -1
	END
END 
GO

--MODIFICAR 
CREATE PROCEDURE ModificarFarmaceutica
@RUC VARCHAR(13),
@Nombre VARCHAR(50),
@CorreoElectronico VARCHAR(50),
@Direccion VARCHAR (50)
AS BEGIN
	--VERIFICAR EXISTENCIA FARMACEUTICA 
	IF EXISTS(SELECT * FROM Farmaceutica WHERE RUC=@RUC)
	BEGIN
		UPDATE Farmaceutica SET Nombre=@Nombre,CorreoElectronico=@CorreoElectronico,Direccion=@Direccion WHERE RUC=@RUC
		RETURN 1
	END	
	ELSE 
	BEGIN
		RETURN -1
	END
END	
GO

--LISTAR
CREATE PROCEDURE BuscarFarmaceutica
@RUC VARCHAR(13)
AS BEGIN
	SELECT * FROM Farmaceutica WHERE RUC=@RUC
END
GO

--BUSCAR 
CREATE PROCEDURE ListarFarmaceutica
AS BEGIN 
	SELECT * FROM Farmaceutica
END
GO

--MEDICAMENTO
--ABM
--ALTA
CREATE PROCEDURE AltaMedicamento
@Codigo INT,
@Farmaceutica INT,
@Descripcion VARCHAR(50),
@Precio FLOAT,
@Nombre VARCHAR(50)
AS BEGIN
	--VERIFICAR EXISTENCIA DEL MEDICAMENTO 
	IF NOT EXISTS(SELECT * FROM Medicamento WHERE Codigo=@Codigo)
	BEGIN
		INSERT Medicamento (Codigo,Farmaceutica,Descripcion,Precio,Nombre) VALUES (@Codigo,@Farmaceutica,@Descripcion,@Precio,@Nombre)
		RETURN 1
	END
	ELSE 
	BEGIN
		RETURN -1
	END
END	
GO

--BAJA
CREATE PROCEDURE BajaMedicamento
@Codigo INT
AS BEGIN
	--VERIFICAR EXISTENCIA DEL MEDICAMENTO 
	IF EXISTS(SELECT * FROM Medicamento WHERE Codigo=@Codigo)
	BEGIN
		DELETE Medicamento WHERE Codigo=@Codigo
		RETURN 1
	END
	ELSE
	BEGIN
		RETURN -1
	END
END 
GO

---MODIFICACION
CREATE PROCEDURE ModificarMedicamento
@Codigo INT,
@Farmaceutica INT,
@Descripcion VARCHAR(50),
@Precio FLOAT,
@Nombre VARCHAR(50)
AS BEGIN
	--VERIFICAR EXISTENCIA MEDICAMENTO
	IF EXISTS(SELECT * FROM Medicamento WHERE Codigo=@Codigo)
	BEGIN
		UPDATE Medicamento SET Codigo=@Codigo,Farmaceutica=@Farmaceutica,Descripcion=@Descripcion,Precio=@Precio,Nombre=@Nombre WHERE Codigo=@Codigo
		RETURN 1
	END
	ELSE 
	BEGIN
		RETURN -1
	END
END
GO

--USUARIO
--ABM
--ALTA
CREATE PROCEDURE AltaUsuario
@Usuario VARCHAR(20),
@Pass VARCHAR(10),
@Nombre VARCHAR(50)
AS BEGIN
	--VERIFICAR EXISTENCIA USUARIO
	IF NOT EXISTS(SELECT * FROM Usuario WHERE Usuario=@Usuario)
	BEGIN
		INSERT Usuario (Usuario,Pass,Nombre) VALUES(@Usuario,@Pass,@Nombre)
		RETURN 1
	END
	ELSE 
	BEGIN
		RETURN -1
	END
END
GO

--BAJA
CREATE PROCEDURE BajaUsuario
@Usuario VARCHAR(50)
AS BEGIN
	--VERIFICAR EXISTENCIA USUARIO
	IF EXISTS(SELECT * FROM Usuario WHERE Usuario=@Usuario)
	BEGIN
		DELETE Usuario WHERE Usuario=@Usuario
		RETURN 1
	END
	ELSE
	BEGIN
		RETURN -1
	END
END 
GO

--MODIFICACION
CREATE PROCEDURE ModificacionUsuario
@Usuario VARCHAR(20),
@Pass VARCHAR(10),
@Nombre VARCHAR(50)
AS BEGIN
	--VERIFICAR EXISTENCIA USUARIO
	IF EXISTS(SELECT * FROM Usuario WHERE Usuario=@Usuario)
	BEGIN
		UPDATE Usuario SET Usuario=@Usuario,Pass=@Pass,Nombre=@Nombre WHERE Usuario=@Usuario
		RETURN 1
	END
	ELSE
	BEGIN
		RETURN -1
	END
END
GO

--LOGUEO
CREATE PROCEDURE BuscarUsuario
@Usuario VARCHAR(20),
@Pass VARCHAR(10)
AS BEGIN
	SELECT * FROM Usuario 
	WHERE Usuario.Usuario=@Usuario AND Pass=@Pass
END
GO

--CLIENTE
--BUSCAR
--ABM
--ALTA
CREATE PROCEDURE AltaCliente
@Usuario VARCHAR(20),
@Pass VARCHAR(10),
@Nombre VARCHAR(50),
@DireccionFacturacion VARCHAR(50),
@Telefono VARCHAR(15)
AS BEGIN
	--VERIFICAR EXISTENCIA CLIENTE
	IF NOT EXISTS(SELECT * FROM Usuario WHERE Usuario=@Usuario)
	BEGIN
		BEGIN TRANSACTION
			INSERT Usuario (Usuario,Pass,Nombre) VALUES(@Usuario,@Pass,@Nombre)
			IF(@@ERROR!=0)
				BEGIN
					ROLLBACK TRANSACTION
					RETURN 0
				END
				
			INSERT Cliente (Usuario,DireccionFacturacion,Telefono) VALUES(@Usuario,@DireccionFacturacion,@Telefono)
			IF(@@ERROR!=0)
				BEGIN
					ROLLBACK TRANSACTION
					RETURN 0
				END
		COMMIT TRANSACTION
		RETURN 1
	END
	ELSE
	BEGIN
		RETURN -1
	END
END
GO

--BAJA
CREATE PROCEDURE BajaCliente
@Usuario VARCHAR(20)
AS BEGIN
	--VERIFICAR EXISTENCIA CLIENTE
	IF EXISTS(SELECT * FROM Cliente WHERE Usuario=@Usuario)
	BEGIN
		BEGIN TRANSACTION
			DELETE Cliente WHERE Cliente.Usuario=@Usuario
			IF(@@ERROR!=0)
			BEGIN
				ROLLBACK TRANSACTION
				RETURN 0
			END
			
			DELETE Usuario WHERE Usuario.Usuario=@Usuario
			IF(@@ERROR!=0)
			BEGIN
				ROLLBACK TRANSACTION
				RETURN 0
			END
		COMMIT TRANSACTION
		RETURN 1
	END
	ELSE
	BEGIN
		RETURN -1
	END
END
GO

--MODIFICAR
CREATE PROCEDURE ModificarCliente
@Usuario VARCHAR(20),
@Pass VARCHAR(10),
@Nombre VARCHAR(50),
@DireccionFacturacion VARCHAR(50),
@Telefono VARCHAR(15)
AS BEGIN
	--VERIFICAR EXISTENCIA CLIENTE
	IF NOT EXISTS(SELECT * FROM Cliente WHERE Usuario=@Usuario)
	BEGIN
		BEGIN TRANSACTION
			UPDATE Usuario SET Pass=@Pass,Nombre=@Nombre WHERE Usuario=@Usuario
			IF(@@ERROR!=0)
			BEGIN
				ROLLBACK TRANSACTION
				RETURN 0
			END
			
			UPDATE Cliente SET DireccionFacturacion=@DireccionFacturacion,Telefono=@Telefono WHERE Usuario=@Usuario
			IF(@@ERROR!=0)
			BEGIN
				ROLLBACK TRANSACTION
				RETURN 0
			END
		COMMIT TRANSACTION
		RETURN 1
	END
	ELSE
	BEGIN
		RETURN -1
	END
END
GO

--LOGUEO
CREATE PROCEDURE LogInCliente
@Usuario VARCHAR(20),
@Pass VARCHAR(10)
AS BEGIN
	SELECT * FROM Usuario 
	INNER JOIN Cliente ON Cliente.Usuario=Usuario.Usuario
	WHERE Usuario.Usuario=@Usuario AND Pass=@Pass
END
GO

--EMPLEADO
--ABM
--ALTA
CREATE PROCEDURE AltaEmpleado
@Usuario VARCHAR(20),
@Pass VARCHAR(10),
@Nombre VARCHAR(50),
@InicioJornada VARCHAR(5),
@FinJornada VARCHAR(5)
AS BEGIN
	--VERIFICAR EXISTENCIA EMPLEADO
	IF NOT EXISTS(SELECT * FROM Usuario WHERE Usuario=@Usuario)
	BEGIN
		BEGIN TRANSACTION
			INSERT Usuario (Usuario,Pass,Nombre) VALUES(@Usuario,@Pass,@Nombre)
			IF(@@ERROR!=0)
				BEGIN
					ROLLBACK TRANSACTION
					RETURN 0
				END
				
			INSERT Empleado(Usuario,InicioJornada,FinJornada) VALUES(@Usuario,@InicioJornada,@FinJornada)
			IF(@@ERROR!=0)
				BEGIN
					ROLLBACK TRANSACTION
					RETURN 0
				END
		COMMIT TRANSACTION
		RETURN 1
	END
	ELSE
	BEGIN
		RETURN -1
	END
END
GO

--BAJA
CREATE PROCEDURE BajaEmpleado
@Usuario VARCHAR(20)
AS BEGIN
	--VERIFICAR EXISTENCIA EMPLEADO
	IF EXISTS(SELECT * FROM Empleado WHERE Usuario=@Usuario)
	BEGIN
		BEGIN TRANSACTION
			DELETE Empleado WHERE Empleado.Usuario=@Usuario
			IF(@@ERROR!=0)
			BEGIN
				ROLLBACK TRANSACTION
				RETURN 0
			END
			
			DELETE Usuario WHERE Usuario.Usuario=@Usuario
			IF(@@ERROR!=0)
			BEGIN
				ROLLBACK TRANSACTION
				RETURN 0
			END
		COMMIT TRANSACTION
		RETURN 1
	END
	ELSE
	BEGIN
		RETURN -1
	END
END
GO

--MODIFICAR
CREATE PROCEDURE ModificarEmpleado
@Usuario VARCHAR(20),
@Pass VARCHAR(10),
@Nombre VARCHAR(50),
@InicioJornada VARCHAR(5),
@FinJornada VARCHAR(5)
AS BEGIN
	--VERIFICAR EXISTENCIA DE EMPLEADO
	IF NOT EXISTS(SELECT * FROM Empleado WHERE Usuario=@Usuario)
	BEGIN
		BEGIN TRANSACTION
			UPDATE Usuario SET Pass=@Pass,Nombre=@Nombre WHERE Usuario=@Usuario
			IF(@@ERROR!=0)
			BEGIN
				ROLLBACK TRANSACTION
				RETURN 0
			END
			
			UPDATE Empleado SET InicioJornada=@InicioJornada,FinJornada=@FinJornada WHERE Usuario=@Usuario
			IF(@@ERROR!=0)
			BEGIN
				ROLLBACK TRANSACTION
				RETURN 0
			END
		COMMIT TRANSACTION
		RETURN 1
	END
	ELSE
	BEGIN
		RETURN -1
	END
END
GO

--LOGEO
CREATE PROCEDURE LogInEmpleado
@Usuario VARCHAR(20),
@Pass VARCHAR(10)
AS BEGIN
	SELECT * FROM Usuario 
	INNER JOIN Empleado ON Empleado.Usuario=Usuario.Usuario
	WHERE Usuario.Usuario=@Usuario AND Pass=@Pass
END
GO

exec AltaEmpleado 'nicolas', 'nicolas', 'nicolas','00:00', '00:00'
GO
EXEC AltaFarmaceutica '1231231231231','FARMACEUTICA','ASDDAS','ASDASD'
