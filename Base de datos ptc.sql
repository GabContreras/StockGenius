use master 
go

drop database if exists BaseDeDatosPtc
go

create database BaseDeDatosPtc
go

use BaseDeDatosPtc
go

create table Rol(
id_Rol int PRIMARY KEY identity(1,1),
Nombre Varchar(50) not null unique
);
go

Create table Usuario(
Id_Usuario int PRIMARY KEY identity(1,1),
NombreUsuario varchar(30) unique not null, 
contraseña varchar(100) not null,
id_Rol int not null

constraint FK_Rol
FOREIGN KEY (id_Rol) references Rol(id_Rol)
on delete cascade
on update cascade
);
go

create table Empleado(
Id_Empleado int PRIMARY KEY identity(1,1),
Nombre varchar(50) not null,
Apellido varchar(50) not null,
Teléfono varchar(50) not null,
DUI varchar (10) unique not null,
Correo varchar(50)unique not null,
Cargo varchar (50) not null,
id_Usuario int not null,

constraint FK_Usuario
FOREIGN KEY(id_Usuario) references Usuario(id_Usuario)
on delete cascade
on update cascade
);
go

create table proveedor(
Id_Proveedor int PRIMARY KEY identity(1,1),
Nombre varchar(50) not null,
Dirección varchar(150) not null,
Telefono varchar(50) unique not null
);
go

Create table Cliente(
Id_Cliente int PRIMARY KEY identity(1,1),
Nombre varchar(50) , --Nombre de cliente natural o juridico (empresa)
Apellido varchar(50),
DUI varchar (10),
Telefono varchar(50) ,
Dirección varchar(150),
Edad int check (edad>=18),
Tipo_Cliente varchar(8) check(Tipo_Cliente IN ('Natural', 'Jurídico')) not null,
NIT varchar(17) , 
NRC varchar(8) ,  --Numero de registro de contribuyente 569-0 tiene que tener un guion
Giro varchar(100), --A qué se dedica
Categoria varchar(7)  CHECK (Categoria IN ('Pequeño', 'Mediano', 'Grande'))--Pequeño, Mediano, Grande)
);
go

Create table Producto(
Id_Producto int PRIMARY KEY identity(1,1),
Nombre varchar(50) not null unique,
Descripcion varchar(150) not null,
Stock int not null check (Stock>=0),
Id_Proveedor int not null,
Precio_Unitario decimal(10,2) check(Precio_Unitario>0),
imagen nvarchar(max)	
constraint FK_Proveedor
FOREIGN KEY (Id_Proveedor) references Proveedor(Id_Proveedor)
on delete cascade 
on update cascade
);
go

CREATE TABLE Pedido(
    Id_Pedido INT PRIMARY KEY IDENTITY(1, 1),
    Id_Cliente INT, -- Este campo puede ser el Id_Cliente o el Id_ClienteJuridico
    Id_Empleado INT NOT NULL,
    Fecha_Pedido DATE NOT NULL,
    Estado VARCHAR(10) CHECK (Estado IN ('En proceso', 'Completo', 'Anulado')),
    CONSTRAINT FK_Cliente
    FOREIGN KEY (Id_Cliente) REFERENCES Cliente(Id_Cliente)
        ON DELETE NO ACTION
        ON UPDATE CASCADE,
 CONSTRAINT Fk_Empleado
    FOREIGN KEY (Id_Empleado) REFERENCES Empleado(Id_Empleado)
        ON DELETE NO ACTION
        ON UPDATE CASCADE
);


CREATE TABLE Detalle_Pedido (
    Id_Detalle INT PRIMARY KEY IDENTITY(1, 1),
    Id_Pedido INT NOT NULL,
    Id_Producto INT NOT NULL,
    Cantidad INT NOT NULL CHECK(Cantidad > 0)

constraint FK_Pedido
FOREIGN KEY (Id_Pedido) references Pedido(Id_Pedido)
on delete cascade 
on update cascade,
constraint FK_Producto
FOREIGN KEY (Id_Producto) references Producto(Id_Producto)
on delete cascade 
on update cascade,
);

insert into Rol(Nombre)
values ('Administrador'),--ya
('Comprador'),--ya
('Gerente de compras'),--ya
('Encargado de bodega'),--ya
('Vendedor');--ya
go

-- Create a filtered unique index for NIT column
CREATE UNIQUE INDEX UX_NIT_Unique ON Cliente (NIT) WHERE NIT IS NOT NULL;

-- Create a filtered unique index for NRC column
CREATE UNIQUE INDEX UX_NRC_Unique ON Cliente (NRC) WHERE NRC IS NOT NULL;

-- Create a unique index for DUI column
CREATE UNIQUE INDEX UX_DUI_Unique ON Cliente (DUI) where DUI is not null;

-- Insertar proveedores
INSERT INTO Proveedor (Nombre, Dirección, Telefono)
VALUES
    ('ElectroComponentes SA', 'Calle Principal #123', '+503 1111-1112'),
    ('Tecnología Total', 'Avenida Comercial #456', '+503 2222-2222'),
    ('Distribuidora Electrónica', 'Calle Central #789', '+503 3333-3333'),
    ('Comercializadora de Equipos', 'Avenida Industrial #1011', '+503 4444-4444'),
    ('Suministros Electrónicos', 'Calle Mayor #1516', '+503 5555-5555'),
    ('ElectroPro', 'Avenida de la Paz #1718', '+503 6666-6666'),	
    ('Componentes Avanzados', 'Calle del Progreso #1920', '+503 7777-7777'),
    ('ElectroDistribuidora', 'Avenida del Sol #2122', '+503 8888-8888'),
    ('ElectroMundo', 'Calle de la Industria #2324', '+503 9999-9999'),
    ('ElectroInnovación', 'Avenida de la Libertad #2526', '+503 1010-1010'),
    ('Soluciones Electrónicas', 'Calle de la Esperanza #2728', '+503 1111-1113'),
    ('ElectroExpress', 'Avenida de la Victoria #2930', '+503 1212-1212'),
    ('Distribuidora Tecnológica', 'Calle de la Ciencia #3132', '+503 1313-1313'),
    ('Componentes Electrónicos', 'Avenida de la Tecnología #3334', '+503 1414-1414'),
    ('ElectroSalud', 'Calle de la Salud #3536', '+503 1515-1515'),
    ('ElectroHogar', 'Avenida de la Casa #3738', '+503 1616-1616'),
    ('Innovación Electrónica', 'Calle de la Innovación #3940', '+503 1717-1717'),
    ('ElectroMovilidad', 'Avenida de la Movilidad #4142', '+503 1818-1818'),
    ('ElectroBaterías', 'Calle de las Baterías #4344', '+503 1919-1919'),
    ('Distribuidora Solar', 'Avenida Solar #4546', '+503 2020-2020');

-- Insertar productos (hasta alcanzar 20 registros)
INSERT INTO Producto (Nombre, Descripcion, Stock, Id_Proveedor, Precio_Unitario)
VALUES
    ('Smartphone Galaxy S22', 'Potente smartphone con cámara de alta resolución', 100, 1, 699.99),
    ('Laptop Ultrabook X1', 'Laptop ultradelgada con pantalla táctil', 50, 2, 1199.99),
    ('Tablet Android Pro', 'Tablet de alto rendimiento con sistema Android', 75, 1, 299.99),
    ('TV LED 4K 55 pulgadas', 'Televisor con resolución 4K y pantalla LED', 200, 2, 699.99),
    ('Auriculares Inalámbricos X2', 'Auriculares Bluetooth con cancelación de ruido', 150, 1, 149.99),
    ('Cámara DSLR 24MP', 'Cámara réflex digital de alta calidad', 80, 2, 899.99),
    ('Impresora Multifunción', 'Impresora láser multifunción de alta velocidad', 120, 1, 299.99),
    ('Monitor Curvo 27 pulgadas', 'Monitor de computadora con pantalla curva', 60, 2, 349.99),
    ('Teclado Mecánico RGB', 'Teclado para juegos mecánico con retroiluminación', 90, 1, 99.99),
    ('Mouse Gaming G3', 'Mouse ergonómico de alto rendimiento para juegos', 40, 2, 49.99),
    ('Router Wi-Fi 6', 'Router inalámbrico de última generación', 65, 1, 199.99),
    ('Disco Duro Externo 2TB', 'Almacenamiento externo de gran capacidad', 110, 2, 79.99),
    ('Altavoces Bluetooth X5', 'Altavoces inalámbricos con calidad de sonido premium', 30, 1, 149.99),
    ('Smartwatch Fitness Pro', 'Reloj inteligente con seguimiento de actividad física', 85, 2, 129.99),
    ('Tarjeta Gráfica GTX 3080', 'Tarjeta gráfica de alto rendimiento para juegos', 70, 1, 699.99);

insert into Cliente(Nombre, Apellido, DUI, Telefono, Dirección, Edad,Tipo_Cliente) values 
                ('Marcelo josé', 'Hernández Hernández', '12345678-9', '+503 8745-9874', 'Avenida el pepe', 18,'Natural'),
				('Juan Carlos', 'Pérez', '11111111-1', '+503 1111-1111', 'Dirección 1', 25, 'Natural'),
				('Ana María', 'Gómez', '22222222-2', '+503 2222-2222', 'Dirección 2', 30, 'Natural'),
				('Carlos Alberto', 'López', '33333333-3', '+503 3333-3333', 'Dirección 3', 35, 'Natural'),
				('Elena Rodríguez', 'Ramírez', '44444444-4', '+503 4444-4444', 'Dirección 4', 40, 'Natural');

INSERT INTO Cliente (Nombre, Telefono, Dirección, NIT, NRC, Giro, Categoria, Tipo_Cliente) values
    ('Empresa Tech', '+503 2345-6789', 'Calle Principal 123', '12345-678-9', '9876-5', 'Venta de productos electrónicos', 'Mediano', 'Jurídico'),
    ('Consultoría ABC', '+503 555-1234', 'Avenida Central 456', '98765-432-1', '5432-1', 'Servicios de Consultoría Empresarial', 'Grande', 'Jurídico'),
    ('Restaurante delicioso', '+503 7890-1234', 'Boulevard Elegante 789', '56789-123-4', '1234-5', 'Restaurante de comida gourmet', 'Pequeño', 'Jurídico'),
    ('Tienda Express', '+503 7777-7777', 'Plaza Comercial 321', '55555-555-5', '1111-1', 'Venta de ropa y accesorios', 'Pequeño', 'Jurídico'),
    ('Servicios de Limpieza', '+503 8888-8888', 'Calle Limpia 555', '44444-444-4', '2222-2', 'Servicios de Limpieza Residencial', 'Mediano', 'Jurídico');
		

--	-- -- Insertar usuarios con contraseñas encriptadas
--INSERT INTO Usuario (NombreUsuario, Contraseña, id_Rol)
--VALUES
--    ('admin', '5baa61e4c9b93f3f0682250b6cf8331b7ee68fd8', 1), --admin 'contraseña_admin'
--    ('comprador1', '98ebfc6ea518dca0e1171f80c59a9a127d46b91a', 2), --comprador 'contraseña_comprador1'
--    ('comprador2', '065f677d28b66b9712d6bb67db1419f4afba6e34', 2), --comprador 'contraseña_comprador2'
--    ('gerente', '5c8db69325d6e019fd34fe13fb1b324f89a9ab9d', 3), --Gerente de compras 'contraseña_gerente'
--    ('encargado', 'bb8d24c504aacc7c3c5a645940cbe921127d126c0', 4), --Encargado de bodega 'contraseña_encargado'
--    ('vendedor1', 'c2f0f5010321f7a66bb343fb0983eb05e8dd949f', 5), --Vendedor 'contraseña_vendedor1'
--    ('vendedor2', 'cf695fca9e1b453123ae3924eb6c68d62f30f8b0', 5), --Vendedor 'contraseña_vendedor2'
--    ('encargado2', '4f75a4f5475c07c9e74430d11b4b924101e5b7a6', 4); --Encargado de bodega 'encarg2'

---- Insertar empleados
--INSERT INTO Empleado (Nombre, Apellido, Teléfono, DUI, Correo, Cargo, id_Usuario)
--VALUES
--    ('Juan', 'Pérez', '+503 1234-5678', '12345678-9', 'juan.perez@example.com', 'Gerente General', 2), --admin
--    ('Ana', 'Gómez', '+503 9876-5432', '98765432-1', 'ana.gomez@example.com', 'Comprador', 3), --comprador
--    ('Carlos', 'López', '+503 5555-5555', '55555555-5', 'carlos.lopez@example.com', 'Comprador', 4), --comprador
--    ('Elena', 'Ramírez', '+503 7777-7777', '77777777-7', 'elena.ramirez@example.com', 'Gerente de compras', 5), --Gerente de compras
--    ('Pedro', 'Díaz', '+503 8888-8888', '88888888-8', 'pedro.diaz@example.com', 'Encargado de bodega', 6), --Encargado de bodega
--    ('Luis', 'Martínez', '+503 9999-9999', '99999999-9', 'luis.martinez@example.com', 'Vendedor', 7), --Vendedor
--    ('Sofía', 'Torres', '+503 1111-1111', '11111111-1', 'sofia.torres@example.com', 'Vendedor', 8), --Vendedor
--    ('María', 'Fernández', '+503 2222-2222', '22222222-2', 'maria.fernandez@example.com', 'Encargado de bodega', 9); --Encargado de bodega

	
	SELECT DP.Id_Producto,P.Nombre,DP.cantidad,P.Precio_Unitario 
                FROM detalle_pedido DP
                 INNER JOIN Producto P ON DP.Id_Producto = P.Id_Producto
                where Id_Pedido= 1

CREATE TRIGGER CalcularTotalDetallePedido
ON Detalle_Pedido
AFTER INSERT
AS
BEGIN
    -- Actualizar la cantidad en stock de Producto
    UPDATE P
    SET Stock = Stock - DP.Cantidad
    FROM Producto AS P
    INNER JOIN Detalle_Pedido AS DP ON P.Id_Producto = DP.Id_Producto
    INNER JOIN inserted AS I ON DP.Id_Detalle = I.Id_Detalle;
END;

CREATE TRIGGER ActualizarStockDespuesEliminarDetalle
ON Detalle_Pedido
AFTER DELETE
AS
BEGIN
    -- Obtener el Id_Producto y la cantidad eliminada del detalle borrado
    DECLARE @Id_Producto INT;
    DECLARE @CantidadEliminada INT;

    SELECT @Id_Producto = Id_Producto, @CantidadEliminada = cantidad
    FROM deleted;

    -- Actualizar el stock en la tabla Producto sumando la cantidad eliminada
    UPDATE Producto
    SET Stock = Stock + @CantidadEliminada
    WHERE Id_Producto = @Id_Producto;
END;





SELECT DP.ID_Producto, P.nombre, sum(DP.cantidad) as Cantidad,  P.Precio_Unitario
				FROM Detalle_Pedido DP
                inner join producto P on P.id_Producto = DP.id_Producto
                where id_pedido = 1
                group by P.nombre, DP.id_producto,DP.Id_Pedido, P.Precio_Unitario

				select * from Cliente

SELECT DP.id_Detalle,DP.Id_Pedido,DP.Id_Producto,P.Nombre AS Producto,DP.cantidad,P.PrecioUnitario as Precio
                FROM detalle_pedido DP
                INNER JOIN Producto P ON DP.Id_Producto = P.Id_Producto
                where P.Nombre like '%Tecl%'

SELECT DP.Id_Detalle,DP.Id_Pedido,DP.Id_Producto,P.Nombre AS Producto,DP.cantidad,P.Precio_Unitario as Precio
                FROM Detalle_Pedido DP
                INNER JOIN Producto P ON DP.Id_Producto = P.Id_Producto
                where dp.Id_Pedido= 1

				select * from detalle_pedido
				select * from producto

SELECT P.Id_Pedido, C.Nombre AS Cliente, E.Nombre AS Empleado, P.Fecha_Pedido as Fecha, p.Estado, C.Tipo_Cliente as "Tipo De Cliente"
                FROM Pedido P
                INNER JOIN Cliente C ON P.Id_Cliente = C.Id_Cliente
                INNER JOIN Empleado E ON P.Id_Empleado = E.Id_Empleado;