using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using OpenQA.Selenium;


namespace AutomateIO
{
    public class Utility
    {
        /// <summary>
        /// This function is used to closed current Browser
        /// </summary>
        public static void QuitBrowser()
        {
            Constant.browser.Quit();
        }

        /// <summary>
        /// This function is used to closed all running process related to chrome browser/driver.
        /// </summary>
        public static void CloseBrowsersAndDrivers()
        {
            Process[] AllProcesses = Process.GetProcesses();
            foreach (var process in AllProcesses)
            {
                if (process.ProcessName != string.Empty)
                {
                    string s = process.ProcessName.ToLower();
                    if (s.Contains("chromedriver"))
                    {
                        process.Kill();
                    }
                }
            }
        }

        /// <summary>
        /// This function is used to generate log text file that contains error/exception information
        /// </summary>
        /// <param name="e"></param>
        public static void Log(Exception e)
        {
            StringBuilder error = new StringBuilder("Exception ocuured at: ");
            error.Append(DateTime.Now.ToString());
            error.Append(Environment.NewLine);
            error.Append(Convert.ToString(e));
            error.Append(Environment.NewLine);
            error.Append(Environment.NewLine);
            File.AppendAllText("C:/Logs/FailedTestCasesLogs.txt", error.ToString());
        }


        /// <summary>
        /// This method is used to screen shot where test method failed 
        /// </summary>
        /// <param name="testCase">TestCaseName</param>
        public static void Capture(string testCase)
        {
            try
            {
                StringBuilder path = new StringBuilder("C:/Logs/Screenshot/");
                Constant.screenshot = ((ITakesScreenshot)Constant.browser).GetScreenshot();
                string fileName = path.Append(string.Format(testCase + "-at-{0:yyyy-MM dd_hh-mm-ss}.jpeg", DateTime.Now)).ToString();
                Constant.screenshot.SaveAsFile(fileName, ScreenshotImageFormat.Jpeg);
            }
            catch (Exception e)
            {
                File.AppendAllText("C:/Logs/FailedTestCasesLogs.txt", "\nCOULD NOT CAPTURE THE SCREENSHOT!\n");
                Log(e);
            }

        }






    }
}
