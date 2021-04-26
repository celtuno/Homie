USE master

GO

CREATE DATABASE HomeAutoDB
GO

USE HomeAutoDB


/*** LAGT TIL Constrinat(unique) PÅ UserName og HouseName  ***/

CREATE TABLE [HOUSE]
( 
	[HouseID]            int  IDENTITY  NOT NULL ,
	[StreetAddress]      char(30)  NOT NULL ,
	[HouseName]          char(15)  NOT NULL ,
	[PostalCode]         int  NOT NULL ,
	[City]               char(30)  NULL ,
	CONSTRAINT [XPKHOUSE] PRIMARY KEY  CLUSTERED ([HouseID] ASC),
	CONSTRAINT [XAKHouseName] UNIQUE ([HouseName]  ASC)
)
go

CREATE TABLE [ROOM]
( 
	[RoomID]             int  IDENTITY  NOT NULL ,
	[HouseID]            int  NULL ,
	[RoomName]           char(15)  NOT NULL ,
	CONSTRAINT [XPKROOM] PRIMARY KEY  CLUSTERED ([RoomID] ASC),
	CONSTRAINT [R_3] FOREIGN KEY ([HouseID]) REFERENCES [HOUSE]([HouseID])
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
)
go

CREATE TABLE [SENSOR_TYPE]
( 
	[SensorTypeID]       int  IDENTITY  NOT NULL ,
	[SensorTypeName]     char(15)  NOT NULL ,
	[SensorUnit]         char(10)  NOT NULL ,
	[SensorDescription]  char(15)  NULL ,
	CONSTRAINT [XPKSENSOR_TYPE] PRIMARY KEY  CLUSTERED ([SensorTypeID] ASC)
)
go

CREATE TABLE [DAQ]
( 
	[DaqID]              int  IDENTITY  NOT NULL ,
	[DaqAddress]         char(10)  NOT NULL ,
	[DaqName]            char(15)  NOT NULL ,
	[HouseID]            int  NULL ,
	[DaqModel]           char(50)  NULL ,
	CONSTRAINT [XPKDAQ] PRIMARY KEY  CLUSTERED ([DaqID] ASC),
	CONSTRAINT [R_12] FOREIGN KEY ([HouseID]) REFERENCES [HOUSE]([HouseID])
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
)
go

CREATE TABLE [DAQ_IO]
( 
	[IoID]               int  IDENTITY  NOT NULL ,
	[DaqID]              int  NULL ,
	[IoName]             char(15)  NULL ,
	[IoAddress]          char(20)  NULL ,
	[IoType]             char(15)  NULL ,
	[IoInputOutput]      char(10)  NOT NULL ,
	CONSTRAINT [XPKDAQ_SENSOR] PRIMARY KEY  CLUSTERED ([IoID] ASC),
	CONSTRAINT [R_10] FOREIGN KEY ([DaqID]) REFERENCES [DAQ]([DaqID])
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
)
go

CREATE TABLE [SENSOR]
( 
	[SensorID]           int  IDENTITY  NOT NULL ,
	[RoomID]             int  NULL ,
	[SensorTypeID]       int  NULL ,
	[IoID]               int  NOT NULL ,
	[SensorName]         char(15)  NOT NULL ,
	CONSTRAINT [XPKSENSOR] PRIMARY KEY  CLUSTERED ([SensorID] ASC),
	CONSTRAINT [R_4] FOREIGN KEY ([RoomID]) REFERENCES [ROOM]([RoomID])
		ON DELETE NO ACTION
		ON UPDATE NO ACTION,
	CONSTRAINT [R_6] FOREIGN KEY ([SensorTypeID]) REFERENCES [SENSOR_TYPE]([SensorTypeID])
		ON DELETE NO ACTION
		ON UPDATE NO ACTION,
	CONSTRAINT [R_13] FOREIGN KEY ([IoID]) REFERENCES [DAQ_IO]([IoID])
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
)
go

CREATE TABLE [STATISTIC]
( 
	[StatisticsID]       int  IDENTITY  NOT NULL ,
	[AverageData]        float  NOT NULL ,
	[MinData]            float  NOT NULL ,
	[MaxData]            float  NOT NULL ,
	[SensorID]           int  NOT NULL ,
	CONSTRAINT [XPKSTATISTICS] PRIMARY KEY  CLUSTERED ([StatisticsID] ASC),
	CONSTRAINT [R_17] FOREIGN KEY ([SensorID]) REFERENCES [SENSOR]([SensorID])
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
)
go

CREATE TABLE [SENSOR_LOG]
( 
	[SensorLogID]        int  IDENTITY  NOT NULL ,
	[LogTime]               datetime  NOT NULL ,
	[SensorValue]        float  NOT NULL ,
	[SensorID]           int  NULL ,
	CONSTRAINT [XPKSENSOR_LOG] PRIMARY KEY  CLUSTERED ([SensorLogID] ASC),
	CONSTRAINT [R_8] FOREIGN KEY ([SensorID]) REFERENCES [SENSOR]([SensorID])
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
)
go

CREATE TABLE [CUSTOMER]
( 
	[UserID]             int  IDENTITY  NOT NULL ,
	[Username]           char(15)  NOT NULL ,
	[AccessLevel]        bit  NOT NULL ,
	[HouseID]            int  NULL ,
	[FirstName]          char(30)  NOT NULL ,
	[LastName]           char(30)  NULL ,
	[Password]           char(64)  NOT NULL ,
	[Email]              char(50)  NOT NULL ,
	CONSTRAINT [XPKUSER] PRIMARY KEY  CLUSTERED ([UserID] ASC),
	CONSTRAINT [Username] UNIQUE ([Username]  ASC),
	CONSTRAINT [R_1] FOREIGN KEY ([HouseID]) REFERENCES [HOUSE]([HouseID])
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
)
go

CREATE TABLE [ACTUATOR_TYPE]
( 
	[ActuatorTypeID]     int  IDENTITY  NOT NULL ,
	[ActuatorTypeName]   char(15)  NOT NULL ,
	[ActuatorUnit]       char(10)  NOT NULL ,
	[ActuatorDescription] char(50)  NULL ,
	CONSTRAINT [XPKAKTUATOR_TYPE] PRIMARY KEY  CLUSTERED ([ActuatorTypeID] ASC)
)
go

CREATE TABLE [ACTUATOR]
( 
	[ActuatorID]         int  IDENTITY  NOT NULL ,
	[ActuatorValue]      bit  NOT NULL ,
	[RoomID]             int  NULL ,
	[Actuator_TypeID]    int  NULL ,
	[IoID]               int  NOT NULL ,
	[ActuatorName]       char(15)  NULL ,
	CONSTRAINT [XPKAKTUATOR] PRIMARY KEY  CLUSTERED ([ActuatorID] ASC),
	CONSTRAINT [R_5] FOREIGN KEY ([RoomID]) REFERENCES [ROOM]([RoomID])
		ON DELETE NO ACTION
		ON UPDATE NO ACTION,
	CONSTRAINT [R_9] FOREIGN KEY ([Actuator_TypeID]) REFERENCES [ACTUATOR_TYPE]([ActuatorTypeID])
		ON DELETE NO ACTION
		ON UPDATE NO ACTION,
	CONSTRAINT [R_16] FOREIGN KEY ([IoID]) REFERENCES [DAQ_IO]([IoID])
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
)
go

/* Sql stored procedures*/

/*Add Sensor Types*/
INSERT INTO SENSOR_TYPE
VALUES('Temperature','C','Temperature')
GO
INSERT INTO SENSOR_TYPE
VALUES('Humidity','%','Humidity')
GO
INSERT INTO SENSOR_TYPE
VALUES('Light-Lux','lux','Light lux')
GO
INSERT INTO ACTUATOR_TYPE
VALUES('Lights','Bool','Light indicator')
GO

create procedure [dbo].[uspLogIn]
(@Username char(15), @password char(64))
AS
declare 
@tmp bit = 0

begin
set @tmp = (select UserID from [CUSTOMER] where Username = @Username and Password = @password)
return @tmp
end
GO


CREATE PROCEDURE [dbo].[CreateCustomer]
@Username char(15), @AccessLevel bit, @FirstName char(30), @LastName char(30),@Email char(50),@Password char(64)
,@StreetAddress char(30), @HouseName char(30), @PostalCode int, @City char(30)
AS
insert into [HOUSE]( StreetAddress,HouseName,PostalCode,City)
VALUES( @StreetAddress,@HouseName,@PostalCode,@City)

declare 
@tmpHouse int
begin
set @tmpHouse = (SELECT TOP 1 HouseID FROM HOUSE ORDER BY HouseID DESC )

insert into [CUSTOMER]( Username, AccessLevel, HouseID,FirstName, LastName,Email,[Password])

VALUES( @Username,@AccessLevel,@tmpHouse,@FirstName,@LastName,@Email,@Password)
end
GO


CREATE PROCEDURE [dbo].[CreateNewHouse]
@StreetAddress char(30), @Name char(30), @PostalCode int, @City char(30)
AS
insert into [HOUSE]( StreetAddress,HouseName,PostalCode,City)
VALUES( @StreetAddress,@Name,@PostalCode,@City)
GO

CREATE PROCEDURE [dbo].[CreateNewUser]
@Username char(15), @AccessLevel bit,@HouseID int, @FirstName char(30), @LastName char(30),@Email char(50),@Password char(64)
AS
insert into [CUSTOMER]( Username, AccessLevel, HouseID,FirstName, LastName,Email,[Password])
VALUES( @Username,@AccessLevel,@HouseId,@FirstName,@LastName,@Email,@Password)
GO

exec CreateCustomer     'admin' ,1,'System','Admin','admin@test.tt', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 'AdminStreet', 'AdminHouse', '9999' ,'AdminCity'
GO

CREATE PROCEDURE [dbo].[CreateNewDAQ]
@DaqAddress char(6), @Name char(30),@HouseId int
AS
insert into [DAQ](DaqAddress,DaqName,HouseID)
VALUES( @DaqAddress,@Name,@HouseId)
GO 

CREATE PROCEDURE [dbo].[CreateNewDaqIO]
@DaqId int, @IoName char(30),@IoAddress char(20),@IoType char (15),@IoInputOutput char(15)
AS
insert into [DAQ_IO](DaqID,IoName,IoAddress,IoType,IoInputOutput)
VALUES( @DaqId,@IoName,@IoAddress,@IoType,@IoInputOutput)
GO

/* Create new DAQ*/
/*Choose an existing house from TABLE HOUSE*/
exec CreateNewDAQ 'Dev1','TestDaq',1
GO
exec CreateNewDaqIO 1,'TestAnalog','Dev1/Ai0','Analog','Input'
exec CreateNewDaqIO 1,'TestDigital','Dev1/port0/line0','Digital','Output'

GO
/* Create new DAQ IO*/
/*Choose an existing DAQ ID from TABLE DAQ*/
CREATE PROCEDURE [dbo].[CreateNewRoom]
@HouseId int,@RoomName char(30)
AS
insert into [ROOM](HouseID,RoomName)
VALUES( @HouseId,@RoomName)
GO

/* Create new room*/ 
CreateNewRoom 1,'TestRoom'
GO

CREATE PROCEDURE [dbo].[CreateSensor]
@RoomId int, @SensorTypeId int,@IOID int, @SensorName char(15)
AS
insert into [SENSOR](RoomID,SensorTypeID,IoID,SensorName)
VALUES( @RoomId,@SensorTypeId,@IOID,@SensorName)
GO

CREATE TRIGGER AddSensorStat ON [dbo].[SENSOR]
AFTER INSERT 
AS
	
	DECLARE @sensorID int

	SELECT @sensorID = SensorID FROM INSERTED

	INSERT INTO  STATISTIC(AverageData,MinData,MaxData,SensorID)
	VALUES(0,20,0, @sensorID)

GO

ALTER TABLE [dbo].[SENSOR] ENABLE TRIGGER [AddSensorStat]
GO

/* Create new sensor  - S( @RoomId,@SensorTypeId,@IOID,@SensorName) */
exec CreateSensor 1,1,1,'TestSensor1'
GO

/* Create trigger for statiscics log*/
CREATE TRIGGER [dbo].[LogAverage] ON [dbo].[SENSOR_LOG]
AFTER INSERT 
AS
	
	DECLARE @sensorvalue float 
	DECLARE @sensorID int
		DECLARE @average float 
	
	SELECT @sensorvalue = SensorValue FROM INSERTED 
	SELECT @sensorID = SensorID FROM INSERTED
	SELECT @average =  (Select AVG(SensorValue) from SENSOR_LOG)

	UPDATE STATISTIC
	Set AverageData = @average where SensorID = @sensorID
	
GO

ALTER TABLE [dbo].[SENSOR_LOG] ENABLE TRIGGER [LogAverage]
GO

CREATE TRIGGER [dbo].[LogMinvalues] ON [dbo].[SENSOR_LOG]
AFTER INSERT 
AS
	
	DECLARE @sensorvalue float 
	DECLARE @sensorID int
	DECLARE @SensorTime datetime
	
	
	SELECT @SensorTime = LogTime FROM INSERTED
	SELECT @sensorvalue = SensorValue FROM INSERTED 
	SELECT @sensorID = SensorID FROM INSERTED
	
	UPDATE STATISTIC
	Set MinData = @sensorvalue, SensorID = @sensorID
	where @sensorvalue < MinData AND SensorID = @sensorID
GO

ALTER TABLE [dbo].[SENSOR_LOG] ENABLE TRIGGER [LogMinvalues]
GO

CREATE TRIGGER [dbo].[LogMaxvalues] ON [dbo].[SENSOR_LOG]
AFTER INSERT 
AS
	
	DECLARE @sensorvalue float 
	DECLARE @sensorID int
	DECLARE @SensorTime datetime
	Declare @sensormaxold float
	
	SELECT @SensorTime = LogTime FROM INSERTED
	SELECT @sensorvalue = SensorValue FROM INSERTED 
	SELECT @sensorID = SensorID FROM INSERTED
	SELECT @sensormaxold =  (Select  MAX(SensorValue) from SENSOR_LOG)
	
	/*
	If @sensorvalue > @sensormaxold
	begin
	*/
	UPDATE STATISTIC
	Set MaxData = @sensorvalue, SensorID = @sensorID
	where @sensorvalue > MaxData and  @sensorID = SensorID
	/*
	end
	*/
GO

ALTER TABLE [dbo].[SENSOR_LOG] ENABLE TRIGGER [LogMaxvalues]
GO

CREATE PROCEDURE [dbo].[AddSensorValues]
@SensorValue float,@SensorId int
AS
insert into [SENSOR_LOG](SensorValue,SensorID,LogTime)
VALUES( @SensorValue,@SensorId,CURRENT_TIMESTAMP)
GO

exec AddSensorValues 18.7,1

GO



CREATE PROCEDURE [dbo].[CreateActuator]
@ActuatorValue int, @RoomId int,@Actuator_TypeID int ,@IOID int, @ActuatorName char(15)
AS
insert into [ACTUATOR](ActuatorValue,RoomID,Actuator_TypeID,IoID,ActuatorName)
VALUES(@ActuatorValue , @RoomId,@Actuator_TypeID , @IOID , @ActuatorName )
GO

/* Create new actuator  - (@ActuatorValue int, @RoomId int,@Actuator_TypeID int ,@IOID int, @ActuatorName char(15)) */
exec CreateActuator 0,1,1,2,'TestActuator1'
GO



CREATE PROCEDURE [dbo].[UpdateActuator]
@ActuatorID int, @ActuatorValue int
AS
UPDATE [ACTUATOR]/*(ActuatorValue,RoomID,Actuator_TypeID,IoID,ActuatorName)*/
set ActuatorValue = @ActuatorValue where ActuatorID = @ActuatorID
GO



/*sql - views*/

CREATE VIEW [dbo].[GetCustomerData]
AS

SELECT
CUSTOMER.UserId, 
CUSTOMER.UserName, 
CUSTOMER.HouseId, 
CUSTOMER.FirstName,
CUSTOMER.LastName,
CUSTOMER.Email,
HOUSE.StreetAddress,
HOUSE.HouseName,
HOUSE.PostalCode,
HOUSE.City

FROM CUSTOMER
INNER JOIN HOUSE ON CUSTOMER.HouseId = HOUSE.HouseId

GO

Create VIEW [dbo].[GetRooms]
AS

SELECT
ROOM.RoomID,
HOUSE.HouseName,
ROOM.RoomName,
ROOM.HouseID

FROM ROOM

INNER JOIN HOUSE ON ROOM.HouseID =HOUSE.HouseID
GO


CREATE VIEW [dbo].[GetSensors]
AS

SELECT
SENSOR.SensorID,
SENSOR.SensorName,
SENSOR_TYPE.SensorTypeName,
SENSOR_TYPE.SensorUnit,
ROOM.RoomID,
ROOM.RoomName,
DAQ_IO.IoAddress,
Room.HouseID

FROM SENSOR
INNER JOIN SENSOR_TYPE ON SENSOR.SensorTypeID= SENSOR_TYPE.SensorTypeID
INNER JOIN ROOM ON SENSOR.RoomID = ROOM.RoomID
INNER JOIN DAQ_IO ON SENSOR.IoID=DAQ_IO.IoID
GO

Create VIEW [dbo].[GetSensorTypes]
AS

SELECT
SENSOR_TYPE.SensorTypeID,
SENSOR_TYPE.SensorTypeName,
SENSOR_TYPE.SensorUnit,
SENSOR_TYPE.SensorDescription

FROM SENSOR_TYPE
/*
INNER JOIN SENSOR_TYPE ON SENSOR.SensorTypeID= SENSOR_TYPE.SensorTypeID
INNER JOIN ROOM ON SENSOR.RoomID = ROOM.RoomID
INNER JOIN DAQ_IO ON SENSOR.IoID=DAQ_IO.IoID
*/
GO





CREATE VIEW [dbo].[GetActuators]
AS

SELECT
ACTUATOR.ActuatorID,
ACTUATOR.ActuatorName,
ACTUATOR.ActuatorValue,
ACTUATOR_TYPE.ActuatorTypeName,
Room.RoomID,
ROOM.RoomName,
DAQ_IO.IoAddress,
ROOM.HouseID


/*DAQ.DaqAddress*/

FROM ACTUATOR
INNER JOIN ACTUATOR_TYPE ON ACTUATOR.Actuator_TypeID = ACTUATOR_TYPE.ActuatorTypeID
INNER JOIN ROOM ON ACTUATOR.RoomID = ROOM.RoomID
INNER JOIN DAQ_IO ON ACTUATOR.IoID=DAQ_IO.IoID

/*inner join DAQ on DAQ_IO.IoID = DAQ.DaqID*/

GO


CREATE VIEW [dbo].[SensorView] AS
select SENSOR.SensorID, ROOM.RoomName, house.HouseID
from HOUSE, ROOM, SENSOR
where house.HouseID = ROOM.HouseID
and ROOM.RoomID = SENSOR.RoomID
GO

Create VIEW [dbo].[GetActuatorTypes]
AS

SELECT
ACTUATOR_TYPE.ActuatorTypeID,
ACTUATOR_TYPE.ActuatorTypeName,
ACTUATOR_TYPE.ActuatorUnit,
ActuatorDescription

FROM ACTUATOR_TYPE
/*
INNER JOIN SENSOR_TYPE ON SENSOR.SensorTypeID= SENSOR_TYPE.SensorTypeID
INNER JOIN ROOM ON SENSOR.RoomID = ROOM.RoomID
INNER JOIN DAQ_IO ON SENSOR.IoID=DAQ_IO.IoID
*/
GO



CREATE VIEW [dbo].[GetDaqIo]
AS

SELECT
DAQ_IO.IoID,
DAQ_IO.IoAddress,
DAQ_IO.IoType,
DAQ_IO.IoInputOutput,
DAQ_IO.DaqID,
HOUSE.HouseID

FROM DAQ_IO
INNER JOIN DAQ ON DAQ.DaqID= DAQ_IO.DaqID
INNER JOIN HOUSE ON HOUSE.HouseID=DAQ.HouseID
GO

/****** Object:  StoredProcedure [dbo].[UpdateCustomer]    Script Date: 2/28/2020 2:04:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateCustomer]
@UserId int,
@HouseId int,
@FirstName varchar(30),
@LastName varchar(30),
@Email varchar(50),
@StreetAddress varchar(50),
@HouseName varchar(50),
@PostalCode int,
@City varchar(50)
AS

UPDATE CUSTOMER
Set FirstName = @FirstName, LastName = @LastName, Email = @Email
Where UserID = @UserId;
UPDATE HOUSE
Set StreetAddress = @StreetAddress, HouseName = @HouseName, PostalCode = @PostalCode
Where HouseID = @HouseId;



/****** Object:  StoredProcedure [dbo].[DeleteCustomer]    Script Date: 3/22/2020 11:33:31 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[DeleteCustomer]
@UserId int
AS

delete from CUSTOMER where UserId=@UserId

GO



CREATE VIEW [dbo].[GetSensorLog]
AS

SELECT
SENSOR_LOG.SensorID,
SENSOR.SensorName,
SENSOR_LOG.SensorValue,
SENSOR_LOG.LogTime,
ROOM.RoomName,
SENSOR_LOG.SensorLogID

FROM SENSOR_LOG

inner join SENSOR ON SENSOR.SensorID = SENSOR_LOG.SensorID
inner join SENSOR_TYPE ON SENSOR.SensorTypeID = SENSOR.SensorTypeID
INNER JOIN ROOM ON SENSOR.RoomID = ROOM.RoomID


GO
