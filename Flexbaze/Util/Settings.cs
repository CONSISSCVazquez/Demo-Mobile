using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace Flexbaze.Util
{
    public static class Settings
    {
        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }

        #region Setting Constants";

        private const string SettingsUser = "false";
        private const string SettingsPassword = "Password";
        private const string SettingsRol = "1";
        private const string SettingsUserName = "2";
        private const string SettingsEmail = "3";
        private const string SettingsNode = "4";
        private const string SettingsPicture = "5";
        private const string SettingsTitle = "6";
        private const string SettingsClient = "Demo";
        private const string SettingsAlerts = "open";
        private const string SettingsToken = "x";
        private const string SettingsLanguage = "y";
        private static readonly string SettingsDefault = string.Empty;

        #endregion

        public static string IsLoggedIn
        {
            get
            {
                return AppSettings.GetValueOrDefault(SettingsUser, SettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(SettingsUser, value);
            }
        }
        public static string Password
        {
            get
            {
                return AppSettings.GetValueOrDefault(SettingsPassword, SettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(SettingsPassword, value);
            }
        }
        public static string Token
        {
            get
            {
                return AppSettings.GetValueOrDefault(SettingsToken, SettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(SettingsToken, value);
            }
        }
        public static string Rol
        {
            get
            {
                return AppSettings.GetValueOrDefault(SettingsRol, SettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(SettingsRol, value);
            }
        }
        public static string UserName
        {
            get
            {
                return AppSettings.GetValueOrDefault(SettingsUserName, SettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(SettingsUserName, value);
            }
        }
        public static string Node
        {
            get
            {
                return AppSettings.GetValueOrDefault(SettingsNode, SettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(SettingsNode, value);
            }
        }
        public static string Email
        {
            get
            {
                return AppSettings.GetValueOrDefault(SettingsEmail, SettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(SettingsEmail, value);
            }
        }
        public static string Picture
        {
            get
            {
                return AppSettings.GetValueOrDefault(SettingsPicture, SettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(SettingsPicture, value);
            }
        }
        public static string Title
        {
            get
            {
                return AppSettings.GetValueOrDefault(SettingsTitle, SettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(SettingsTitle, value);
            }
        }
        public static string Client
        {
            get
            {
                return AppSettings.GetValueOrDefault(SettingsClient, SettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(SettingsClient, value);
            }
        }
        public static string ShowAlerts
        {
            get
            {
                return AppSettings.GetValueOrDefault(SettingsAlerts, "open");
            }
            set
            {
                AppSettings.AddOrUpdateValue(SettingsAlerts, value);
            }
        }

        public static string Language
        {
            get
            {
                return AppSettings.GetValueOrDefault(SettingsLanguage, SettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(SettingsLanguage, value);
            }
        }
    }
}
