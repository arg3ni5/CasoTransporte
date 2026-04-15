-- PROCEDIMIENTO ALMACENADO PARA LA MODIFICACIÓN DE LAS MULTAS
CREATE PROC sp_Modifica_Multa
(
@IdMulta int,
@IdVehiculo int,
@IdTipoMulta int, 
@Fecha datetime,
@MontoAplicado decimal(10, 2),
@Pagada bit
)
AS
BEGIN
	UPDATE Multas
	SET IdVehiculo = @IdVehiculo, IdTipoMulta = @IdTipoMulta, Fecha = @Fecha, MontoAplicado = @MontoAplicado, Pagada = @Pagada
	WHERE IdMulta = @IdMulta
END