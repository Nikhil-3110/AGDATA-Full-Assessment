using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace Helpers
{
    public class SeleniumWebDriver
    {
        public static IWebDriver driver;
        public static ChromeDriver chromeDriver;       
        public static Size browserSize;
        public static Configuration configuration;
        public static string DriverInternalTimeout;
        public static string DriverDynamicWaitTimeOut;
        public static string DriverPopUpWaitTime;

        static SeleniumWebDriver()
        {
            try
            {
                DriverInternalTimeout = "300000000000";
                DriverDynamicWaitTimeOut = "05";
                DriverPopUpWaitTime = "200";
            }
            catch(Exception ex)
            {
                ExtentLogger.LogError(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Method to Go to URL
        /// </summary>
        /// <param name="url">URL</param>
        public static void GotoURL(string url)
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);
        }

        /// <summary>
        /// Create driver instance
        /// </summary>
        /// <param name="browserType">browser type</param>
        /// <returns></returns>
        public static bool CreateDriverInstance(string browserType = "CHROME")
        {
            bool isDriverInstantiated = false;
            if (driver == null)
            {
                switch (browserType)
                {
                    case BrowserType.CHROME:
                        driver = DriverOptions.GetChromeDriver();
                        break;

                    

                    default:
                        break;
                }

            }
            if (driver != null)
            {
                //  ExplicitWait.wait = new WebDriverWait(SeleniumWebDriver.driver, new TimeSpan(0, Convert.ToInt32(SeleniumWebDriver.DriverDynamicWaitTimeOut), 0));
                isDriverInstantiated = true;
            }
            return isDriverInstantiated;
        }

        /// <summary>
        /// Kill initialized driver
        /// </summary>
        public static void KillDriver()
        {
          //  Log.WriteLine("Kill WebDriver Instanse");
            if (SeleniumWebDriver.driver != null)
            {
                SeleniumWebDriver.driver.Close();
                SeleniumWebDriver.driver.Quit();
                SeleniumWebDriver.driver = null;
            }
        }

    }

    public static class BrowserType
    {
        public const String CHROME = "CHROME";
        
    }



    public class DriverOptions
    {
        public static Configuration configValues;        

        /// <summary>
        /// Get an instance of Chrome driver
        /// </summary>
        /// <returns></returns>
        public static ChromeDriver GetChromeDriver()
        {
            KillProcessByName("chrome");
            // Reading browser installed path from Registry
            var path = Microsoft.Win32.Registry.GetValue(@"HKEY_CLASSES_ROOT\ChromeHTML\shell\open\command", null, null) as string;
            if (path != null)
            {
                var split = path.Split('\"');
                path = split.Length >= 2 ? split[1] : null;
            }

            var options = new ChromeOptions
            {
                BinaryLocation = path
            };

            //Initializing chrome driver based on chrome version
            new DriverManager().SetUpDriver(new ChromeConfig(), WebDriverManager.Helpers.VersionResolveStrategy.MatchingBrowser);
            SeleniumWebDriver.chromeDriver = new ChromeDriver();
            return SeleniumWebDriver.chromeDriver;
        }

        /// <summary>
        /// Method to kill a process by its name
        /// </summary>
        /// <param name="processName">Process Name</param>
        /// <returns></returns>
        public static bool KillProcessByName(string processName)
        {
            // Close all Internet Explorer Instances.
            Process[] procs;
            procs = Process.GetProcessesByName(processName);
            foreach (Process proc in procs)
            {
                try
                {
                    proc.Kill();
                }
                catch
                {
                }
            }
            procs = Process.GetProcessesByName(processName);
            if (procs.Length == 0)
                return true;
            else
                return false;
        }
    }

    /// <summary>
    /// Desc : Class is used for constant elements maintance.
    /// </summary>
    public class DriverConstants
    {
        public static int TIMESPAN = 1200000000;

        public static string ChromeExePath = "";
    }
}

