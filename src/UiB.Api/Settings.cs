using Microsoft.Extensions.Configuration;

namespace UiB.API
{
    public class Settings
    {
        public string ConnectionString { get; set; }

        public Settings(IConfiguration config)
        {
            config.Bind(this);
        }
    }
}