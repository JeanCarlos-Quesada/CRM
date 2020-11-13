create database DB_CRM;

use DB_CRM;

create table clients(
	clientId bigint primary key identity not null,
	clientName varchar(50) not null,
	phone varchar(15) not null,
	email varchar(50),
	gender char, -- M(Male) F(Female) N(No Definite)
	registerDate Date not null,
	isActive bit not null
);

create table employees(
	employeeId bigint primary key identity not null,
	employeeName varchar(50) not null,
	phone varchar(15) not null,
	email varchar(50) not null,
	gender char, -- M(Male) F(Female) N(No Definite)
	registerDate Date not null,
	isActive bit not null
);

create table users(
	userId bigint primary key identity not null,
	employeeId bigint foreign key references employees(employeeId) not null,
	userName varbinary(max) not null,
	userPassword varbinary(max) not null
);

create table rols(
	rolId tinyint primary key identity not null,
	rolName varchar(20) not null
);

create table users_X_rols(
	id bigint primary key identity not null,
	rolId tinyint foreign key references rols(rolId) not null,
	userId bigint foreign key references users(userId) not null
);

create table keys(
	id tinyint primary key identity,
	_Key varbinary(max),
	_IV varbinary(max),
);

create table categorys(
	id int primary key identity not null,
	categoryName varchar(255) not null
)

create table products(
	productId bigint primary key identity not null,
	productName varchar(255) not null,
	inventory int not null,
	price Decimal(12,2) not null,
	categoryId int foreign key references categorys(id) not null
);


create table orders(
	orderId bigint primary key identity not null,
	clintID bigint foreign key references clients(clientId) not null,
	employeeId bigint foreign key references employees(employeeId) not null,
	registerDate DateTime not null,
	status tinyint not null, --0(cancel) 1(open) 2(close)
);

create table orderDetails(
	orderId bigint foreign key references orders(orderId) not null,
	productId bigint foreign key references products(productId) not null,
);

create table orderFollows(
	orderId bigint foreign key references orders(orderId) not null,
	comment varchar(1000) not null,
	number int not null,
	registerDate DateTime not null
);

insert into rols values('Administrator'),('Seller');


select * from users;
select * from users_X_rols;