use master 
go

drop database if exists BaseDeDatosPtc
go

create database BaseDeDatosPtc
go

use BaseDeDatosPtc
go

create table Cargo(
Id_Cargo int PRIMARY KEY identity(1,1) ,
Nombre Varchar(50) not null unique
);
go

Create table Usuario(
Id_Usuario int PRIMARY KEY identity(1,1),
NombreUsuario varchar(30) unique not null, 
contrase�a varchar(100) not null
);
go

create table Empleado(
Id_Empleado int PRIMARY KEY identity(1,1),
Nombre varchar(50) not null,
Apellido varchar(50) not null,
Tel�fono varchar(50) unique not null,
DUI varchar (9) unique not null,
Correo varchar(50)unique not null,
id_Cargo int not null,
id_Usuario int not null,

constraint FK_Cargo
FOREIGN KEY (id_Cargo) references Cargo(id_Cargo)
on delete cascade
on update cascade,
constraint FK_Usuario
FOREIGN KEY(id_Usuario) references Usuario(id_Usuario)
on delete cascade
on update cascade,

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
Nombre varchar(50) not null,
Apellido varchar(50) not null,
DUI varchar (9) unique not null,
Telefono varchar(50) unique not null,
Direcci�n varchar(150) not null,
Edad int check (edad>21)
);
go

Create table Producto(
Id_Producto int PRIMARY KEY identity(1,1),
Nombre varchar(50) not null,
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
    Total DECIMAL(10, 2) -- Elimina el check y la asignaci�n de Total aqu�

constraint FK_Pedido
FOREIGN KEY (Id_Pedido) references Pedido(Id_Pedido)
on delete cascade 
on update cascade,
constraint FK_Producto
FOREIGN KEY (Id_Producto) references Producto(Id_Producto)
on delete cascade 
on update cascade,
);

CREATE TRIGGER CalcularTotalDetallePedido
ON Detalle_Pedido
AFTER INSERT, UPDATE
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


insert into Cargo(Nombre)
values ('Gerente'),
('Supervisor'),
('Operario'), 
('Asistente'),
('T�cnico'), 
('Contador'), 
('Analista'),
('Vendedor'), 
('Recepcionista');
go

insert into Usuario(NombreUsuario, contrase�a)
values ('Juanito', 'qwerty123'), 
('Laura', 'pass1234'), 
('Admin', 'adminpass'), 
('Carlos45', 'abcde6789'),
('Pepe23', 'Elpepe234'),
('Maria82', 'maria123'), 
('Pedro_12', 'p@ssw0rd'),
('AnaBanana', 'banana321'),
('JuanSoto', 'juansoto#'), 
('ElenaG', 'elenita456');
go

insert into Empleado(Nombre, Apellido, Tel�fono, DUI, Correo, id_Cargo, id_Usuario)
values ('Pedro', 'L�pez', '+503 7854-9654', '0809234-0', 'pedro@example.com', 2, 3),
('Ana', 'Garc�a', '+503 6543-9876', '1234567-8', 'ana@example.com', 1, 6),
  ('Carlos', 'Ram�rez', '+503 7890-4321', '9876543-2', 'carlos@example.com', 3, 2),
  ('Sofia', 'Morales', '+503 6754-3241', '5678901-2', 'sofia@example.com', 5, 8),
  ('Luis', 'Gonz�lez', '+503 4532-9876', '4567890-1', 'luis@example.com', 2, 3),
  ('Mar�a', 'Hern�ndez', '+503 3254-6754', '0987654-3', 'maria@example.com', 4, 1),
  ('Andr�s', 'L�pez', '+503 9856-3214', '8765432-1', 'andres@example.com', 3, 4),
  ('Isabel', 'Mart�nez', '+503 7412-3654', '5678910-2', 'isabel@example.com', 2, 9),
  ('Eduardo', 'Fern�ndez', '+503 6302-9867', '3456789-0', 'eduardo@example.com', 6, 5),
  ('Paola', 'Rojas', '+503 8475-1236', '9012345-6', 'paola@example.com', 7, 7);
  go

insert into Proveedor(Nombre, Direcci�n, Telefono)
values('ElectroPro', 'Av. Tecnol�gica #456, San Salvador', '+503 2222-3333'),
      ('TecnoParts', 'Colonia Centro #789, Santa Tecla', '+503 7777-8888'),
      ('SuperTech', 'Colonia Moderna #123, San Salvador', '+503 4444-5555'),
	   ('ElectroPro', 'Av. Tecnol�gica #456, San Salvador', '+503 2222-3353'),
  ('TechnoPepe', 'Colonia norte #798, Santa Tecla', '+503 7777-8889'),
  ('SuperPepe', 'Colonia antigua #132, San Salvador', '+503 4444-5535'),
  ('MegaElectronics', 'Residencial Los Pinos #789, San Salvador', '+503 6666-7777'),
  ('TechZone', 'Colonia Escal�n #567, San Salvador', '+503 9999-0000'),
  ('GadgetLand', 'Colonia Flor Blanca #432, San Salvador', '+503 1111-2222'),
  ('DigitalStore', 'Colonia Miramonte #987, San Salvador', '+503 3333-4444');
  go

	  insert into Cliente(Nombre, Apellido, DUI, Telefono, Direcci�n, Edad)
values('Luis', 'Mart�nez', '1234567-8', '+503 2222-1111', 'Col. Primavera #456, San Salvador', 28),
      ('Ana', 'G�mez', '5678901-2', '+503 7777-9999', 'Col. Flor Blanca #789, San Salvador', 35),
      ('Roberto', 'P�rez', '9012345-6', '+503 4444-7777', 'Col. Los Alamos #012, San Salvador', 42),
	  ('Josue', 'Alvarado', '1232367-9', '+503 2222-2222', 'Col. oto�o #465, San Salvador', 53),
  ('Mar�a', 'Jos�', '5657894-4', '+503 9999-9999', 'Col. Flor negra #798, San Salvador', 27),
  ('Francisco', 'Pizarro', '1248759-8', '+503 4444-4444', 'Col. Los Matani�os #021, San Salvador', 45),
  ('Mar�a', 'Hern�ndez', '3456789-0', '+503 3333-6666', 'Col. San Benito #567, San Salvador', 24),
  ('Carlos', 'L�pez', '7890123-4', '+503 8888-1111', 'Col. Escal�n #789, San Salvador', 31),
  ('Laura', 'Ram�rez', '2345678-9', '+503 5555-2222', 'Col. La Mascota #123, San Salvador', 29),
  ('Pedro', 'Garc�a', '5614521-5', '+503 9999-4444', 'Col. Miramonte #456, San Salvador', 37);
  go
  INSERT INTO Producto(Nombre, Descripcion, Stock, Id_Proveedor, PrecioUnitario)
VALUES
('Teclado Genius', 'Teclado multimedia con cable', 15, 3, 25.00),
('Monitor LED 24"', 'Monitor de alta resoluci�n para PC', 8, 3, 200.00),
('Disco Duro 1TB', 'Unidad de almacenamiento SATA3', 30, 3, 80.00),
('Teclado Genius', 'Teclado multimedia con cable', 15, 3, 25.00),
('Monitor LED 24"', 'Monitor de alta resoluci�n para PC', 8, 3, 200.00),
('Disco Duro 1TB', 'Unidad de almacenamiento SATA3', 30, 3, 80.00),
('Mouse inal�mbrico', 'Mouse ergon�mico de 6 botones', 20, 1, 15.00),
('Auriculares Bluetooth', 'Auriculares inal�mbricos con cancelaci�n de ruido', 12, 2, 50.00),
('Impresora l�ser', 'Impresora monocrom�tica de alta velocidad', 5, 4, 150.00),
('Tablet Android', 'Tablet de 10" con sistema operativo Android', 25, 5, 120.00);

	  insert into Pedido(Id_Cliente, Id_Empleado, Fecha_Pedido)
values(2, 4, '2023/11/15'),
      (3, 3, '2023/10/20'),
	    (2, 4, '2023/11/15'),
  (3, 3, '2023/10/20'),
  (1, 5, '2023/09/05'),
  (4, 2, '2023/12/02'),
  (2, 1, '2023/08/10'),
  (3, 6, '2023/07/25'),
  (1, 4, '2023/06/12'),
  (5, 3, '2023/05/18');
  go

	  insert into Detalle_Pedido(Id_Pedido, Id_Producto, cantidad, Total)
values(2, 3, 2, 150.00),
      (1, 1, 3, 75.50),
	    (2, 3, 2, 150.00),
  (1, 1, 3, 75.50),
  (3, 2, 1, 80.00),
  (4, 4, 5, 300.00),
  (1, 5, 2, 120.00),
  (2, 6, 4, 200.00),
  (5, 7, 3, 180.00),
  (3, 1, 2, 100.00);
  go

	  insert into Factura(Id_Pedido, TotalFinal)
values(2, 450.00),
      (1, 250.00),
	  (2, 450.00),
  (1, 250.00),
  (3, 80.00),
  (4, 300.00),
  (1, 120.00),
  (2, 200.00),
  (5, 180.00),
  (3, 100.00);
  go


  SELECT Nombre, apellido
FROM empleado

SELECT Producto.Id_Producto, Producto.Nombre AS Nombre_Producto, Producto.Descripcion, Producto.Stock, Proveedor.Nombre AS Nombre_Proveedor
FROM Producto
INNER JOIN Proveedor ON Producto.Id_Proveedor = Proveedor.Id_Proveedor;


SELECT U.NombreUsuario, U.contrase�a, E.Nombre AS Nombre_Empleado, E.Apellido AS Apellido_Empleado, E.Tel�fono AS Tel�fono_Empleado, E.DUI AS DUI_Empleado, E.Correo AS Correo_Empleado, C.Nombre AS Nombre_Cargo
FROM Usuario U
INNER JOIN Empleado E ON U.id_Usuario = E.id_Usuario
INNER JOIN Cargo C ON E.id_Cargo = C.Id_Cargo;


SELECT U.id_Usuario, E.Id_Empleado, U.NombreUsuario, U.contrase�a,E.Nombre AS Nombre, E.Apellido AS Apellido, E.Tel�fono AS Tel�fono, E.DUI AS DUI, E.Correo AS Correo, C.Nombre AS Cargo
FROM Usuario U
INNER JOIN Empleado E ON U.id_Usuario = E.id_Usuario
INNER JOIN Cargo C ON E.id_Cargo = C.Id_Cargo;

SELECT DP.Id_Detalle, DP.Id_Pedido, DP.Id_Producto, P.Nombre AS Nombre_Producto, DP.cantidad, P.PrecioUnitario,
       DP.cantidad * P.PrecioUnitario AS Total
FROM Detalle_Pedido DP
INNER JOIN Producto P ON DP.Id_Producto = P.Id_Producto;


SELECT Producto.Id_Producto, Producto.Nombre AS Nombre_Producto, Producto.Descripcion, Producto.Stock, Producto.PrecioUnitario, Proveedor.Nombre AS Nombre_Proveedor
FROM Producto
INNER JOIN Proveedor ON Producto.Id_Proveedor = Proveedor.Id_Proveedor;

SELECT P.Id_Pedido, C.Nombre AS Nombre_Cliente, E.Nombre AS Nombre_Empleado, P.Fecha_Pedido
FROM Pedido P
INNER JOIN Cliente C ON P.Id_Cliente = C.Id_Cliente
INNER JOIN Empleado E ON P.Id_Empleado = E.Id_Empleado;



select Stock from Producto
where Id_Producto=11;

update Producto
set Stock=(((select Stock from Producto where Id_Producto=11)) + ((select cantidad from Detalle_Pedido where Id_Pedido=1)-490))
where Id_Producto=11;


update Producto
set stock=500
where Id_Producto=11;

UPDATE Detalle_Pedido
SET Id_Pedido = 1, Id_Producto = 11, cantidad = 499
WHERE Id_Detalle = 22;

select * from Detalle_Pedido where Id_Detalle=22;