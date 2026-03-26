USE master;
GO

CREATE DATABASE Bank
GO

USE Bank;
GO 

CREATE TABLE PaymentMethod(
    PaymentMethodId Int PRIMARY KEY IDENTITY(1,1),
    Type VARCHAR(25) NOT NULL
)

CREATE TABLE [User](
    UserId INT PRIMARY KEY IDENTITY (1,1),
    FullName VARCHAR(100),
    Balance DECIMAL (10,2),
    Debt DECIMAL (10,2),
);

CREATE TABLE Payment(
    PaymentId INT PRIMARY KEY IDENTITY(1,1),
    UserId INT FOREIGN KEY REFERENCES [User] (UserId),
    Amount DECIMAL(10,2),
    PaymentMethodId INT,
    Date DATETIME2 DEFAULT GETDATE()

    FOREIGN KEY (PaymentMethodId) REFERENCES PaymentMethod(PaymentMethodId)
);
GO

INSERT INTO Paymentmethod (type)
VALUES
('NEQUI'),
('CASH')

INSERT INTO [User] (FullName, Balance, Debt)
VALUES
('John Smith', 1200.00, 600.00),
('Maria Lopez', 850.00, 850.00),
('David Brown', 430.00, 500.00),
('Ana Torres', 2100.00, 1000.00),
('Carlos Diaz', 560.00, 100.00);
GO

CREATE TABLE UserPaymentMethod(
    UserId INT,
    PaymentMethodId INT,
    PRIMARY KEY (UserId, PaymentMethodId),
    FOREIGN KEY (UserId) REFERENCES [User](UserId),
    FOREIGN KEY (PaymentMethodId) REFERENCES PaymentMethod(PaymentMethodId)
)
GO

INSERT INTO UserPaymentMethod(UserId, PaymentMethodId)
VALUES
(1,1),
(1,2),
(2,1),
(3,1),
(4,2),
(5,1),
(5,2)

CREATE PROCEDURE sp_ProcessPayment
    @UserId INT,
    @AmountEntered DECIMAL (10,2),
    @IdPaymentMethod INT,
    @Response DECIMAL (10,2) OUTPUT,
    @ResponseCode INT OUTPUT
AS
BEGIN

-- validar que el usuario y el metodo exista
    IF NOT EXISTS (SELECT 1 FROM [USER] WHERE UserId = @UserId) AND NOT EXISTS (SELECT 1 FROM PaymentMethod WHERE PaymentMethodId = @IdPaymentMethodMethod)
    BEGIN 
        SET @ResponseCode = 404;
        RETURN;
    END

    DECLARE @TotalDue DECIMAL(10,2);
    DECLARE @Debt DECIMAL(10,2);

    SELECT @TotalDue = Balance FROM [User] WHERE UserId = @UserId;
    SELECT @Debt = Debt FROM [User] WHERE UserId = @UserId;

-- validar que el valor no sea negativo o zero y cuente con el suficiente saldo
    IF @AmountEntered <= 0 OR @AmountEntered > @TotalDue
    BEGIN
        SET @ResponseCode = 400;
        RETURN;
    END

-- se ingresa mas dinero (deuda en 0 y mostrar cambio)
    ELSE

    BEGIN

        IF @AmountEntered >= @Debt
        BEGIN
            SET @Response = @AmountEntered - @Debt;   -- lo que sobro
            SET @TotalDue = @TotalDue - @Debt;
            UPDATE [User] SET Debt = 0 WHERE UserId = @UserId;

            INSERT INTO Payment (UserId, Amount, PaymentMethodId)
            VALUES (@UserId, @TotalDue, @IdPaymentMethodMethod)
        END

-- se ingresa menos dinero (restar a la deuda y mostrar en que quedo)
        ELSE
        BEGIN
            SET @Response = @TotalDue - @AmountEntered;   -- lo que queda por pagar
            SET @Debt = @Debt - @AmountEntered;
            UPDATE [User] SET Balance = @Response WHERE UserId = @UserId;

            INSERT INTO Payment (UserId, Amount, MethodPaymentId)
            VALUES (@UserId, @AmountEntered, @FkMethod)
        END

        UPDATE [User] SET Debt = @Debt WHERE UserId = @UserId;
        SET @ResponseCode = 200;
    
    END
END