using MainModels.DTOModels;
using Newtonsoft.Json;

namespace MainModels.Util
{
    public class AppDataUtility
    {
        private const string SessionKey = "SessionManager";
        private const string notificationKey = "NotificationKey";

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
        public static List<NotificationsDTO> UserNotifications
        {
            get
            {
                var session = _contextAccessor?.HttpContext?.Session;
                var result = session?.GetString(notificationKey);
                return result == null ? null : JsonConvert.DeserializeObject<List<NotificationsDTO>>(result);
            }
            set
            {
                var session = _contextAccessor?.HttpContext?.Session;
                if (session != null)
                {
                    session.SetString(notificationKey, JsonConvert.SerializeObject(value));
                }
            }
        }













        public static SystemPreferencesVM SystemPreferences { get;set; }
        public static AccountingPreferencesVM AccountingPrefrences { get { return SystemSettingsDTO.GetAccountingPreferences(); } }

    }



}
