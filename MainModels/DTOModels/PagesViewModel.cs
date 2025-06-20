using MainModels.Util;

namespace MainModels.DTOModels
{
    public class PagesViewModel
    {
        public List<LoginUserVM> LoginUsers { get; set; }
        public LoginUserVM LoginUser { get; set; }
        public List<RolesVM> Roles { get; set; }
        public List<CountryVM> Countries { get; set; }
        public IEnumerable<BusinessEntityTypeVM> BusinessEntities { get; set; }

        public List<DepartmentVM>? Departments { get; set; }
        public List<CategoryVM>? Categories { get; set; }
        public List<UomVM>? UOMs { get; set; }
        public List<UomsubVM>? SubUOMs { get; set; }
        public List<SizeVM> Sizes { get; set; }
        public List<ColorVM> Colors { get; set; }
        public List<MaterialVM> Materials { get; set; }
        public List<ProductVariantVM> ProductVariants { get; set; }
        public List<ProductImageVM> ProductImages { get; set; }
        public List<BrandVM> Brands { get; set; }
        public ProductVM Product { get; set; }
        public static DashBoardSettings DashBoardSetting { get; set; }
        public static SystemSettings SystemSettings { get; set; }
        public static ThemeSettings? ThemeSettings { get; set; }
        public IEnumerable<OrganizationVM> Organizations { get; set; }

        public IEnumerable<BusinessCategoryVM> BusinessCategories { get; set; }
      
        public  DTOPermissionModels Permission { get; set; }
    }
    public class ThemeSettings
    {
        public string ToggleSideBar { get; set; } = "";
        public string TemplateColor { get; set; } = "";

    }
    public class SystemSettings
    {
        public string ContentAPIUrl { get; set; }
        public string CompanyCode { get; set; }
        public string BranchId { get; set; }
        public int DecimalPoint { get; set; }


    }
    public class UploadImage()
    {
        public string Id { get; set; }
        public IFormFile File { get; set; }
    }
    public class APIImageContentRequest
    {
        public string? Base64String { get; set; }
        public string? Website { get; set; }
        public string? Folder { get; set; }
        public string? DataType { get; set; }
        public string? FileExtension { get; set; }
    }
    public class APIImageContentResponse
    {
        public string ImageUrl { get; set; }
        public string StatusCode { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }
    }

    public class RequestModel
    {
        public Guid ProductId { get; set; }
        public Guid ProductImageId { get; set; }
        public Guid? UOMId { get; set; }
        public bool IsActive { get; set; }
        public Guid? VariantId { get; set; }
        public string PriceFormat { get; set; }
    }
    public class UpdateVariantModel
    {
        public string DataType { get; set; }
        public Guid VariantId { get; set; }
        public string Value { get; set; }
    }
    public class DashBoardSettings
    {
        public int TotalProducts { get; set; }
        public int TotalVariants { get; set; }
    }
    public class SecretLock
    {
        public string UnlockKey { get; set; }
    }
   
}