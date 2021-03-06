using Microsoft.Extensions.Configuration;

namespace kcar.model
{
    public sealed class Settings
    {
        public Settings()
        {
            ApplicationInsightConnectionString = "";
            Sample = "";
            Caledos = new Caledos();
        }

        private static Settings instance = new Settings();

        static public void Load(IConfiguration config, string key)
        {
            Settings.instance = new Settings();
            config.GetSection(key).Bind(instance);
        }

        public static Settings Instance
        {
            get
            {
                return instance;
            }
        }

        public string ApplicationInsightConnectionString { get; set; }
        public string Sample { get; set; }
        public Caledos Caledos { get; set; }
        public Disk Disk { get; set; }
    }

    public class Caledos
    {
        public Caledos()
        {
            DBConnectionString = "";
            TableStorageAccessKey = "";
            Username = "";
            Password = "";
        }
        public string DBConnectionString { get; set; }
        public string TableStorageAccessKey { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class Disk
    {
        public Disk()
        {
            Path = "";
        }
        public string Path { get; set; }
    }
}