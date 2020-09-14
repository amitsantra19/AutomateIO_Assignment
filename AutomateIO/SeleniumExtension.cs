using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomateIO
{
    public static class SeleniumExtension
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="browser"></param>
        /// <param name="by"></param>
        /// <param name="noOfAttempt"></param>
        /// <returns></returns>
        public static IWebElement FindWebElement(this IWebDriver browser, By by, int noOfAttempt = 200)
        {
            int retries = 0;
            IWebElement Element = null;
            do
            {
                retries++;
                try
                {
                    Element = browser.FindElement(by);
                }
                catch (Exception)
                {
                    // Suppressing the exception to reattempt finding the element
                }
            }
            while (Element == null && retries < noOfAttempt);
            return Element;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Parent"></param>
        /// <param name="by"></param>
        /// <param name="noOfAttempt"></param>
        /// <returns></returns>
        public static IWebElement FindChildWebElement(this IWebElement Parent, By by, int noOfAttempt = 100)
        {
            int retries = 0;
            IWebElement Element = null;
            do
            {
                retries++;
                try
                {
                    Element = Parent.FindElement(by);
                }
                catch (Exception)
                {
                    // Suppressing the exception to reattempt finding the element
                }
            }
            while (Element == null && retries < noOfAttempt);
            Stopwatch timeout = new Stopwatch();
            timeout.Start();
            while (timeout.ElapsedMilliseconds < 1000 && Element == null)
            {
                try
                {
                    Element = Parent.FindElement(by);
                }
                catch (Exception)
                {
                    // Suppressing the exception to return null for the element
                }
            }
            return Element;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="browser"></param>
        /// <param name="by"></param>
        /// <param name="noOfAttempt"></param>
        /// <returns></returns>
        public static ReadOnlyCollection<IWebElement> FindWebElements(this IWebDriver browser, By by, int noOfAttempt = 100)
        {
            int retries = 0;
            ReadOnlyCollection<IWebElement> Elements = null;
            do
            {
                retries++;
                try
                {
                    Elements = browser.FindElements(by);
                }
                catch (Exception)
                {
                    // Suppressing the exception to reattempt finding the element
                }
            }
            while (Elements.Count == 0 && retries < noOfAttempt);
            Stopwatch timeout = new Stopwatch();
            timeout.Start();
            while (timeout.ElapsedMilliseconds < 1000 && Elements.Count == 0)
            {
                try
                {
                    Elements = browser.FindElements(by);
                }
                catch (Exception)
                {
                    // Suppressing the exception to return null for the element
                }
            }
            return Elements;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Parent"></param>
        /// <param name="by"></param>
        /// <param name="noOfAttempt"></param>
        /// <returns></returns>
        public static ReadOnlyCollection<IWebElement> FindChildWebElements(this IWebElement Parent, By by, int noOfAttempt = 100)
        {
            int retries = 0;
            ReadOnlyCollection<IWebElement> Elements = null;
            do
            {
                retries++;
                try
                {
                    Elements = Parent.FindElements(by);
                }
                catch (Exception)
                {
                    // Suppressing the exception to reattempt finding the element
                }
            }
            while (Elements.Count == 0 && retries < noOfAttempt);
            Stopwatch timeout = new Stopwatch();
            timeout.Start();
            while (timeout.ElapsedMilliseconds < 1000 && Elements.Count == 0)
            {
                try
                {
                    Elements = Parent.FindElements(by);
                }
                catch (Exception)
                {
                    // Suppressing the exception to return null for the element
                }
            }

            return Elements;

        }


        public static bool WaitForElementToBeVisible(IWebDriver browser, By by)
        {
            int attemptToFindElement = 0;
            bool elementFound = false;
            IWebElement elementIdentifier = null;
            do
            {
                attemptToFindElement++;
                try
                {
                    elementIdentifier = browser.FindWebElement(by);
                    elementFound = (elementIdentifier.Displayed && elementIdentifier.Enabled) ? true : false;
                }
                catch (Exception)
                {
                    elementFound = false;
                }

            }
            while (elementFound == false && attemptToFindElement < 100);

            return elementFound;
        }

        public static void WaitUntilBusyIndicatorWorking()
        {
            Stopwatch timer = new Stopwatch();
            try
            {
                timer.Restart();
                do
                {
                    try
                    {
                        Constant.busyIndicator = Constant.browser.FindWebElements(By.XPath("/html/body/div[3]")).FirstOrDefault(ele => ele.GetAttribute("indicatorid") != null && ele.GetAttribute("indicatorid").Equals("globalBusyIndicatorId")).FindChildWebElement(By.ClassName("mom-modal-overlay-spinner-widget"));
                    }
                    catch (Exception)
                    {
                        //Suppressing the exception when the busy indicator is not found in the current page 
                    }
                }
                while (Constant.busyIndicator == null && timer.ElapsedMilliseconds < 2000);
                
            }
            catch (Exception)
            {
                //Suppressing the exception when the busy indicator's style attribute is not retrievable
            }
        }
    }
}
