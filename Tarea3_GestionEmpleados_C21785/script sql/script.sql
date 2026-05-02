CREATE DATABASE GestionEmpleados;
GO

USE GestionEmpleados;
GO

CREATE TABLE Empleados (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(80) NOT NULL,
    Apellidos NVARCHAR(100) NOT NULL,
    Departamento NVARCHAR(50) NOT NULL,
    Salario DECIMAL(18,2) NOT NULL,
    FechaIngreso DATETIME NOT NULL,
    Activo BIT NOT NULL
);