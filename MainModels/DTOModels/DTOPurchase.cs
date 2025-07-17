using MainModels.Models;

namespace MainModels.DTOModels
{
    public partial class PurchaseMasterVM
    {
        public Guid PurchaseMasterId { get; set; }

        public string PurchaseNumber { get; set; }

        public int? PurchaseType { get; set; }

        public int? SupplierId { get; set; }
        public string SupplierBusinessName { get; set; }
        public DateTime? PurchaseDate { get; set; }

        public decimal? DiscountAmount { get; set; }

        public decimal? TotalAmount { get; set; }

        public decimal? GrandTotal { get; set; }

        public int? Status { get; set; }

        public string Remarks { get; set; }

        public Guid? UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public bool? IsActive { get; set; }

        public DateTime? CreatedOn { get; set; }

        public int? Createdby { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public Guid? BranchId { get; set; }

        public int? OrganizationId { get; set; }
        public List<PurchaseDetailVM> PurchaseDetails { get; set; }
        public SupplierVM Supplier { get; set; }

    }

    public partial class PurchaseDetailVM
    {
        public Guid PurchaseDetailId { get; set; }

        public Guid PurchaseMasterId { get; set; }

        public Guid? VariantId { get; set; }

        public decimal? Qty { get; set; }

        public decimal? UnitPrice { get; set; }

        public decimal? TotalPrice { get; set; }

        public decimal? DiscountAmount { get; set; }

        public decimal? LineTotal { get; set; }

        public bool? IsActive { get; set; }

        public DateTime? CreatedOn { get; set; }

        public int? Createdby { get; set; }
        public ProductVariantVM ProductVariant { get; set; }
        public DateTime? ModifiedOn { get; set; }

    }

}
