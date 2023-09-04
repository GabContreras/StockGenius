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

NIT varchar(17) , 
NRC varchar(8) ,  --Numero de registro de contribuyente 569-0 tiene que tener un guion
Giro varchar(100), --A qu� se dedica
Categoria varchar(7)  CHECK (Categoria IN ('Peque�o', 'Mediano', 'Grande'))--Peque�o, Mediano, Grande)
);
go


SELECT Id_Cliente, Nombre as NombreEmpresa, Apellido, DUI, Telefono, Direcci�n, Edad, NIT, NRC, Giro, Categoria
FROM Cliente
WHERE NIT IS NOT NULL AND NRC IS NOT NULL AND Giro IS NOT NULL AND Categoria IS NOT NULL;


-- Create a filtered unique index for NIT column
CREATE UNIQUE INDEX UX_NIT_Unique ON Cliente (NIT) WHERE NIT IS NOT NULL;

-- Create a filtered unique index for NRC column
CREATE UNIQUE INDEX UX_NRC_Unique ON Cliente (NRC) WHERE NRC IS NOT NULL;

-- Create a unique index for DUI column
CREATE UNIQUE INDEX UX_DUI_Unique ON Cliente (DUI) where DUI is not null;



Create table Producto(
Id_Producto int PRIMARY KEY identity(1,1),
Nombre varchar(50) not null unique,
Descripcion varchar(150) not null,
Stock int not null check (Stock>=0),
Id_Proveedor int not null,
PrecioUnitario decimal(10,2) check(PrecioUnitario>0),
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
	Tipo_Cliente varchar(8) check(Tipo_Cliente IN ('Natural', 'Juridico')),

    CONSTRAINT FK_Cliente
    FOREIGN KEY (Id_Cliente) REFERENCES Cliente(Id_Cliente)
        ON DELETE NO ACTION
        ON UPDATE CASCADE,
);



CREATE TABLE Detalle_Pedido (
    Id_Detalle INT PRIMARY KEY IDENTITY(1, 1),
    Id_Pedido INT NOT NULL,
    Id_Producto INT NOT NULL,
    Cantidad INT NOT NULL CHECK(Cantidad > 0),
    Total DECIMAL(10, 2),

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
values ('Administrador'),--ya
('Comprador'),--ya
('Gerente de compras'),--ya
('Encargado de bodega'),--ya
('Vendedor');--ya
go

SELECT P.Id_Producto, P.Nombre , P.Descripcion, P.Stock, P.PrecioUnitario as Precio, Pr.Nombre AS Proveedor, P.imagen as imagen
                FROM Producto P 
				INNER JOIN Proveedor Pr ON P.Id_Proveedor = Pr.Id_Proveedor
select * from rol
--compra al proveedor (comprador (agregar y actualizar nada m�s en productos y proovedor) 
--recepcion de mercaderia (gerente de compras(tiene acceso a todo lo de proovedor y producto)
--almacenaje de mercaderia (Encargado de bodega(acceso a productos pero solo para actualizar adicional o sea no le puede quitar al stock  update Producto  set  Stock= 123 + 12
--WHERE Id_Producto = 1 )
--venta (vendedor(Acceso a ventas y clientes pero solo agregar y actualizar)


SELECT P.Id_Pedido, C.Nombre AS Cliente, E.Nombre AS Empleado, P.Fecha_Pedido as Fecha, p.Estado, p.Tipo_Cliente as "Tipo De Cliente"
FROM Pedido P
                INNER JOIN Cliente C ON P.Id_Cliente = C.Id_Cliente
				INNER JOIN Empleado E ON P.Id_Empleado = E.Id_Empleado;

				select c.Id_Cliente, c.Nombre as NombreCliente,c.DUI ,c.Nit as NIT,c.NRC
				from cliente c

        SELECT Id_Cliente, Nombre as NombreEmpresa ,Telefono, Direcci�n, NIT, NRC, Giro, Categoria
        FROM Cliente
        WHERE NIT IS NOT NULL AND NRC IS NOT NULL AND Giro IS NOT NULL AND Categoria IS NOT NULL;

		SELECT Id_Cliente, Nombre , Apellido, DUI, Telefono, Direcci�n, Edad 
		FROM Cliente
        WHERE DUI IS NOT NULL AND Apellido IS NOT NULL AND Edad IS NOT NULL;

		select * from cliente


select * from producto

update Producto  set  Stock= 123 + 12
WHERE Id_Producto = 1


select* from Empleado
select * from usuario

insert into Usuario(NombreUsuario, contrase�a,id_Rol)
values ('Admin1', 'contrase�a1',1), 
('GerenteG1', 'contrase�a2',2), 
('Vendedor1', 'contrase�a3',3), 
('T�cnico1', 'contrase�a4',4),
('GerenteC1', 'contrase�a5',5);
go

SELECT  E.Id_Empleado, U.id_Rol,U.id_usuario,R.Nombre as Rol,E.Nombre AS Nombre,
 E.Apellido AS Apellido, E.Tel�fono AS Telefono, E.DUI AS Dui, E.Correo AS Correo, U.NombreUsuario AS Usuario, U.contrase�a AS Contrase�a,E.Cargo AS Cargo
                FROM Empleado E 
				INNER JOIN Usuario U ON E.id_Usuario = U.id_Usuario
				INNER JOIN Rol R on U.id_Rol= R.id_Rol
				delete from usuario where id_usuario=2
select * from usuario 
select * from empleado 

delete from usuario where Id_Usuario= 8

select sum(total) as total from Detalle_Pedido 
where Id_Pedido = 1

insert into Empleado(Nombre, Apellido, Tel�fono, DUI, Correo, Cargo, id_Usuario)
values ('Pedro', 'L�pez', '+503 7854-9655', '0809234-1', 'Elpepe@example.c om', 'Jefe', 1),
('Ana', 'Garc�a', '+503 6543-9876', '1234567-8', 'ana@example.com', 'Gerente General', 2),
  ('Carlos', 'Ram�rez', '+503 7890-4321', '9876543-2', 'carlos@example.com', 'Vendedor', 3),
  ('Sofia', 'Morales', '+503 6754-3241', '5678901-2', 'sofia@example.com', 'T�cnico de selecci�n', 4),
  ('Luis', 'Gonz�lez', '+503 4532-9876', '4567890-1', 'luis@example.com','Gerente de compras', 5) ;
  go


  sELECT Id_Empleado ,concat (Nombre,' ', Apellido, ', ', DUI ) as 'Empleado' from Empleado


  SELECT E.Id_Empleado, E.Nombre AS Nombre, E.Apellido AS Apellido, E.Tel�fono AS Telefono, E.DUI AS Dui, E.Correo AS Correo,
       E.Cargo AS Cargo, U.NombreUsuario AS Nombre_Usuario, U.contrase�a AS Contrase�a
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


SELECT  E.Id_Empleado, U.id_Rol,R.Nombre as Rol, U.NombreUsuario AS Usuario, U.contrase�a AS Contrase�a,E.Cargo AS Cargo, E.Nombre AS Nombre, E.Apellido AS Apellido,
                 E.Tel�fono AS Telefono, E.DUI AS Dui, E.Correo AS Correo 
                FROM Empleado E
				INNER JOIN Usuario U ON E.id_Usuario = U.id_Usuario
				INNER JOIN Rol R on U.id_Rol= R.id_Rol
				where E.nombre like '%a%'