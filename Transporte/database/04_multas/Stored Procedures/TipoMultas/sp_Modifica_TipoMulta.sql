-- PROCEDIMIENTO ALMACENADO PARA LA MODIFICACIÓN DE LOS DATOS DEL TIPO DE MULTA INDICADO
CREATE PROC sp_Modifica_TipoMulta
(
@IdTipoMulta int,
@Descripcion varchar(150),
@MontoBase decimal(10, 2),
@Activa bit
)
AS
BEGIN
	UPDATE TipoMulta
	SET Descripcion = @Descripcion, MontoBase = @MontoBase, Activa = @Activa
	WHERE IdTipoMulta = @IdTipoMulta
END