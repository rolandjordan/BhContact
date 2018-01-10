using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace BhContacts.WebUtils
{
    public static class AppConfiguration
    {
        private static volatile IConfiguration _instance;
        private static readonly object SyncRoot = new object();

        public static IConfiguration Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (SyncRoot)
                    {
                        if (_instance == null)
                        {
                            var settingPath = Path.GetFullPath(Path.Combine(@"./appsettings.json"));
                            var builder = new ConfigurationBuilder()
                                .SetBasePath(AppContext.BaseDirectory)
                                .AddJsonFile(settingPath, optional: true, reloadOnChange: true);

                            _instance = builder.Build();
                        }
                    }
                }

                return _instance;
            }
        }
    }
}
