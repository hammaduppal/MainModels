
namespace MainModels.DTOModels
{
    public partial class LoginUserVM
    {
        public int Id { get; set; }
        public string UserName { get; set; }

        public string Password { get; set; }
        public string Profile { get; set; }
        public int? PersonId { get; set; }

        public int? SettingsId { get; set; }

        public bool IsActive { get; set; }

        public DateTime? CreatedOn { get; set; }

        public Guid? BranchId { get; set; }
        public string RoleName { get; set; }
        public Guid? LoginGuid { get; set; }
        public bool Remember { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<AssignedRoleVM>? AssignedRoles { get; set; }
    
        public List<RolesVM>? Roles { get; set; }
        public PersonVM? Person { get; set; }
        public Guid BusinessStoreId { get; set; }
    }

    public partial class AssignedRoleVM
    {
        public int Id { get; set; }

        public int? RoleId { get; set; }

        public int? LoginId { get; set; }

        public bool? IsActive { get; set; }
        public DateTime? CreatedOn { get; set; }

        public int? BranchId { get; set; }

    }
    public partial class RolesVM
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public bool? IsActive { get; set; }
    }
    public partial class ErpPermissionVM
    {
        public int PermissionId { get; set; }

        public int? UserId { get; set; }

        public bool? CanView { get; set; }

        public bool? CanEdit { get; set; }

        public bool? CanDelete { get; set; }

        public bool? CanCreate { get; set; }

        public int? UrlMenuId { get; set; }

    }
    public partial class UrlMenuVM
    {
        public int UrlMenuId { get; set; }
        public string UrlMenuLink { get; set; }

        public DateTime? CreatedOn { get; set; }

        public int? CreatedBy { get; set; }

    }
    public partial class PersonVM
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobileNumber { get; set; }

        public string Cnic { get; set; }
        public string SocialSecurity { get; set; }
        public string Email { get; set; }

        public string ImageUrl { get; set; }

        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public int? CreatedBy { get; set; }

        public bool? IsActive { get; set; }
        public int CityId { get; set; }
        public string? Address { get; set; }
        public Guid? BranchId { get; set; }
        //public string? BranchName { get; set; }
        //public string? BranchCode { get; set; }
        //public string? OrganizationName { get; set; }
        public  BranchVM Branch{ get; set; }
        public List<LaneAddressVM> LaneAddress{ get; set; }
    }
    
    public partial class LaneAddressVM
    {
        public int AddressId { get; set; }

        public string LaneAddressOne { get; set; }

        public string LaneAddressTwo { get; set; }

        public string Area { get; set; }

        public string FamousPlace { get; set; }

        public int? PersonId { get; set; }

        public int? CityId { get; set; }
        public int StateProvinceId { get; set; }
        public int CountryId { get; set; }
        public string? AddressType { get; set; }
        public CityVM? City { get; set; }
    }
    public partial class CityVM
    {
        public int CityId { get; set; }

        public string? CityName { get; set; }

        public int? StateProvinceId { get; set; }

        public int? CountryId { get; set; }
        public StateProvinceVM? StateProvince { get; set; }

    }
    public partial class StateProvinceVM
    {
        public int StateProvinceId { get; set; }

        public string StateProvinceName { get; set; }

        public int? CountryId { get; set; }
        public CountryVM? Country { get; set; }
    }
    public partial class CountryVM
    {
        public int CountryId { get; set; }

        public string CountryName { get; set; }

    }
    public class AssignRolesVM {
        public int Id { get; set; }
        public List<int> RoleIds { get; set; }

    }

    public partial class SupplierVM
    {
        public int SupplierId { get; set; }

        public string? SupplierBusinessName { get; set; }

        public string? SupplierCode { get; set; }

        public DateTime? CreatedOn { get; set; }

        public string? Ntn { get; set; }

        public string? CompanyLogo { get; set; }

        public bool IsActive { get; set; }
        public PersonVM Person { get; set; }

        public List<SupplierContactVM>? SupplierContacts { get; set; }

    }
    public class SupplierContactVM
    {
        public int SpplierContactId { get; set; }

        public int? PersonId { get; set; }

        public int? SupplierId { get; set; }

        public DateTime? CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool? IsActive { get; set; }

        public bool? IsDeleted { get; set; }
        public PersonVM Person { get; set; }

    }
    public partial class CustomerVM
    {
        public Guid CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string CustomerCode { get; set; }

        public int? PersonId { get; set; }

        public bool? IsDeleted { get; set; }

        public DateTime? CreatedOn { get; set; }

        public int? Createdby { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool? IsActive { get; set; }

        public Guid? BranchId { get; set; }

        public virtual PersonVM Person { get; set; }
    }
    public partial class EmployeeVM
    {
        public int EmployeeId { get; set; }

        public string EmployeeCode { get; set; }

        public int? DepartmentId { get; set; }

        public int? DesignationId { get; set; }

        public DateTime? CreatedOn { get; set; }

        public bool? IsActive { get; set; }

        public int? PersonId { get; set; }

        public bool? IsSalePerson { get; set; }

        public virtual PersonVM Person { get; set; }
    }

    public partial class EmployeeDepartmentVM
    {
        public int EmployeeDepartmentId { get; set; }

        public string Title { get; set; }

        public virtual ICollection<EmployeeVM> Employees { get; set; } = new List<EmployeeVM>();
    }
    public partial class EmployeeDesignationVM
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public virtual ICollection<EmployeeVM> Employees { get; set; } = new List<EmployeeVM>();
    }
}
