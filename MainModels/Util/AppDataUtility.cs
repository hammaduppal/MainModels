using MainModels.DTOModels;

namespace MainModels.Util
{
    public class AppDataUtility
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AppDataUtility(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }



        public static LoginUserVM SessionUser { get; set; }
    }
}
