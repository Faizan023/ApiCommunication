create database LoginPage;
use LoginPage;

create table login(
Id int identity(1,1) not null,
firstName varchar(15) not null,
lastName varchar(15) not null,
gender varchar(5) not null,
email varchar(30) not null,
password varchar(15)  not null
);

select * from login;

delete	login where firstName = ''