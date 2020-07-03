create database crudaharon

use crudaharon

create table usuario(
idUsuario int primary key identity,
Nombres varchar(80),
Apellidos varchar(80),
Telefono varchar(30),
Correo varchar(120))

insert into usuario(Nombres, Apellidos, Telefono, Correo) values('Juan', 'Guevara','1234','juanpa2062@hotmail.com')
select * from usuario