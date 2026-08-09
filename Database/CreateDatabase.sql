/*
    PROG7312 ICE Task 2
    Database script for the Safe / Unsafe addition application.

    The application creates this automatically on first run, but the script is
    included so the database can also be built by hand in SQL Server Management
    Studio or the Visual Studio SQL Server Object Explorer.
*/

IF DB_ID('ICE2NumbersDb') IS NULL
BEGIN
    CREATE DATABASE [ICE2NumbersDb];
END
GO

USE [ICE2NumbersDb];
GO

IF OBJECT_ID('dbo.Numbers', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.Numbers
    (
        NumberId  INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        Value     INT NOT NULL,
        DateAdded DATETIME NOT NULL DEFAULT GETDATE()
    );
END
GO
