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
        SELECT @PedidoId = Id_Pedido
		FROM inserted;

        -- Incrementar el stock de los productos en el pedido anulado
        UPDATE Producto
        SET Stock = Stock +(select sum(DP.cantidad) 
		from Detalle_Pedido DP 
		where DP.id_pedido= @PedidoId
		AND DP.id_producto= Producto.Id_Producto
		)
		where Id_Producto IN (select DP.id_Producto
		from Detalle_Pedido DP 
		where DP.Id_Pedido= @PedidoId);
    END
END;
go
use master
go