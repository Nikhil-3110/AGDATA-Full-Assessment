using Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductModel.PageObjects
{
    public class HomePage
    {
        #region Repository  
        private readonly string companyByXpath = "//*[@href='#'][text()='Company']";
        private readonly string overviewByXpath = "//a[@href='https://www.agdata.com/company/']";
        public readonly string leadershipByXpath = "//a[@href='https://www.agdata.com/company/leadership/']";
        private readonly string careersByXpath = "//a[@href='https://www.agdata.com/company/careers/']";
        private readonly string jobDescriptionHeaderByXpath = "//span[@class='sectionheader']//span[text()='Job Description']";
        private readonly string applyButtonByXpath = "//a[@class='btn btn-primary btn-apply']";
        
        #endregion

        #region Properties

        private IWebElement LinkCompany
        {
            get
            {
                return WebElementFinder.FindElement(SeleniumWebDriver.driver, ElementBy.Xpath, companyByXpath);
            }
        }

        private IWebElement LinkOverview
        {
            get
            {
                return WebElementFinder.FindElement(SeleniumWebDriver.driver, ElementBy.Xpath, overviewByXpath);
            }
        }

        private IWebElement LinkLeadership
        {
            get
            {
                return WebElementFinder.FindElement(SeleniumWebDriver.driver, ElementBy.Xpath, leadershipByXpath);
            }
        }

        private IWebElement LinkCareers
        {
            get
            {
                return WebElementFinder.FindElement(SeleniumWebDriver.driver, ElementBy.Xpath, careersByXpath);
            }
        }

        private IWebElement TextJobDescriptionHeader
        {
            get
            {
                return WebElementFinder.FindElement(SeleniumWebDriver.driver, ElementBy.Xpath, jobDescriptionHeaderByXpath);
            }
        }

        private IWebElement ButtonApply
        {
            get
            {
                return WebElementFinder.FindElement(SeleniumWebDriver.driver, ElementBy.Xpath, applyButtonByXpath);
            }
        }

        #endregion

        #region Methods 
        
        /// <summary>
        /// Method to navigate to Careers Tab
        /// </summary>
        public void NavigateToCareersTab()
        {
            Actions action = new Actions(SeleniumWebDriver.driver);
            action.MoveToElement(LinkCompany).Perform();
            LinkCareers.Click();
            System.Threading.Thread.Sleep(2000);
        }

        /// <summary>
        /// Method to click on Job Title
        /// </summary>
        /// <param name="JobTitle">Job Title</param>
        /// <returns>True/False</returns>
        public bool ClickOnJob(string JobTitle)
        {
            bool flag = true;

            var element = WebElementFinder.FindElement(SeleniumWebDriver.driver, ElementBy.Xpath, "//span[@class='job']//a[text()='" + JobTitle + "']");
            if (element.Displayed)
            {

                element.Click();
            }
            else
            {
                flag = false;
            }

            return flag;
        }

        /// <summary>
        /// Method to Verify Job Description
        /// </summary>
        /// <returns>True/False</returns>
        public bool VerifyJobDescriptionPage()
        {
            bool flag = true;
            
            if (TextJobDescriptionHeader.Displayed)
            {
                ExtentLogger.LogTest("Job Description has been displayed.");
            }
            else
            {
                ExtentLogger.LogError("Job Description is not present in the page.");
                flag = false;
            }

            if (ButtonApply.Displayed)
            {
                ExtentLogger.LogTest("Apply button is present in the page.");
            }
            else
            {
                ExtentLogger.LogError("Apply button is not present in the page.");
                flag = false;
            }

            return flag;
        }

        #endregion
    }
}
