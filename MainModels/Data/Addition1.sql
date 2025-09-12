CREATE TABLE INV.BranchStock
(
    BranchStockId     uniqueidentifier  PRIMARY KEY,
    ProductVariantId  uniqueidentifier  NULL,
    BranchId          uniqueidentifier  NULL,

    -- Prices
    SalePrice         DECIMAL(18,2) NULL,
    RetailPrice       DECIMAL(18,2) NULL,
    PromotionPrice    DECIMAL(18,2) NULL,
    StaffPrice        DECIMAL(18,2) NULL,
    Cost              DECIMAL(18,2) NULL,

    -- Stock
    Qty               DECIMAL(18,2) NOT NULL DEFAULT 0,

    -- Status
    IsActive          BIT NOT NULL DEFAULT 1,
    IsDeleted         BIT NOT NULL DEFAULT 0,

    -- Audit
    CreatedOn         DATETIME NOT NULL DEFAULT GETDATE(),
    CreatedBy         INT NULL
);

-- Indexes for performance
CREATE INDEX IX_BranchStock_ProductVariant ON INV.BranchStock(ProductVariantId);
CREATE INDEX IX_BranchStock_Branch         ON INV.BranchStock(BranchId);

ALTER TABLE INV.BranchStock
ADD CONSTRAINT FK_BranchStock_ProductVariant
    FOREIGN KEY (ProductVariantId) 
    REFERENCES INV.ProductVariants(VariantId);

-- Add FK to Branches
ALTER TABLE INV.BranchStock
ADD CONSTRAINT FK_BranchStock_Branch
    FOREIGN KEY (BranchId) 
    REFERENCES Business.Branches(BranchId);


    ALTER TABLE Business.Branches
ADD IsMasterBranch BIT NOT NULL CONSTRAINT DF_Branches_IsMasterBranch DEFAULT (0);
CREATE TABLE System.TaxSlabs
(
    TaxSlabId UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID() PRIMARY KEY,
    SlabName NVARCHAR(200) NOT NULL,
    Rate DECIMAL(5,2) NOT NULL,  -- supports rates like 18.50%
    IsActive BIT NOT NULL DEFAULT 1,
    CreatedOn DATETIME NOT NULL DEFAULT GETDATE(),
    ModifiedOn DATETIME NULL
);


ALTER TABLE INV.ProductVariants
ADD TaxSlabId UNIQUEIDENTIFIER NULL;

ALTER TABLE INV.ProductVariants
ADD CONSTRAINT FK_ProductVariants_TaxSlabs
FOREIGN KEY (TaxSlabId) REFERENCES System.TaxSlabs (TaxSlabId);
-- Seed data


IF OBJECT_ID('INV.InvoiceSources', 'U') IS NULL
BEGIN
    CREATE TABLE INV.InvoiceSources
    (
        InvoiceSourceId INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        SourceName NVARCHAR(100) NOT NULL,
        Description NVARCHAR(255) NULL,
        IsActive BIT NOT NULL DEFAULT 1,
        CreatedOn DATETIME NOT NULL DEFAULT GETDATE(),
        ModifiedOn DATETIME NULL
    );
END




BEGIN
    ALTER TABLE INV.InvoiceMaster
    ADD InvoiceSourceId INT NULL;
END


IF NOT EXISTS (
    SELECT 1 FROM sys.foreign_keys 
    WHERE name = 'FK_Invoices_InvoiceSources'
)
BEGIN
    ALTER TABLE INV.InvoiceMaster
    ADD CONSTRAINT FK_Invoices_InvoiceSources
        FOREIGN KEY (InvoiceSourceId) REFERENCES INV.InvoiceSources(InvoiceSourceId);
END




CREATE TABLE Setup.PaymentStatus (
    PaymentStatusId INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    IsActive BIT NOT NULL DEFAULT 1,
    CreatedOn DATETIME NOT NULL DEFAULT GETDATE()
);


CREATE TABLE Setup.ShippingType (
    ShippingTypeId INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    IsActive BIT NOT NULL DEFAULT 1,
    CreatedOn DATETIME NOT NULL DEFAULT GETDATE()
);

CREATE TABLE INV.InvoiceMaster
(
    InvoiceMasterId UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,

    InvoiceNo NVARCHAR(50) NOT NULL UNIQUE,
    InvoiceDate DATETIME NOT NULL DEFAULT GETDATE(),

    InvoiceSourceId INT NOT NULL,           -- e.g. POS, Online, Call Order (Enum-driven)
    PaymentMethodId INT NULL,               -- FK → System.PaymentMethods
    PaymentStatusId INT NULL,               -- FK → System.PaymentStatuses
    ShippingTypeId INT NULL,                -- FK → System.ShippingTypes

    CustomerId UNIQUEIDENTIFIER NULL,       -- FK → CRM.Customers
    EmployeeId INT NULL,                    -- FK → HR.Employees
    ServingTableId UNIQUEIDENTIFIER NULL,   -- FK → INV.ServingTables

    TotalAmount DECIMAL(18,2) NOT NULL DEFAULT 0,   -- Subtotal before discount/tax
    DiscountAmount DECIMAL(18,2) NULL,              -- Overall invoice discount
    TaxAmount DECIMAL(18,2) NULL,                   -- Total tax
    GrandTotal DECIMAL(18,2) NOT NULL DEFAULT 0,    -- After tax & discount

    CustomerRemarks NVARCHAR(500) NULL,
    OfficeRemarks NVARCHAR(500) NULL,

    CreatedBy INT NULL,
    CreatedDate DATETIME NOT NULL DEFAULT GETDATE(),
    UpdatedBy INT NULL,
    UpdatedDate DATETIME NULL
);


ALTER TABLE INV.InvoiceMaster
    ADD CONSTRAINT FK_InvoiceMaster_Customer FOREIGN KEY (CustomerId) REFERENCES HRM.Customers(CustomerId);

ALTER TABLE INV.InvoiceMaster
    ADD CONSTRAINT FK_InvoiceMaster_Employee FOREIGN KEY (EmployeeId) REFERENCES HRM.Employee(EmployeeId);

ALTER TABLE INV.InvoiceMaster
    ADD CONSTRAINT FK_InvoiceMaster_ServingTable FOREIGN KEY (ServingTableId) REFERENCES Ast.ServingTables(ServingTableId);

ALTER TABLE INV.InvoiceMaster
    ADD CONSTRAINT FK_InvoiceMaster_PaymentMethod FOREIGN KEY (PaymentMethodId) REFERENCES Setup.PaymentMethods(PaymentMethodId);

ALTER TABLE INV.InvoiceMaster
    ADD CONSTRAINT FK_InvoiceMaster_PaymentStatus FOREIGN KEY (PaymentStatusId) REFERENCES Setup.paymentstatus(PaymentStatusId);

ALTER TABLE INV.InvoiceMaster
    ADD CONSTRAINT FK_InvoiceMaster_ShippingType FOREIGN KEY (ShippingTypeId) REFERENCES Setup.ShippingType(ShippingTypeId);

CREATE TABLE INV.InvoiceDetail
(
    InvoiceDetailId UNIQUEIDENTIFIER NOT NULL  PRIMARY KEY,
    InvoiceMasterId UNIQUEIDENTIFIER NOT NULL, -- FK → InvoiceMaster

    ProductId UNIQUEIDENTIFIER NOT NULL,       -- FK → INV.Products
    VariantId UNIQUEIDENTIFIER NULL,           -- FK → INV.ProductVariants

    Quantity DECIMAL(18,2) NOT NULL,
    UnitPrice DECIMAL(18,2) NOT NULL,

    TaxRate DECIMAL(5,2) NULL,                 -- %
    TaxAmount DECIMAL(18,2) NULL,

    LineTotal DECIMAL(18,2) NOT NULL,          -- Qty * UnitPrice
    LineTotalWithTax DECIMAL(18,2) NOT NULL,   -- LineTotal + Tax

    Discount DECIMAL(18,2) NULL,
    Remarks NVARCHAR(500) NULL,

    CreatedDate DATETIME NOT NULL DEFAULT GETDATE()
);



-- Foreign Keys for InvoiceDetail
ALTER TABLE INV.InvoiceDetail
    ADD CONSTRAINT FK_InvoiceDetail_InvoiceMaster FOREIGN KEY (InvoiceMasterId) REFERENCES INV.InvoiceMaster(InvoiceMasterId);

ALTER TABLE INV.InvoiceDetail
    ADD CONSTRAINT FK_InvoiceDetail_Product FOREIGN KEY (ProductId) REFERENCES INV.Products(ProductId);

ALTER TABLE INV.InvoiceDetail
    ADD CONSTRAINT FK_InvoiceDetail_Variant FOREIGN KEY (VariantId) REFERENCES INV.ProductVariants(VariantId);

    CREATE NONCLUSTERED INDEX IX_InvoiceDetail_ProductId ON INV.InvoiceDetail(ProductId);
CREATE NONCLUSTERED INDEX IX_InvoiceDetail_VariantId ON INV.InvoiceDetail(VariantId);

-- InvoiceMaster: Common filters
CREATE NONCLUSTERED INDEX IX_InvoiceMaster_Date ON INV.InvoiceMaster(InvoiceDate);
CREATE NONCLUSTERED INDEX IX_InvoiceMaster_CustomerId ON INV.InvoiceMaster(CustomerId);
CREATE NONCLUSTERED INDEX IX_InvoiceMaster_EmployeeId ON INV.InvoiceMaster(EmployeeId);