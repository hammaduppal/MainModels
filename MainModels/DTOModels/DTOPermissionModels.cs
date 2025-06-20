using MainModels.Util;

namespace MainModels.DTOModels
{
    public static class CheckPermissions
    {
        public static bool HasAnyRole(params string[] allowedRoles)
        {
            var userRoles = AppDataUtility.SessionUser?.Roles;
            if (userRoles == null || !userRoles.Any())
                return false;

            return userRoles.Any(r => allowedRoles.Contains(r.Name));
        }
    }
    public class DTOPermissionModels
    {
        public int Id { get; set; }
        public string URL { get; set; }
        public int UserId { get; set; }
        public string Role { get; set; }
        public string Module { get; set; }
        public string Feature { get; set; }
        public bool CanView { get; set; }
        public bool CanEdit { get; set; }
        public bool CanDelete { get; set; }

    }
    public enum ModuleList
    {

        Product,
        Category
    }
    public class PermissionHelper
    {
     
        public static List<DTOPermissionModels> Permissions()
        {
            var permissions = new List<DTOPermissionModels>();
            permissions.Add(new DTOPermissionModels
            {
                CanDelete = false,
                CanEdit = true,
                CanView = true,
                Feature = "ProductList",
                Module = "Product",
                URL = "/Product/Products",
                UserId = 1,
                Role = "User"
            });
            permissions.Add(new DTOPermissionModels
            {
                CanDelete = true,
                CanEdit = true,
                CanView = true,
                Feature = ModuleList.Category.ToString(),
                Module = ModuleList.Product.ToString(),
                URL = "/Product/Products",
                UserId = 1,
                Role = "Admin"
            });
            permissions.Add(new DTOPermissionModels
            {
                CanDelete = true,
                CanEdit = true,
                CanView = true,
                Feature = "DCS",
                Module = "AttributeManager",
                URL = "/Products/EditProduct",
                UserId = 1,
                Role = "Admin"
            });
            permissions.Add( new DTOPermissionModels
            {
                CanDelete = true,
                CanEdit = true,
                CanView = true,
                Feature = "Product",
                Module = "Product",
                URL = "/Products/EditProduct",
                UserId = 1,
                Role = "Admin"
            });
            permissions.Add(new DTOPermissionModels
            {
                CanDelete = false,
                CanEdit = true,
                CanView = true,
                Feature = "Brand",
                Module = "AttributeManager",
                URL = "/Brands/Manage",
                UserId = 1,
                Role = "Admin"
            });

        

            permissions.Add(new DTOPermissionModels
            {
                CanDelete = false,
                CanEdit = false,
                CanView = true,
                Feature = "SubCategory",
                Module = "AttributeManager",
                URL = "/SubCategories/View",
                UserId = 1,
                Role = "POSUser"
            });

            permissions.Add(new DTOPermissionModels
            {
                CanDelete = true,
                CanEdit = false,
                CanView = true,
                Feature = "Department",
                Module = "AttributeManager",
                URL = "/Departments/Overview",
                UserId = 1,
                Role = "PowerUser"
            });

          

            permissions.Add(new DTOPermissionModels
            {
                CanDelete = true,
                CanEdit = true,
                CanView = true,
                Feature = "EditProduct",
                Module = "Product",
                URL = "/Products/Edit/5",
                UserId = 1,
                Role = "Admin"
            });

            permissions.Add(new DTOPermissionModels
            {
                CanDelete = false,
                CanEdit = false,
                CanView = true,
                Feature = "ProductDetail",
                Module = "Product",
                URL = "/Products/Details/5",
                UserId = 1,
                Role = "User"
            });

            permissions.Add(new DTOPermissionModels
            {
                CanDelete = false,
                CanEdit = true,
                CanView = true,
                Feature = "CreateProduct",
                Module = "Product",
                URL = "/Products/Create",
                UserId = 1,
                Role = "Admin"
            });

            permissions.Add(new DTOPermissionModels
            {
                CanDelete = true,
                CanEdit = true,
                CanView = true,
                Feature = "CategoryAssignment",
                Module = "Product",
                URL = "/Products/AssignCategory",
                UserId = 1,
                Role = "Admin"
            });

            permissions.Add(new DTOPermissionModels
            {
                CanDelete = false,
                CanEdit = false,
                CanView = true,
                Feature = "POSView",
                Module = "Product",
                URL = "/POS/ViewProducts",
                UserId = 1,
                Role = "POSUser"
            });

            return permissions;
        }
    }
}
