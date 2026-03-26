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