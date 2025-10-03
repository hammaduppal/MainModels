CREATE TABLE Accounting.ChartOfAccounts (
    CoaId INT IDENTITY(1,1) PRIMARY KEY,
    AccountCode VARCHAR(20) NOT NULL UNIQUE,
    AccountName NVARCHAR(200) NOT NULL,
    AccountType VARCHAR(50) NOT NULL, -- Asset, Liability, Equity, Revenue, Expense
    ParentCoaId INT NULL,
    IsActive BIT NOT NULL DEFAULT 1,
    CreatedAt DATETIME NOT NULL DEFAULT GETDATE(),
    UpdatedAt DATETIME NULL
);
