

using MainModels.Models;
using Newtonsoft.Json;

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
        public List<SubCategoryVM>? SubCategories { get; set; }
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
        public List<CategoryVM>? Categories { get; set; }
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
        public string? SubCategorySlug { get; set; }
        public string? CategorySlug { get; set; }
        public string? DepartmentSlug { get; set; }
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
        public Guid? BrandModelId { get; set; }
        public string? ModelName { get; set; }
    

        public List<ProductVariantVM> ProductVariants { get; set; }
        public virtual ICollection<ProductImageVM> ProductImages { get; set; } = new List<ProductImageVM>();

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
    public class AddItemToCartVM
    {
        public Guid CartId { get; set; }
        public ProductVariantVM Item { get; set; }
    }
    public partial class ProductVariantVM
    {
        public Guid VariantId { get; set; }
        public Guid? TaxSlabId { get; set; }
        public decimal TaxRate { get; set; }

        public Guid? MaterialId { get; set; }

        public Guid? ColorId { get; set; }
        public Guid? SizeId { get; set; }
        public Guid? SubCategoryId { get; set; }
        public Guid? ProductId { get; set; }

        public decimal? QoH { get; set; }
        public decimal? Qty { get; set; }


        public decimal? Cost { get; set; }

        public string BarCode { get; set; }

        public decimal? SalePrice { get; set; }

        public decimal? PromotionPrice { get; set; }

        public decimal? RetailPrice { get; set; }
        public decimal? CurrentPrice { get; set; }

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
        public List<BranchStockVM> BranchStock { get; set; }
        public List<BranchVM> AllowedBranches { get; set; }
        public string ImageUrl { get; set; }
        public string SubCategoryName { get; set; }
        public int? ProductType { get; set; }

    }
    public class SubCategoryProductsVM
    {
        public Guid? SubCategoryId { get; set; }
        public string? SubCategoryName { get; set; }
        public List<ProductVariantVM>? Products { get; set; }
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
    public class DCSNameAndSlug
    {
        public string? SubCategoryName { get; set; }
        public string? CategoryName { get; set; }
        public string? DepartmentName { get; set; }
        public string? SubCategorySlug { get; set; }
        public string? CategorySlug { get; set; }
        public string? DepartmentSlug { get; set; }
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
        public string? HarmonizedSystemCode { get; set; }
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
        public Guid? ServingTableId { get; set; }
        public Guid? CustomerId { get; set; }
        public int? PaymentMethodId { get; set; }
        public int PurchaseTypeId { get; set; }
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
    public class ProductSearchVM
    {
        public string SearchParams { get; set; }
    }

    public partial class PaymentMethodVM
    {
        public int PaymentMethodId { get; set; }

        public string Name { get; set; }

        public bool? IsActive { get; set; }

        public DateTime? CreatedOn { get; set; }
    }
    public partial class InvoiceMasterVM
    {

        public Guid InvoiceMasterId { get; set; }
        public string InvoiceNo { get; set; }
        public DateTime InvoiceDate { get; set; }
        public Guid? ParentInvoiceId { get; set; }

        public int ShippingTypeId { get; set; }
        public Guid? CustomerId { get; set; }
        public Guid? ServingTableId { get; set; }
        public int? EmployeeId { get; set; }

        public decimal TotalAmount { get; set; }
        public decimal? DiscountAmount { get; set; }
        public decimal? TotalTax { get; set; }
        public decimal? TaxAmount { get; set; }
        public decimal? ShippingCharges { get; set; }
        public decimal? ServiceCharges { get; set; }
        public decimal GrandTotal { get; set; }
        public decimal AmountPaid { get; set; }
        public decimal BalanceDue { get; set; }
        public DateTime? DueDate { get; set; }

        public int PaymentMethodId { get; set; }
        public int PaymentStatusId { get; set; }
        public string TransactionReference { get; set; }

        public string CurrencyCode { get; set; }
        public decimal ExchangeRate { get; set; }

        public string CustomerRemarks { get; set; }
        public string OfficeRemarks { get; set; }

        //public int InvoiceStatusId { get; set; }
        public bool IsReturn { get; set; }
        public Guid? ReturnInvoiceId { get; set; }

        public int? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public virtual ICollection<InvoiceDetailVM> InvoiceDetails { get; set; } = new List<InvoiceDetailVM>();

        public virtual PaymentMethodVM PaymentMethod { get; set; }


        public InvoiceSourceVM? InvoiceSource { get; set; }

        public OrderStatusVM? OrderStatus { get; set; }


        public PaymentStatusVM? PaymentStatus { get; set; }

        public ServingTableVM? ServingTable { get; set; }

        public ShippingTypeVM? ShippingType { get; set; }
        public EmployeeVM? Employee { get; set; }
        public CustomerVM? Customer { get; set; }
    }
    public partial class InvoiceDetailVM
    {
        public Guid InvoiceDetailId { get; set; }
        public Guid InvoiceMasterId { get; set; }

        public Guid ProductId { get; set; }
        public Guid? VariantId { get; set; }

        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        public decimal TaxRate { get; set; }
        public decimal TaxAmount { get; set; }

        public decimal LineTotal { get; set; }
        public decimal LineTotalWithTax { get; set; }

        public decimal? Discount { get; set; }
        public string Remarks { get; set; }

        public virtual InvoiceMasterVM InvoiceMaster { get; set; }
        public virtual ProductVM Product { get; set; }
        public virtual ProductVariantVM Variant { get; set; }
    }

    public partial class BranchStockVM
    {
        public Guid BranchStockId { get; set; }

        public Guid? ProductVariantId { get; set; }

        public Guid? BranchId { get; set; }

        public decimal? SalePrice { get; set; }

        public decimal? RetailPrice { get; set; }

        public decimal? PromotionPrice { get; set; }

        public decimal? StaffPrice { get; set; }

        public decimal? Cost { get; set; }

        public decimal Qty { get; set; }

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime CreatedOn { get; set; }

        public int? CreatedBy { get; set; }
    }
    public partial class InvoiceSourceVM
    {
        public int InvoiceSourceId { get; set; }

        public string SourceName { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

    }


    public partial class OrderMasterVM
    {
        public Guid OrderMasterId { get; set; }

        public Guid? ParentOrderId { get; set; }

        public string OrderNo { get; set; }

        public DateTime OrderDate { get; set; }

        public int? OrderSourceId { get; set; }

        public int? PaymentMethodId { get; set; }

        public int? PaymentStatusId { get; set; }

        public int? ShippingTypeId { get; set; }

        public Guid? CustomerId { get; set; }

        public int? EmployeeId { get; set; }

        public Guid? ServingTableId { get; set; }

        public decimal? TotalAmount { get; set; }

        public decimal? DiscountAmount { get; set; }

        public decimal? TaxAmount { get; set; }

        public decimal? GrandTotal { get; set; }

        public string CustomerRemarks { get; set; }

        public string OfficeRemarks { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public int OrderStatusId { get; set; }

        public ICollection<OrderMasterVM> InverseParentOrder { get; set; } = new List<OrderMasterVM>();

        public ICollection<OrderDetailVM> OrderDetails { get; set; } = new List<OrderDetailVM>();

        public InvoiceSourceVM? OrderSource { get; set; }

        public OrderStatusVM? OrderStatus { get; set; }

        public OrderMasterVM? ParentOrder { get; set; }

        public PaymentStatusVM? PaymentStatus { get; set; }

        public ServingTableVM? ServingTable { get; set; }

        public ShippingTypeVM? ShippingType { get; set; }
        public EmployeeVM? Employee { get; set; }
        public CustomerVM? Customer { get; set; }
        public PaymentMethodVM? PaymentMethod { get; set; }

    }
    public partial class OrderDetailVM
    {
        public Guid OrderDetailId { get; set; }

        public Guid OrderMasterId { get; set; }

        public Guid ProductId { get; set; }

        public Guid VariantId { get; set; }

        public decimal? Quantity { get; set; }

        public decimal? UnitPrice { get; set; }

        public decimal? TaxRate { get; set; }

        public decimal? TaxAmount { get; set; }

        public decimal? LineTotal { get; set; }

        public decimal? LineTotalWithTax { get; set; }

        public decimal? Discount { get; set; }

        public string Remarks { get; set; }

        public DateTime CreatedDate { get; set; }

        public virtual OrderMasterVM OrderMaster { get; set; }

        public virtual ProductVM Product { get; set; }

        public virtual ProductVariantVM Variant { get; set; }
    }

    public partial class OrderStatusVM
    {
        public int OrderStatusId { get; set; }

        public string OrderStatusName { get; set; }
    }
    public partial class ShippingTypeVM
    {
        public int ShippingTypeId { get; set; }

        public string Name { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedOn { get; set; }

        public virtual ICollection<InvoiceMasterVM> InvoiceMasters { get; set; } = new List<InvoiceMasterVM>();

        public virtual ICollection<OrderMasterVM> OrderMasters { get; set; } = new List<OrderMasterVM>();
    }
    public partial class PaymentStatusVM
    {
        public int PaymentStatusId { get; set; }

        public string Name { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedOn { get; set; }

        public virtual ICollection<InvoiceMasterVM> InvoiceMasters { get; set; } = new List<InvoiceMasterVM>();

        public virtual ICollection<OrderMasterVM> OrderMasters { get; set; } = new List<OrderMasterVM>();


    }
    public class BrandModelVM
    {
        public Guid BrandModelId { get; set; }

        public string ModelName { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public Guid BrandId { get; set; }

        public BrandVM Brand { get; set; }
    }


    public class InvoiceRequestFBR
    {
        public string InvoiceType { get; set; } = "Sale Invoice";
        public string InvoiceDate { get; set; } =   DateTime.Now.ToString("yyyy-MM-dd");
        public string SellerNTNCNIC { get; set; }
        public string SellerBusinessName { get; set; }
        public string SellerProvince { get; set; }
        public string SellerAddress { get; set; }
        public string BuyerNTNCNIC { get; set; }
        public string BuyerBusinessName { get; set; }
        public string BuyerProvince { get; set; }
        public string BuyerAddress { get; set; }
        public string BuyerRegistrationType { get; set; }
        public string InvoiceRefNo { get; set; }
        public string ScenarioId { get; set; }

        public List<InvoiceItemFBR> Items { get; set; }
    }

    public class InvoiceItemFBR
    {
        public string HsCode { get; set; }
        public string ProductDescription { get; set; }
        public string Rate { get; set; }
        public string UoM { get; set; }
        public decimal Quantity { get; set; }
        public decimal TotalValues { get; set; }
        public decimal ValueSalesExcludingST { get; set; }
        public decimal FixedNotifiedValueOrRetailPrice { get; set; }
        public decimal SalesTaxApplicable { get; set; }
        public decimal SalesTaxWithheldAtSource { get; set; }
        public decimal ExtraTax { get; set; }
        public decimal FurtherTax { get; set; }
        public string SroScheduleNo { get; set; }
        public decimal FedPayable { get; set; }
        public decimal Discount { get; set; }
        public string SaleType { get; set; }
        public string SroItemSerialNo { get; set; }
    }
    public class ErrorResponseFBR
    {
        [JsonProperty("invoiceNumber")]
        public string InvoiceNumber { get; set; }

        [JsonProperty("dated")]
        public string Dated { get; set; }

        [JsonProperty("validationResponse")]
        public ValidationResponseFBR ValidationResponse { get; set; }
    }

    public class ValidationResponseFBR
    {
        [JsonProperty("statusCode")]
        public string StatusCode { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("error")]
        public string Error { get; set; }

        [JsonProperty("invoiceStatuses")]
        public List<InvoiceStatusFBR> InvoiceStatuses { get; set; }
    }

    public class InvoiceStatusFBR
    {
        [JsonProperty("itemSNo")]
        public string ItemSNo { get; set; }

        [JsonProperty("statusCode")]
        public string StatusCode { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("invoiceNo")]
        public string InvoiceNo { get; set; }

        [JsonProperty("errorCode")]
        public string ErrorCode { get; set; }

        [JsonProperty("error")]
        public string Error { get; set; }
    }
    public partial class PurchaseTypeVM
    {
        public int PurchaseTypeId { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public bool IsActive { get; set; }

        public int SortOrder { get; set; }

        public DateTime CreatedOn { get; set; }

        public int? CreatedBy { get; set; }

    }

    public partial class CartMasterVM
    {
        public Guid CartId { get; set; }

        public Guid? CustomerId { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public bool? IsCheckedOut { get; set; }

        public Guid? SessionId { get; set; }

        public virtual ICollection<CartDetailVM> CartDetails { get; set; } = new List<CartDetailVM>();
    }
    public partial class CartDetailVM
    {
        public Guid CartDetailId { get; set; }

        public Guid CartId { get; set; }

        public Guid ProductId { get; set; }

        public Guid? VariantId { get; set; }
        public string ProductName { get; set; }
        public decimal Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal? Discount { get; set; }

        public decimal? Tax { get; set; }

        public decimal? TotalAmount { get; set; }
        public string ImageUrl { get; set; }

        public virtual CartMasterVM Cart { get; set; }

        public virtual ProductVM Product { get; set; }

        public virtual ProductVariantVM Variant { get; set; }
    }
   
    #region RequestVMs
    public class ProductRequestVM
    {
        public Guid ProductId { get; set; }
        public string ProductSlug { get; set; }

    }
    #endregion
}
