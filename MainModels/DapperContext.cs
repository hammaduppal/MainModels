using Microsoft.Data.SqlClient;
using System.Data;

namespace MainModels
{
    //public class DapperContext
    //{
    //    private readonly string _connectionString;
    //    public DapperContext(IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
    //    {
    //        var httprequest = httpContextAccessor.HttpContext.Request;
    //        var customerId = httprequest.Headers["CompanyCode"].ToString();
    //        if (string.IsNullOrEmpty(customerId))
    //        {
    //            customerId = "None";
    //        }
    //        _connectionString = configuration.GetConnectionString(customerId);
    //    }
    //    public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
    //}

    public class DapperContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("MarketDB");
        }
        public IDbConnection CreateConnection()
            => new SqlConnection(_connectionString);
    }
}
