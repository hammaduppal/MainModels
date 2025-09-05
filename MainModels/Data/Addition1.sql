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