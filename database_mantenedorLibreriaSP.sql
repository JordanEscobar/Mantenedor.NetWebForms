--Primero crear base de datos
--CREATE DATABASE CRUD

--luego usar la base de datos
--USE CRUD

--luego crear la tabla con su id autoincrementable
/*CREATE TABLE PRODUCTOS(
id_producto int identity(1,1),
nombre varchar(255),
cantidad int,
precio int,
fecha date
)*/

-- crear procedimiento almacenado para cargar los productos
/*CREATE PROCEDURE sp_load
AS BEGIN
SELECT * FROM Productos
END*/

--PROCEDIMIENTO CRUD para crear
/*CREATE PROCEDURE sp_create
@nombre varchar(255),
@cantidad int,
@precio int,
@fecha date
AS BEGIN
INSERT INTO Productos VALUES(@nombre,@cantidad,@precio,@fecha)
END*/

--Procedimiento CRUD para read
/*CREATE PROCEDURE sp_read
@id int
AS BEGIN
SELECT * FROM Productos WHERE id_producto=@id
END*/

--PROCEDIMIENTO CRUD UPDATE
/*CREATE PROCEDURE sp_update
@id int,
@nombre varchar(255),
@cantidad int,
@precio int,
@fecha date
AS BEGIN
UPDATE Productos SET nombre=@nombre,cantidad=@cantidad,precio=@precio,fecha=@fecha
WHERE id_producto=@id
END*/

--Procedimiento CRUD DELETE
/*CREATE PROCEDURE sp_delete
@id int
AS BEGIN
DELETE FROM Productos WHERE id_producto=@id
END*/



