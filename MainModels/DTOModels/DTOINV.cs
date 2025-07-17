namespace MainModels.DTOModels
{
    public class CategoryVM
    {
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }
        public Guid? DepartmentId { get; set; }
        public Guid? BusinessStoreId { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? Createdby { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
    }
    public class ColorVM
    {
        public Guid ColorId { get; set; }
        public string ColorName { get; set; }
        public Guid? BusinessStoreId { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? Createdby { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
    }

    public class DepartmentVM
    {
        public Guid DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public Guid? BusinessStoreId { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? Createdby { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
    }

    public partial class MaterialVM
    {
        public Guid MaterialId { get; set; }
        public string MaterialName { get; set; }
        public Guid? BusinessStoreId { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? Createdby { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
    }

    public partial class ProductVM
    {
        public Guid ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public decimal? Qoh { get; set; }
        public Guid? SubCategoryId { get; set; }
        public string? SubCategoryName { get; set; }
        public string? CategoryName { get; set; }
        public string? DepartmentName { get; set; }
        public BrandVM Brand { get; set; }
        public Guid? BusinessStoreId { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? Createdby { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public string ImageUrl { get; set; }
        public Guid? UOMId { get; set; }
        public string? UOMName { get; set; }
        public Guid BrandId { get; set; }
        public string BrandName { get; set; }
    }

    public partial class ProductImageVM
    {
        public Guid ProductImageId { get; set; }
        public string ImageUrl { get; set; }
        public string Caption { get; set; }
        public short? Priority { get; set; }
        public Guid? ProductId { get; set; }
        public bool IsDefault { get; set; }
        public Guid? BusinessStoreId { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? Createdby { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
    }

    public partial class ProductVariantVM
    {
        public Guid VariantId { get; set; }

        public Guid? MaterialId { get; set; }

        public Guid? ColorId { get; set; }

        public Guid? SizeId { get; set; }

        public Guid? ProductId { get; set; }

        public decimal? QoH { get; set; }

        public decimal? Cost { get; set; }

        public string BarCode { get; set; }

        public decimal? SalesPrice { get; set; }

        public decimal? PromotionPrice { get; set; }

        public decimal? RetailPrice { get; set; }
        public int? MinQty { get; set; }
        public int? MaxQty { get; set; }

        public DateTime? LastPurchase { get; set; }

        public DateTime? LastSold { get; set; }

        public DateTime? CreatedOn { get; set; }

        public int? Createdby { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool? IsActive { get; set; }

        public bool? IsDeleted { get; set; }

        public Guid? BranchId { get; set; }

        public Guid? VariantImageId { get; set; }


        public string? ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public string? ProductSlug { get; set; }
        public string? ColorName { get; set; }
        public string? MaterialName { get; set; }
        public string? SizeName { get; set; }
        public string? UOMName { get; set; }
        public string? SubUOMName { get; set; }
        public Guid? Uomid { get; set; }
        public int? PriceFormat { get; set; }
        public Guid? SubUomid { get; set; }
        public string? BrandName { get; set; }
        public decimal? QuantityPerUnit { get; set; }
        public ProductVM Product { get; set; }
        public ColorVM Color { get; set; }
        public MaterialVM Material { get; set; }
        public SizeVM Size { get; set; }
        public bool? IsSerial { get; set; }


    }

    public partial class SizeVM
    {
        public Guid SizeId { get; set; }
        public string SizeName { get; set; }
        public Guid? BusinessStoreId { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? Createdby { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public string SizeSlug { get; set; }
    }
    public partial class SubCategoryVM
    {
        public Guid SubCategoryId { get; set; }
        public string SubCategoryName { get; set; }
        public Guid? CategoryId { get; set; }
        public Guid? BusinessStoreId { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? Createdby { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
    }
    public partial class UomVM
    {
        public Guid Uomid { get; set; }
        public string UOMName { get; set; }
        public string Uomtype { get; set; }
        public Guid? BusinessStoreId { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? Createdby { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
    }

    public partial class UomsubVM
    {
        public Guid SubUomId { get; set; }
        public Guid? UOMId { get; set; }
        public string SubUOMName { get; set; }
        public decimal? ConversionFactor { get; set; }
        public Guid? BusinessStoreId { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? Createdby { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
    }
    public class BrandVM
    {
        public Guid BrandId { get; set; }
        public string? BrandName { get; set; }
        public string? BrandSlug { get; set; }
        public Guid? BranchId { get; set; }

        public DateTime? CreatedOn { get; set; }

        public int? Createdby { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool? IsActive { get; set; }

        public bool? IsDeleted { get; set; }

        public bool? IsDefault { get; set; }
    }
    public class PurchaseDataDto
    {
        public List<BillItems> Items { get; set; }
        public decimal Discount { get; set; }
        public decimal GrandTotal { get; set; }
        public int SupplierId { get; set; }
        public Guid BranchId { get; set; }
    }

    public class BillItems
    {
        public Guid ProductId { get; set; }
        public Guid VariantId { get; set; }
        public string BarCode { get; set; }
        public decimal Quantity { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal TotalPrice { get; set; }
    }

}
