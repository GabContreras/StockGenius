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
Teléfono varchar(50) unique not null,
DUI varchar (9) unique not null,
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
Nombre varchar(50) not null,
Apellido varchar(50) not null,
DUI varchar (9) unique not null,
Telefono varchar(50) unique not null,
Dirección varchar(150) not null,
Edad int check (edad>=21)
);
go

Create table Producto(
Id_Producto int PRIMARY KEY identity(1,1),
Nombre varchar(50) not null unique,
Descripcion varchar(150) not null,
Stock int not null check (Stock>=0),
Id_Proveedor int not null,
PrecioUnitario decimal(10,2) check(PrecioUnitario>0),

constraint FK_Proveedor
FOREIGN KEY (Id_Proveedor) references Proveedor(Id_Proveedor)
on delete cascade 
on update cascade
);
go

Create table Pedido(
Id_Pedido int PRIMARY KEY identity(1,1),
Id_Cliente int not null,
Id_Empleado int not null,
Fecha_Pedido Date not null,

constraint FK_Cliente 
FOREIGN KEY (Id_Cliente) references Cliente(Id_Cliente)
on delete cascade 
on update cascade,
constraint FK_Empleado
FOREIGN KEY (Id_Empleado) references Empleado(Id_Empleado)
on delete cascade 
on update cascade
);
go

CREATE TABLE Detalle_Pedido (
    Id_Detalle INT PRIMARY KEY IDENTITY(1, 1),
    Id_Pedido INT NOT NULL,
    Id_Producto INT NOT NULL,
    Cantidad INT NOT NULL CHECK(Cantidad > 0),
    Total DECIMAL(10, 2) 

constraint FK_Pedido
FOREIGN KEY (Id_Pedido) references Pedido(Id_Pedido)
on delete cascade 
on update cascade,
constraint FK_Producto
FOREIGN KEY (Id_Producto) references Producto(Id_Producto)
on delete cascade 
on update cascade,
);


create table Factura(
Id_Factura int PRIMARY KEY identity(1,1),
Id_Pedido int not null,
TotalFinal decimal(10,2) not null check (TotalFinal>0),

constraint FK_Pedidos
FOREIGN KEY (Id_Pedido) references Pedido(Id_Pedido)
on delete cascade 
on update cascade
);
go
insert into Rol(Nombre)
values ('Administrador'),
('Gerente General'),
('Vendedor'),
('Técnico de selección'),
('Gerente de compras');
go

select* from Empleado
select * from usuario

insert into Usuario(NombreUsuario, contraseña,id_Rol)
values ('Admin1', 'contraseña1',1), 
('GerenteG1', 'contraseña2',2), 
('Vendedor1', 'contraseña3',3), 
('Técnico1', 'contraseña4',4),
('GerenteC1', 'contraseña5',5);
go

SELECT  E.Id_Empleado, U.id_Rol,U.id_usuario,R.Nombre as Rol,E.Nombre AS Nombre,
 E.Apellido AS Apellido, E.Teléfono AS Telefono, E.DUI AS Dui, E.Correo AS Correo, U.NombreUsuario AS Usuario, U.contraseña AS Contraseña,E.Cargo AS Cargo
                FROM Empleado E 
				INNER JOIN Usuario U ON E.id_Usuario = U.id_Usuario
				INNER JOIN Rol R on U.id_Rol= R.id_Rol

select * from usuario 
select * from empleado 

delete from usuario where Id_Usuario= 8

select sum(total) as total from Detalle_Pedido 
where Id_Pedido = 1

insert into Empleado(Nombre, Apellido, Teléfono, DUI, Correo, Cargo, id_Usuario)
values ('Pedro', 'López', '+503 7854-9655', '0809234-1', 'Elpepe@example.c om', 'Jefe', 1),
('Ana', 'García', '+503 6543-9876', '1234567-8', 'ana@example.com', 'Gerente General', 2),
  ('Carlos', 'Ramírez', '+503 7890-4321', '9876543-2', 'carlos@example.com', 'Vendedor', 3),
  ('Sofia', 'Morales', '+503 6754-3241', '5678901-2', 'sofia@example.com', 'Técnico de selección', 4),
  ('Luis', 'González', '+503 4532-9876', '4567890-1', 'luis@example.com','Gerente de compras', 5) ;
  go


  sELECT Id_Empleado ,concat (Nombre,' ', Apellido, ', ', DUI ) as 'Empleado' from Empleado


  SELECT E.Id_Empleado, E.Nombre AS Nombre, E.Apellido AS Apellido, E.Teléfono AS Telefono, E.DUI AS Dui, E.Correo AS Correo,
       E.Cargo AS Cargo, U.NombreUsuario AS Nombre_Usuario, U.contraseña AS Contraseña
FROM Empleado E
INNER JOIN Usuario U ON E.id_Usuario = U.id_Usuario


SELECT PrecioUnitario FROM Producto WHERE Id_Producto =1

select * from Detalle_Pedido

CREATE TRIGGER CalcularTotalDetallePedido
ON Detalle_Pedido
AFTER INSERT
AS
BEGIN
    -- Actualizar el total en Detalle_Pedido usando el precio unitario de Producto
    UPDATE DP
    SET Total = P.PrecioUnitario * DP.Cantidad
    FROM Detalle_Pedido AS DP
    INNER JOIN inserted AS I ON DP.Id_Detalle = I.Id_Detalle
    INNER JOIN Producto AS P ON DP.Id_Producto = P.Id_Producto;

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

SELECT  E.Id_Empleado, U.id_Rol,R.Nombre as Rol, U.NombreUsuario AS Usuario, U.contraseña AS Contraseña,E.Cargo AS Cargo, E.Nombre AS Nombre, E.Apellido AS Apellido,
                 E.Teléfono AS Telefono, E.DUI AS Dui, E.Correo AS Correo 
                FROM Empleado E
				INNER JOIN Usuario U ON E.id_Usuario = U.id_Usuario
				INNER JOIN Rol R on U.id_Rol= R.id_Rol
				where E.nombre like '%a%'