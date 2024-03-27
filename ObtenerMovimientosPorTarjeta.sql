CREATE PROCEDURE ObtenerMovimientosPorTarjeta
    @NumeroTarjeta VARCHAR(16)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT *
    FROM Movimientos
    WHERE NumeroTarjeta = @NumeroTarjeta;
END;
