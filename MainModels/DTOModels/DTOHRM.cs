namespace MainModels.DTOModels
{
    public partial class LoginUserVM
    {
        public int Id { get; set; }
        public string UserName { get; set; }

        public string Passwords { get; set; }
        public string Profile { get; set; }
        public int? PersonId { get; set; }

        public int? SettingsId { get; set; }

        public bool IsActive { get; set; }

        public DateTime? CreatedOn { get; set; }

        public Guid? BranchId { get; set; }
        public Guid? LoginGuid { get; set; }
        public bool Remember { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<AssignedRoleVM>? AssignedRoles { get; set; }
        public List<RolesVM>? Roles { get; set; }
        public PersonVM? PersonVM { get; set; }
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

        public int? BranchId { get; set; }

    }

}
