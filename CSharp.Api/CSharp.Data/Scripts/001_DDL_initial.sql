CREATE DATABASE CSharp 

GO 

USE CSharp 

GO 

CREATE TABLE [Customer] 
  ( 
     Id   BIGINT IDENTITY(1, 1) NOT NULL, 
     Name NVARCHAR(200) NOT NULL, 
	 Email NVARCHAR(200) NOT NULL, 
	 Timestamp  TIMESTAMP, 
	 Deleted BIT DEFAULT 0
     PRIMARY KEY (Id) 
  ) 

GO 

CREATE TABLE [Order]
  ( 
	 Id   BIGINT IDENTITY(1, 1) NOT NULL, 
     CustomerId      BIGINT NOT NULL,
     Price		   MONEY NOT NULL, 
     CreatedDate    DATETIME NOT NULL, 
	 Timestamp  TIMESTAMP, 
	 Deleted BIT DEFAULT 0
     PRIMARY KEY (Id), 
     FOREIGN KEY (CustomerId) REFERENCES Customer(Id) 
  ) 

GO 