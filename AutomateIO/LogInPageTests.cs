using System;
using System.Linq;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace AutomateIO
{
    [TestClass]
    public class LogInPageTests
    {

        [AssemblyInitialize]
        public static void AssemblyStartUp(TestContext context)
        {
            //Assembly initilize variable declaration
            int attempts = 3;
            bool stopexecution = true;
            Exception captureException = null;
            do
            {
                attempts = attempts - 1;
                try
                {
                    switch(Constant.browserName)
                    {
                        case "Chrome":
                            Constant.browser = new ChromeDriver();
                            Constant.browser.Navigate().GoToUrl(Constant.host);
                            break;
                        case "Firefox":
                            Constant.browser = new FirefoxDriver();
                            Constant.browser.Navigate().GoToUrl(Constant.host);
                            break;
                        case "Edge":
                            Constant.browser = new EdgeDriver();
                            Constant.browser.Navigate().GoToUrl(Constant.host);
                            break;
                        default:
                            throw new Exception("Browser not Found");
                    }
                    
                    Constant.browser.Manage().Window.Maximize();
                    System.Threading.Thread.Sleep(4000);
                    stopexecution = false;

                }
                catch (Exception ex)
                {
                    Utility.CloseBrowsersAndDrivers();
                    Utility.Log(ex);
                    captureException = ex;
                    stopexecution = true;
                }
            }
            while (attempts > 0 && stopexecution);

            //Stoping the execution if assembly startup method has issue.
            if (stopexecution)
            {
                Utility.Capture(MethodBase.GetCurrentMethod().Name);
                Assert.Fail("Assembly initilize having issue and exception is " + captureException.ToString());
            }
        }

        [AssemblyCleanup]
        public static void AssemblyCleanUp()
        {
            Utility.QuitBrowser();
        }

        [TestMethod]
        [TestCategory("Smoke")]
        public void AutomateIO_RegisterAsNewUser()
        {
            SeleniumExtension.WaitForElementToBeVisible(Constant.browser, By.TagName(Constant.tag_AioSignUp));
            ConfigureLogInPage.RegisterInAutomateIO(Constant.fullName, Constant.uName, Constant.pass);
        }

        [TestMethod]
        [TestCategory("Smoke")]
        public void AutomateIO_AuthenticateWithGmailAccount()
        {
            ConfigureLogInPage.LogInToAutomateIo(Constant.uName, Constant.pass);
            bool isLoginSuccess = ConfigureLogInPage.VerifyLogInSuccessfull(Constant.name);
            Assert.IsTrue(isLoginSuccess, Constant.userMissmatch);
            ConfigureLogInPage.AddApps(Constant.appName);
        }

        [TestMethod]
        [TestCategory("Smoke")]
        public void AutomateIO_CreateAndEnableBots()
        {
            ConfigureLogInPage.LogInToAutomateIo(Constant.uName, Constant.pass);
            bool isLoginSuccess = ConfigureLogInPage.VerifyLogInSuccessfull(Constant.name);
            Assert.IsTrue(isLoginSuccess, Constant.userMissmatch);


        }  
    }
}
