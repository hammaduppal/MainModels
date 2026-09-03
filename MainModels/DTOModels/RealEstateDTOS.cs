



using MainModels.Models;
using System.ComponentModel.DataAnnotations;

namespace MainModels.DTOModels
{
    public  class ReaddressVM
    {
        public int ReaddressId { get; set; }

        public string ReaddressName { get; set; }

        public int? CityId { get; set; }

        public string ReaddressType { get; set; }

        public DateTime? CreatedOn { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public int? ModifiedBy { get; set; }

        public int? RecompanyContactId { get; set; }

        public virtual CityVM City { get; set; }

        public virtual RecompanyContactVM RecompanyContact { get; set; }
    }
    public  class RecompanyVM
    {
        public int RecompanyId { get; set; }

        public string RecontactName { get; set; }

        public DateTime? CreatedOn { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public int? ModifiedBy { get; set; }

        public virtual ICollection<RecompanyContactVM> RecompanyContacts { get; set; } = new List<RecompanyContactVM>();
    }
    public  class RecompanyContactVM
    {
        public int RecompanyContactId { get; set; }

        public string FullName { get; set; }

        public string Cnic { get; set; }

        public int? RecontactTypeId { get; set; }

        public int? RecompanyId { get; set; }

        public DateTime? CreatedOn { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public int? ModifiedBy { get; set; }

        public string Email { get; set; }

        public string MobileHome { get; set; }

        public string MobileWork { get; set; }

        public string LandLine { get; set; }
        public int CityId { get; set; }
        public string Address { get; set; }
        public string RecontactTypeName { get; set; }

        public virtual ICollection<ReaddressVM> Readdresses { get; set; } = new List<ReaddressVM>();

        public virtual RecompanyVM Recompany { get; set; }

        public virtual RecontactTypeVM RecontactType { get; set; }
    }
    public  class RecontactTypeVM
    {
        public int RecontactTypeId { get; set; }

        public string RecontactTypeName { get; set; }

        public DateTime? CreatedOn { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public int? ModifiedBy { get; set; }

        public virtual ICollection<RecompanyContactVM> RecompanyContacts { get; set; } = new List<RecompanyContactVM>();
    }




    public class RepropertyVM
    {
        public long PropertyId { get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }

        public string? PropertyCode { get; set; }

        public int? PropertyTypeId { get; set; }

        public byte? PurposeTypeId { get; set; }

        public byte? PropertyStatusTypeId { get; set; }

        public int? CityId { get; set; }

        public int? LocalityId { get; set; }

        public int? SubLocalityId { get; set; }

        public string? AddressDetails { get; set; }

        public decimal? Latitude { get; set; }

        public decimal? Longitude { get; set; }

        public decimal? BaseSizeInSqFt { get; set; }

        public int? DisplayUnitId { get; set; }

        public decimal? DimensionFront { get; set; }

        public decimal? DimensionDepth { get; set; }

        public decimal? CoveredAreaSqFt { get; set; }

        public decimal? Price { get; set; }

        public decimal? SecurityDeposit { get; set; }

        public int? LeaseDurationMonths { get; set; }

        public int? AdvanceRentMonths { get; set; }

        public bool? IsPriceNegotiable { get; set; }

        public decimal? MaintenanceFee { get; set; }

        public byte? Bedrooms { get; set; }

        public byte? Bathrooms { get; set; }

        public byte? FloorsCount { get; set; }

        public byte? ParkingSpaces { get; set; }

        public byte? ConstructionStatusTypeId { get; set; }

        public int? YearBuilt { get; set; }

        public string? KhasraNumber { get; set; }

        public string? KhewatNumber { get; set; }

        public string? KhatoniNumber { get; set; }

        public string? MouzaName { get; set; }

        public byte? WaterSourceTypeId { get; set; }

        public byte? NocStatusTypeId { get; set; }

        public byte? PossessionStatusTypeId { get; set; }

        public byte? OwnershipTypeId { get; set; }

        public bool? HasGas { get; set; }

        public bool? HasElectricity { get; set; }

        public bool? HasWaterSupply { get; set; }

        public bool? HasSewerage { get; set; }

        public bool? IsCornerPlot { get; set; }

        public bool? IsMainBoulevard { get; set; }

        public bool? IsParkFacing { get; set; }

        public bool? IsFeatured { get; set; }

        public bool? IsActive { get; set; }

        public DateTime? CreatedOn { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public int? ModifiedBy { get; set; }

        public CityVM? City { get; set; }

        public LocalityVM? Locality { get; set; }

        public SubLocalityVM? SubLocality { get; set; }

        public List<PropertyEnquiryVM> PropertyEnquiries { get; set; } = new List<PropertyEnquiryVM>();

        public List<PropertyMediumVM> PropertyMedia { get; set; } = new List<PropertyMediumVM>();

        public List<AmenityVM> Amenities { get; set; } = new List<AmenityVM>();
    }


    public class PropertyMediumVM
    {
        public long PropertyMediaId { get; set; }

        public long? PropertyId { get; set; }

        public byte? MediaTypeId { get; set; }

        public string? MediaUrl { get; set; }

        public string? Caption { get; set; }

        public int? DisplayOrder { get; set; }

        public bool? IsFeatured { get; set; }

        public DateTime? CreatedOn { get; set; }

        public RepropertyVM? Property { get; set; }
    }
    public class PropertyEnquiryVM
    {
        public long EnquiryId { get; set; }

        public long? PropertyId { get; set; }

        public string? FullName { get; set; }

        public string? Phone { get; set; }

        public string? Email { get; set; }

        public string? Message { get; set; }

        public byte? EnquiryStatusTypeId { get; set; }

        public DateTime? CreatedOn { get; set; }

        public RepropertyVM? Property { get; set; }
    }
    public class AmenityVM
    {
        public int AmenityId { get; set; }

        public string? AmenityName { get; set; }

        public string? AmenityCategory { get; set; }

        public string? IconClass { get; set; }

        public List<RepropertyVM> Properties { get; set; } = new List<RepropertyVM>();
    }

    public class PropertySizeUnitVM
    {
        public int PropertySizeUnitId { get; set; }

        public string? UnitName { get; set; }

        public string? UnitCode { get; set; }

        public decimal? SqFtConversionFactor { get; set; }
    }

    public  class RepropertyTypeVM
    {
        public int PropertyTypeId { get; set; }

        public string PropertyTypeName { get; set; }

        public virtual ICollection<RepropertyVM> Reproperties { get; set; } = new List<RepropertyVM>();
    }
    public  class PropertyPurposeTypeVM
    {
        public byte PurposeTypeId { get; set; }

        public string PurposeTypeName { get; set; }

        public virtual ICollection<RepropertyVM> Reproperties { get; set; } = new List<RepropertyVM>();
    }

    public class AddPropertyModel
    {
        [Required]
        public string Title { get; set; }

        public string? PropertyCode { get; set; }

        public string? Description { get; set; }

        [Required]
        public int? PropertyTypeId { get; set; }

        [Required]
        public byte? PurposeTypeId { get; set; }

        [Required]
        public int? CityId { get; set; }

        public string AddressDetails { get; set; }

        public decimal? Price { get; set; }

        public decimal? SecurityDeposit { get; set; }

        public int? Bedrooms { get; set; }

        public int? Bathrooms { get; set; }

        public decimal? CoveredAreaSqFt { get; set; }

        public decimal? BaseSizeInSqFt { get; set; }

        public int? DisplayUnitId { get; set; }

        public decimal? Latitude { get; set; }

        public decimal? Longitude { get; set; }

        public int? YearBuilt { get; set; }

        public int? ParkingSpaces { get; set; }

        public bool IsPriceNegotiable { get; set; }
        public bool HasGas { get; set; }
        public bool HasElectricity { get; set; }
        public bool HasWaterSupply { get; set; }
        public bool HasSewerage { get; set; }

        // Multiple video urls with same name in form
        public List<string> VideoUrls { get; set; }

        // Files uploaded
        public List<IFormFile> PropertyMediaFiles { get; set; }
    }
}
