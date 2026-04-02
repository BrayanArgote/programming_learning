USE master;
GO 


CREATE DATABASE Notification;
GO 


USE Notification;
GO


CREATE TABLE NotificationChannel(
    Id INT PRIMARY KEY IDENTITY (1,1),
    Type VARCHAR(20) NOT NULL
);
GO

CREATE TABLE NotificationLog(
    Id INT PRIMARY KEY IDENTITY (1,1),
    NotificationChannelId INT NOT NULL FOREIGN KEY REFERENCES NotificationChannel(Id),
    Sender VARCHAR(20) NOT NULL,
    Recipient VARCHAR(20) NOT NULL,
    Content NVARCHAR(50) NOT NULL
);  


INSERT INTO NotificationChannel(Type)
    VALUES
    (EMAIL),
    (SMS);
GO

INSERT INTO NotificationLog (NotificationChannelId, Sender, Recipient, Content)
VALUES (1, 'no-reply@empresa.com', 'cliente@email.com', 'Tu pedido #1025 ha sido enviado con éxito.');