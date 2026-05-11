CREATE TABLE Customers (
CustomerId int identity(1,1)primary key  ,
email NVARCHAR(50) Unique,
orederid int ,
ProductId int ,

)

CREATE TABLE Products (
ProductId int identity(1,1)primary key  ,
price decimal(10,2) check(price>=0),
orderid int,

)
CREATE TABLE Orders (
OrderId int identity(1,1)primary key  ,
quantity int default 1,
OrderitemsId int ,


)
CREATE TABLE OrderItems (
OrderitemsId int identity(1,1)primary key,


)
ALTER TABLE Customers
ADD CONSTRAINT orederid
Foreign key (orederid )
references Orders(OrderId);

ALTER TABLE Customers
ADD CONSTRAINT ProductId
Foreign key (ProductId)
references Products(ProductId);


insert into Customers(email,orederid,ProductId)
VALUES('GGGG@GMAIL',5,4),
('HHHH@GMAIL',5,4);

 insert into Products(price,orderid)
 Values(2.00,1),
 (3.00,1),
 (4.00,1);

 insert into Orders(quantity,OrderitemsId)
 Values(2,1),
 (3,1);

 USE GBG;	
 select c.email,o.OrderId,o.quantity,p.price from
 Customers c
 inner join Orders o on c.orederid=o.OrderId
 inner join Products p on c.ProductId=p.ProductId

  USE GBG;	
 SELECT 
    c.Email,
    SUM(o.Quantity * p.Price) AS Total
FROM Customers c
INNER JOIN Orders o
ON c.orederid = o.OrderId
INNER JOIN Products p
ON c.ProductId = p.ProductId
GROUP BY c.Email;

  USE GBG;	
SELECT 
    c.Email,
    SUM(o.Quantity * p.Price) AS Total
FROM Customers c
INNER JOIN Orders o
ON c.orederid = o.OrderId
INNER JOIN Products p
ON c.ProductId = p.ProductId
GROUP BY c.Email
HAVING SUM(o.Quantity * p.Price) > 200;


--Check errors 
INSERT INTO Products(price, orderid)
VALUES(-5,1);

--bonus
create table Categories(
CategoryId int primary key identity(1,1),
number int ,
)

create table ProductCategory(
CategoryId int ,
ProductId int,
primary key(ProductId,CategoryId ),
Foreign key (CategoryId)  references Categories( CategoryId),
Foreign key (ProductId) references Products( ProductId),
)