	
--Ejecutar LUEGO de insertar el primer usuario en la interfaz de primer uso

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
 
 --contraseña1

-- Insertar empleados
INSERT INTO Empleado (Nombre, Apellido, Teléfono, DUI, Correo, Cargo, id_Usuario)
VALUES
    ('Juan', 'Pérez', '1234-5678', '12345678-9', 'juan.perez@stockgenius.com', 'Gerente General', 2), --admin
    ('Ana', 'Gómez', '9876-5432', '98765432-1', 'ana.gomez@stockgenius.com', 'Comprador', 3), --comprador
    ('Carlos', 'López', '5555-5555', '55555555-5', 'carlos.lopez@stockgenius.com', 'Comprador', 4), --comprador
    ('Elena', 'Ramírez', '7777-7777', '77777777-7', 'elena.ramirez@stockgenius.com', 'Gerente de compras', 5), --Gerente de compras
    ('Pedro', 'Díaz', '8888-8888', '88888888-8', 'pedro.diaz@stockgenius.com', 'Encargado de bodega', 6); --Encargado de bodega
use master
go	
