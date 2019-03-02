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
Numero INT PRIMARY KEY IDENTITY(1,1),
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
@Farmaceutica VARCHAR(13),
@Descripcion VARCHAR(50),
@Precio FLOAT,
@Nombre VARCHAR(50)
AS BEGIN
	--VERIFICAR EXISTENCIA DEL MEDICAMENTO 
	IF NOT EXISTS(SELECT * FROM Medicamento WHERE Codigo=@Codigo AND Farmaceutica=@Farmaceutica)
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
@Codigo INT,
@Farmaceutica VARCHAR(13)
AS BEGIN
	--VERIFICAR EXISTENCIA DEL MEDICAMENTO 
	IF EXISTS(SELECT * FROM Medicamento WHERE Codigo=@Codigo AND Farmaceutica=@Farmaceutica)
	BEGIN
		DELETE Medicamento WHERE Codigo=@Codigo AND Farmaceutica=@Farmaceutica
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
@Farmaceutica VARCHAR(13),
@Descripcion VARCHAR(50),
@Precio FLOAT,
@Nombre VARCHAR(50)
AS BEGIN
	--VERIFICAR EXISTENCIA MEDICAMENTO
	IF EXISTS(SELECT * FROM Medicamento WHERE Codigo=@Codigo AND Farmaceutica=@Farmaceutica)
	BEGIN
		UPDATE Medicamento SET Codigo=@Codigo,Farmaceutica=@Farmaceutica,Descripcion=@Descripcion,Precio=@Precio,Nombre=@Nombre 
		WHERE Codigo=@Codigo AND Farmaceutica=@Farmaceutica
		RETURN 1
	END
	ELSE 
	BEGIN
		RETURN -1
	END
END
GO

--BUSCAR 
CREATE PROCEDURE BuscarMedicamento
@Codigo INT,
@Farmaceutica VARCHAR(13)
AS BEGIN
	SELECT * FROM Medicamento WHERE Codigo=@Codigo AND Farmaceutica=@Farmaceutica
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

--LISTAR
CREATE PROCEDURE ListarMedicamento
AS BEGIN
	SELECT * FROM Medicamento ORDER BY Nombre
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

--BUSCAR
CREATE PROCEDURE Buscarcliente
@Usuario VARCHAR(20)
AS BEGIN
	SELECT * FROM Cliente INNER JOIN Usuario ON Usuario.Usuario=Cliente.Usuario WHERE Cliente.Usuario=@Usuario
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
	IF EXISTS(SELECT * FROM Empleado WHERE Usuario=@Usuario)
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

--BUSCAR
CREATE PROCEDURE BuscarEmpleado
@Usuario VARCHAR(20)
AS BEGIN
	SELECT * FROM Empleado INNER JOIN Usuario ON Usuario.Usuario=Empleado.Usuario WHERE Empleado.Usuario=@Usuario
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

CREATE PROCEDURE AltaPedido
@Cliente VARCHAR(20),
@MedicamentoCodigo INT,
@MedicamentoFarmaceutica VARCHAR(13),
@CantidadMedicamento INT,
@Estado VARCHAR(50)
AS BEGIN
	--VERIFICAR EXISTENCIA CLIENTE
	IF EXISTS(SELECT * FROM Cliente WHERE Cliente.Usuario=@Cliente)
	BEGIN
		--VERIFICAR EXISTENCIA FARMACEUTICA
		IF EXISTS(SELECT * FROM Farmaceutica WHERE Farmaceutica.RUC=@MedicamentoFarmaceutica)
		BEGIN
			--VERIFICAR EXISTENCIA MEDICAMENTO
			IF EXISTS(SELECT * FROM Medicamento WHERE Medicamento.Codigo=@MedicamentoCodigo AND Medicamento.Farmaceutica=@MedicamentoFarmaceutica)
			BEGIN
				INSERT INTO Pedido (Cliente,MedicamentoCodigo,MedicamentoFarmaceutica,CantidadMedicamento,Estado) VALUES (@Cliente,@MedicamentoCodigo,@MedicamentoFarmaceutica,@CantidadMedicamento,@Estado)
				RETURN 1
			END
			ELSE
			BEGIN
				--NO EXISTE MEDICAMENTO
				RETURN -3
			END
		END
		ELSE
		BEGIN
		--FARMACEUTICA NO EXISTE
			RETURN -2
		END
	END
	ELSE
	BEGIN
		--CLIETNE NO EXISTE
		RETURN -1
	END
END
GO

--BAJA
CREATE PROCEDURE BajaPedido
@Numero INT
AS BEGIN
	IF EXISTS(SELECT * FROM Pedido WHERE Numero=@Numero)
	BEGIN
		DELETE Pedido WHERE Numero=@Numero
		RETURN 1
	END
	ELSE 
	BEGIN
		RETURN -1
	END
END
GO

--LISTAR PEDIDO POR CLIENTE GENERADOS
CREATE PROCEDURE ListarPedidoPorClienteGENERADOS
@Usuario VARCHAR(20)
AS BEGIN 
	SELECT * FROM Pedido WHERE Cliente=@Usuario AND Estado='GENERADO'
END	
GO

--BUSCAR PEDIDO
CREATE PROCEDURE BuscarPedido
@Numero INT
AS BEGIN
	SELECT * FROM Pedido WHERE Numero=@Numero
END
GO

--EMPLEADOS DATA DE PRUEBA
exec AltaEmpleado 'NICOLAS', 'NICOLAS', 'NICOLAS','09:00', '17:45'
GO
exec AltaEmpleado 'VICTORIA', 'VICTORIA', 'VICTORIA','09:00', '17:45'
GO
exec AltaEmpleado 'JORGE', 'JORGE', 'JORGE','10:00', '18:45'
GO

--CLIENTES DATA DE PRUEBA
EXEC AltaCliente 'ANDRES', 'ANDRES', 'ANDRES', 'DIRECCION ANDRES','+594 114540'
GO
EXEC AltaCliente 'AGUSTIN', 'AGUSTIN', 'AGUSTIN', 'DIRECCION AGUSTIN','+594 421610'
GO
EXEC AltaCliente 'SOLEDAD', 'SOLEDAD', 'SOLEDAD', 'DIRECCION SOLEDAD','+594 231567'
GO 

--FARMACEUTICAS DATA DE PRUEBA
EXEC AltaFarmaceutica '1231231231231','FARMACEUTICA SOL','FSOL@FARMACIA.COM','DIRECCION FSOL'
GO
EXEC AltaFarmaceutica '3213213213213','FARMACEUTICA PIEDRAS','FPIEDRAS@FARMACIA.COM','DIRECCION FPIEDRAS'
GO
EXEC AltaFarmaceutica '2342342342342','FARMACEUTICA MAR','FMAR@FARMACIA.COM','DIRECCION FMAR'
GO

--MEDICAMENTOS DATA DE PRUEBA
--MEDICAMENTOS FARMACEUTICA 1231231231231
EXEC AltaMedicamento 0,'1231231231231','DESCRIPCION MEDICAMENTO 0',10,'MED-123-A'
GO
EXEC AltaMedicamento 1,'1231231231231','DESCRIPCION MEDICAMENTO 1',20,'MED-123-B'
GO
EXEC AltaMedicamento 2,'1231231231231','DESCRIPCION MEDICAMENTO 2',35,'MED-123-C'
GO

--MEDICAMENTOS FARMACEUTICA 3213213213213
EXEC AltaMedicamento 0,'3213213213213','DESCRIPCION MEDICAMENTO 0',15,'MED-321-A'
GO
EXEC AltaMedicamento 1,'3213213213213','DESCRIPCION MEDICAMENTO 1',25,'MED-321-B'
GO
EXEC AltaMedicamento 2,'3213213213213','DESCRIPCION MEDICAMENTO 2',10,'MED-321-C'
GO

--MEDICAMENTOS FARMACEUTICA 2342342342342
EXEC AltaMedicamento 0,'2342342342342','DESCRIPCION MEDICAMENTO 0',15,'MED-234-A'
GO
EXEC AltaMedicamento 1,'2342342342342','DESCRIPCION MEDICAMENTO 1',10,'MED-234-B'
GO
EXEC AltaMedicamento 2,'2342342342342','DESCRIPCION MEDICAMENTO 2',15,'MED-234-C'