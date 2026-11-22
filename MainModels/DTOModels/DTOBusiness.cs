using MainModels.Models;

namespace MainModels.DTOModels
{
    public class DTOBusiness
    {
    }
    public class OrganizationRegistrationDto
    {
        public string BusinessName { get; set; }
        public string BranchName { get; set; }
        public string Website { get; set; }
        public short BusinessCategory { get; set; }
        public short BusinessEntity { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
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
    public partial class BranchVM
    {
        public Guid BranchId { get; set; }
        public bool? IsMasterBranch { get; set; }

        public string BranchName { get; set; }
        public string OrganizationName { get; set; }
        public int? OrganizationId { get; set; }

        public short? BusinessCategoryId { get; set; }

        public int? BusinessStoreTypeId { get; set; }

        public short? BusinessEntityTypeId { get; set; }

        public string BranchCode { get; set; }
        public string? Address { get; set; }

        public string? Email { get; set; }

        public string? Phone { get; set; }

        public int? CityId { get; set; }
        public string CityName { get; set; }

        public OrganizationVM Organization { get; set; }
    }

    //public partial class BusinessVM
    //{
    //    public int BusinessId { get; set; }
    //    public string BusinessName { get; set; }
    //    public short? BusinessEntityTypeId { get; set; }
    //    public string? BusinessEntityTypeName { get; set; }
    //    public short? BusinessCategoryId { get; set; }
    //    public string? BusinessCategoryName { get; set; }
    //    public bool IsActive { get; set; }
    //    public DateTime? CreatedOn { get; set; }
    //    public int? CreatedBy { get; set; }
    //    public DateTime? ModifiedOn { get; set; }
    //    public string Address { get; set; }
    //    public string City { get; set; }
    //    public string Country { get; set; }
    //    public string ContactNumber { get; set; }
    //    public string Mobile { get; set; }
    //    public string Ntn { get; set; }
    //    public string BusinessEmail { get; set; }
    //    public string WebSite { get; set; }
    //    public string Action { get; set; } = "SomeString";
    //    public int OrganizationId { get; set; }
    //    public string OrganizationName { get; set; }
    //    public bool IsDeleted { get; set; }
    //}

    public partial class BusinessEntityTypeVM
    {
        public short BusinessEntityTypeId { get; set; }
        public string BusinessEntityTypeName { get; set; }

        public bool? IsActive { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public int? CreatedBy { get; set; }
    }
    public class BranchLicenseStatusVM
    {
        public Guid BranchId { get; set; }
        public string? BranchName { get; set; }

        // Overall access state
        public bool IsLicensed { get; set; }
        public bool IsInGracePeriod { get; set; }
        public bool IsExpired { get; set; }
        public bool IsFingerprintMismatch { get; set; }
        public bool IsClockRollbackDetected { get; set; }

        // Key / limits info
        public string? RequestCode { get; set; }
        public string? ServerFingerprint { get; set; }
        public DateTime? ExpiryDateUtc { get; set; }
        public DateTime? GraceUntilDateUtc { get; set; }
        public int AllowedTills { get; set; }
        public int? DaysRemaining { get; set; }

        // User-facing or UI banner message
        public string StatusCode { get; set; } = "UNLICENSED"; // e.g. ACTIVE, GRACE, EXPIRED, FINGERPRINT_MISMATCH, UNLICENSED
        public string Message { get; set; } = string.Empty;

        // Optional underlying record if needed by views/admin
        public BranchLicenseVM? License { get; set; }
    }
    public partial class BranchLicenseVM
    {
        public int Id { get; set; }

        public Guid BranchId { get; set; }

        public string RequestCode { get; set; }

        public string ServerFingerprint { get; set; }

        public string LicenseKey { get; set; }

        public DateTime? ExpiryDate { get; set; }

        public int AllowedTills { get; set; }

        public bool IsActive { get; set; }

        public DateTime? LastValidatedOn { get; set; }

        public DateTime? ActivatedOn { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public virtual BranchVM Branch { get; set; }
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
