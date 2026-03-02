USE TransporteDB;
GO

DECLARE @IdJuan INT = (SELECT TOP 1 IdPersona FROM dbo.Personas WHERE Identificacion = '1-1111-1111');
DECLARE @IdMaria INT = (SELECT TOP 1 IdPersona FROM dbo.Personas WHERE Identificacion = '2-2222-2222');

IF @IdJuan IS NOT NULL AND NOT EXISTS (SELECT 1 FROM dbo.Vehiculos WHERE Placa = 'ABC-123')
  INSERT dbo.Vehiculos (Placa, Marca, Modelo, IdPropietario)
  VALUES ('ABC-123', 'Toyota', 'Corolla', @IdJuan);

IF @IdMaria IS NOT NULL AND NOT EXISTS (SELECT 1 FROM dbo.Vehiculos WHERE Placa = 'XYZ-789')
  INSERT dbo.Vehiculos (Placa, Marca, Modelo, IdPropietario)
  VALUES ('XYZ-789', 'Hyundai', 'Accent', @IdMaria);
GO