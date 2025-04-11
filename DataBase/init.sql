IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'Sal7ly')
BEGIN
    CREATE DATABASE Sal7ly;
    PRINT 'Database Sal7ly created successfully.';
END
ELSE
BEGIN
    PRINT 'Database Sal7ly already exists.';
END;
GO