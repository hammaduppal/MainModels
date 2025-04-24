namespace MainModels.DTOModels
{
    public class DTOBusiness
    {
    }
    public partial class OrganizationVM
    {
        public int OrganizationId { get; set; }
        public string OrganizationName { get; set; }
        public string BranchCode { get; set; }
        public bool IsActive { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? CreatedBy { get; set; }
        public bool IsDeleted { get; set; }

    }

    public partial class BusinessVM
    {
        public int BusinessId { get; set; }
        public string BusinessName { get; set; }
        public short? BusinessEntityTypeId { get; set; }
        public string? BusinessEntityTypeName { get; set; }
        public short? BusinessCategoryId { get; set; }
        public string? BusinessCategoryName { get; set; }
        public bool IsActive { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string ContactNumber { get; set; }
        public string Mobile { get; set; }
        public string Ntn { get; set; }
        public string BusinessEmail { get; set; }
        public string WebSite { get; set; }
        public string Action { get; set; } = "SomeString";
        public int OrganizationId { get; set; }
        public string OrganizationName { get; set; }
        public bool IsDeleted { get; set; }
    }

    public partial class BusinessEntityTypeVM
    {
        public short BusinessEntityTypeId { get; set; }
        public string BusinessEntityTypeName { get; set; }

        public bool? IsActive { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public int? CreatedBy { get; set; }
    }


    public partial class BusinessCategoryVM
    {
        public short BusinessCategoryId { get; set; }
        public string BusinessCategoryName { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? Createdby { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool? IsActive { get; set; }
    }


}
