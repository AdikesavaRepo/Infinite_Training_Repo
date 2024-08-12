create database normalizationdb

use normalizationdb


-----------------------------------------------------------------------------
-----------------------------------------------------------------------------
-----------------First Normal Form (1NF)---------------

--Every cell should containt only one attribute
--it increases data integrity
--Data redundancy will be reduced

create table tbl_AllDetails_1NF
(
	Clientno varchar(10),
    cName varchar(100),
    propertyNo varchar(10),
    pAddress varchar(225),
    rentStart Date,
    rentFinish Date,
    rent Decimal(10,2),
    ownerNo varchar(10),
    oName varchar(100)
)
 
insert into tbl_AllDetails_1NF values
	('CR76', 'John kay', 'PG4', '6 lawrence st, Glasgow', '2000-07-01', '2001-08-31', 350, 'CO40', 'Tina Murphy'),
	('CR76', 'John kay', 'PG16', '5 Novar Dr, Glasgow', '2002-09-01', '2002-09-01', 450, 'CO93', 'Tony Shaw'),
	('CR56', 'Aline Stewart', 'PG4', '6 lawrence st, Glasgow', '2009-09-01', '2000-06-10', 350, 'CO40', 'Tina Murphy'),
	('CR56', 'Aline Stewart', 'PG36', '2 Manor Rd, Glasgow', '2000-10-10', '2001-12-01', 370, 'CO93', 'Tony Shaw'),
	('CR56', 'Aline Stewart', 'PG16', '5 Novar Dr, Glasgow', '2002-11-01', '2003-08-01', 4550, 'CO93', 'Tony Shaw')

select * from tbl_AllDetails_1NF
 
------------------------------------------------------------------------------------------------------------------------------------------------
---------------------- Second Normal Form (2NF) ---------------------------

-- Table should be in 1NF
-- No Partial Dependency
-- =>Identify and remove partial dependencies
-- =>2NF requires that every non-key attribute (column) is fully dependent on the primary key.
 
 
create table tblClientDetails_2NF_1
(
    Clientno VARCHAR(10) PRIMARY KEY,
    cName VARCHAR(100)
)
 
insert into tblClientDetails_2NF_1 values
	('CR76', 'John kay'),
	('CR56', 'Aline Stewart')

select * from tblClientDetails_2NF_1
-------------------
 
Create table tblPropertyDetails_2NF_2
(
    propertyNo Varchar(10) Primary key,
    pAddress Varchar(225)
)
 
Insert into tblPropertyDetails_2NF_2 
Values ('PG4', '6 lawrence st, Glasgow'),
       ('PG16', '5 Novar Dr, Glasgow'),
       ('PG36', '2 Manor Rd, Glasgow')
 
select * from tblPropertyDetails_2NF_2
-------------------------------------
Create Table tblRentDetails_2NF_3 
(
    Clientno Varchar(10),
    propertyNo Varchar(10),
    rentStart Date,
    rentFinish Date,
    rent Decimal(10,2),
    ownerNo Varchar(10),
    oName Varchar(100),
    primary key (Clientno, propertyNo),
    foreign key (Clientno) references tblClientDetails_2NF_1(Clientno),
    foreign key (propertyNo) references tblPropertyDetails_2NF_2(propertyNo)
)
 
Insert into tblRentDetails_2NF_3 
Values ('CR76', 'PG4', '2000-07-01', '2001-08-31', 350, 'CO40', 'Tina Murphy'),
       ('CR76', 'PG16', '2002-09-01', '2002-09-01', 450, 'CO93', 'Tony Shaw'),
       ('CR56', 'PG4', '1999-09-01', '2000-06-10', 350, 'CO40', 'Tina Murphy'),
       ('CR56', 'PG36', '2000-10-10', '2001-12-01', 370, 'CO93', 'Tony Shaw'),
       ('CR56', 'PG16', '2002-11-01', '2003-08-10', 450, 'CO93', 'Tony Shaw')
 
select * from tblRentDetails_2NF_3

-----------------------------------------------------------------------------------------------
------------------- Third Normal Form (3NF) ---------------------------------------------------

-- Tables should be in 2NF
-- Eliminate Transitive Dependencies

create table tblClientDetails_3NF_1
(
    Clientno VARCHAR(10) PRIMARY KEY,
    cName VARCHAR(100)
)
 
insert into tblClientDetails_3NF_1 values
	('CR76', 'John kay'),
	('CR56', 'Aline Stewart')

select * from tblClientDetails_3NF_1
 
-----------------------------------------------------------
 
create table tblPropertyDetails_3NF_2
(
    propertyNo Varchar(10) Primary key,
    pAddress Varchar(225)
)
 
insert into tblPropertyDetails_3NF_2 values
	('PG4', '6 lawrence st, Glasgow'),
    ('PG16', '5 Novar Dr, Glasgow'),
    ('PG36', '2 Manor Rd, Glasgow')
 
select * from tblPropertyDetails_3NF_2
-----------------------------------------------------------
 
Create Table tblOwnerDetails_3NF_3
(
	ownerNo Varchar(10) PRIMARY KEY,
	oName Varchar(100)
)
 
Insert Into tblOwnerDetails_3NF_3 values
	('CO40', 'Tina Murphy'),
	('CO93', 'Tony Shaw')
 
select * from tblOwnerDetails_3NF_3
 
-----------------------------------------------------------
create table tblRentDetails_3NF_4
(
	Clientno Varchar(10),
	propertyNo Varchar(10),
	rentStart Date,
	rentFinish Date,
	rent Decimal(10,2),
	ownerNo Varchar(10),
	primary key (clientno, propertyNo),
	foreign key (clientno) references tblClientDetails_3NF_1(clientno),
	foreign key (propertyNo) references tblPropertyDetails_3NF_2(propertyNo),
	foreign key (ownerNo) references tblOwnerDetails_3NF_3(ownerNo)
)
 
insert into tblRentDetails_3NF_4 values
	('CR76', 'PG4', '2000-07-01', '2001-08-31', 350.00, 'CO40'),
	('CR76', 'PG16', '2002-09-01', '2002-09-01', 450.00, 'CO93'),
	('CR56', 'PG4', '2009-09-01', '2000-06-10', 350.00, 'CO40'),
	('CR56', 'PG36', '2000-10-10', '2001-12-01', 370.00, 'CO93'),
	('CR56', 'PG16', '2002-11-01', '2003-08-10', 450.00, 'CO93')
 
select * from tblRentDetails_3NF_4
 
------------------------------------------------------------------------------
create table tblClubbingAll_3NF_5
(
	clientno Varchar(10),
	propertyNo Varchar(10),
	ownerNo Varchar(10),
	primary key (clientno, propertyNo, ownerNo),
	foreign key (clientno, propertyNo) references tblRentDetails_3NF_4(clientno, propertyNo),
	foreign key (ownerNo) references tblOwnerDetails_3NF_3(ownerNo)
)
 
insert Into tblClubbingAll_3NF_5 values
	('CR76', 'PG4', 'CO40'),
	('CR76', 'PG16', 'CO93'),
	('CR56', 'PG4', 'CO40'),
	('CR56', 'PG36', 'CO93'),
	('CR56', 'PG16', 'CO93')
 
select * from tblClubbingAll_3NF_5

-------------------------------------------------------------------------------

--select propertyNo,cName from tblRentDetails_3NF_4 where ownerNo='CO40' and rentFinish = '2001-08-31'

select 





