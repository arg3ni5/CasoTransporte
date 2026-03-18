-- PROCEDIMIENTO ALMACENADO PARA EL REGISTRO DE NUEVOS TIPOS DE MULTAS
CREATE PROC sp_Inserta_TipoMulta
(
@Descripcion varchar(150),
@MontoBase decimal(10, 2),
@Activa bit
)
AS
BEGIN
	INSERT INTO TipoMulta (Descripcion, MontoBase, Activa)
	VALUES (@Descripcion, @MontoBase, @Activa)
END