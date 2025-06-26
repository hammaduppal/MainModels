using System.Text.RegularExpressions;
using System;

namespace MainModels.Util
{
    public class HelperClass
    {
        private readonly IConfiguration _config;
        private readonly DBManager _db;
        public HelperClass(IConfiguration config)
        {
            _config = config;
            _db = new DBManager(_config);
        }
        private static readonly Random random = new Random();

        public static  string CreateSlug(string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                try
                {
                    var row = value.Replace(' ', '-').ToLower();
                    var sanitized = Regex.Replace(row, "[^a-z0-9-]", string.Empty);
                    string result = sanitized /*+ "-" + random.Next(1000, 10000)*/;
                    return result;
                }
                catch (Exception)
                {

                    throw;
                }
            }
            else
            {
                return "";
            }


        }
        public async Task<ReturnDataofQuery> BuildDataTableQueryAsync(string baseQuery, DataTableRequest request, List<string> columnMap, string tableName)
        {
            int totalRecords = await _db.ExecuteQuery<int>($"SELECT COUNT(*) FROM {tableName}");

            // Initialize default order if not provided
            if (request.Order == null || request.Order.Length == 0)
            {
                request.Order = new[] { new Order { Column = 0, Dir = "asc" } };
            }

            // Extract parameters
            string searchValue = request.Search?.Value ?? string.Empty;
            int sortColumnIndex = request.Order[0].Column;
            string sortDirection = request.Order[0].Dir;
            string sortColumn = columnMap[sortColumnIndex];

            // Append search filters
            if (!string.IsNullOrEmpty(searchValue))
            {
                baseQuery += $" AND (BranchName LIKE '%{searchValue}%' OR BranchCode LIKE '%{searchValue}%')";
            }

            // Append sorting
            baseQuery += $" ORDER BY {sortColumn} {sortDirection}";

            // Append pagination
            baseQuery += $" OFFSET {request.Start} ROWS FETCH NEXT {request.Length} ROWS ONLY";
            var obj = new ReturnDataofQuery
            {
                baseQuery = baseQuery,
                TotalRecords = totalRecords
            };
            return obj;
        }
        public class ReturnDataofQuery
        {
            public string baseQuery { get; set; }
            public int TotalRecords { get; set; }

        }
    }
    public static class CommonParamHelper
    {
        public static CommonParams GetCommonParams()
        {
            return new CommonParams
            {
                BranchId= AppDataUtility.SessionUser.PersonVM.BranchId,
                OrganizationId = AppDataUtility.SessionUser.PersonVM.Branch.Organization.OrganizationId,
                CreatedBy = AppDataUtility.SessionUser.Id,
                CreatedOn = DateTime.Now,
                IsActive = true,
                IsDeleted = false,
                ModifiedOn = DateTime.Now
            };
        }
        public class CommonParams
        {
            public Guid? BranchId { get; set; }
            public int OrganizationId { get; set; }
            public string BusinessName { get; set; }
            public DateTime? CreatedOn { get; set; }
            public DateTime? ModifiedOn { get; set; }
            public bool? IsActive { get; set; }
            public int? CreatedBy { get; set; }
            public bool? IsDeleted { get; set; }
        }
       
    }

}
