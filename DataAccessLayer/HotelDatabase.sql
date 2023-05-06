use Hotel

--Branche
CREATE TABLE Branche (
    ID int NOT NULL,
    brancheName varchar(255) NOT NULL,
    BrancheLocation varchar(255) NOT NULL,
    PRIMARY KEY (ID)
);

--Room

CREATE TABLE Room (
    RoomNo int IDENTITY(1,1),
    NoOfBeds int NOT NULL,
    FloorNo int NOT NULL,
    PricePerDay DECIMAL(5,2) NOT NULL,
	BrancheId int,
	IsAvailable BIT default 'TRUE',
    PRIMARY KEY (RoomNo),
    FOREIGN KEY (BrancheId) REFERENCES  dbo.Branche(ID)

);

-- Customer
CREATE TABLE Customer (
Id int Identity(1,1) NOT NULL,
FullName varchar(255) NOT NULL,
Email varchar(255) NOT NULL,
Phone varchar(125) NOT NULL,
CustomerAddress varchar(255) NOT NULL,
CreatedAt DATE,
PRIMARY KEY (Id)
);
	
--Booking
CREATE TABLE Booking(
BookingId int Identity(1,1) NOT NULL,
CustomerId int NOT NULL,
BrancheId int NOT NULL,
StartDate date NOT NULL,
 NoOfDays int NOT NULL,
IsCanceled BIT default 'FALSE',
PRIMARY KEY (BookingId),
FOREIGN KEY (CustomerId) REFERENCES  dbo.Customer(Id),
FOREIGN KEY (BrancheId) REFERENCES  dbo.Branche(ID),
);

--Booking Details
CREATE TABLE Booking_Details(
Id int identity(1,1) NOT NULL,
BookingId int NOT NULL,
RoomId int NOT NULL,
NoOfDayes int NOT NULL,
PricePerDay  DECIMAL(5,2) NOT NULL,
PRIMARY KEY (Id),
FOREIGN KEY (BookingId) REFERENCES  dbo.Booking(BookingId),
FOREIGN KEY (RoomId) REFERENCES  dbo.Room(RoomNo),
);
--Seed Branche
INSERT INTO dbo.Branche (ID, brancheName, BrancheLocation)
VALUES (1, 'Branche-A', '123 main st. address'),
		(2, 'Branche-B', '55 next to st. address'),
		(3, 'Branche-C', '44 st. address'),
		(4, 'Branche-D', '1 st. address'),
		(5, 'Branche-E', 'any st. address');



	





INSERT INTO dbo.Booking(CustomerId, BrancheId, StartDate,NoOfDays)
VALUES (1, 2,'2023-5-3',5);


INSERT INTO dbo.Booking_Details(BookingId, RoomId,NoOfDayes,PricePerDay)
VALUES (1, 2,5,200);

INSERT INTO dbo.Booking_Details(BookingId, RoomId,NoOfDayes,PricePerDay)
VALUES (1, 10,5,250);


INSERT INTO dbo.Customer(FullName, Email, Phone,CustomerAddress, CreatedAt)
VALUES ('Asmaa Mohamed', 'asmaa23@gmail.com','01121009287'
, 'Main st. Giza, Egypt', '2023-5-4'),
('Ahmed Mohamed', 'ahmed.mohamed@gmail.com','01225223666'
, '7 A st. Cairo, Egypt', '2023-5-3'),
('Hossam Ali', 'hossam.ali.9@gmail.com','01000201223'
, '7 A st. Cairo, Egypt', '2023-5-4'),
('Shady Saeed', 'shadys.33@gmail.com','015516771819'
, 'Main st test address', '2023-5-4');





--============================================
-- store procedures
CREATE PROCEDURE GetAllBranches
AS
SELECT * FROM dbo.Branche
GO;


EXEC GetAllBranches;




CREATE PROCEDURE GetBrancheById
 @BrancheId    int

AS 
BEGIN 
     SET NOCOUNT ON 
	 SELECT * FROM dbo.Branche WHERE dbo.Branche.ID = @BrancheId 

END 
GO

EXEC GetBrancheById 
 @BrancheId = 2;




CREATE PROCEDURE AddRoom
       @NoOfBeds     int, 
       @FloorNo      int, 
       @PricePerDay  DECIMAL(5,2),   
	   @BrancheId    int
AS 
BEGIN 
     SET NOCOUNT ON 

     INSERT INTO dbo.Room(NoOfBeds,FloorNo,PricePerDay,BrancheId) 
     VALUES(@NoOfBeds,@FloorNo,@PricePerDay,@BrancheId) 
END 
GO

EXEC AddRoom
@NoOfBeds = 2,
@FloorNo = 2 ,
@PricePerDay = 400,
@BrancheId = 1
GO

SELECT dbo.Branche.brancheName ,dbo.Room.RoomNo,dbo.Room.FloorNo,dbo.Room.NoOfBeds,
dbo.Room.PricePerDay,dbo.Room.IsAvailable
FROM dbo.Room
INNER JOIN dbo.Branche ON dbo.Room.BrancheId =dbo.Branche.ID 
WHERE dbo.Branche.ID = 1
AND dbo.Room.IsAvailable = 'TRUE';


CREATE PROCEDURE GetAllRoomsWithBranchId
	   @BrancheId    int
AS 
BEGIN 
     SET NOCOUNT ON 
		SELECT dbo.Branche.brancheName ,dbo.Room.RoomNo,dbo.Room.FloorNo,dbo.Room.NoOfBeds,
		dbo.Room.PricePerDay,dbo.Room.IsAvailable
		FROM dbo.Room
		INNER JOIN dbo.Branche ON dbo.Room.BrancheId =dbo.Branche.ID 
		WHERE dbo.Branche.ID = @BrancheId;
		
END 


CREATE PROCEDURE GetAllAvailableRoomsWithBranchId
	   @BrancheId    int
AS 
BEGIN 
     SET NOCOUNT ON 
		SELECT dbo.Branche.brancheName ,dbo.Room.RoomNo,dbo.Room.FloorNo,dbo.Room.NoOfBeds,
		dbo.Room.PricePerDay,dbo.Room.IsAvailable
		FROM dbo.Room
		INNER JOIN dbo.Branche ON dbo.Room.BrancheId =dbo.Branche.ID 
		WHERE dbo.Branche.ID = @BrancheId
		AND dbo.Room.IsAvailable = 'TRUE';
		
END 

CREATE PROCEDURE GetRoomById
	   @RoomNo    int
AS 
BEGIN 
     SET NOCOUNT ON 
		SELECT dbo.Branche.brancheName ,dbo.Room.RoomNo,dbo.Room.FloorNo,dbo.Room.NoOfBeds,
		dbo.Room.PricePerDay,dbo.Room.IsAvailable
		FROM dbo.Room
		INNER JOIN dbo.Branche ON dbo.Room.BrancheId =dbo.Branche.ID 
		 WHERE dbo.Room.RoomNo = @RoomNo;
		
END 


CREATE PROCEDURE UpdateRoom
	   @NoOfBeds     int, 
       @FloorNo      int, 
       @PricePerDay  DECIMAL(5,2),   
	   @BrancheId    int,
	   @RoomNo int,
	   @IsAvailable bit
AS 
BEGIN 
     SET NOCOUNT ON 
		UPDATE dbo.Room
		SET dbo.Room.NoOfBeds = @NoOfBeds, dbo.Room.FloorNo = @FloorNo, dbo.Room.PricePerDay = @PricePerDay,
		dbo.Room.BrancheId = @BrancheId, dbo.Room.IsAvailable = @IsAvailable
		WHERE dbo.Room.RoomNo = @RoomNo;
		
END 


EXEC GetAllRoomsWithBranchId @BrancheId = 1
GO


EXEC GetAllAvailableRoomsWithBranchId @BrancheId = 1
GO

EXEC UpdateRoom 
@NoOfBeds = 1, 
@FloorNo  = 1, 
@PricePerDay  = 300,   
@BrancheId = 1,
@RoomNo =2,
@IsAvailable = 'TRUE'
GO

EXEC GetRoomById
@RoomNo  = 1
GO


CREATE PROCEDURE CreateCustomer
       @FullName    varchar(255), 
       @Email     varchar(255), 
       @Phone  varchar(125),   
	   @CustomerAddress   varchar(255),
	   @CreatedAt DATE
AS 
BEGIN 
     SET NOCOUNT ON 
	INSERT INTO dbo.Customer(FullName, Email, Phone,CustomerAddress, CreatedAt)
	VALUES (@FullName,@Email,@Phone,@CustomerAddress,@CreatedAt);
END 
GO

EXEC CreateCustomer
 @FullName ='Shimaa Mohamed', 
 @Email    ='shimaa22@gmail.com', 
 @Phone  ='01121898829',   
 @CustomerAddress  ='any test address',
 @CreatedAt ='2023-5-4'

GO
CREATE PROCEDURE GetAllCustomers
AS
SELECT * FROM dbo.Customer
GO;


EXEC GetAllCustomers;


CREATE PROCEDURE GetBookingByBrancheId
	   @BranncheId   int
AS 
BEGIN 
     SET NOCOUNT ON 
		SELECT  dbo.Customer.*, dbo.Booking.BookingId, dbo.Branche.brancheName,dbo.Booking.StartDate,
		dbo.Booking.NoOfDays,dbo.Booking.IsCanceled
		FROM dbo.Customer
		INNER JOIN dbo.Booking ON dbo.Customer.Id =dbo.Booking.CustomerId
		
	    INNER JOIN dbo.Branche ON dbo.Booking.BrancheId =dbo.Branche.ID 
		WHERE dbo.Branche.ID = @BranncheId;	
END 


EXEC GetBookingByBrancheId
@BranncheId = 2
GO


CREATE PROCEDURE GetBookingDetailsByBookingId
	   @BookingId   int
AS 
BEGIN 
     SET NOCOUNT ON 
		SELECT  dbo.Booking_Details.Id, dbo.Room.RoomNo,dbo.Room.NoOfBeds,dbo.Room.FloorNo,
		dbo.Booking_Details.NoOfDayes,dbo.Booking_Details.PricePerDay
		FROM dbo.Booking_Details
		INNER JOIN dbo.Room ON dbo.Booking_Details.RoomId =dbo.Room.RoomNo
		WHERE dbo.Booking_Details.BookingId = @BookingId
END 

EXEC GetBookingDetailsByBookingId
@BookingId = 1
GO

CREATE PROCEDURE CountOfCustomerBooking
	   @CustomerId   int
AS 
BEGIN 
SELECT  COUNT(*) AS CountOfBooking FROM Booking WHERE CustomerId = @CustomerId AND IsCanceled != 'TRUE' ;
END

EXEC CountOfCustomerBooking

@CustomerId = 1;

SELECT * FROM Booking_Details

	SELECT dbo.Branche.ID, dbo.Branche.brancheName ,dbo.Branche.BrancheLocation,dbo.Room.RoomNo,dbo.Room.FloorNo,dbo.Room.NoOfBeds,
		dbo.Room.PricePerDay,dbo.Room.IsAvailable
		FROM dbo.Room
		INNER JOIN dbo.Branche ON dbo.Room.BrancheId =dbo.Branche.ID 
		ORDER BY  dbo.Branche.ID 



		
CREATE PROCEDURE ReportAllRooms
AS 
BEGIN
SELECT dbo.Branche.ID, dbo.Branche.brancheName ,dbo.Branche.BrancheLocation,dbo.Room.RoomNo,dbo.Room.FloorNo,dbo.Room.NoOfBeds,
		dbo.Room.PricePerDay,dbo.Room.IsAvailable
		FROM dbo.Room
		INNER JOIN dbo.Branche ON dbo.Room.BrancheId =dbo.Branche.ID 
		ORDER BY  dbo.Branche.ID 
END

EXEC ReportAllRooms
