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