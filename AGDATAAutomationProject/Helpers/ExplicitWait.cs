using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpers
{
    public static class ExplicitWait
    {
        public static OpenQA.Selenium.Support.UI.WebDriverWait wait;

        static ExplicitWait()
        {
            ExplicitWait.wait = new WebDriverWait(SeleniumWebDriver.driver, new TimeSpan(0, Convert.ToInt32(SeleniumWebDriver.DriverDynamicWaitTimeOut), 0));
        }

        /// <summary>
        /// Method to wait for the element untill it is present on the UI
        /// </summary>
        /// <param name="wait">Wait object</param>
        /// <param name="ele">Element type</param>
        /// <param name="frameName">Framename</param>
        /// <returns></returns>
        public static bool WaitUntilElementPresent(this WebDriverWait wait, By ele, string frameName = "")
        {
            DateTime currentTime = DateTime.Now.ToLocalTime();
            bool testResult = false;
            while ((DateTime.Now.ToLocalTime() - currentTime).Minutes <= wait.Timeout.Minutes)
            {
                try
                {                    
                    var elements = SeleniumWebDriver.driver.FindElements(ele);
                    if (elements.Count != 0)
                    {
                        
                        testResult = true;
                        break;
                    }
                }
                catch
                {
                    ExtentLogger.LogInfo("Not able to wait until the element was displayed.");                   
                    break;
                }
            }
            return testResult;
        }

    }
}
