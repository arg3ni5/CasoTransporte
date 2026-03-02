USE TransporteDB;
GO

IF OBJECT_ID('dbo.Vehiculos', 'U') IS NULL
BEGIN
  CREATE TABLE dbo.Vehiculos (
    IdVehiculo INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    Placa NVARCHAR(20) NOT NULL,
    Marca NVARCHAR(50) NOT NULL,
    Modelo NVARCHAR(50) NOT NULL,
    IdPropietario INT NOT NULL, -- references Propietarios.IdPersona

    CONSTRAINT FK_Vehiculos_Propietarios
      FOREIGN KEY (IdPropietario) REFERENCES dbo.Propietarios(IdPersona)
  );

  CREATE UNIQUE INDEX UX_Vehiculos_Placa ON dbo.Vehiculos(Placa);
END
GO