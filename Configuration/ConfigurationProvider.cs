using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStoreDemo.Configuration
{
    public static class ConfigurationProvider
    {
        public static Config Config { get; set; }
        public static string CurrentEnviromentName { get; set; }
        public static PetStoreEnviroment CurrentEnviroment { get; set; }

        public static void LoadConfiguration()
        {
            var config = new ConfigurationBuilder()
                   .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                   .AddJsonFile("Config.json").Build();
            Config = config.Get<Config>();

            SetCurrentEnviroment();
        }

        public static void SetCurrentEnviroment()
        {
            var enviroment = Environment.GetEnvironmentVariable("ENV_NAME");
            if (enviroment == null)
            {
                enviroment = Config.DefaultEnviroment;
            }
            CurrentEnviromentName = enviroment;
            CurrentEnviroment = Config.Enviroments[CurrentEnviromentName];
        }
    }


}
