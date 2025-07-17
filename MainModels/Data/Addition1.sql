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
