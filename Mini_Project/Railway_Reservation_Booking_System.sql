create database RailwayReservation_Booking_System

use RailwayReservation_Booking_System

create table tblTrains
(
	Train_No int primary key,
	Train_Name varchar(100) not null,
	Source_Station varchar(50)not null,
	Destination_Station varchar(50)not null,
	Status varchar(20) check(Status IN ('Active', 'Inactive')) default 'Active'
)

select* from tblTrains
delete from tblTrains where Train_No = 1234567



--------------------------------
create table tblClassDetails
(
	Class_ID int  primary key identity,
	Train_No int,
	Class_Name Varchar(50),
	Total_Seats int NOT NULL,
	Available_Seats int NOT NULL,
	Fare decimal(10,2)
	foreign key (Train_No) references tblTrains(Train_No)
)

select*from tblClassDetails
delete from tblclassdetails where Train_No = 1234567


------------------------------------

create table tblBookings


(
	Booking_ID int primary key identity,
	Passenger_Name varchar(50),
	Train_No int NOT NULl,
	Class_Name varchar(50) NOT NULL,
	Travel_Date date NOT NULL,
	Tickets_Count int NOT NULL,
	Total_Amount decimal(10, 2) ,
	Status varchar(20) check (Status IN ('Active', 'Inactive')) default 'Active'
	foreign key (Train_No) references tblTrains(Train_No)
)

select* from tblBookings

--------------------------------------

create table tblCancellation
(
	Cancellation_ID  int primary key identity,
	Booking_ID int,
	Passenger_Name varchar(30),
	Train_No int,
	Class_Name varchar(30) ,
	Tickets_Count int,
	DateOf_Cancel date default GETDATE(),
	foreign key (Booking_ID) references tblbookings(Booking_ID),
	foreign key (Train_No) references tblTrains(Train_No)
)

select* from tblCancellation




-----------------------------------
-- Procedures--
-----------------------------------

-- 1) proc to add trains into tbltrains
create or alter procedure sp_AddTrain
    @Train_No int,
    @Train_Name varchar(100),
    @Source_Station varchar(100),
	@Destination_Station varchar(100)
as
begin
insert into tblTrains(Train_No, Train_Name, Source_Station, Destination_Station)
values (@Train_No, @Train_Name, @Source_Station, @Destination_Station )
end

select* from tblTrains

-----------------------------------------------------------------------------
-- 2) proc to add class details into tblclassdetails
create or alter procedure sp_AddClass_Detail 
@Train_No int,
@Class_Name Varchar(50),
@Total_Seats int ,
@Available_Seats int,
@Fare decimal(10,2)  
as
begin
insert into tblClassDetails(Train_No,Class_Name, Total_Seats,Available_Seats,Fare)
values (@Train_No,@Class_Name, @Total_Seats,@Available_Seats,@Fare);
end


select * from tblClassDetails
---------------------------------------------------------
-- 3) proc to display trains
create or alter proc sp_Display_Train
as
begin
select*from tblTrains
end 

exec sp_Display_Train

----------------------------------------------------------
-- 4) proc to display class details
create or alter proc sp_Display_Class
as
begin
select*from tblClassDetails
end 

exec sp_Display_Class

-----------------------------------------------------------------
-- 5) Create procedure to fetch available trains based on source and destination
CREATE or alter PROCEDURE sp_GetAvailableTrains
    @SourceStation VARCHAR(100),
    @DestinationStation VARCHAR(100)
AS
BEGIN
    -- Fetch available trains based on source and destination
    SELECT * FROM tblTrains
    WHERE Source_Station = @SourceStation
      AND Destination_Station = @DestinationStation
      AND Status = 'Active';
END;

-- EXEC sp_GetAvailableTrains 'Chennai','kadapa'




---------------------------------------------------------------
-- 6) Proc to book ticket with all messages
create or alter procedure sp_BookingTrain_Ticket
    @Train_No INT,
    @Passenger_Name VARCHAR(50),
    @Class_Name VARCHAR(50),
    @Travel_Date DATETIME,
    @Tickets_Count INT
as
begin
------------ Calculate booking amount-------------------------
declare @Ticket_Fare decimal(10, 2)
declare @Total_Amount decimal(10, 2)

select @Ticket_Fare = Fare from tblClassDetails
where Train_No = @Train_No AND Class_Name = @Class_Name;
set @Total_Amount = @Ticket_Fare * @Tickets_Count;

------ Check if the train and class are available----------------------
declare @Available_Seats int;
select @Available_Seats = Available_Seats from tblClassDetails
where Train_No = @Train_No AND Class_Name = @Class_Name;

if @Available_Seats >= @Tickets_Count
begin
------------- Update available seats--------------------------------------------
update tblClassDetails
set Available_Seats = Available_Seats - @Tickets_Count
where Train_No = @Train_No AND Class_Name = @Class_Name;
------------ Insert booking details-----------------------------------------------
insert into tblBookings(Train_No, Passenger_Name, Class_Name,Travel_Date ,Tickets_Count, Total_Amount, Status)
values ( @Train_No, @Passenger_Name, @Class_Name, @Travel_Date, @Tickets_Count, @Total_Amount, 'Active');
end
end

Select*from tblBookings


----

-------------------------------------------------------------------------------------
---- 7) proc for Cancelling Ticket -----------------
create or alter procedure sp_Cancel_Ticket
@Booking_ID int,
@Passenger_Name varchar(30),
@Train_No int,
@Class_Name varchar(30),
@Tickets_Count int
as
begin
-- Update available seats in CLASS_DETAILS----------------------------------
update tblClassDetails
set AVAILABLE_SEATS = AVAILABLE_SEATS + @Tickets_Count
where TRAIN_NO = @Train_No;
---- Insert cancellation details into Cancellation table------------------
insert into tblCancellation (Booking_ID, Passenger_Name, Train_No, Class_Name, Tickets_Count)
values (@Booking_ID, @Passenger_Name, @Train_No, @Class_Name, @Tickets_Count)

-- Update booking table status as cancelled
    UPDATE tblBookings
    SET Status = 'Inactive'
    WHERE Booking_ID = @Booking_ID
end


--------------------------------

-- 8) procedure for updating train status-------------------------------------------------
create or alter procedure sp_TrainStatus
    @Train_No INT
as
begin

update tblTrains
set Status = 'Active'
where Train_No = @Train_No AND Status = 'Inactive';

update tblTrains
set Status = 'Inactive'
where Train_No = @Train_No AND Status = 'Active';

-- Select and return the updated status of the train
select Status from tblTrains
where Train_No = @Train_No;
end