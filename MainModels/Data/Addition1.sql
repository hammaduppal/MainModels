
CREATE SCHEMA Accounting
go

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
    ARId UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    CustomerId UNIQUEIDENTIFIER NOT NULL,
    InvoiceId UNIQUEIDENTIFIER NULL,
    JournalEntryId UNIQUEIDENTIFIER NULL,
    Amount DECIMAL(18,2) NOT NULL,
    ReceivedAmount DECIMAL(18,2) DEFAULT 0,
    Balance AS (Amount - ReceivedAmount) PERSISTED,
    DueDate DATE NULL,
    Status VARCHAR(20) DEFAULT 'Pending', -- Pending, Paid, Partial, Overdue
    BranchId UNIQUEIDENTIFIER NOT NULL,
    CreatedBy INT NULL,
    CreatedAt DATETIME DEFAULT GETDATE(),
    
    FOREIGN KEY (CustomerId) REFERENCES HRM.Customers(CustomerId),
    FOREIGN KEY (InvoiceId) REFERENCES INV.InvoiceMaster(InvoiceMasterId),
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


--M Hammad Ali
--04/10/2025
Alter Table INV.PurchaseMaster ADD TaxAmount Decimal(18,2) null

ALTER TABLE INV.InvoiceMaster
ADD DueDate DATE NULL;

Alter Table Accounting.AccountPayables
Drop Column PurchaseId

Alter Table Accounting.AccountPayables
Add  PurchaseId uniqueIdentifier

--M Hammad Ali 09/10/2025
ALTER TABLE Accounting.AccountPayables
ADD CONSTRAINT FK_AccountPayables_Supplier
FOREIGN KEY (SupplierId)
REFERENCES Hrm.Supplier(SupplierId);

CREATE TABLE INV.BrandModels (
    BrandModelId UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    ModelName NVARCHAR(200) NOT NULL,
    IsActive BIT NOT NULL DEFAULT 1,
    CreatedOn DATETIME NOT NULL DEFAULT GETDATE(),
    ModifiedOn DATETIME NULL,
    BrandId UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT FK_BrandModels_Brands FOREIGN KEY (BrandId)
        REFERENCES INV.Brands(BrandId)
);

ALTER TABLE INV.Products
ADD BrandModelId UNIQUEIDENTIFIER NULL;

ALTER TABLE INV.Products
ADD CONSTRAINT FK_Products_BrandModels FOREIGN KEY (BrandModelId)
    REFERENCES INV.BrandModels(BrandModelId);

    --This task is pending until change the flow
--    ALTER TABLE INV.Products
--DROP CONSTRAINT FK_Products_Brands;

--ALTER TABLE INV.Products
--DROP COLUMN BrandId;


ALTER TABLE INV.Products
ALTER COLUMN ProductDescription NVARCHAR(MAX) NULL;
alter table Inv.Subcategory add HarmonizedSystemCode nvarchar(500) null

ALTER Table Inv.InvoiceMaster Add IsCancelled bit null
ALTER Table Inv.InvoiceMaster Add CanceledDate date null

CREATE TABLE System.Devices (
    Id INT IDENTITY PRIMARY KEY,
    BranchId UNIQUEIDENTIFIER NOT NULL,
	DeviceUniqueId VARCHAR(200) NOT NULL,
    DevicePayload VARBINARY(MAX) NOT NULL,  -- encrypted JSON
    CreatedAt DATETIME DEFAULT GETDATE(),

    CONSTRAINT FK_Devices_Branches FOREIGN KEY (BranchId)
        REFERENCES Business.Branches(BranchId)
        ON DELETE CASCADE  -- optional, deletes devices if branch deleted
);
ALTER TABLE System.Devices
ALTER COLUMN DevicePayload NVARCHAR(MAX) NOT NULL;


CREATE TABLE System.ServiceLicense
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    LicenseKey NVARCHAR(1000) NOT NULL,
    CustomerName NVARCHAR(200) NULL,
    DeviceId NVARCHAR(200) NULL,
    ProductName NVARCHAR(200) NOT NULL,
    ValidTill DATETIME NOT NULL,
    IsActive BIT NOT NULL DEFAULT 1,
    CreatedAt DATETIME NOT NULL DEFAULT GETUTCDATE(),
    UpdatedAt DATETIME NULL
);


CREATE TABLE System.ClientLicenses (
    Id INT IDENTITY PRIMARY KEY,
    LicenseKey NVARCHAR(200) NOT NULL,
    MachineFingerprint NVARCHAR(200) NULL,
    ValidFrom DATETIME2 NULL,
    ValidTo DATETIME2 NULL,
    IsActive BIT NOT NULL DEFAULT 1,
    Signature NVARCHAR(MAX) NULL,
    CreatedAt DATETIME2 DEFAULT GETDATE()
);

ALTER TABLE INV.Products Add ProductType int


CREATE TABLE INV.PurchaseType
(
    Id          INT         NOT NULL,  -- Must match code constants
    Code        VARCHAR(50) NOT NULL,
    Name        VARCHAR(100) NOT NULL,
    IsActive    BIT         NOT NULL CONSTRAINT DF_PurchaseType_IsActive DEFAULT (1),
    SortOrder   INT         NOT NULL,
    CreatedOn   DATETIME2   NOT NULL CONSTRAINT DF_PurchaseType_CreatedOn DEFAULT (SYSDATETIME()),
    CreatedBy   INT         NULL,

    CONSTRAINT PK_PurchaseType PRIMARY KEY (Id),
    CONSTRAINT UQ_PurchaseType_Code UNIQUE (Code)
);
--One time only after disable
--UPDATE INV.PurchaseType
--SET IsActive = 0
--WHERE Code = 'OPENING_STOCK';

ALTER TABLE INV.PurchaseMaster
ADD PurchaseTypeId INT NULL;
GO
ALTER TABLE INV.PurchaseMaster
ADD CONSTRAINT FK_INV_PurchaseMaster_PurchaseType
FOREIGN KEY (PurchaseTypeId)
REFERENCES INV.PurchaseType (Id);
GO
CREATE NONCLUSTERED INDEX IX_INV_PurchaseMaster_PurchaseTypeId
ON INV.PurchaseMaster (PurchaseTypeId);
GO

ALTER TABLE INV.CartMaster
DROP COLUMN SessionId;

Alter Table Inv.CartMaster
add SessionId uniqueidentifier null

Alter Table INv.CartDetail
Add ImageUrl nvarchar (max)

ALTER TABLE INV.CartDetail
ALTER COLUMN ProductId UNIQUEIDENTIFIER NULL;

ALTER TABLE INV.Products
Add  AdditionalInformation nvarchar (max)
CREATE TABLE ProductReviews (
    ReviewId BIGINT IDENTITY PRIMARY KEY,

    ProductId uniqueIdentifier NULL,
    UserId int  NULL,
    OrderId uniqueIdentifier NULL, -- Nullable FK

    Rating TINYINT NOT NULL CHECK (Rating BETWEEN 1 AND 5),
    Title NVARCHAR(200) NULL,
    Comment NVARCHAR(MAX) NOT NULL,

    IsVerifiedPurchase BIT NOT NULL DEFAULT 0,
    IsApproved BIT NOT NULL DEFAULT 0,
    IsDeleted BIT NOT NULL DEFAULT 0,

    HelpfulCount INT NOT NULL DEFAULT 0,
    NotHelpfulCount INT NOT NULL DEFAULT 0,

    AdminReply NVARCHAR(MAX) NULL,

    IPAddress VARCHAR(45) NULL,
    UserAgent NVARCHAR(255) NULL,

    CreatedAt DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
    UpdatedAt DATETIME2 NULL,

    -- 🔗 Foreign Keys
    CONSTRAINT FK_ProductReviews_Product
        FOREIGN KEY (ProductId) REFERENCES Inv.Products(ProductId),

    CONSTRAINT FK_ProductReviews_User
        FOREIGN KEY (UserId) REFERENCES Hrm.LoginUsers(Id),

    CONSTRAINT FK_ProductReviews_Order
        FOREIGN KEY (OrderId) REFERENCES Inv.OrderMaster(OrderMasterId)
);

CREATE TABLE INV.Coupons (
    CouponId UNIQUEIDENTIFIER PRIMARY KEY,
    CouponCode VARCHAR(50) NOT NULL UNIQUE,
    CouponName VARCHAR(100) NOT NULL,

    UsageLimitPerUser INT NULL,
    MaxTotalUsage INT NULL,

    StartDate DATETIME NOT NULL,
    EndDate DATETIME NOT NULL,

    MinQuantity INT NULL,
    MinCartAmount DECIMAL(18,2) NULL,

    DiscountType VARCHAR(20) NOT NULL,
    DiscountValue DECIMAL(18,2) NOT NULL,

    AllowStacking BIT DEFAULT 0,
    IsActive BIT DEFAULT 1,

    CreatedDate DATETIME DEFAULT GETDATE(),
    UpdatedDate DATETIME DEFAULT GETDATE()
);
GO


CREATE TABLE INV.CouponProduct (
    CouponProductId UNIQUEIDENTIFIER PRIMARY KEY,
    CouponId UNIQUEIDENTIFIER NOT NULL,
    ProductVariantId UNIQUEIDENTIFIER NOT NULL,

    CONSTRAINT FK_CouponProduct_Coupon
        FOREIGN KEY (CouponId) REFERENCES INV.Coupons (CouponId),

    CONSTRAINT FK_CouponProduct_ProductVariant
        FOREIGN KEY (ProductVariantId) REFERENCES INV.ProductVariants (VariantId)
);
GO


CREATE TABLE INV.CouponCategory (
    CouponCategoryId UNIQUEIDENTIFIER PRIMARY KEY,
    CouponId UNIQUEIDENTIFIER NOT NULL,
    CategoryId UNIQUEIDENTIFIER NOT NULL,

    CONSTRAINT FK_CouponCategory_Coupon
        FOREIGN KEY (CouponId) REFERENCES INV.Coupons (CouponId),

    CONSTRAINT FK_CouponCategory_Category
        FOREIGN KEY (CategoryId) REFERENCES INV.Categories (CategoryId)
);
GO

Alter Table HRM.Persons
Add IsVerifiedUser bit null

Alter Table HRM.Persons
Add PasswordResetToken nvarchar(max) null

ALTER TABLE HRM.Countries
ADD 
    ISOCode NVARCHAR(5) NULL,
    CountryDialCode NVARCHAR(10) NULL,
    CurrencyFormat NVARCHAR(20) NULL,
    TopLevelDomain NVARCHAR(10) NULL;

    ALTER TABLE webcms.ContentCategory
ADD 
    ImageURL nvarchar(2048),
    ShortDescription nvarchar(3000),
    Description nvarchar(4000),
    Icon nvarchar(255);