USE TransporteDB;
GO

/* Catalog seed */
IF NOT EXISTS (SELECT 1 FROM dbo.TipoMulta WHERE Descripcion = 'Mal estacionado')
  INSERT dbo.TipoMulta (Descripcion, MontoBase, Activa) VALUES ('Mal estacionado', 15000, 1);

IF NOT EXISTS (SELECT 1 FROM dbo.TipoMulta WHERE Descripcion = 'Exceso de velocidad')
  INSERT dbo.TipoMulta (Descripcion, MontoBase, Activa) VALUES ('Exceso de velocidad', 25000, 1);

/* Multas seed (TEMP: without vehicle) */
DECLARE @IdTipo1 INT = (SELECT TOP 1 IdTipoMulta FROM dbo.TipoMulta WHERE Descripcion = 'Mal estacionado');
IF @IdTipo1 IS NOT NULL AND NOT EXISTS (SELECT 1 FROM dbo.Multas WHERE IdTipoMulta = @IdTipo1 AND Fecha >= '2026-01-01')
  INSERT dbo.Multas (IdVehiculo, IdTipoMulta, Fecha, MontoAplicado, Pagada)
  VALUES (NULL, @IdTipo1, GETDATE(), 15000, 0);
GO