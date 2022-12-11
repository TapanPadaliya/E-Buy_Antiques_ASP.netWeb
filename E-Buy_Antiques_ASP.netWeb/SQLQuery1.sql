CREATE TABLE ItemMaster (
 itemId INT PRIMARY KEY IDENTITY ,
 itemName varchar(30) NOT NULL,
 categoryId varchar(30) NOT NULL,
 itemDescription  text DEFAULT NULL,
 itemWeight Float(2)  NOT NULL,
 itemAge int Not Null ,
 updatedBy int FOREIGN KEY REFERENCES UserMaster(userId),
 updatedOn date DEFAULT NULL,
 addedDate date NOT NULL,
  
  
)select * from ItemMaster
select * from ItemPricingMaster
Alter table ItemMaster add itemImage varchar(MAX) NULL;
CREATE TABLE CategoryMaster (
 categoryId INT PRIMARY KEY IDENTITY ,
 categoryName varchar(30) NOT NULL,
 categoryDescription text DEFAULT NULL,
 updatedBy int FOREIGN KEY REFERENCES UserMaster(userId),
 updatedOn date DEFAULT NULL,
 addedDate date NOT NULL,
)select * from CategoryMaster
select * from CategoryMaster
CREATE TABLE UserMaster (
 userId INT PRIMARY KEY IDENTITY ,
 userName varchar(30) NOT NULL,
 userRegistered datetime NOT NULL,
 isAdmin  tinyint DEFAULT 0,
 userEmail varchar(255)  Not Null ,
 userPassword varchar(30) Not Null,
 userAddress text  Not Null,
 orderedTimes int Not Null DEFAULT 0,
  
)
ALTER TABLE UserMaster drop column userMobile
select * from UserMaster
insert into UserMaster(userName,userEmail,userAddress,userRegistered,userPassword) values('dharmanshah',
'shahdharman786@gmail.com','barrage road,vasna,ahmedabad',GETDATE(),'admin')
update  UserMaster  set isAdmin=1 where userName='dharmanshah';
ALTER TABLE UserMaster
DROP COLUMN userMobile;
CREATE TABLE ItemPricingMaster (
itemId  int FOREIGN KEY REFERENCES ItemMaster(itemId),
startDatetimeStamp date Null,
endDatetimeStamp date Null,
originalPrice float(2) Not Null,
discount float(2) Null,
discountedPrice float(2) Not Null,/* used in the query default original price*/
updatedBy int FOREIGN KEY REFERENCES UserMaster(userId),
 updatedOn date DEFAULT NULL,
)
CREATE TABLE StockMaster (
itemId  int FOREIGN KEY REFERENCES ItemMaster(itemId),
quantity int NOT NULL Default 1,  
updatedBy int FOREIGN KEY REFERENCES UserMaster(userId) NULL,
updatedOn date NULL,
)
select * from CategoryMaster
insert into CategoryMaster(categoryName,categoryDescription,addedDate) values('Coins & Currency'
,'Coins & Currency Category',GETDATE())

insert into CategoryMaster(categoryName,categoryDescription,addedDate) values('Jewelry'
,'Jewelry Category',GETDATE())


insert into CategoryMaster(categoryName,categoryDescription,addedDate) values('HandCraft'
,'HandCraft Category',GETDATE())


insert into CategoryMaster(categoryName,categoryDescription,addedDate) values('Arts & Paintings'
,'Arts & Paintings Category',GETDATE())

insert into CategoryMaster(categoryName,categoryDescription,addedDate) values('Antique Weapons'
,'Antique Weapons Category',GETDATE())

insert into CategoryMaster(categoryName,categoryDescription,addedDate) values('Sports Items'
,'Sports Items Category',GETDATE())




insert into CategoryMaster(categoryName,categoryDescription) values('Porcelain Pottery'
,'Porcelain Pottery Category')

insert into CategoryMaster(categoryName,categoryDescription) values('Furniture'
,'Furniture Category')

insert into CategoryMaster(categoryName,categoryDescription) values('Glass Items'
,'Glass Items Category')


insert into CategoryMaster(categoryName,categoryDescription) values('Fashion'
,'Fashion Category')

insert into CategoryMaster(categoryName,categoryDescription) values('Electronics'
,'Electronics Category')

