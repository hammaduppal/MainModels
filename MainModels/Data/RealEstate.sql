INSERT INTO RealEstate.REContactType (
    REContactTypeId, 
    REContactTypeName, 
    CreatedOn, 
    CreatedBy, 
    ModifiedOn, 
    ModifiedBy
)
VALUES
    (1,  'Contractor',      GETDATE(), 1, NULL, NULL),
    (2,  'Mason',           GETDATE(), 1, NULL, NULL),
    (3,  'Laborer',         GETDATE(), 1, NULL, NULL),
    (4,  'LegalAdvisor',    GETDATE(), 1, NULL, NULL),
    (5,  'Supplier',        GETDATE(), 1, NULL, NULL),
    (6,  'Architect',       GETDATE(), 1, NULL, NULL),
    (7,  'CivilEngineer',   GETDATE(), 1, NULL, NULL),
    (8,  'Electrician',     GETDATE(), 1, NULL, NULL),
    (9,  'Plumber',         GETDATE(), 1, NULL, NULL),
    (10, 'Carpenter',       GETDATE(), 1, NULL, NULL),
    (11, 'Painter',         GETDATE(), 1, NULL, NULL),
    (12, 'SiteSupervisor',  GETDATE(), 1, NULL, NULL),
    (13, 'RealEstateAgent', GETDATE(), 1, NULL, NULL),
    (14, 'PropertyOwner',   GETDATE(), 1, NULL, NULL),
    (15, 'Tenant',          GETDATE(), 1, NULL, NULL),
    (16, 'Buyer',           GETDATE(), 1, NULL, NULL),
    (17, 'Investor',        GETDATE(), 1, NULL, NULL),
    (18, 'Surveyor',        GETDATE(), 1, NULL, NULL),
    (19, 'Valuer',          GETDATE(), 1, NULL, NULL),
    (20, 'SandSupplier',    GETDATE(), 1, NULL, NULL),
    (21, 'CrushSupplier',   GETDATE(), 1, NULL, NULL),
    (22, 'CementSupplier',  GETDATE(), 1, NULL, NULL),
    (23, 'InteriorSupplier',GETDATE(), 1, NULL, NULL),

    (99, 'Other',           GETDATE(), 1, NULL, NULL);


    INSERT INTO RealEstate.PropertySizeUnit (PropertySizeUnitId, PropertySizeUnitName)
VALUES 
    -- Primary Urban & Housing Society Units
    (1, N'Marla'),
    (2, N'Kanal'),
    (3, N'Square Feet'),
    (4, N'Square Yards'), -- Commonly referred to as 'Gaz' in Karachi/Sindh
    
    -- Large Land & Commercial Units
    (5, N'Acre'),
    (6, N'Hectare'),
    
    -- Traditional & Agricultural / Revenue Record Units (Punjab / KP / Rural)
    (7, N'Killa'),        -- 1 Killa = 1 Acre (8 Kanals)
    (8, N'Bigha'),        -- 1 Bigha = 4 Kanals (varies by region)
    (9, N'Murabba'),      -- 1 Murabba = 25 Acres / 200 Kanals
    (10, N'Biswa'),       -- 1/20th of a Bigha
    (11, N'Sarsahi'),     -- Also known as Karam (1/9th of a Marla)
    
    -- Modern / International Metric Units
    (12, N'Square Meters');



    
INSERT INTO RealEstate.REPropertyTypes (PropertyTypeId, PropertyTypeName)
VALUES 
    -- Main Categories
    (1,  N'Residential'),
    (2,  N'Commercial'),
    (3,  N'Agricultural'),
    (4,  N'Industrial'),

    -- Residential Types
    (5,  N'House / Villa'),
    (6,  N'Flat / Apartment'),
    (7,  N'Upper Portion'),
    (8,  N'Lower Portion'),
    (9,  N'Farm House'),
    (10, N'Penthouse'),
    (11, N'Room / Hostel'),
    (12, N'Residential Plot'),

    -- Commercial Types
    (13, N'Commercial Plot'),
    (14, N'Shop'),
    (15, N'Office'),
    (16, N'Plaza / Building'),
    (17, N'Showroom'),
    (18, N'Warehouse / Godown'),

    -- Agricultural Types
    (19, N'Agricultural Land'),
    (20, N'Farm Land'),
    (21, N'Poultry / Livestock Farm'),

    -- Industrial Types
    (22, N'Industrial Land'),
    (23, N'Factory');
