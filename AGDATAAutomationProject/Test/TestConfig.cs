using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class TestConfig
    {
        public static string ApplicationURL
        {
            get
            {
                return ConfigurationManager.AppSettings["ApplicationUrl"];
            }
            set
            {
                ConfigurationManager.AppSettings["ApplicationUrl"] = value;
                ConfigurationManager.RefreshSection("appSettings");
            }

        }

        public static string BrowserType
        {
            get
            {
                return ConfigurationManager.AppSettings["BrowserType"];
            }
            set
            {
                ConfigurationManager.AppSettings["BrowserType"] = value;
                ConfigurationManager.RefreshSection("appSettings");
            }
        }

        public static string LogFolderPath
        {
            get
            {
                return ConfigurationManager.AppSettings["LogFolderPath"];
            }
            set
            {
                ConfigurationManager.AppSettings["LogFolderPath"] = value;
                ConfigurationManager.RefreshSection("appSettings");
            }
        }

    }
}
