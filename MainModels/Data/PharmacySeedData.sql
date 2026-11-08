INSERT INTO Business.BusinessCategory (
    BusinessCategoryId,
    BusinessCategoryName,
    CreatedOn,
    CreatedBy,
    IsActive,
    IsDeleted
)
VALUES
(1, 'Real Estate', GETDATE(), 1, 1, 0),
(2, 'Hospitality', GETDATE(), 1, 1, 0),
(3, 'Restaurant', GETDATE(), 1, 1, 0),
(4, 'Hotel', GETDATE(), 1, 1, 0),
(5, 'Retail & Stores', GETDATE(), 1, 1, 0),
(6, 'Information Technology (IT)', GETDATE(), 1, 1, 0),
(7, 'Construction', GETDATE(), 1, 1, 0),
(8, 'Education & Training', GETDATE(), 1, 1, 0),
(9, 'Healthcare & Medical', GETDATE(), 1, 1, 0),
(10, 'Finance & Insurance', GETDATE(), 1, 1, 0),
(11, 'Transportation & Logistics', GETDATE(), 1, 1, 0),
(12, 'Manufacturing & Production', GETDATE(), 1, 1, 0),
(13, 'Telecommunication', GETDATE(), 1, 1, 0),
(14, 'Media & Entertainment', GETDATE(), 1, 1, 0),
(15, 'Legal Services', GETDATE(), 1, 1, 0),
(16, 'Agriculture & Farming', GETDATE(), 1, 1, 0),
(17, 'Automotive', GETDATE(), 1, 1, 0),
(18, 'Beauty & Personal Care', GETDATE(), 1, 1, 0),
(19, 'E-commerce', GETDATE(), 1, 1, 0),
(20, 'Sports & Recreation', GETDATE(), 1, 1, 0);

INSERT INTO Business.BusinessEntityType (
    BusinessEntityTypeId,
    BusinessEntityTypeName,
    CreatedOn,
    CreatedBy,
    IsActive
)
VALUES
(1, 'Sole Proprietorship', GETDATE(), 1, 1),
(2, 'Partnership', GETDATE(), 1, 1),
(3, 'Limited Liability Company (LLC)', GETDATE(), 1, 1),
(4, 'Corporation (Inc)', GETDATE(), 1, 1),
(5, 'S Corporation', GETDATE(), 1, 1),
(6, 'Nonprofit Organization', GETDATE(), 1, 1),
(7, 'Cooperative', GETDATE(), 1, 1),
(8, 'Joint Venture', GETDATE(), 1, 1);


INSERT INTO System.Roles (Id, Name, IsActive)
VALUES(1, 'SuperAdmin', 1),
(2, 'Admin', 1),
(3, 'PowerUser', 1),
(4, 'DataEntry', 1),
(5, 'Product', 1),
(6, 'Purchase', 1),
(7, 'Accounts', 1),
(8, 'POSUser', 1),
(9, 'Sales', 1),
(10, 'CustomerSupport', 1),
(11, 'Delivery', 1),
(12, 'Marketing', 1),
(13, 'User', 1),
(14, 'Customer', 1);

INSERT INTO System.TaxSlabs (SlabName, Rate) VALUES
(N'Standard GST 18%', 18.00),
(N'Service Tax 15%', 15.00),
(N'Luxury Tax 20%', 20.00),
(N'Engine <1500cc', 12.00),
(N'Engine 1500-1800cc', 18.00),
(N'Engine >2000cc', 25.00);

INSERT INTO INV.InvoiceSources (SourceName, Description)
VALUES 
(N'POS', N'Point of Sale'),
(N'Online', N'Online Order'),
(N'WebOrder', N'Website Order'),
(N'CallOrder', N'Call-based Order');

INSERT INTO Setup.PaymentMethods (PaymentMethodId, Name, IsActive, CreatedOn)
VALUES
-- Traditional
(1, 'Cash', 1, GETDATE()),
(2, 'Credit Card', 1, GETDATE()),
(3, 'Debit Card', 1, GETDATE()),
(4, 'Bank Transfer', 1, GETDATE()),
(5, 'Cheque', 1, GETDATE()),
(6, 'Gift Card / Voucher', 1, GETDATE()),

-- Online Payment Gateways
(7, 'PayPal', 1, GETDATE()),
(8, 'Stripe', 1, GETDATE()),
(9, 'Square', 1, GETDATE()),
(10, 'Apple Pay', 1, GETDATE()),
(11, 'Google Pay', 1, GETDATE()),
(12, 'Amazon Pay', 1, GETDATE()),

-- Mobile Wallets
(13, 'Venmo', 1, GETDATE()),
(14, 'Cash App', 1, GETDATE()),
(15, 'WeChat Pay', 1, GETDATE()),
(16, 'Alipay', 1, GETDATE()),

-- Pakistani Wallets
(20, 'Easypaisa', 1, GETDATE()),
(21, 'JazzCash', 1, GETDATE()),
(22, 'UPaisa', 1, GETDATE()),
(23, 'HBL Konnect', 1, GETDATE()),

-- Cryptocurrency
(30, 'Bitcoin', 1, GETDATE()),
(31, 'Ethereum', 1, GETDATE()),
(32, 'USDT (Tether)', 1, GETDATE());


INSERT INTO setup.PaymentStatus (Name, IsActive, CreatedOn)
VALUES
('Paid', 1, GETDATE()),
('Pending', 1, GETDATE()),
('Partially Paid', 1, GETDATE()),
('Refunded', 1, GETDATE()),
('Cancelled', 1, GETDATE()),
('Chargeback', 1, GETDATE()),
('Failed', 1, GETDATE());

INSERT INTO Setup.ShippingType (Name, IsActive, CreatedOn)
VALUES
('Pickup (In-Store)', 1, GETDATE()),
('Home Delivery', 1, GETDATE()),
('Courier Service', 1, GETDATE()),
('Express Delivery', 1, GETDATE()),
('Standard Delivery', 1, GETDATE()),
('No Shipping (Digital/Service)', 1, GETDATE());

INSERT INTO System.NotificationTypes(NotificationTypeId,NotificationTypeName)
Values(1,'New Order'),
(2,'Customer Registration');


INSERT INTO Accounting.ChartOfAccounts (AccountCode, AccountName, AccountType, ParentCoaId)
VALUES
-- ASSETS (1000-1999)
('1000', 'Assets', 'Asset', NULL),
('1010', 'Cash on Hand', 'Asset', 1),
('1020', 'Bank Accounts', 'Asset', 1),
('1021', 'Checking Account', 'Asset', 2),
('1022', 'Savings Account', 'Asset', 2),
('1030', 'Accounts Receivable', 'Asset', 1),
('1040', 'Inventory', 'Asset', 1),
('1050', 'Prepaid Expenses', 'Asset', 1),
('1060', 'Fixed Assets', 'Asset', 1),
('1061', 'Equipment', 'Asset', 9),
('1062', 'Furniture & Fixtures', 'Asset', 9),

-- LIABILITIES (2000-2999)
('2000', 'Liabilities', 'Liability', NULL),
('2010', 'Accounts Payable', 'Liability', 12),
('2020', 'Accrued Expenses', 'Liability', 12),
('2030', 'Taxes Payable', 'Liability', 12),
('2040', 'Loans Payable', 'Liability', 12),

-- EQUITY (3000-3999)
('3000', 'Equity', 'Equity', NULL),
('3010', 'Owner’s Capital', 'Equity', 17),
('3020', 'Owner’s Drawings', 'Equity', 17),
('3030', 'Retained Earnings', 'Equity', 17),

-- REVENUE (4000-4999)
('4000', 'Revenue', 'Revenue', NULL),
('4010', 'Sales Income', 'Revenue', 21),
('4020', 'Service Income', 'Revenue', 21),
('4030', 'Other Income', 'Revenue', 21),

-- COST OF GOODS SOLD (5000-5999)
('5000', 'Cost of Goods Sold', 'Expense', NULL),
('5010', 'Purchases', 'Expense', 25),
('5020', 'Direct Materials', 'Expense', 25),
('5030', 'Direct Labor', 'Expense', 25),
('5040', 'Freight In', 'Expense', 25),

-- EXPENSES (6000-7999)
('6000', 'Operating Expenses', 'Expense', NULL),
('6010', 'Rent Expense', 'Expense', 30),
('6020', 'Utilities Expense', 'Expense', 30),
('6030', 'Salaries Expense', 'Expense', 30),
('6040', 'Marketing Expense', 'Expense', 30),
('6050', 'Insurance Expense', 'Expense', 30),
('6060', 'Office Supplies', 'Expense', 30),
('6070', 'Depreciation Expense', 'Expense', 30),
('6080', 'Bank Charges', 'Expense', 30),
('1070', 'Input Tax (Purchase Tax)', 'Assets', 1),
('2041', 'Output Tax (Sales Tax)', 'Liability', 12);

-- Create schema if it doesn't exist
IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = 'inv')
BEGIN
    EXEC('CREATE SCHEMA inv')
END
GO

-- Create table if it doesn't exist
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[inv].[purchasetype]') AND type in (N'U'))
BEGIN
    CREATE TABLE [inv].[purchasetype] (
        [Id] INT NOT NULL,
        [Code] NVARCHAR(100) NOT NULL,
        [Name] NVARCHAR(150) NOT NULL,
        [IsActive] BIT NOT NULL,
        [SortOrder] INT NOT NULL,
        [CreatedOn] DATETIME2 NOT NULL,
        [CreatedBy] INT NULL,
        CONSTRAINT [PK_inv_purchasetype] PRIMARY KEY CLUSTERED ([Id] ASC)
    )
END
GO

INSERT INTO [inv].[purchasetype] ([Id], [Code], [Name], [IsActive], [SortOrder], [CreatedOn], [CreatedBy]) VALUES
(1,  'REQUISITION',         'Requisition',         1, 1,  GETUTCDATE(), NULL),
(2,  'PURCHASE_ORDER',      'Purchase Order',      1, 2,  GETUTCDATE(), NULL),
(3,  'RECEIVING',           'Receiving',           1, 3,  GETUTCDATE(), NULL),
(4,  'PURCHASE_RETURN',     'Purchase Return',     1, 4,  GETUTCDATE(), NULL),
(5,  'OPENING_STOCK',       'Opening Stock',       1, 5,  GETUTCDATE(), NULL),
(6,  'STOCK_ADJUSTMENT',    'Stock Adjustment',    1, 6,  GETUTCDATE(), NULL),
(7,  'BRANCH_TRANSFER',     'Branch Transfer',     1, 7,  GETUTCDATE(), NULL),
(8,  'STOCK_IN',            'Stock In',            1, 8,  GETUTCDATE(), NULL),
(9,  'STOCK_OUT',           'Stock Out',           1, 9,  GETUTCDATE(), NULL),
(10, 'STOCK_RETURN',        'Stock Return',        1, 10, GETUTCDATE(), NULL),
(11, 'STOCK_AUDIT',         'Stock Audit',         1, 11, GETUTCDATE(), NULL),
(12, 'STOCK_COUNT',         'Stock Count',         1, 12, GETUTCDATE(), NULL),
(13, 'STOCK_WRITE_OFF',     'Stock Write Off',     1, 13, GETUTCDATE(), NULL),
(14, 'STOCK_CONSUMPTION',   'Stock Consumption',   1, 14, GETUTCDATE(), NULL),
(15, 'STOCK_RESERVATION',   'Stock Reservation',   1, 15, GETUTCDATE(), NULL),
(16, 'STOCK_RELEASE',       'Stock Release',       1, 16, GETUTCDATE(), NULL),
(17, 'WAREHOUSE_TRANSFER',  'Warehouse Transfer',  1, 17, GETUTCDATE(), NULL);
GO
    
INSERT INTO Accounting.ChartOfAccounts
    (
        
        AccountCode,
        AccountName,
        AccountType,
        ParentCoaId,
        IsActive,
        CreatedAt,
        UpdatedAt
    )
    VALUES
    (
        
        3075,           -- AccountCode in 3000 range for Equity
        'Opening Stock',
        'Equity',       -- AccountType
        17,             -- ParentCoaId (Equity)
        1,              -- IsActive
        GETDATE(),      -- CreatedAt
        NULL            -- UpdatedAt
    );

    INSERT INTO INV.OrderStatus (OrderStatusName)
VALUES
('Pending'),
('Confirmed'),
('Processing'),
('Shipped'),
('Delivered'),
('Cancelled');


UPDATE Accounting.ChartOfAccounts
SET ParentCoaId = 21
WHERE CoaId IN (22, 23, 24);


UPDATE Accounting.ChartOfAccounts
SET ParentCoaId = 25
WHERE CoaId IN (26, 27, 28, 29);

UPDATE Accounting.ChartOfAccounts
SET ParentCoaId = 30
WHERE CoaId IN (31,32,33,34,35,36,37,38);

UPDATE Accounting.ChartOfAccounts
SET ParentCoaId = 12
WHERE CoaId IN (13,14,15,16);

UPDATE Accounting.ChartOfAccounts
SET ParentCoaId = 17
WHERE CoaId IN (18,19,20);

UPDATE Accounting.ChartOfAccounts
SET ParentCoaId = 9
WHERE CoaId IN (10, 11);

-- Insert script for Medical Store Units of Measure (UOMs)
WITH ParentUOMs AS (
    SELECT UOMId, UOMName FROM [INV].[UOM]
)
INSERT INTO [INV].[UOMSub] ([SubUOMId], [UOMId], [SubUOMName], [ConversionFactor], [CreatedOn], [Createdby], [ModifiedOn], [IsActive], [IsDeleted])
SELECT 
    NEWID(), 
    p.UOMId, 
    src.SubUOMName, 
    src.ConversionFactor, 
    CAST(N'2026-11-06T12:00:00.000' AS DateTime), 
    2, 
    CAST(N'2026-11-06T12:00:00.000' AS DateTime), 
    1, 
    0
FROM (
    VALUES
        -- ==========================================
        -- BOX PACKAGING BREAKDOWNS (Tablets, Capsules, Syrups, Consumables)
        -- ==========================================
        (N'Box', N'Strips per Box (10s)', 10.00),
        (N'Box', N'Strips per Box (14s)', 14.00),
        (N'Box', N'Strips per Box (20s)', 20.00),
        (N'Box', N'Blisters per Box', 10.00),
        (N'Box', N'Tablets per Box (100s)', 100.00),
        (N'Box', N'Tablets per Box (200s)', 200.00),
        (N'Box', N'Capsules per Box (100s)', 100.00),
        (N'Box', N'Bottles per Box (Small Syrup - 24s)', 24.00),
        (N'Box', N'Bottles per Box (Large Syrup - 12s)', 12.00),
        (N'Box', N'Ampoules per Box (10s)', 10.00),
        (N'Box', N'Ampoules per Box (50s)', 50.00),
        (N'Box', N'Vials per Box (10s)', 10.00),
        (N'Box', N'Pre-filled Syringes per Box (5s)', 5.00),
        (N'Box', N'Inhalers per Box', 1.00),
        (N'Box', N'Tubes per Box (Ointments/Creams - 12s)', 12.00),
        (N'Box', N'Sachets per Box (Granules/Powders - 30s)', 30.00),
        (N'Box', N'Infusion Bags per Box (IV Fluids - 20s)', 20.00),
        (N'Box', N'Disposable Syringes per Box (100s)', 100.00),
        (N'Box', N'Scalp Vein / Butterfly Needles per Box (100s)', 100.00),
        (N'Box', N'Cannulas per Box (50s)', 50.00),

        -- ==========================================
        -- STRIP / BLISTER BREAKDOWNS (Tablets & Capsules)
        -- ==========================================
        (N'Strip', N'Tablets per Strip (10s)', 10.00),
        (N'Strip', N'Tablets per Strip (14s)', 14.00),
        (N'Strip', N'Tablets per Strip (15s)', 15.00),
        (N'Strip', N'Tablets per Strip (4s)', 4.00),
        (N'Strip', N'Capsules per Strip (10s)', 10.00),
        (N'Strip', N'Pcs per Strip', 10.00),
        (N'Blister', N'Tablets per Blister (10s)', 10.00),
        (N'Blister', N'Tablets per Blister (5s)', 5.00),
        (N'Blister', N'Capsules per Blister (10s)', 10.00),

        -- ==========================================
        -- PACK BREAKDOWNS (Sachets, Cotton, Gauze, Kits)
        -- ==========================================
        (N'Pack', N'Sachets per Pack (10s)', 10.00),
        (N'Pack', N'Sachets per Pack (20s)', 20.00),
        (N'Pack', N'Bottles per Pack (6s)', 6.00),
        (N'Pack', N'Pieces per Surgical Pack', 5.00),
        (N'Pack', N'Gauze Swabs per Pack (100s)', 100.00),

        -- ==========================================
        -- ROLL BREAKDOWNS (Bandages, Tapes, Cotton)
        -- ==========================================
        (N'Roll', N'Meters per Elastic Bandage Roll (4m)', 4.00),
        (N'Roll', N'Meters per Gauze Roll (10m)', 10.00),
        (N'Roll', N'Meters per Surgical Tape Roll (9m)', 9.00),
        (N'Roll', N'Grams per Cotton Roll (50g)', 50.00),
        (N'Roll', N'Grams per Cotton Roll (500g)', 500.00),

        -- ==========================================
        -- BOTTLE / VIAL / TUBE / AMPOULE BREAKDOWNS
        -- ==========================================
        (N'Bottle', N'Milliliters per Syrup Bottle (60ml)', 60.00),
        (N'Bottle', N'Milliliters per Syrup Bottle (120ml)', 120.00),
        (N'Bottle', N'Milliliters per Syrup Bottle (90ml)', 90.00),
        (N'Bottle', N'Milliliters per IV Bottle (500ml)', 500.00),
        (N'Bottle', N'Milliliters per IV Bottle (250ml)', 250.00),
        (N'Vial', N'Milliliters per Liquid Vial (10ml)', 10.00),
        (N'Vial', N'Milligrams per Powder Vial (500mg)', 500.00),
        (N'Vial', N'Grams per Powder Vial (1g)', 1000.00),
        (N'Ampoule', N'Milliliters per Ampoule (1ml)', 1.00),
        (N'Ampoule', N'Milliliters per Ampoule (2ml)', 2.00),
        (N'Ampoule', N'Milliliters per Ampoule (3ml)', 3.00),
        (N'Tube', N'Grams per Ointment Tube (20g)', 20.00),
        (N'Tube', N'Grams per Cream Tube (30g)', 30.00),
        (N'Tube', N'Grams per Gel Tube (15g)', 15.00)
) AS src(ParentUOMName, SubUOMName, ConversionFactor)
JOIN ParentUOMs p ON p.UOMName LIKE '%' + src.ParentUOMName + '%'
GO