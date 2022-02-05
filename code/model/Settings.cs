using Microsoft.Extensions.Configuration;

namespace kcar.model
{
    public sealed class Settings
    {
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

        public string Sample { get; set; }
        public Caledos Caledos { get; set; }
    }

    public class Caledos
    {
        public string DBConnectionString { get; set; }
        public string TableStorageConnectionString { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}