using MainModels.DTOModels;
using Microsoft.EntityFrameworkCore.Storage.Json;
using Newtonsoft.Json;

namespace MainModels.Util
{
    public class AppDataUtility
    {
        private const string SessionKey = "SessionManager";
        private static IHttpContextAccessor _contextAccessor;

        public static void Configure(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }
        public static LoginUserVM SessionUser
        {
            get
            {
                var session = _contextAccessor?.HttpContext?.Session;
                var result = session?.GetString(SessionKey);
                return result == null ? null : JsonConvert.DeserializeObject<LoginUserVM>(result);
            }
            set
            {
                var session = _contextAccessor?.HttpContext?.Session;
                if (session != null)
                {
                    session.SetString(SessionKey, JsonConvert.SerializeObject(value));
                }
            }
        }
        public static SystemPreferences SystemPreferences { get { return SystemSettingsDTO.GetSystemPreferences(); } }
        public static AccountingPreferences SystemSettings { get { return SystemSettingsDTO.GetAccountingPreferences(); } }

    }



}
