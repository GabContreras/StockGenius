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
contrase�a varchar(100) not null,
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
Tel�fono varchar(50) not null,
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
Direcci�n varchar(150) not null,
Telefono varchar(50) unique not null
);
go

Create table Cliente(
Id_Cliente int PRIMARY KEY identity(1,1),
Nombre varchar(50) , --Nombre de cliente natural o juridico (empresa)
Apellido varchar(50),
DUI varchar (10),
Telefono varchar(50) ,
Direcci�n varchar(150),
Edad int check (edad>=18),
Tipo_Cliente varchar(8) check(Tipo_Cliente IN ('Natural', 'Jur�dico')) not null,
NIT varchar(17) , 
NRC varchar(8) ,  --Numero de registro de contribuyente 569-0 tiene que tener un guion
Giro varchar(100), --A qu� se dedica
Categoria varchar(7)  CHECK (Categoria IN ('Peque�o', 'Mediano', 'Grande'))--Peque�o, Mediano, Grande)
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
INSERT INTO Proveedor (Nombre, Direcci�n, Telefono)
VALUES
    ('ElectroComponentes SA', 'Calle Principal #123', '+503 1111-1112'),
    ('Tecnolog�a Total', 'Avenida Comercial #456', '+503 2222-2222'),
    ('Distribuidora Electr�nica', 'Calle Central #789', '+503 3333-3333'),
    ('Comercializadora de Equipos', 'Avenida Industrial #1011', '+503 4444-4444'),
    ('Suministros Electr�nicos', 'Calle Mayor #1516', '+503 5555-5555'),
    ('ElectroPro', 'Avenida de la Paz #1718', '+503 6666-6666'),	
    ('Componentes Avanzados', 'Calle del Progreso #1920', '+503 7777-7777'),
    ('ElectroDistribuidora', 'Avenida del Sol #2122', '+503 8888-8888'),
    ('ElectroMundo', 'Calle de la Industria #2324', '+503 9999-9999'),
    ('ElectroInnovaci�n', 'Avenida de la Libertad #2526', '+503 1010-1010'),
    ('Soluciones Electr�nicas', 'Calle de la Esperanza #2728', '+503 1111-1113'),
    ('ElectroExpress', 'Avenida de la Victoria #2930', '+503 1212-1212'),
    ('Distribuidora Tecnol�gica', 'Calle de la Ciencia #3132', '+503 1313-1313'),
    ('Componentes Electr�nicos', 'Avenida de la Tecnolog�a #3334', '+503 1414-1414'),
    ('ElectroSalud', 'Calle de la Salud #3536', '+503 1515-1515'),
    ('ElectroHogar', 'Avenida de la Casa #3738', '+503 1616-1616'),
    ('Innovaci�n Electr�nica', 'Calle de la Innovaci�n #3940', '+503 1717-1717'),
    ('ElectroMovilidad', 'Avenida de la Movilidad #4142', '+503 1818-1818'),
    ('ElectroBater�as', 'Calle de las Bater�as #4344', '+503 1919-1919'),
    ('Distribuidora Solar', 'Avenida Solar #4546', '+503 2020-2020');

-- Insertar productos (hasta alcanzar 20 registros)
INSERT INTO Producto (Nombre, Descripcion, Stock, Id_Proveedor, Precio_Unitario, Imagen)
VALUES
    ('Smartphone Galaxy S22', 'Potente smartphone con c�mara de alta resoluci�n', 100, 1, 699.99, 'galaxy_s22.jpg'),
    ('Laptop Ultrabook X1', 'Laptop ultradelgada con pantalla t�ctil', 50, 2, 1199.99, 'ultrabook_x1.jpg'),
    ('Tablet Android Pro', 'Tablet de alto rendimiento con sistema Android', 75, 1, 299.99, 'tablet_android_pro.jpg'),
    ('TV LED 4K 55 pulgadas', 'Televisor con resoluci�n 4K y pantalla LED', 200, 2, 699.99, 'tv_led_4k.jpg'),
    ('Auriculares Inal�mbricos X2', 'Auriculares Bluetooth con cancelaci�n de ruido', 150, 1, 149.99, 'auriculares_x2.jpg'),
    ('C�mara DSLR 24MP', 'C�mara r�flex digital de alta calidad', 80, 2, 899.99, 'camara_dslr_24mp.jpg'),
    ('Impresora Multifunci�n', 'Impresora l�ser multifunci�n de alta velocidad', 120, 1, 299.99, 'impresora_multifuncion.jpg'),
    ('Monitor Curvo 27 pulgadas', 'Monitor de computadora con pantalla curva', 60, 2, 349.99, 'monitor_curvo_27.jpg'),
    ('Teclado Mec�nico RGB', 'Teclado para juegos mec�nico con retroiluminaci�n', 90, 1, 99.99, 'teclado_mecanico_rgb.jpg'),
    ('Mouse Gaming G3', 'Mouse ergon�mico de alto rendimiento para juegos', 40, 2, 49.99, 'mouse_gaming_g3.jpg'),
    ('Router Wi-Fi 6', 'Router inal�mbrico de �ltima generaci�n', 65, 1, 199.99, 'router_wifi_6.jpg'),
    ('Disco Duro Externo 2TB', 'Almacenamiento externo de gran capacidad', 110, 2, 79.99, 'disco_duro_externo_2tb.jpg'),
    ('Altavoces Bluetooth X5', 'Altavoces inal�mbricos con calidad de sonido premium', 30, 1, 149.99, 'altavoces_x5.jpg'),
    ('Smartwatch Fitness Pro', 'Reloj inteligente con seguimiento de actividad f�sica', 85, 2, 129.99, 'smartwatch_fitness_pro.jpg'),
    ('Tarjeta Gr�fica GTX 3080', 'Tarjeta gr�fica de alto rendimiento para juegos', 70, 1, 699.99, 'tarjeta_grafica_gtx_3080.jpg');

insert into Cliente(Nombre, Apellido, DUI, Telefono, Direcci�n, Edad,Tipo_Cliente) values 
                ('Marcelo jos�', 'Hern�ndez Hern�ndez', '12345678-9', '+503 8745-9874', 'Avenida el pepe', 18,'Natural'),
				('Juan Carlos', 'P�rez', '11111111-1', '+503 1111-1111', 'Direcci�n 1', 25, 'Natural'),
				('Ana Mar�a', 'G�mez', '22222222-2', '+503 2222-2222', 'Direcci�n 2', 30, 'Natural'),
				('Carlos Alberto', 'L�pez', '33333333-3', '+503 3333-3333', 'Direcci�n 3', 35, 'Natural'),
				('Elena Rodr�guez', 'Ram�rez', '44444444-4', '+503 4444-4444', 'Direcci�n 4', 40, 'Natural');

INSERT INTO Cliente (Nombre, Telefono, Direcci�n, NIT, NRC, Giro, Categoria, Tipo_Cliente) values
    ('Empresa Tech', '+503 2345-6789', 'Calle Principal 123', '12345-678-9', '9876-5', 'Venta de productos electr�nicos', 'Mediano', 'Jur�dico'),
    ('Consultor�a ABC', '+503 555-1234', 'Avenida Central 456', '98765-432-1', '5432-1', 'Servicios de Consultor�a Empresarial', 'Grande', 'Jur�dico'),
    ('Restaurante delicioso', '+503 7890-1234', 'Boulevard Elegante 789', '56789-123-4', '1234-5', 'Restaurante de comida gourmet', 'Peque�o', 'Jur�dico'),
    ('Tienda Express', '+503 7777-7777', 'Plaza Comercial 321', '55555-555-5', '1111-1', 'Venta de ropa y accesorios', 'Peque�o', 'Jur�dico'),
    ('Servicios de Limpieza', '+503 8888-8888', 'Calle Limpia 555', '44444-444-4', '2222-2', 'Servicios de Limpieza Residencial', 'Mediano', 'Jur�dico');
		
-- Insertar usuarios
INSERT INTO Usuario (NombreUsuario, Contrase�a, id_Rol)
VALUES
    ('admin', 'contrase�a_admin', 1),
    ('comprador1', 'contrase�a_comprador1', 2),
    ('comprador2', 'contrase�a_comprador2', 2),
    ('gerente', 'contrase�a_gerente', 3),
    ('encargado', 'contrase�a_encargado', 4),
    ('vendedor1', 'contrase�a_vendedor1', 5),
    ('vendedor2', 'contrase�a_vendedor2', 5),
    ('user1', 'user1pass', 2),
    ('user2', 'user2pass', 2),
    ('user3', 'user3pass', 2);

	-- Insertar empleados
INSERT INTO Empleado (Nombre, Apellido, Tel�fono, DUI, Correo, Cargo, id_Usuario)
VALUES
    ('Juan', 'P�rez', '+503 1234-5678', '12345678-9', 'juan.perez@example.com', 'Gerente', 1),
    ('Ana', 'G�mez', '+503 9876-5432', '98765432-1', 'ana.gomez@example.com', 'Comprador', 2),
    ('Carlos', 'L�pez', '+503 5555-5555', '55555555-5', 'carlos.lopez@example.com', 'Encargado de Bodega', 4),
    ('Elena', 'Ram�rez', '+503 7777-7777', '77777777-7', 'elena.ramirez@example.com', 'Vendedor', 6),
    ('Pedro', 'D�az', '+503 8888-8888', '88888888-8', 'pedro.diaz@example.com', 'Vendedor', 7),
    ('Luis', 'Mart�nez', '+503 9999-9999', '99999999-9', 'luis.martinez@example.com', 'Vendedor', 8),
    ('Sof�a', 'Torres', '+503 1111-1111', '11111111-1', 'sofia.torres@example.com', 'Vendedor', 9),
    ('Mar�a', 'Fern�ndez', '+503 2222-2222', '22222222-2', 'maria.fernandez@example.com', 'Vendedor', 10),
    ('David', 'Garc�a', '+503 3333-3333', '33333333-3', 'david.garcia@example.com', 'Vendedor', 11),
    ('Laura', 'Gonz�lez', '+503 4444-4444', '44444444-4', 'laura.gonzalez@example.com', 'Vendedor', 12);

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





SELECT DP.ID_Producto as "Id Producto",DP.Id_Pedido as Pedido, P.nombre as Producto, sum(DP.cantidad) as Cantidad 
FROM Detalle_Pedido DP
inner join producto P on P.id_Producto = DP.id_Producto
where id_pedido = 1
group by P.nombre, DP.id_producto,DP.Id_Pedido


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