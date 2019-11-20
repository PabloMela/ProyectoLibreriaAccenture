CREATE DATABASE Biblioteca_LeopoldoMarechal;
GO

USE Biblioteca_LeopoldoMarechal;

CREATE TABLE Autores
(
	Id int primary key identity(1,1),
	Nombre varchar(50) not null,
	Nacionalidad varchar(30),
	Fec_Nac datetime2,
)

CREATE TABLE Generos
(
	Id int primary key identity(1,1),
	Nombre varchar(20) not null,
	CONSTRAINT UQ_Generos_Nombre UNIQUE (Nombre)
)

CREATE TABLE Editoriales
(
	Id int primary key identity(1,1),
	Nombre varchar(40) not null,
	Pais varchar(20),
	CONSTRAINT UQ_Nombre_Pais UNIQUE (Nombre,Pais)
)

CREATE TABLE Libros 
(
	Id int primary key identity(1,1),
	ISBN int not null,
	Titulo varchar(30) not null,

	-- agregar Descripcion varchar(200),

	IdAutor int not null,
	IdAutor2 int,
	IdAutor3 int,
	IdEditorial int,
	
	-- agregar varchar Genero
	-- agregar varchar Subgenero

	IdGenero int not null,
	IdSubGenero int,
	IdSubGenero2 int,
	FechaPublicacion date,
	Stock int not null,
	Precio money not null,

	--FOREGIN KEYS
	CONSTRAINT FK_Libros_IdAutor FOREIGN KEY (IdAutor) REFERENCES Autores(Id),
	CONSTRAINT FK_Libros_IdAutor2 FOREIGN KEY (IdAutor2) REFERENCES Autores(Id),
	CONSTRAINT FK_Libros_IdAutor3 FOREIGN KEY (IdAutor3) REFERENCES Autores(Id),
	CONSTRAINT FK_Libros_IdEditorial FOREIGN KEY (IdEditorial) REFERENCES Editoriales(Id)
	CONSTRAINT FK_Libros_Genero FOREIGN KEY (IdGenero) REFERENCES Generos(Id),
	CONSTRAINT FK_Libros_IdSubGenero FOREIGN KEY (IdSubGenero) REFERENCES Generos(Id),
	CONSTRAINT FK_Libros_IdSubGenero2 FOREIGN KEY (IdSubGenero2) REFERENCES Generos(Id),

	CONSTRAINT CHK_Libros_PrecioValido CHECK (Precio >= 0),
	CONSTRAINT UQ_Libros_ISBN UNIQUE (ISBN),
	CONSTRAINT CHK_Libros_StockNoNegativo CHECK (Disponibilidad >= 0),
	CONSTRAINT CHK_Libros_ISBN CHECK (ISBN >= 0), --(ISBN BETWEEN 1000000000000 AND 9999999999999),
)