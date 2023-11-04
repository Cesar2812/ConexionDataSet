
Create DataBase Persona

use Persona 
go


Create Table Persona(
id int identity(1,1) primary key,
nombre varchar(20) not null,
edad int not null
)


insert into Persona values('Cesar','23'),('Juan','22'),('Luis','18'),('Isabel','22')

select * from Persona

delete from Persona 
where id=1

