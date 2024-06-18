-- Eliminar la base de datos si existe
IF EXISTS (SELECT * FROM sys.databases WHERE name = 'MiBaseDeDatos')
BEGIN
    DROP DATABASE MiBaseDeDatos;
END
GO

-- Crear la base de datos
CREATE DATABASE MiBaseDeDatos;
GO

-- Seleccionar la base de datos
USE MiBaseDeDatos;
GO

-- Crear la tabla Company con los nuevos campos
CREATE TABLE Company (
    IdCompany INT IDENTITY(1,1) PRIMARY KEY,
    Name VARCHAR(100) NOT NULL,
    Telephone VARCHAR(15),
    EmailCompany VARCHAR(100),
    Externa BIT NOT NULL DEFAULT 0,
    WebCompany VARCHAR(255)
);
GO

-- Crear la tabla Zone
CREATE TABLE Zone (
    IdZone INT IDENTITY(1,1) PRIMARY KEY,
    DesZone VARCHAR(100) NOT NULL
);
GO

-- Crear la tabla ProductionLine
CREATE TABLE ProductionLine (
    IdLine INT IDENTITY(1,1) PRIMARY KEY,
    DesLine VARCHAR(255) NOT NULL
);
GO

-- Crear la tabla Active
CREATE TABLE Active (
    IdActive INT PRIMARY KEY,
    IdLine INT NOT NULL,
    IdZone INT NOT NULL,
    DesActive NVARCHAR(255) NOT NULL,
    ImageActive NVARCHAR(255),
    FOREIGN KEY (IdLine) REFERENCES ProductionLine(IdLine),
    FOREIGN KEY (IdZone) REFERENCES Zone(IdZone)
);
GO

-- Crear la tabla Belt
CREATE TABLE Belt (
    IdBelt INT IDENTITY(1,1) PRIMARY KEY,
    NameBelt VARCHAR(255) NOT NULL,
    DataSheet VARCHAR(255),
    Certificate VARCHAR(255)
);
GO

-- Crear la tabla BeltAssignment
CREATE TABLE BeltAssignment (
    IdAssignment INT IDENTITY(1,1) PRIMARY KEY,
    IdLine INT NOT NULL,
    IdZone INT NOT NULL,
    IdBelt INT NOT NULL,
    FOREIGN KEY (IdLine) REFERENCES ProductionLine(IdLine),
    FOREIGN KEY (IdZone) REFERENCES Zone(IdZone),
    FOREIGN KEY (IdBelt) REFERENCES Belt(IdBelt)
);
GO

-- Crear la tabla Commercial
CREATE TABLE Commercial (
    IdCommercial INT IDENTITY(1,1) PRIMARY KEY,
    IdCompany INT NOT NULL,
    Name VARCHAR(100) NOT NULL,
    Surname VARCHAR(100) NOT NULL,
    Telephone VARCHAR(15),
    Email VARCHAR(100),
    FOREIGN KEY (IdCompany) REFERENCES Company(IdCompany)
);
GO

-- Crear la tabla ContactPerson
CREATE TABLE ContactPerson (
    IdContactPerson INT IDENTITY(1,1) PRIMARY KEY,
    IdCompany INT NOT NULL,
    Name VARCHAR(100) NOT NULL,
    Surname VARCHAR(100) NOT NULL,
    Telephone VARCHAR(15),
    Email VARCHAR(100),
    FOREIGN KEY (IdCompany) REFERENCES Company(IdCompany)
);
GO

-- Crear la tabla Product con el nuevo campo FechaLote
CREATE TABLE Product (
    IdProduct INT IDENTITY(1,1) PRIMARY KEY,
    IdLine INT NOT NULL,
    DesProduct VARCHAR(255) NOT NULL,
    FechaLote DATE NOT NULL,
    FOREIGN KEY (IdLine) REFERENCES ProductionLine(IdLine)
);
GO

-- Crear la tabla Assembler
CREATE TABLE Assembler (
    IdAssembler INT IDENTITY(1,1) PRIMARY KEY,
    IdCompany INT NOT NULL,
    Name VARCHAR(100) NOT NULL,
    Surname VARCHAR(100) NOT NULL,
    Telephone VARCHAR(15),
    Email VARCHAR(100),
    FOREIGN KEY (IdCompany) REFERENCES Company(IdCompany)
);
GO

-- Crear la tabla User
CREATE TABLE [User] (
    IdUser INT IDENTITY(1,1) PRIMARY KEY,
    IdCompany INT NOT NULL,
    Name VARCHAR(100) NOT NULL,
    Surname VARCHAR(100) NOT NULL,
    Telephone VARCHAR(15),
    Email VARCHAR(100),
    FOREIGN KEY (IdCompany) REFERENCES Company(IdCompany)
);
GO

CREATE TABLE ConveyorBeltsByAsset (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name VARCHAR(100) NOT NULL,
    IdActive INT NOT NULL,
    IdBelt INT NOT NULL,
    Longitude INT NOT NULL,
    Wide INT NOT NULL,
    Closed BIT NOT NULL,
    FOREIGN KEY (idActive) REFERENCES Active(idActive),
    FOREIGN KEY (idBelt) REFERENCES Belt(idBelt)
);
GO

-- Insertar datos en la tabla Zone
INSERT INTO Zone (DesZone) VALUES ('Envasado');
INSERT INTO Zone (DesZone) VALUES ('Entre túneles');
INSERT INTO Zone (DesZone) VALUES ('Formado');
GO

-- Insertar datos en la tabla Company
INSERT INTO Company (Name, Telephone, EmailCompany, Externa, WebCompany) VALUES ('Monbake', '645978312', 'contacto@monbake.com', 0, 'www.monbake.com');
INSERT INTO Company (Name, Telephone, EmailCompany, Externa, WebCompany) VALUES ('Bankor System', '684513759', 'contacto@bankorsystem.com', 1, 'www.bankorsystem.com');
GO

-- Insertar datos en la tabla ProductionLine
INSERT INTO ProductionLine (DesLine) VALUES ('Línea 1');
INSERT INTO ProductionLine (DesLine) VALUES ('Línea 2');
GO

-- Insertar datos en la tabla Active
INSERT INTO Active (IdActive, IdLine, IdZone, DesActive, ImageActive)
VALUES (1001, 1, 1, 'Descripción 1', 'Activos/Banda Transporte_01.jpg');
INSERT INTO Active (IdActive, IdLine, IdZone, DesActive, ImageActive)
VALUES (1002, 1, 2, 'Descripción 2', 'Activos/Banda Transporte_02.jpg');
INSERT INTO Active (IdActive, IdLine, IdZone, DesActive, ImageActive)
VALUES (1003, 1, 3, 'Descripción 3', 'Activos/Banda Transporte_03.jpg');
INSERT INTO Active (IdActive, IdLine, IdZone, DesActive, ImageActive)
VALUES (1004, 2, 1, 'Descripción 4', 'Activos/Banda Transporte_04.jpg');
INSERT INTO Active (IdActive, IdLine, IdZone, DesActive, ImageActive)
VALUES (1005, 2, 1, 'Descripción 5', 'Activos/Banda Transporte_05.jpg');
GO

-- Insertar datos en la tabla Belt
INSERT INTO Belt (NameBelt, DataSheet, Certificate)
VALUES ('2 PUR X20 CWT', 'Ficha Técnica 1', 'Certificado 1');
INSERT INTO Belt (NameBelt, DataSheet, Certificate)
VALUES ('3 PUR X30 CWT', 'Ficha Técnica 2', 'Certificado 2');
INSERT INTO Belt (NameBelt, DataSheet, Certificate)
VALUES ('4 PUR X40 CWT', 'Ficha Técnica 3', 'Certificado 3');
GO

-- Insertar datos en la tabla Commercial
INSERT INTO Commercial (IdCompany, Name, Surname, Telephone, Email)
VALUES (2, 'John', 'Doe', '123456789', 'john.doe@bankorsystem.com');
INSERT INTO Commercial (IdCompany, Name, Surname, Telephone, Email)
VALUES (2, 'Jane', 'Smith', '987654321', 'jane.smith@bankorsystem.com');
GO

-- Insertar datos en la tabla ContactPerson
INSERT INTO ContactPerson (IdCompany, Name, Surname, Telephone, Email)
VALUES (2, 'Mike', 'Johnson', '654987321', 'mike.johnson@bankorsystem.com');
INSERT INTO ContactPerson (IdCompany, Name, Surname, Telephone, Email)
VALUES (2, 'Sara', 'Williams', '321654987', 'sara.williams@bankorsystem.com');
GO

-- Insertar datos en la tabla Product
-- Línea 1: Ensaimadas
INSERT INTO Product (IdLine, DesProduct, FechaLote) VALUES (1, 'Ensaimada Normal', '2023-01-01');
INSERT INTO Product (IdLine, DesProduct, FechaLote) VALUES (1, 'Ensaimada Fermentada', '2023-01-01');
INSERT INTO Product (IdLine, DesProduct, FechaLote) VALUES (1, 'Ensaimada de Cabello de Angel', '2023-01-01');
INSERT INTO Product (IdLine, DesProduct, FechaLote) VALUES (1, 'Ensaimada de Crema', '2023-01-01');
-- Línea 1: Empanillas
INSERT INTO Product (IdLine, DesProduct, FechaLote) VALUES (1, 'Empanilla de Pisto', '2023-01-01');
INSERT INTO Product (IdLine, DesProduct, FechaLote) VALUES (1, 'Empanilla de Curry', '2023-01-01');
INSERT INTO Product (IdLine, DesProduct, FechaLote) VALUES (1, 'Empanilla Criolla', '2023-01-01');
-- Línea 2: Cruasanes
INSERT INTO Product (IdLine, DesProduct, FechaLote) VALUES (2, 'Cruasan Normal', '2023-01-01');
INSERT INTO Product (IdLine, DesProduct, FechaLote) VALUES (2, 'Cruasan de Chocolate', '2023-01-01');
-- Línea 2: Lacitos
INSERT INTO Product (IdLine, DesProduct, FechaLote) VALUES (2, 'Lacitos', '2023-01-01');
GO

-- Insertar datos en la tabla BeltAssignment
-- Línea 1: Asignación de Cintas
INSERT INTO BeltAssignment (IdLine, IdZone, IdBelt) VALUES (1, 1, 1);
INSERT INTO BeltAssignment (IdLine, IdZone, IdBelt) VALUES (1, 2, 2);
INSERT INTO BeltAssignment (IdLine, IdZone, IdBelt) VALUES (1, 3, 3);
-- Línea 2: Asignación de Cintas
INSERT INTO BeltAssignment (IdLine, IdZone, IdBelt) VALUES (2, 1, 1);
INSERT INTO BeltAssignment (IdLine, IdZone, IdBelt) VALUES (2, 2, 2);
INSERT INTO BeltAssignment (IdLine, IdZone, IdBelt) VALUES (2, 3, 3);
GO

-- Insertar datos en la tabla Assembler
INSERT INTO Assembler (IdCompany, Name, Surname, Telephone, Email)
VALUES (1, 'Alex', 'Brown', '123123123', 'alex.brown@monbake.com');
INSERT INTO Assembler (IdCompany, Name, Surname, Telephone, Email)
VALUES (2, 'Chris', 'Green', '456456456', 'chris.green@bankorsystem.com');
GO

-- Insertar datos en la tabla User
INSERT INTO [User] (IdCompany, Name, Surname, Telephone, Email)
VALUES (1, 'Sam', 'White', '789789789', 'sam.white@monbake.com');
INSERT INTO [User] (IdCompany, Name, Surname, Telephone, Email)
VALUES (1, 'Taylor', 'Blue', '321321321', 'taylor.blue@monbake.com');
GO

-- Crear triggers para las restricciones de negocio

-- Trigger para validar que Commercial solo pertenece a empresas externas
CREATE TRIGGER trg_CheckCommercialCompany
ON Commercial
AFTER INSERT, UPDATE
AS
BEGIN
    IF EXISTS (
        SELECT 1
        FROM inserted i
        JOIN Company c ON i.IdCompany = c.IdCompany
        WHERE c.Externa = 0
    )
    BEGIN
        RAISERROR ('Commercial debe pertenecer a una empresa externa.', 16, 1);
        ROLLBACK TRANSACTION;
    END
END
GO

-- Trigger para validar que ContactPerson solo pertenece a empresas externas
CREATE TRIGGER trg_CheckContactPersonCompany
ON ContactPerson
AFTER INSERT, UPDATE
AS
BEGIN
    IF EXISTS (
        SELECT 1
        FROM inserted i
        JOIN Company c ON i.IdCompany = c.IdCompany
        WHERE c.Externa = 0
    )
    BEGIN
        RAISERROR ('ContactPerson debe pertenecer a una empresa externa.', 16, 1);
        ROLLBACK TRANSACTION;
    END
END
GO

-- Trigger para validar que Assembler pertenece a empresas externas o Monbake
CREATE TRIGGER trg_CheckAssemblerCompany
ON Assembler
AFTER INSERT, UPDATE
AS
BEGIN
    IF EXISTS (
        SELECT 1
        FROM inserted i
        JOIN Company c ON i.IdCompany = c.IdCompany
        WHERE c.Externa = 0 AND c.Name <> 'Monbake'
    )
    BEGIN
        RAISERROR ('Assembler debe pertenecer a una empresa externa o Monbake.', 16, 1);
        ROLLBACK TRANSACTION;
    END
END
GO

-- Trigger para validar que User solo pertenece a Monbake
CREATE TRIGGER trg_CheckUserCompany
ON [User]
AFTER INSERT, UPDATE
AS
BEGIN
    IF EXISTS (
        SELECT 1
        FROM inserted i
        JOIN Company c ON i.IdCompany = c.IdCompany
        WHERE c.Name <> 'Monbake'
    )
    BEGIN
        RAISERROR ('User debe pertenecer a Monbake.', 16, 1);
        ROLLBACK TRANSACTION;
    END
END
GO


