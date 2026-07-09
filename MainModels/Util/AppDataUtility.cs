using MainModels.DTOModels;
using Newtonsoft.Json;

namespace MainModels.Util
{
    public static class AppDataUtility
    {
        private static IServiceProvider _serviceProvider;

        public static void Configure(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public static LoginUserVM SessionUser
        {
            get
            {
                var httpContextAccessor = _serviceProvider?.GetService<IHttpContextAccessor>();
                var currentContext = httpContextAccessor?.HttpContext;
                var sessionService = currentContext?.RequestServices?.GetService<ISessionService>();

                return sessionService?.SessionUser;
            }
        }
        public static SystemPreferencesVM SystemPreferences
        {
            get
            {
                var httpContextAccessor = _serviceProvider?.GetService<IHttpContextAccessor>();
                var currentContext = httpContextAccessor?.HttpContext;
                var sessionService = currentContext?.RequestServices?.GetService<ISessionService>();

                return sessionService?.SystemPreferences;
            }
        }
        public static List<NotificationsDTO> UserNotifications
        {
            get
            {
                var httpContextAccessor = _serviceProvider?.GetService<IHttpContextAccessor>();
                var currentContext = httpContextAccessor?.HttpContext;
                var sessionService = currentContext?.RequestServices?.GetService<ISessionService>();

                return sessionService?.UserNotifications;
            }
        }
    }

    public interface ISessionService
    {
        LoginUserVM SessionUser { get; set; }
        List<NotificationsDTO> UserNotifications { get; set; }
        SystemPreferencesVM SystemPreferences { get; set; }
    }

    public class SessionService : ISessionService
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private const string SessionKey = "SessionManager";
        private const string NotificationKey = "NotificationKey";
        private const string SystemPreferencesKey = "SystemPreferencesKey";

        public SessionService(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        private ISession Session => _contextAccessor?.HttpContext?.Session;

        public LoginUserVM SessionUser
        {
            get => Session?.GetString(SessionKey) == null ? null : JsonConvert.DeserializeObject<LoginUserVM>(Session.GetString(SessionKey));
            set => Session?.SetString(SessionKey, JsonConvert.SerializeObject(value));
        }

        public List<NotificationsDTO> UserNotifications
        {
            get => Session?.GetString(NotificationKey) == null ? null : JsonConvert.DeserializeObject<List<NotificationsDTO>>(Session.GetString(NotificationKey));
            set => Session?.SetString(NotificationKey, JsonConvert.SerializeObject(value));
        }
        public SystemPreferencesVM SystemPreferences
        {
            get => Session?.GetString(SystemPreferencesKey) == null ? null : JsonConvert.DeserializeObject<SystemPreferencesVM>(Session.GetString(NotificationKey));
            set => Session?.SetString(SystemPreferencesKey, JsonConvert.SerializeObject(value));
        }
    }


}
