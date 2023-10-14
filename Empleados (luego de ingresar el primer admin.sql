use BaseDeDatosPtc
go

-- -- Insertar usuarios con contraseñas encriptadas
INSERT INTO Usuario (NombreUsuario, Contraseña, id_Rol)
VALUES
    ('Admin2', '5a63e75a6e7a09f1f2bbded46dd2acae2211c972f09f109c822cd7cc06db0db6', 1), --admin 
    ('Comprador1', '5a63e75a6e7a09f1f2bbded46dd2acae2211c972f09f109c822cd7cc06db0db6', 2), --comprador 
    ('Gcompras', '5a63e75a6e7a09f1f2bbded46dd2acae2211c972f09f109c822cd7cc06db0db6', 3), --Gerente de compras 
    ('EBodega', '5a63e75a6e7a09f1f2bbded46dd2acae2211c972f09f109c822cd7cc06db0db6', 4), --Encargado de bodega 
    ('Vendedor', '5a63e75a6e7a09f1f2bbded46dd2acae2211c972f09f109c822cd7cc06db0db6', 5);--Vendedor 
 

-- Insertar empleados
INSERT INTO Empleado (Nombre, Apellido, Teléfono, DUI, Correo, Cargo, id_Usuario)
VALUES
    ('Juan', 'Pérez', '+503 1234-5678', '12345678-9', 'juan.perez@example.com', 'Gerente General', 2), --admin
    ('Ana', 'Gómez', '+503 9876-5432', '98765432-1', 'ana.gomez@example.com', 'Comprador', 3), --comprador
    ('Carlos', 'López', '+503 5555-5555', '55555555-5', 'carlos.lopez@example.com', 'Comprador', 4), --comprador
    ('Elena', 'Ramírez', '+503 7777-7777', '77777777-7', 'elena.ramirez@example.com', 'Gerente de compras', 5), --Gerente de compras
    ('Pedro', 'Díaz', '+503 8888-8888', '88888888-8', 'pedro.diaz@example.com', 'Encargado de bodega', 6); --Encargado de bodega
use master
go	