use master 
go

drop database BaseDeDatosPtc
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
contraseña varchar(300),
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
id_Usuario int,


constraint FK_Usuario
FOREIGN KEY(id_Usuario) references Usuario(id_Usuario)
on delete set null
on update cascade
);
go

create table proveedor(
Id_Proveedor int PRIMARY KEY identity(1,1),
Nombre varchar(50) not null,
Dirección varchar(150) not null,
Telefono varchar(50) unique not null,
Estado varchar(9) CHECK (Estado IN ('Activo', 'Inactivo'))
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
Categoria varchar(7)  CHECK (Categoria IN ('Pequeño', 'Mediano', 'Grande')),--Pequeño, Mediano, Grande)
Estado varchar(8) CHECK (Estado IN ('Activo', 'Inactivo'))
);
go

Create table Producto(
Id_Producto int PRIMARY KEY identity(1,1),
Nombre varchar(50) not null,
Descripcion varchar(150) not null,
Stock int not null check (Stock>=0),
Id_Proveedor int not null,
Precio_Unitario decimal(10,2) check(Precio_Unitario>0),
imagen nvarchar(max)	

constraint FK_Proveedor
FOREIGN KEY (Id_Proveedor) references Proveedor(Id_Proveedor)
on delete no action 
on update cascade
);
go

Create table Ingreso_Producto(
Id_Ingreso int Primary key identity(1,1),
fecha_Ingreso Date not null,
cantidad int not null, 
Id_Producto int,

constraint FK_Producto2
FOREIGN KEY (Id_Producto) references Producto(Id_Producto)
on delete no action 
on update cascade

);
go

CREATE TABLE Pedido(
    Id_Pedido INT PRIMARY KEY IDENTITY(1, 1),
    Id_Cliente INT, -- Este campo puede ser el Id_Cliente o el Id_ClienteJuridico
    Id_Empleado INT NOT NULL,
    Fecha_Pedido DATE NOT NULL,
    Estado VARCHAR(10) CHECK (Estado IN ('En proceso', 'Completado', 'Anulado')),
    CONSTRAINT FK_Cliente
    FOREIGN KEY (Id_Cliente) REFERENCES Cliente(Id_Cliente)
        ON DELETE NO ACTION
        ON UPDATE CASCADE,
 CONSTRAINT Fk_Empleado
    FOREIGN KEY (Id_Empleado) REFERENCES Empleado(Id_Empleado)
        on delete no action
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
('Vendedor'),
('Master Admin');--ya
go

-- Create a filtered unique index for NIT column
CREATE UNIQUE INDEX UX_NIT_Unique ON Cliente (NIT) WHERE NIT IS NOT NULL;

-- Create a filtered unique index for NRC column
CREATE UNIQUE INDEX UX_NRC_Unique ON Cliente (NRC) WHERE NRC IS NOT NULL;

-- Create a unique index for DUI column
CREATE UNIQUE INDEX UX_DUI_Unique ON Cliente (DUI) where DUI is not null;

-- Insertar proveedores
INSERT INTO Proveedor (Nombre, Dirección, Telefono,Estado)
VALUES
    ('ElectroComponentes SA', 'Calle Principal #123', '+503 1111-1112','Activo'),
    ('Tecnología Total', 'Avenida Comercial #456', '+503 2222-2222','Activo'),
    ('Distribuidora Electrónica', 'Calle Central #789', '+503 3333-3333','Activo'),
    ('Comercializadora de Equipos', 'Avenida Industrial #1011', '+503 4444-4444','Activo'),
    ('Suministros Electrónicos', 'Calle Mayor #1516', '+503 5555-5555','Activo'),
    ('ElectroPro', 'Avenida de la Paz #1718', '+503 6666-6666','Activo'),	
    ('Componentes Avanzados', 'Calle del Progreso #1920', '+503 7777-7777','Activo'),
    ('ElectroDistribuidora', 'Avenida del Sol #2122', '+503 8888-8888','Activo'),
    ('ElectroMundo', 'Calle de la Industria #2324', '+503 9999-9999','Activo'),
    ('ElectroInnovación', 'Avenida de la Libertad #2526', '+503 1010-1010','Activo');

-- Insertar productos (hasta alcanzar 20 registros)
INSERT INTO Producto (Nombre, Descripcion, Stock, Id_Proveedor, Precio_Unitario)
VALUES
    ('Smartphone Galaxy S22', 'Potente smartphone con cámara de alta resolución', 0, 1, 699.99),
    ('Laptop Ultrabook X1', 'Laptop ultradelgada con pantalla táctil', 0, 2, 1199.99),
    ('Tablet Android Pro', 'Tablet de alto rendimiento con sistema Android', 0, 1, 299.99),
    ('TV LED 4K 55 pulgadas', 'Televisor con resolución 4K y pantalla LED', 0, 3, 699.99),
    ('Auriculares Inalámbricos X2', 'Auriculares Bluetooth con cancelación de ruido', 0, 1, 149.99),
    ('Cámara DSLR 24MP', 'Cámara réflex digital de alta calidad', 0, 2, 899.99);
	go

insert into Cliente(Nombre, Apellido, DUI, Telefono, Dirección, Edad,Tipo_Cliente,Estado) values 
                ('Marcelo josé', 'Hernández Hernández', '12345678-9', '8745-9874', 'Avenida el pepe', 18,'Natural','Activo'),
				('Juan Carlos', 'Pérez', '11111111-1', '1111-1111', 'Avenida Aguilares 218 San Salvador CP, San Salvador 1101', 25, 'Natural','Activo'),
				('Ana María', 'Gómez', '22222222-2', '2222-2222', 'Bouevard Santa Elena, lote #4, Antiguo Cuscatlán', 30, 'Natural','Activo'),
				('Carlos Alberto', 'López', '33333333-3', '3333-3333', 'Redondel Fuentes Beethoven &, 75 Avenida Nte, San Salvador', 35, 'Natural','Activo'),
				('Elena Rodríguez', 'Ramírez', '44444444-4', '4444-4444', 'C. Los Sisimiles 3130, San Salvador	', 40, 'Natural','Activo');

INSERT INTO Cliente (Nombre, Telefono, Dirección, NIT, NRC, Giro, Categoria, Tipo_Cliente,Estado) values
    ('Empresa Tech', '+503 2345-6789', 'Calle Principal 123', '5555-666666-777-6', '9876-5', 'Venta de productos electrónicos', 'Mediano', 'Jurídico','Activo'),
    ('Consultoría ABC', '+503 555-1234', 'Avenida Central 456', '5555-444444-995-7', '5432-1', 'Servicios de Consultoría Empresarial', 'Grande', 'Jurídico','Activo'),
    ('Restaurante delicioso', '+503 7890-1234', 'Boulevard Elegante 789', '5555-555555-555-8', '1234-5', 'Restaurante de comida gourmet', 'Pequeño', 'Jurídico','Activo'),
    ('Tienda Express', '+503 7777-7777', 'Plaza Comercial 321', '5555-555555-555-5', '1111-1', 'Venta de ropa y accesorios', 'Pequeño', 'Jurídico','Activo'),
    ('Servicios de Limpieza', '+503 8888-8888', 'Calle Limpia 555', '6666-777777-888-9', '2222-2', 'Servicios de Limpieza Residencial', 'Mediano', 'Jurídico','Activo');


-- Actualiza los primeros 5 registros de Ingreso_Producto con fecha del 1 de agosto de 2023
--UPDATE TOP(5) Ingreso_Producto
--SET fecha_Ingreso = '2023-08-01'




