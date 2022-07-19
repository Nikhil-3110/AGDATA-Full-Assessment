using Helpers;
using NUnit.Framework;
using OpenQA.Selenium;
using ProductModel.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class AllTests : BaseTest
    {
        [Test, Description("Verification of AGDATA List of Jobs")]
        public void VerifyAGDATAJobs()
        {
            string jobTitle = "Associate Software Engineer";

            ExtentLogger.LogStep("Navigate to Careers tab");
            new HomePage().NavigateToCareersTab();

            ExtentLogger.LogStep("Update page frame");
            System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> jobs = SeleniumWebDriver.driver.FindElements(By.TagName("iframe"));            
            SeleniumWebDriver.driver.SwitchTo().Frame("HBIFRAME");
            
            ExtentLogger.LogStep("Fetch all the listed jobs");
            var allJobs = WebElementFinder.FindElements(SeleniumWebDriver.driver, ElementBy.Xpath, "//span[@class='job']");

            ExtentLogger.LogStep("Available listed jobs are : ");            
            for (int i = 0; i < allJobs.Count; i++)
            {                
                string job = allJobs[i].Text.Trim();
                ExtentLogger.LogInfo(i + ". " + allJobs[i].Text);
               
            }

            ExtentLogger.LogStep("Navigate to Job : " + jobTitle);
            new HomePage().ClickOnJob(jobTitle);

            if (new HomePage().VerifyJobDescriptionPage())
            {
                ExtentLogger.LogTest("Job Description has been verified successfully.");
            }
            else
            {
                ExtentLogger.LogError("Failed to verify Job Description.");
            }
            
        }

    }
}
