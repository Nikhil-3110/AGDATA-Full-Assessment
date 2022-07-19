using Helpers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{   

    public class BaseTest
    {
        public static System.IO.DirectoryInfo dirPath = null;

        //  protected static Log Log;
        protected static string logLocation;
        public BaseTest()
        {
           
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        [OneTimeSetUp]
        public static void ExecutionInitialization()
        {
            //Get Working Directory
            string workingDirectory = AppDomain.CurrentDomain.BaseDirectory;
            //Get Sol Directory
            string solDirectory = Directory.GetParent(workingDirectory).Parent.Parent.Parent.FullName;

            logLocation = Path.Combine(solDirectory, "TestResults");
            dirPath = new DirectoryInfo(logLocation);

        }

        [SetUp]
        public void TestSetUp()
        {
            try
            {
                string assembliesToIgnoreLog = string.Empty;
                ExtentLogger extentLogger = new ExtentLogger(dirPath);
                ExtentLogger.StartTestCaseLogger(TestContext.CurrentContext.Test.Name, TestContext.CurrentContext.Test.Properties.Get("Description").ToString());
                
                SeleniumWebDriver.CreateDriverInstance(TestConfig.BrowserType);

                ExtentLogger.LogStep("Open Chrome browser and launch AGDATA website.");
                SeleniumWebDriver.GotoURL(TestConfig.ApplicationURL);

                ExtentLogger.LogStep("Test Started => URL: " + TestConfig.ApplicationURL);
                ExtentLogger.LogStep("Browser: " + TestConfig.BrowserType);               

            }
            catch (Exception ex)
            {
                ExtentLogger.LogInfo(ex.StackTrace);
            }
        }

        /// <summary>
        /// Test Cleanup
        /// </summary>
        [TearDown]
        public void TestTearDown()
        {
            try
            {
                SeleniumWebDriver.KillDriver();
                ExtentLogger.EndReport();               
                // Logging Ends for the Current Running Test Case and Log Test Case Result.
            }
            catch (Exception ex)
            {
                ExtentLogger.LogInfo(ex.StackTrace);
                
            }
        }

    }
}
