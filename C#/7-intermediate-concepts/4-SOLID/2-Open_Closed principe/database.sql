USE master;
GO

CREATE DATABASE Bank
GO

USE Bank;
GO 

CREATE TABLE [User](
    UserId INT PRIMARY KEY IDENTITY (1,1),
    FullName VARCHAR(100),
    Balance DECIMAL (10,2),
    Debt DECIMAL (10,2)
);

CREATE TABLE Payment(
    PaymentId INT PRIMARY KEY IDENTITY(1,1),
    UserId INT FOREIGN KEY REFERENCES [User] (UserId),
    Method VARCHAR(50),
    Date DATETIME2 DEFAULT GETDATE()
);
GO

INSERT INTO [User] (FullName, Balance, Debt)
VALUES
('John Smith', 1200.00, 600.00),
('Maria Lopez', 850.00, 850.00),
('David Brown', 430.00, 500.00),
('Ana Torres', 2100.00, 1000.00),
('Carlos Diaz', 560.00, 100.00);
GO


/* en la tabla user esta: cuanto se debe (Balance) y saldo disponible (Debt),
la tabla payment es una tipo historial (donde solo se va guardar registros de movimientos),
el metodo con el que se paga lo da el front 
*/

CREATE PROCEDURE sp_ProcessPayment
    @UserId INT,
    @AmountEntered DECIMAL (10,2),
    @Method VARCHAR (20),
    @Response DECIMAL (10,2) OUTPUT
AS
BEGIN
    DECLARE @TotalDue DECIMAL(10,2);
    DECLARE @Debt DECIMAL(10,2);

    SELECT @TotalDue = Balance FROM [User] WHERE UserId = @UserId;
    SELECT 

-- validar que el usuario exista
    IF EXISTS (SELECT 1 FROM [USER] WHERE UserId = @UserId) 
    BEGIN 
        SET @RESPONSE = 404;
        RETURN;
    END

-- validar que el valor no sea negativo o zero
    IF @AmountEntered <= 0 OR @AmountEntered > 
    BEGIN
        SET @Response = 0;
        RETURN;
    END

-- ==== SE DEBE INSERTAR UN REGISTRO TIPO HISTORIAL ====

-- se ingresa mas dinero (deuda en 0 y mostrar cambio)
    ELSE
    BEGIN

        IF @AmountEntered >= @TotalDue
        BEGIN
            SET @Response = @AmountEntered - @TotalDue;   -- lo que sobro
            UPDATE [User] SET Balance = 0 WHERE UserId = @UserId;

            INSERT INTO Payment (UserId, Amount, Method)
            VALUES (@UserId, @Response, @Method)
        END

-- se ingresa menos dinero (restar a la deuda y mostrar en que quedo)
        ELSE
        BEGIN
            SET @Response = @TotalDue - @AmountEntered;   -- lo que queda por pagar
            UPDATE [User] SET Balance = @Response WHERE UserId = @UserId;
        END
    
        INSERT INTO Payment (UserId, Amount, Method)
        VALUES (@UserId, @Response, @Method)

    END


