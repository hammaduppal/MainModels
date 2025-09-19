CREATE TABLE INV.OrderMaster (
    [OrderMasterId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
    [ParentOrderId] UNIQUEIDENTIFIER NULL, -- Self-reference for sub-orders
    [OrderNo] NVARCHAR(50) NOT NULL,
    [OrderDate] DATETIME NOT NULL DEFAULT (GETDATE()),
    [OrderSourceId] INT NOT NULL,
    [PaymentMethodId] INT NULL,
    [PaymentStatusId] INT NULL,
    [ShippingTypeId] INT NULL,
    [CustomerId] UNIQUEIDENTIFIER NULL,
    [EmployeeId] INT NULL,
    [ServingTableId] UNIQUEIDENTIFIER NULL,
    [TotalAmount] DECIMAL(18, 2) NOT NULL DEFAULT (0),
    [DiscountAmount] DECIMAL(18, 2) NULL,
    [TaxAmount] DECIMAL(18, 2) NULL,
    [GrandTotal] DECIMAL(18, 2) NOT NULL DEFAULT (0),
    [CustomerRemarks] NVARCHAR(500) NULL,
    [OfficeRemarks] NVARCHAR(500) NULL,
    [CreatedBy] INT NULL,
    [CreatedDate] DATETIME NOT NULL DEFAULT (GETDATE()),
    [UpdatedBy] INT NULL,
    [UpdatedDate] DATETIME NULL
);

-- Self reference
ALTER TABLE INV.OrderMaster
ADD CONSTRAINT FK_OrderMaster_Parent
FOREIGN KEY (ParentOrderId) REFERENCES INV.OrderMaster(OrderMasterId);

-- Reference to ServingTable
ALTER TABLE INV.OrderMaster
ADD CONSTRAINT FK_OrderMaster_ServingTable
FOREIGN KEY (ServingTableId) REFERENCES AST.ServingTables(ServingTableId);



CREATE TABLE INV.OrderDetail (
    [OrderDetailId] UNIQUEIDENTIFIER NOT NULL,
    [OrderMasterId] UNIQUEIDENTIFIER NOT NULL,
    [ProductId] UNIQUEIDENTIFIER NOT NULL,
    [VariantId] UNIQUEIDENTIFIER NULL,
    [Quantity] DECIMAL(18, 2) NOT NULL,
    [UnitPrice] DECIMAL(18, 2) NOT NULL,
    [TaxRate] DECIMAL(5, 2) NULL,
    [TaxAmount] DECIMAL(18, 2) NULL,
    [LineTotal] DECIMAL(18, 2) NOT NULL,
    [LineTotalWithTax] DECIMAL(18, 2) NOT NULL,
    [Discount] DECIMAL(18, 2) NULL,
    [Remarks] NVARCHAR(500) NULL,
    [CreatedDate] DATETIME NOT NULL DEFAULT (GETDATE()),
    CONSTRAINT PK_OrderDetail PRIMARY KEY (OrderDetailId),
    CONSTRAINT FK_OrderDetail_OrderMaster FOREIGN KEY (OrderMasterId) REFERENCES INV.OrderMaster(OrderMasterId),
    CONSTRAINT FK_OrderDetail_Product FOREIGN KEY (ProductId) REFERENCES INV.Products(ProductId),
    CONSTRAINT FK_OrderDetail_ProductVariant FOREIGN KEY (VariantId) REFERENCES INV.ProductVariants(VariantId)
);

CREATE TABLE [INV].[OrderStatus]
(
    OrderStatusId INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    OrderStatusName NVARCHAR(500) NOT NULL
);


INSERT INTO [INV].[OrderStatus] (OrderStatusName)
VALUES 
    (N'Pending'),
    (N'Confirmed'),
    (N'Processing'),
    (N'Shipped'),
    (N'Delivered'),
    (N'Cancelled');

	-- Add the column to OrderMaster
ALTER TABLE [INV].[OrderMaster]
ADD OrderStatusId INT NOT NULL CONSTRAINT DF_OrderMaster_OrderStatusId DEFAULT(1);

-- Create the foreign key relation
ALTER TABLE [INV].[OrderMaster]
ADD CONSTRAINT FK_OrderMaster_OrderStatus
FOREIGN KEY (OrderStatusId) REFERENCES [INV].[OrderStatus](OrderStatusId);
