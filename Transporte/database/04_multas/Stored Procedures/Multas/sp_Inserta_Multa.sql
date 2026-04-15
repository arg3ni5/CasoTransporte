-- PROCEDIMIENTO ALMACENADO PARA EL REGISTRO DE NUEVAS MULTAS
CREATE PROC sp_Inserta_Multa
(
@IdVehiculo int,
@IdTipoMulta int, 
@Fecha datetime,
@MontoAplicado decimal(10, 2),
@Pagada bit
)
AS
BEGIN
	INSERT INTO Multas (IdVehiculo, IdTipoMulta, Fecha, MontoAplicado, Pagada)
	VALUES (@IdVehiculo, @IdTipoMulta, @Fecha, @MontoAplicado, @Pagada)
END