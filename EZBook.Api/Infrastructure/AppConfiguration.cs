using System.Configuration;

namespace Testing9.Infrastructure
{
    public static class AppConfiguration
    {
        private const string ConnectionStringName = "ezbookdatabase";
        private const string DefaultConnectionString = @"Data Source=(LocalDb)\localdbezbook;Initial Catalog=ezbookdatabase;Integrated Security=True";

        public static string GetDatabaseConnectionString()
        {
            var connectionString = ConfigurationManager.ConnectionStrings[ConnectionStringName]?.ConnectionString;
            return string.IsNullOrWhiteSpace(connectionString) ? DefaultConnectionString : connectionString;
        }

        public static SmtpSettings GetSmtpSettings()
        {
            return new SmtpSettings(
                ConfigurationManager.AppSettings["Smtp.Host"],
                GetPort(),
                ConfigurationManager.AppSettings["Smtp.Username"],
                ConfigurationManager.AppSettings["Smtp.Password"],
                ConfigurationManager.AppSettings["Smtp.FromAddress"],
                GetEnableSsl());
        }

        private static int GetPort()
        {
            int port;
            return int.TryParse(ConfigurationManager.AppSettings["Smtp.Port"], out port) ? port : 25;
        }

        private static bool GetEnableSsl()
        {
            bool enableSsl;
            return bool.TryParse(ConfigurationManager.AppSettings["Smtp.EnableSsl"], out enableSsl) && enableSsl;
        }
    }

    public sealed class SmtpSettings
    {
        public SmtpSettings(string host, int port, string username, string password, string fromAddress, bool enableSsl)
        {
            Host = host;
            Port = port;
            Username = username;
            Password = password;
            FromAddress = fromAddress;
            EnableSsl = enableSsl;
        }

        public string Host { get; }

        public int Port { get; }

        public string Username { get; }

        public string Password { get; }

        public string FromAddress { get; }

        public bool EnableSsl { get; }

        public bool IsConfigured
        {
            get
            {
                return !string.IsNullOrWhiteSpace(Host)
                    && Port > 0
                    && !string.IsNullOrWhiteSpace(Username)
                    && !string.IsNullOrWhiteSpace(Password)
                    && !string.IsNullOrWhiteSpace(FromAddress);
            }
        }
    }
}
