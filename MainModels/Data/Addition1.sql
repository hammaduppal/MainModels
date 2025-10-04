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

CREATE TABLE Accounting.JournalEntries (
    JournalEntryId UNIQUEIDENTIFIER PRIMARY KEY,
    EntryNumber VARCHAR(50) NOT NULL UNIQUE,
    EntryDate DATE NOT NULL,
    ReferenceNumber VARCHAR(50) NULL,
    Description NVARCHAR(500) NULL,
    SourceModule VARCHAR(50) NULL,
    BranchId UNIQUEIDENTIFIER NOT NULL,
    TotalDebit DECIMAL(18,2) DEFAULT 0,
    TotalCredit DECIMAL(18,2) DEFAULT 0,
    Status VARCHAR(20) DEFAULT 'Posted',

    CreatedBy INT NULL,   -- FK to HRM.LoginUsers
    CreatedAt DATETIME NOT NULL DEFAULT GETDATE(),
    UpdatedBy INT NULL,
    UpdatedAt DATETIME NULL,

    FOREIGN KEY (CreatedBy) REFERENCES HRM.LoginUsers(Id),
    FOREIGN KEY (UpdatedBy) REFERENCES HRM.LoginUsers(Id)
);

CREATE TABLE Accounting.JournalLines (
    JournalLineId UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
    JournalEntryId UNIQUEIDENTIFIER NOT NULL,
    CoaId INT NOT NULL,                             -- from ChartOfAccounts
    Description NVARCHAR(500) NULL,
    Debit DECIMAL(18,2) DEFAULT 0,
    Credit DECIMAL(18,2) DEFAULT 0,
    ReferenceId UNIQUEIDENTIFIER NULL,              -- e.g. Customer, Supplier, Invoice
    ReferenceType VARCHAR(50) NULL,                 -- e.g. 'Customer', 'Supplier', 'Invoice'
    LineOrder INT NULL,                             -- display ordering
    CreatedAt DATETIME NOT NULL DEFAULT GETDATE(),

    FOREIGN KEY (JournalEntryId) REFERENCES Accounting.JournalEntries(JournalEntryId),
    FOREIGN KEY (CoaId) REFERENCES Accounting.ChartOfAccounts(CoaId)
);


CREATE INDEX IX_JournalEntries_EntryDate ON Accounting.JournalEntries(EntryDate);
CREATE INDEX IX_JournalEntries_BranchId ON Accounting.JournalEntries(BranchId);
CREATE INDEX IX_JournalLines_CoaId ON Accounting.JournalLines(CoaId);
CREATE INDEX IX_JournalLines_JournalEntryId ON Accounting.JournalLines(JournalEntryId);

CREATE TABLE Accounting.AccountBalances (
    BalanceId UNIQUEIDENTIFIER PRIMARY KEY,
    CoaId int NOT NULL,        -- from ChartOfAccounts
    BranchId UNIQUEIDENTIFIER NOT NULL,
    FiscalYear INT NOT NULL,
    FiscalPeriod INT NOT NULL,                  -- e.g., Month 1–12
    OpeningBalance DECIMAL(18,2) DEFAULT 0,
    DebitTotal DECIMAL(18,2) DEFAULT 0,
    CreditTotal DECIMAL(18,2) DEFAULT 0,
    ClosingBalance AS (OpeningBalance + DebitTotal - CreditTotal) PERSISTED,

    LastUpdated DATETIME NOT NULL DEFAULT GETDATE(),

    FOREIGN KEY (CoaId) REFERENCES Accounting.ChartOfAccounts(CoaId)
);



CREATE TABLE Accounting.AccountReceivables (
    ARId UNIQUEIDENTIFIER PRIMARY KEY,
    CustomerId INT NOT NULL,
    InvoiceId INT NULL,                   -- link to your existing invoice table
    JournalEntryId UNIQUEIDENTIFIER NULL, -- for accounting linkage
    Amount DECIMAL(18,2) NOT NULL,
    ReceivedAmount DECIMAL(18,2) DEFAULT 0,
    Balance AS (Amount - ReceivedAmount) PERSISTED,
    DueDate DATE NULL,
    Status VARCHAR(20) DEFAULT 'Pending', -- Pending, Paid, Partial, Overdue
    BranchId UNIQUEIDENTIFIER NOT NULL,
    CreatedBy INT NULL,
    CreatedAt DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (JournalEntryId) REFERENCES Accounting.JournalEntries(JournalEntryId)
);

CREATE TABLE Accounting.AccountPayables (
    APId UNIQUEIDENTIFIER PRIMARY KEY,
    SupplierId INT NOT NULL,
    PurchaseId INT NULL,                  -- link to your existing purchase table
    JournalEntryId UNIQUEIDENTIFIER NULL,
    Amount DECIMAL(18,2) NOT NULL,
    PaidAmount DECIMAL(18,2) DEFAULT 0,
    Balance AS (Amount - PaidAmount) PERSISTED,
    DueDate DATE NULL,
    Status VARCHAR(20) DEFAULT 'Pending', -- Pending, Paid, Partial, Overdue
    BranchId UNIQUEIDENTIFIER NOT NULL,
    CreatedBy INT NULL,
    CreatedAt DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (JournalEntryId) REFERENCES Accounting.JournalEntries(JournalEntryId)
);



CREATE TABLE Accounting.Payments (
    PaymentId UNIQUEIDENTIFIER PRIMARY KEY,
    PaymentType VARCHAR(20) NOT NULL,        -- 'Receipt', 'Payment'
    SourceType VARCHAR(20) NOT NULL,         -- 'Customer', 'Supplier', 'Expense'
    SourceId INT NULL,                       -- CustomerId, SupplierId etc.
    ReferenceId INT NULL,                    -- InvoiceId, PurchaseId, etc.
    JournalEntryId UNIQUEIDENTIFIER NULL,
    PaymentMode VARCHAR(20) NOT NULL,        -- 'Cash', 'Bank', 'Cheque', 'Online'
    Amount DECIMAL(18,2) NOT NULL,
    PaymentDate DATE NOT NULL DEFAULT GETDATE(),
    BranchId UNIQUEIDENTIFIER NOT NULL,
    CreatedBy INT NULL,
    CreatedAt DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (JournalEntryId) REFERENCES Accounting.JournalEntries(JournalEntryId)
);




CREATE TABLE Accounting.FiscalPeriods (
    FiscalPeriodId UNIQUEIDENTIFIER PRIMARY KEY,
    FiscalYear INT NOT NULL,
    PeriodNumber INT NOT NULL,                  -- 1–12 for months
    PeriodName VARCHAR(50) NOT NULL,            -- e.g., 'January', 'February'
    StartDate DATE NOT NULL,
    EndDate DATE NOT NULL,
    IsClosed BIT DEFAULT 0,                     -- Prevent postings after closing
    BranchId UNIQUEIDENTIFIER NOT NULL,
    CreatedBy INT NULL,
    CreatedAt DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (CreatedBy) REFERENCES HRM.LoginUsers(Id)
);




CREATE TABLE Accounting.TaxTransactions (
    TaxTransactionId UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
    SourceType VARCHAR(20) NOT NULL,        -- 'Sales', 'Purchase'
    SourceId INT NOT NULL,                  -- InvoiceId or PurchaseId
    JournalEntryId UNIQUEIDENTIFIER NULL,
    TaxAccountId INT NOT NULL,              -- FK from ChartOfAccounts (INT)
    TaxRate DECIMAL(5,2) NOT NULL,          -- e.g., 17.00
    TaxAmount DECIMAL(18,2) NOT NULL,
    BaseAmount DECIMAL(18,2) NOT NULL,      -- Amount before tax
    TaxType VARCHAR(50) NULL,               -- e.g., 'VAT', 'GST', 'WHT'
    BranchId UNIQUEIDENTIFIER NOT NULL,
    CreatedBy INT NULL,
    CreatedAt DATETIME DEFAULT GETDATE(),

    FOREIGN KEY (TaxAccountId) REFERENCES Accounting.ChartOfAccounts(CoaId),
    FOREIGN KEY (JournalEntryId) REFERENCES Accounting.JournalEntries(JournalEntryId)
);


CREATE TABLE Accounting.ReconciliationLogs (
    ReconciliationId UNIQUEIDENTIFIER PRIMARY KEY,
    SourceType VARCHAR(20) NOT NULL,         -- e.g., 'AR', 'AP', 'Bank'
    SourceId UNIQUEIDENTIFIER NULL,
    Description NVARCHAR(500) NULL,
    AdjustmentAmount DECIMAL(18,2) DEFAULT 0,
    CreatedBy INT NULL,
    CreatedAt DATETIME DEFAULT GETDATE(),
    BranchId UNIQUEIDENTIFIER NOT NULL
);

CREATE TABLE Accounting.Payments (
    PaymentId UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
    PaymentType VARCHAR(20) NOT NULL,       -- 'Customer', 'Supplier', 'Expense', 'Refund'
    ReferenceId INT NULL,                   -- e.g., InvoiceId or PurchaseId
    PaymentMethod VARCHAR(20) NOT NULL,     -- 'Cash', 'Bank', 'Cheque', 'Online'
    PaymentDate DATETIME NOT NULL DEFAULT GETDATE(),
    Amount DECIMAL(18,2) NOT NULL,
    Description NVARCHAR(500) NULL,
    JournalEntryId UNIQUEIDENTIFIER NULL,   -- Link to Journal Entry
    BranchId UNIQUEIDENTIFIER NOT NULL,
    CreatedBy INT NULL,
    CreatedAt DATETIME DEFAULT GETDATE(),

    FOREIGN KEY (JournalEntryId) REFERENCES Accounting.JournalEntries(JournalEntryId)
);
--M Hammad Ali
--04/10/2025
Alter Table INV.PurchaseMaster ADD TaxAmount Decimal(18,2) null