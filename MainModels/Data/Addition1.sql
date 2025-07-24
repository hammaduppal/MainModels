USE [inspirenation_main_dev]
GO
/****** Object:  Table [INV].[PurchaseDetail]    Script Date: 12/07/2025 3:26:44 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [INV].[PurchaseDetail](
	[PurchaseDetailId] [uniqueidentifier] NOT NULL,
	[PurchaseMasterId] [uniqueidentifier] NOT NULL,
	[VariantId] [uniqueidentifier] NULL,
	[Qty] [decimal](18, 2) NULL,
	[UnitPrice] [decimal](18, 2) NULL,
	[TotalPrice]  AS ([Qty]*[UnitPrice]) PERSISTED,
	[DiscountAmount] [decimal](18, 2) NULL,
	[LineTotal]  AS ([Qty]*[UnitPrice]-[DiscountAmount]) PERSISTED,
	[IsActive] [bit] NULL,
	[CreatedOn] [datetime] NULL,
	[Createdby] [int] NULL,
	[ModifiedOn] [datetime] NULL,
 CONSTRAINT [PK_PurchaseDetail] PRIMARY KEY CLUSTERED 
(
	[PurchaseDetailId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [INV].[PurchaseMaster]    Script Date: 12/07/2025 3:26:44 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [INV].[PurchaseMaster](
	[PurchaseMasterId] [uniqueidentifier] NOT NULL,
	[PurchaseNumber] [nvarchar](50) NULL,
	[PurchaseType] [int] NULL,
	[SupplierId] [int] NULL,
	[PurchaseDate] [datetime] NULL,
	[DiscountAmount] [decimal](18, 2) NULL,
	[TotalAmount] [decimal](18, 2) NULL,
	[GrandTotal] [decimal](18, 2) NULL,
	[Status] [int] NULL,
	[Remarks] [nvarchar](500) NULL,
	[UpdatedBy] [uniqueidentifier] NULL,
	[UpdatedDate] [datetime] NULL,
	[IsActive] [bit] NULL,
	[CreatedOn] [datetime] NULL,
	[Createdby] [int] NULL,
	[ModifiedOn] [datetime] NULL,
	[BranchId] [uniqueidentifier] NULL,
	[OrganizationId] [int] NULL,
 CONSTRAINT [PK__Purchase__5450C11901866B34] PRIMARY KEY CLUSTERED 
(
	[PurchaseMasterId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UQ__Purchase__373B5B6EE9029448] UNIQUE NONCLUSTERED 
(
	[PurchaseNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [INV].[PurchaseDetail] ADD  CONSTRAINT [DF__PurchaseD__Disco__17C286CF]  DEFAULT ((0)) FOR [DiscountAmount]
GO
ALTER TABLE [INV].[PurchaseMaster] ADD  CONSTRAINT [DF__PurchaseM__Purch__0880433F]  DEFAULT ((1)) FOR [PurchaseType]
GO
ALTER TABLE [INV].[PurchaseMaster] ADD  CONSTRAINT [DF__PurchaseM__Purch__09746778]  DEFAULT (getdate()) FOR [PurchaseDate]
GO
ALTER TABLE [INV].[PurchaseMaster] ADD  CONSTRAINT [DF__PurchaseM__Disco__0A688BB1]  DEFAULT ((0)) FOR [DiscountAmount]
GO
ALTER TABLE [INV].[PurchaseMaster] ADD  CONSTRAINT [DF__PurchaseM__Total__0B5CAFEA]  DEFAULT ((0)) FOR [TotalAmount]
GO
ALTER TABLE [INV].[PurchaseMaster] ADD  CONSTRAINT [DF__PurchaseM__Grand__0C50D423]  DEFAULT ((0)) FOR [GrandTotal]
GO
ALTER TABLE [INV].[PurchaseMaster] ADD  CONSTRAINT [DF__PurchaseM__Statu__0D44F85C]  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [INV].[PurchaseDetail]  WITH CHECK ADD  CONSTRAINT [FK__PurchaseD__Purch__15DA3E5D] FOREIGN KEY([PurchaseMasterId])
REFERENCES [INV].[PurchaseMaster] ([PurchaseMasterId])
GO
ALTER TABLE [INV].[PurchaseDetail] CHECK CONSTRAINT [FK__PurchaseD__Purch__15DA3E5D]
GO
ALTER TABLE [INV].[PurchaseDetail]  WITH CHECK ADD  CONSTRAINT [FK__PurchaseD__Varia__16CE6296] FOREIGN KEY([VariantId])
REFERENCES [INV].[ProductVariants] ([VariantId])
GO
ALTER TABLE [INV].[PurchaseDetail] CHECK CONSTRAINT [FK__PurchaseD__Varia__16CE6296]
GO


------------------------------------------------
USE [InspireErp_Dev]
GO
/****** Object:  Table [SYSTEM].[Notifications]    Script Date: 25/07/2025 12:20:20 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [SYSTEM].[Notifications](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Message] [nvarchar](max) NOT NULL,
	[Params] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NULL,
	[GroupName] [nvarchar](255) NULL,
	[IsRead] [bit] NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[NotificationTypeId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [SYSTEM].[NotificationTypes]    Script Date: 25/07/2025 12:20:20 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [SYSTEM].[NotificationTypes](
	[NotificationTypeId] [int] NOT NULL,
	[NotificationTypeName] [nvarchar](500) NULL,
 CONSTRAINT [PK_NotificationTypes] PRIMARY KEY CLUSTERED 
(
	[NotificationTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [SYSTEM].[Notifications] ADD  DEFAULT ((0)) FOR [IsRead]
GO
ALTER TABLE [SYSTEM].[Notifications] ADD  DEFAULT (getutcdate()) FOR [CreatedAt]
GO
ALTER TABLE [SYSTEM].[Notifications]  WITH CHECK ADD  CONSTRAINT [FK_Notifications_NotificationTypes] FOREIGN KEY([NotificationTypeId])
REFERENCES [SYSTEM].[NotificationTypes] ([NotificationTypeId])
GO
ALTER TABLE [SYSTEM].[Notifications] CHECK CONSTRAINT [FK_Notifications_NotificationTypes]
GO
-------------------------------------------
 


 CREATE TABLE [INV].[InvoiceMaster] (
    InvoiceMasterId UNIQUEIDENTIFIER PRIMARY KEY,
    InvoiceNo VARCHAR(50) NOT NULL,
    InvoiceDate DATETIME NOT NULL,
    CustomerId UNIQUEIDENTIFIER NULL, -- FK to Customers table
    TotalAmount DECIMAL(18, 2) NOT NULL,
    DiscountAmount DECIMAL(18, 2) DEFAULT 0,
    TaxAmount DECIMAL(18, 2) DEFAULT 0,
    NetAmount AS (TotalAmount - DiscountAmount + TaxAmount) PERSISTED,
    PaymentMethod VARCHAR(50),
    PaymentStatus VARCHAR(50),
    Remarks NVARCHAR(500),
    CreatedBy INT,
    CreatedDate DATETIME DEFAULT GETDATE(),
    UpdatedBy INT,
    UpdatedDate DATETIME
);
------------------------------------------------
CREATE TABLE [INV].[InvoiceDetail] (
    InvoiceDetailId UNIQUEIDENTIFIER PRIMARY KEY,
    InvoiceMasterId UNIQUEIDENTIFIER NOT NULL,
    ProductId UNIQUEIDENTIFIER NOT NULL,
    VariantId UNIQUEIDENTIFIER NULL,
    Quantity DECIMAL(18, 2) NOT NULL,
    UnitPrice DECIMAL(18, 2) NOT NULL,
    Discount DECIMAL(18, 2) DEFAULT 0,
    Tax DECIMAL(18, 2) DEFAULT 0,
    TotalAmount AS ((Quantity * UnitPrice) - Discount + Tax) PERSISTED,
    Remarks NVARCHAR(500),
    FOREIGN KEY (InvoiceMasterId) REFERENCES [INV].[InvoiceMaster](InvoiceMasterId),
    FOREIGN KEY (ProductId) REFERENCES [INV].[Products](ProductId),
    FOREIGN KEY (VariantId) REFERENCES [INV].[ProductVariants](VariantId)
);
------------------------------------------------
CREATE TABLE [INV].[CartMaster] (
    CartId UNIQUEIDENTIFIER PRIMARY KEY,
    CustomerId UNIQUEIDENTIFIER NULL,
    SessionId VARCHAR(100) NULL,
    CreatedDate DATETIME DEFAULT GETDATE(),
    UpdatedDate DATETIME,
    IsCheckedOut BIT DEFAULT 0
);
------------------------------------------------
CREATE TABLE [INV].[CartDetail] (
    CartDetailId UNIQUEIDENTIFIER PRIMARY KEY,
    CartId UNIQUEIDENTIFIER NOT NULL,
    ProductId UNIQUEIDENTIFIER NOT NULL,
    VariantId UNIQUEIDENTIFIER NULL,
    Quantity DECIMAL(18, 2) NOT NULL,
    UnitPrice DECIMAL(18, 2) NOT NULL,
    Discount DECIMAL(18, 2) DEFAULT 0,
    Tax DECIMAL(18, 2) DEFAULT 0,
    TotalAmount AS ((Quantity * UnitPrice) - Discount + Tax) PERSISTED,
    FOREIGN KEY (CartId) REFERENCES [INV].[CartMaster](CartId),
    FOREIGN KEY (ProductId) REFERENCES [INV].[Products](ProductId),
    FOREIGN KEY (VariantId) REFERENCES [INV].[ProductVariants](VariantId)
);
------------------------------------------------

BEGIN TRY
    BEGIN TRANSACTION;

    -- Create CollectionMaster Table
    CREATE TABLE [INV].[CollectionMaster]
    (
        CollectionId UNIQUEIDENTIFIER PRIMARY KEY,
        CollectionName NVARCHAR(200) NOT NULL,
        Description NVARCHAR(MAX) NULL,
        ImageUrl NVARCHAR(500) NULL,
        StartDate DATETIME NULL,
        EndDate DATETIME NULL,
        IsActive BIT NOT NULL DEFAULT 1,
        CreatedBy UNIQUEIDENTIFIER NULL,
        CreatedAt DATETIME NOT NULL DEFAULT GETDATE(),
        UpdatedBy UNIQUEIDENTIFIER NULL,
        UpdatedAt DATETIME NULL
    );

    -- Create CollectionDetail Table
    CREATE TABLE [INV].[CollectionDetail]
(
    CollectionDetailId UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    CollectionId UNIQUEIDENTIFIER NOT NULL,
    ProductId UNIQUEIDENTIFIER NOT NULL,
    VariantId UNIQUEIDENTIFIER NULL,
    SortOrder INT NULL,

    CONSTRAINT FK_CollectionDetail_CollectionMaster FOREIGN KEY (CollectionId)
        REFERENCES [INV].[CollectionMaster](CollectionId)
        ON DELETE CASCADE,

    CONSTRAINT FK_CollectionDetail_Product FOREIGN KEY (ProductId)
        REFERENCES [INV].[Products](ProductId)
        ON DELETE CASCADE,

    CONSTRAINT FK_CollectionDetail_Variant FOREIGN KEY (VariantId)
        REFERENCES [INV].[ProductVariants](VariantId)
        ON DELETE CASCADE
);


    COMMIT TRANSACTION;
    PRINT 'Tables created successfully.';
END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION;
    PRINT 'Error occurred. Transaction rolled back.';
    PRINT ERROR_MESSAGE();
END CATCH;
