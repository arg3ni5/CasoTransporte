USE TransporteDB;
GO

/* Make some Personas owners (idempotent via PK IdPersona) */
DECLARE @IdJuan INT = (SELECT TOP 1 IdPersona FROM dbo.Personas WHERE Identificacion = '1-1111-1111');
DECLARE @IdMaria INT = (SELECT TOP 1 IdPersona FROM dbo.Personas WHERE Identificacion = '2-2222-2222');

IF @IdJuan IS NOT NULL AND NOT EXISTS (SELECT 1 FROM dbo.Propietarios WHERE IdPersona = @IdJuan)
  INSERT dbo.Propietarios (IdPersona, Telefono, Direccion)
  VALUES (@IdJuan, '8888-1111', 'San Jose');

IF @IdMaria IS NOT NULL AND NOT EXISTS (SELECT 1 FROM dbo.Propietarios WHERE IdPersona = @IdMaria)
  INSERT dbo.Propietarios (IdPersona, Telefono, Direccion)
  VALUES (@IdMaria, '8888-2222', 'Heredia');
GO