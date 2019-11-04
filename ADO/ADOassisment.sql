create database ADOassisment

use ADOassisment

create Table Customer
(
ID int identity primary key,
name varchar(24),
Product_id int,
Quantity int,
Supplier_Id int,
totalBill bigint

)
drop table Customer
create table product(
Id int primary key identity,
Name varchar(24)

)
drop table product
create table suppliers
(
Id int Primary key identity,
Name varchar(24),
Product_id int foreign key references product(Id),
location varchar(24),
price bigint
)
drop table suppliers

create table customer
(
ID int identity primary key,
name varchar(24),
Product_id int foreign key references product(Id),
Quantity int,
Supplier_Id int foreign key references suppliers(Id)
)

insert into product values('Tv')
insert into product values('watch')
insert into product values('moblie')

select *from product
insert into suppliers values('Samsung',1,'Sp road',59999)
insert into suppliers values('OnePlus',1,'Sp road',69999)

insert into suppliers values('Sony',1,'Sp road',79999)
insert into suppliers values('Apple',2,'Sp road',49999)
insert into suppliers values('Samsung',2,'Sp road',24999)
insert into suppliers values('Huwai',2,'Sp road',18999)
insert into suppliers values('Mi',1,'Sp road',24999)
insert into suppliers values('Mi',2,'Sp road',3999)
insert into suppliers values('Mi',3,'Sp road',14999)
insert into suppliers values('Samsung',3,'Sp road',34999)
insert into suppliers values('OnePlus',3,'Sp road',38999)
insert into suppliers values('Apple',3,'Sp road',79999)
select *from suppliers where product_id = 1
select price from suppliers where id = 2

