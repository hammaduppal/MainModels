namespace MainModels.Util
{
    public class DataTableRequest
    {
        public int Draw { get; set; }
        public int Start { get; set; }
        public int Length { get; set; }
        public Search Search { get; set; }
        public Order[] Order { get; set; }
        public int RecordsTotal { get; set; }
        public int RecordsFiltered { get; set; }

    }

    public class Search
    {
        public string Value { get; set; }
        public bool Regex { get; set; }
    }

    public class Order
    {
        public int Column { get; set; }
        public string Dir { get; set; }
    }
    public class ParamQueries
    {
        public class DataTableQueryResult
        {
            public string TotalRecordsQuery { get; set; }
            public string FilteredRecordsQuery { get; set; }
            public string DataQuery { get; set; }
        }

        public static DataTableQueryResult BuildDataTableQuery(string tableName, string searchColumnName, DataTableRequest request, List<string> columnMap)
        {
            // Validate input
            if (string.IsNullOrWhiteSpace(tableName)) throw new ArgumentException("Table name cannot be null or empty.");

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

            // Base queries
            string baseQuery = $"SELECT * FROM {tableName} WHERE IsDeleted = 0 OR IsDeleted IS NULL";

            string totalRecordsQuery = $"SELECT COUNT(*) FROM {tableName} WHERE IsActive=1";
            string filteredRecordsQuery = baseQuery;

            // Apply search filters
            if (!string.IsNullOrEmpty(searchValue))
            {
                filteredRecordsQuery += $" AND ({searchColumnName} LIKE '%{searchValue}%' OR BranchCode LIKE '%{searchValue}%')";
            }

            // Add sorting and pagination to the data query
            string dataQuery = filteredRecordsQuery + $" ORDER BY {sortColumn} {sortDirection}" +
                               $" OFFSET {request.Start} ROWS FETCH NEXT {request.Length} ROWS ONLY";

            // Wrap filtered records query in a count query
            filteredRecordsQuery = $"SELECT COUNT(*) FROM ({filteredRecordsQuery}) AS FilteredQuery";

            return new DataTableQueryResult
            {
                TotalRecordsQuery = totalRecordsQuery,
                FilteredRecordsQuery = filteredRecordsQuery,
                DataQuery = dataQuery
            };
        }

    }
f
}
