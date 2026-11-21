using Microsoft.Extensions.Configuration;
using System.IO;

namespace ExamenAutomationSofka.Core.Config
{
    public class ConfigReader : IConfigReader
    {
        private readonly IConfiguration _configuration;

        public ConfigReader(string fileName = "appsettings.json")
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(fileName, optional: false, reloadOnChange: true);

            _configuration = builder.Build();
        }
        public string GetValue(string key) => _configuration[key] ?? string.Empty;
    }
}