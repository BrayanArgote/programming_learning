USE master;
GO

CREATE DATABASE TaskManager;
Go

USE TaskManager;
GO 

CREATE TABLE Tasks
(
    Id INT PRIMARY KEY IDENTITY(1,1),
    Title VARCHAR(30) NOT NULL,
    Description VARCHAR(40) NULL,
    DueDate DATE NOT NULL,
    IsCompleted BIT NOT NULL DEFAULT 0
);
GO 

CREATE TABLE Users
(
    Id INT PRIMARY KEY IDENTITY(1,1),
    IdTask INT FOREIGN KEY REFERENCES Tasks(Id),
    Username VARCHAR(20) NOT NULL,
    Password NVARCHAR(10) NOT NULL,
);
GO

INSERT INTO Tasks (Title, Description, DueDate, IsCompleted)
VALUES ('Wash clothes', 'The clotes are in the your room', '2024-07-01', 0);
GO

INSERT INTO Users (IdTask, Username, Password)
VALUES (1, 'joe', '123');
GO