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

INSERT INTO Business.BusinessStoreType(BusinessStoreTypeId,BusinessStoreTypeName,IsActive,CreatedOn,ModifiedOn)
Values(1,'Branch',1,GETDATE(),GETDATE())
INSERT INTO Business.BusinessStoreType(BusinessStoreTypeId,BusinessStoreTypeName,IsActive,CreatedOn,ModifiedOn)
Values(2,'Franchise',1,GETDATE(),GETDATE())


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