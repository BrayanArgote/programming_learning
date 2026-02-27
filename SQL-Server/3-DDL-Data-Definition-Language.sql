-- DATA BASE

-- CREATE
CREATE DATABASE test;

-- DELETE
DROP DATABASE test;


-- DATA

NOT NULL = data is required
NULL = data can be null
PRIMARY KEY IDENTITY(1,1)
UNIQUE = values can not repeat
DEFAULT = add value by default
CHECK = add a condition
FOREIGN KEY REFERENCES nametable(column)


-- TABLE

-- CREATE 
CREATE TABLE Users (
    User_id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(20) NOT NULL,
    Email NVARCHAR(100) NULL
);

-- DROP TABLE
DROP TABLE Users;


-- RENAME COLUMN
EXEC sp_rename 'Users.surname', 'last_name', 'COLUMN';


-- RENAME TABLE
EXEC sp_rename 'users', 'Users';


-- ALTER

-- ADD
ALTER TABLE Users
ADD phone NVARCHAR(20);

-- MODIFY
ALTER TABLE Users
ALTER COLUMN name NVARCHAR(20) NOT NULL;

-- DROP COLUMN
ALTER TABLE Users
DROP COLUMN phone;





