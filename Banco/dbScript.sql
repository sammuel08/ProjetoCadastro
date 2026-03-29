create database dbbancoApp;
use dbbancoApp;

create table tbUsuario(
IdUsu int primary key auto_increment,
NomeUsu varchar(50) not null,
Cargo varchar(50) not null,
DataNasc datetime
);

insert into tbUsuario(NomeUsu, Cargo, DataNasc)
	values('João Paulo', 'Gerente', '1978/05/01'),
          ('Sammuel', 'Colaborador', '1978/05/01');
    

select * from tbUsuario;

create table endereco(
Id int primary key auto_increment,
CEP varchar(10) not null,
Estado varchar(70) not null,
Cidade varchar(70) not null,
Bairro varchar(70) not null,
Logradouro varchar(150) not null,
Complemento varchar(150) not null,
Numero varchar(15) not null
);