use BaseDeDatosPtc 
go

CREATE TRIGGER AgregarStockSiPedidoAnulado
ON Pedido
AFTER UPDATE
AS
BEGIN
    -- Verificar si el estado del pedido se ha cambiado a 'Anulado'
    IF UPDATE(Estado) AND (SELECT Estado FROM inserted) = 'Anulado'
    BEGIN
        -- Obtener el Id del pedido anulado
        DECLARE @PedidoId INT;
        SELECT @PedidoId = Id_Pedido FROM inserted;

        -- Calcular la suma de la cantidad total del pedido anulado
        DECLARE @TotalCantidad INT;
        SELECT @TotalCantidad = DP.Cantidad
        FROM Detalle_Pedido DP
        WHERE DP.Id_Pedido = @PedidoId;

        -- Incrementar el stock de los productos en el pedido anulado
        UPDATE Producto
        SET Stock = Stock + @TotalCantidad
        WHERE Id_Producto IN (
            SELECT DP.Id_Producto
            FROM Detalle_Pedido DP
            WHERE DP.Id_Pedido = @PedidoId
        );
    END
END;
go
use master
go