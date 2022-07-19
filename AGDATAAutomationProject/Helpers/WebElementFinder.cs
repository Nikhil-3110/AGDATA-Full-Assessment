using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpers
{
    public enum ElementBy
    {
        Id, Xpath, Classname, CssSelector, LinkText, Name, PartialLinKText, TagName
    }
    
    public class WebElementFinder
    {
        public static IWebElement FindElement(IWebDriver driver, ElementBy elementBy, string value, string frameName = "", bool needToWaitUntilDisplay = false)
        {
            try
            {
                IWebElement element;
                bool result = false;
                switch (elementBy)
                {
                    case ElementBy.Id:
                        if (needToWaitUntilDisplay)
                            result = (string.IsNullOrEmpty(frameName)) ? ExplicitWait.wait.WaitUntilElementPresent(By.Id(value)) : ExplicitWait.wait.WaitUntilElementPresent(By.Id(value), frameName);
                        // scroll to element
                        element = driver.FindElement(By.Id(value));

                        break;
                    case ElementBy.Xpath:
                        if (needToWaitUntilDisplay)
                            result = (string.IsNullOrEmpty(frameName)) ? ExplicitWait.wait.WaitUntilElementPresent(By.XPath(value)) : ExplicitWait.wait.WaitUntilElementPresent(By.XPath(value), frameName);
                        element = driver.FindElement(By.XPath(value));
                        break;
                    case ElementBy.Classname:
                        if (needToWaitUntilDisplay)
                            result = (string.IsNullOrEmpty(frameName)) ? ExplicitWait.wait.WaitUntilElementPresent(By.ClassName(value)) : ExplicitWait.wait.WaitUntilElementPresent(By.ClassName(value), frameName);
                        element = driver.FindElement(By.ClassName(value));
                        break;
                    case ElementBy.CssSelector:
                        if (needToWaitUntilDisplay)
                            result = (string.IsNullOrEmpty(frameName)) ? ExplicitWait.wait.WaitUntilElementPresent(By.CssSelector(value)) : ExplicitWait.wait.WaitUntilElementPresent(By.CssSelector(value), frameName);
                        element = driver.FindElement(By.CssSelector(value));
                        break;
                    case ElementBy.LinkText:
                        if (needToWaitUntilDisplay)

                            result = (string.IsNullOrEmpty(frameName)) ? ExplicitWait.wait.WaitUntilElementPresent(By.LinkText(value)) : ExplicitWait.wait.WaitUntilElementPresent(By.LinkText(value), frameName);
                        element = driver.FindElement(By.LinkText(value));
                        break;
                    case ElementBy.Name:
                        if (needToWaitUntilDisplay)

                            result = (string.IsNullOrEmpty(frameName)) ? ExplicitWait.wait.WaitUntilElementPresent(By.Name(value)) : ExplicitWait.wait.WaitUntilElementPresent(By.Name(value), frameName);
                        element = driver.FindElement(By.Name(value));
                        break;
                    case ElementBy.PartialLinKText:
                        if (needToWaitUntilDisplay)

                            result = (string.IsNullOrEmpty(frameName)) ? ExplicitWait.wait.WaitUntilElementPresent(By.PartialLinkText(value)) : ExplicitWait.wait.WaitUntilElementPresent(By.PartialLinkText(value), frameName);
                        element = driver.FindElement(By.PartialLinkText(value));
                        break;
                    case ElementBy.TagName:
                        if (needToWaitUntilDisplay)
                            result = (string.IsNullOrEmpty(frameName)) ? ExplicitWait.wait.WaitUntilElementPresent(By.TagName(value)) : ExplicitWait.wait.WaitUntilElementPresent(By.TagName(value), frameName);
                        element = driver.FindElement(By.TagName(value));
                        break;
                    default:
                        element = null;
                        break;
                }
                return element;
            }
            catch (Exception ex)
            {
                ExtentLogger.LogInfo(ex.StackTrace);               
                return null;
            }
        }

        public static IReadOnlyList<IWebElement> FindElements(IWebDriver driver, ElementBy elementBy, string value, string frameName = "", bool needToWaitUntilDisplay = false)
        {
            try
            {
                IReadOnlyList<IWebElement> elements;
                bool result = false;
                switch (elementBy)
                {

                    case ElementBy.Id:
                        if (needToWaitUntilDisplay)
                            result = (string.IsNullOrEmpty(frameName)) ? ExplicitWait.wait.WaitUntilElementPresent(By.Id(value)) : ExplicitWait.wait.WaitUntilElementPresent(By.Id(value), frameName);
                        elements = driver.FindElements(By.Id(value));
                        break;
                    case ElementBy.Xpath:
                        if (needToWaitUntilDisplay)
                            result = (string.IsNullOrEmpty(frameName)) ? ExplicitWait.wait.WaitUntilElementPresent(By.XPath(value)) : ExplicitWait.wait.WaitUntilElementPresent(By.XPath(value), frameName);
                        elements = driver.FindElements(By.XPath(value));
                        break;
                    case ElementBy.Classname:
                        if (needToWaitUntilDisplay)
                            result = (string.IsNullOrEmpty(frameName)) ? ExplicitWait.wait.WaitUntilElementPresent(By.ClassName(value)) : ExplicitWait.wait.WaitUntilElementPresent(By.ClassName(value), frameName);
                        elements = driver.FindElements(By.ClassName(value));
                        break;
                    case ElementBy.CssSelector:
                        if (needToWaitUntilDisplay)
                            result = (string.IsNullOrEmpty(frameName)) ? ExplicitWait.wait.WaitUntilElementPresent(By.CssSelector(value)) : ExplicitWait.wait.WaitUntilElementPresent(By.CssSelector(value), frameName);
                        elements = driver.FindElements(By.CssSelector(value));
                        break;
                    case ElementBy.LinkText:
                        if (needToWaitUntilDisplay)
                            result = (string.IsNullOrEmpty(frameName)) ? ExplicitWait.wait.WaitUntilElementPresent(By.LinkText(value)) : ExplicitWait.wait.WaitUntilElementPresent(By.LinkText(value), frameName);
                        elements = driver.FindElements(By.LinkText(value));
                        break;
                    case ElementBy.Name:
                        if (needToWaitUntilDisplay)
                            result = (string.IsNullOrEmpty(frameName)) ? ExplicitWait.wait.WaitUntilElementPresent(By.Name(value)) : ExplicitWait.wait.WaitUntilElementPresent(By.Name(value), frameName);
                        elements = driver.FindElements(By.Name(value));
                        break;
                    case ElementBy.PartialLinKText:
                        if (needToWaitUntilDisplay)
                            result = (string.IsNullOrEmpty(frameName)) ? ExplicitWait.wait.WaitUntilElementPresent(By.PartialLinkText(value)) : ExplicitWait.wait.WaitUntilElementPresent(By.PartialLinkText(value), frameName);
                        elements = driver.FindElements(By.PartialLinkText(value));
                        break;
                    case ElementBy.TagName:
                        if (needToWaitUntilDisplay)
                            result = (string.IsNullOrEmpty(frameName)) ? ExplicitWait.wait.WaitUntilElementPresent(By.TagName(value)) : ExplicitWait.wait.WaitUntilElementPresent(By.TagName(value), frameName);
                        elements = driver.FindElements(By.TagName(value));
                        break;
                    default:
                        elements = null;
                        break;
                }
                return elements;
            }
            catch (Exception ex)
            {
                ExtentLogger.LogInfo(ex.StackTrace);
                return null;
            }
        }
    
    }
}
