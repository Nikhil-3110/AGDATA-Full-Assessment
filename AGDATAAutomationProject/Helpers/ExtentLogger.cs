using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpers
{
    public enum TestResult { PASS, FAIL, OutOfScope, NotAutomated }
    public class ExtentLogger
    {
        static ExtentReports _extent;
        static ExtentTest _test;
        static string imageFolderPath;
        static string textFilePath = null;
        static readonly string dirPath = string.Empty;

        static ExtentLogger()
        {
        }

        public ExtentLogger(DirectoryInfo dirPath)
        {
            try
            {
                if (_extent == null)
                {
                    _extent = new ExtentReports();
                    imageFolderPath = dirPath.FullName;
                    textFilePath = dirPath.FullName + "\\Automation_Report_Text.txt";
                    var htmlReporter = new ExtentHtmlReporter(dirPath.FullName + "\\Automation_Report" + ".html");
                    _extent.AddSystemInfo("Environment", "AGDATA Test Environment");                    
                    _extent.AttachReporter(htmlReporter);

                }
            }
            catch
            {

                throw;
            }
        }


        public static void StartTestCaseLogger(string testName, string description = "")
        {
            if (!String.IsNullOrEmpty(description))
            {
                new LoggerUtility().WriteToText(textFilePath, testName + " " + description);
                _test = _extent.CreateTest(testName, description);
            }
            else
            {
                new LoggerUtility().WriteToText(textFilePath, testName);
                _test = _extent.CreateTest(testName);
            }

        }


        public static void LogInfo(string message)
        {
            new LoggerUtility().WriteToText(textFilePath, "LOG INFO -> " + message);

            _test.Log(Status.Info, message);
        }

        public static void LogTest(string message)
        {
            new LoggerUtility().WriteToText(textFilePath, "LOG TEST -> " + message);

            _test.Log(Status.Pass, "<font color=\"MediumSeaGreen\">" + message + "</font>");
        }

        public static void LogStep(string message)
        {
            new LoggerUtility().WriteToText(textFilePath, "LOG INFO -> " + message);

            _test.Log(Status.Info, "<font color=\"DodgerBlue\">" + message + "</font>");
        }        

        public static void LogError(string message, string errorDesc = "")
        {
            var screenShotPath = GetLogScreenShot("ScreenShot_" + RandomString());
            screenShotPath.Replace("/", "\\");
            if (String.IsNullOrEmpty(errorDesc))
            {
                new LoggerUtility().WriteToText(textFilePath, "LOG ERROR -> " + message);

                _test.Log(Status.Fail, " <font color=\"Tomato\">" + message + " <a href = '" + screenShotPath + "\'> \n " + " </a></font>");
            }
            else
            {
                new LoggerUtility().WriteToText(textFilePath, "LOG ERROR MESSAGE -> " + message + "LOG ERROR DESC : " + errorDesc);

                _test.Log(Status.Fail, " <font color=\"Tomato\">" + message + "<a href = '" + screenShotPath + " \'> \n " + errorDesc + " </a></font>");
            }
        }

        public static void EndTestCase(TestResult testResult, string message, string testCaseName = "", Exception ex = null)
        {
            string errorMessage = "";
            if (ex != null)
                errorMessage = ex.StackTrace;
            //new  LoggerUtility().WriteToText(textFilePath, "TEST CASE NAME -> " + testCaseName);
            switch (testResult)
            {
                case TestResult.PASS:
                    new LoggerUtility().WriteToText(textFilePath, "TEST CASE RESULT -> PASS");
                    _test.Pass("\n\n<font color=\"green\">" + message + "</font>");
                    break;

                case TestResult.FAIL:
                    new LoggerUtility().WriteToText(textFilePath, "TEST CASE RESULT -> FAIL");
                    GetScreenShot(testCaseName);
                    _test.Fail(errorMessage + "\n\n<font color=\"red\">" + message + "</font>");
                    break;

                case TestResult.OutOfScope:
                    new LoggerUtility().WriteToText(textFilePath, "TEST CASE RESULT -> OUTOFSCOPE");
                    _test.Skip("\n\n<font color=\"Orange\">" + message + "</font>");
                    break;

                case TestResult.NotAutomated:
                    new LoggerUtility().WriteToText(textFilePath, "TEST CASE RESULT -> NOTAUTOMATED");
                    _test.Warning("\n\n<font color=\"violet\">" + message + "</font>");
                    break;

                default:
                    new LoggerUtility().WriteToText(textFilePath, "TEST CASE RESULT -> FATAL");
                    _test.Fatal("\n\n<font color=\"Tomato\">" + message + "</font>");
                    break;
            }

        }

        public static void EndReport()
        {
            _extent.Flush();

        }

        private static string GetScreenShot(string screenShotName)
        {
            try
            {

                string path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;                
                string localpath = imageFolderPath + "\\" + screenShotName + ".jpeg";

                CaptureScreen(localpath);

                //     _test.Fail("",MediaEntityBuilder.CreateScreenCaptureFromPath(localpath).Build());
                _test.AddScreenCaptureFromPath(localpath);
                return localpath;


            }
            catch (Exception ex)
            {
                ExtentLogger.LogError(ex.Message);
                return null;
            }
        }

        private static string GetLogScreenShot(string screenShotName)
        {
            try
            {

                string path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
                string localpath = imageFolderPath + "\\" + screenShotName + ".png";

                CaptureScreen(localpath);

                return localpath;


            }
            catch (Exception ex)
            {
                ExtentLogger.LogError(ex.Message);
                return null;
            }
        }

        private static void CaptureScreen(string filePath)
        {
            //Bitmap memoryImage;

            //var screen = System.Windows.Forms.Screen.PrimaryScreen.Bounds;
            //var width = screen.Width + 100;
            //var height = screen.Height + 100;

            //memoryImage = new Bitmap(width, height);
            //Size s = new Size(memoryImage.Width, memoryImage.Height);

            //// Create graphics 
            //Graphics memoryGraphics = Graphics.FromImage(memoryImage);

            //// Copy data from screen 
            //memoryGraphics.CopyFromScreen(0, 0, 0, 0, s);

            //// Save it! 
            ////Console.WriteLine("Saving the image...");
            //memoryImage.Save(filePath);
        }

        public static string RandomString(int size = 4, bool lowerCase = true)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }


    
    }
}
