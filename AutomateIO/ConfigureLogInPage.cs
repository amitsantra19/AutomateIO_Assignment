using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomateIO
{
    public class ConfigureLogInPage
    {
        /// <summary>
        /// This function is used for log in to AutomateIO
        /// </summary>
        /// <param name="uName">UserName</param>
        /// <param name="passWord">Passward</param>
        public static void LogInToAutomateIo(string uName, string passWord)
        {
            SeleniumExtension.WaitForElementToBeVisible(Constant.browser, By.ClassName(Constant.class_logo));
            var login = Constant.browser.FindWebElements(By.TagName("a")).FirstOrDefault(ele => ele.Text.Equals("Login"));
            if (login != null)
            {
                login.Click();
            }
            SeleniumExtension.WaitForElementToBeVisible(Constant.browser, By.ClassName("inner"));
            var logIn = Constant.browser.FindWebElements(By.TagName("a")).FirstOrDefault(ele => ele.Text.Equals(Constant.button_LoginText));
            if (login != null)
            {
                logIn.Click();
            }
            SeleniumExtension.WaitForElementToBeVisible(Constant.browser, By.TagName(Constant.tag_AioSignIn));
            Constant.browser.FindWebElement(By.Id(Constant.id_email)).SendKeys(uName);
            Constant.browser.FindWebElement(By.Id(Constant.id_Password)).SendKeys(passWord);
            var submitButton = Constant.browser.FindWebElements(By.TagName(Constant.tag_button)).FirstOrDefault(ele => ele.Text.Equals(Constant.button_LoginText));
            if (submitButton != null)
            {
                submitButton.Click();
            }
            SeleniumExtension.WaitForElementToBeVisible(Constant.browser, By.ClassName("profile-image"));
            System.Threading.Thread.Sleep(3000);
        }


        /// <summary>
        /// This function will confirms secure log in
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool VerifyLogInSuccessfull(string name)
        {
            SeleniumExtension.WaitForElementToBeVisible(Constant.browser, By.ClassName("profile-image"));
            var uName = Constant.browser.FindWebElements(By.TagName(Constant.tag_span)).FirstOrDefault(ele => ele.Text.ToLower().Equals(name)).Text;
            if (uName.ToLower() == name.ToLower())
                return true;
            else
                return false;
        }

        /// <summary>
        /// Register in Automate IO 
        /// </summary>
        /// <param name="fullName"></param>
        /// <param name="email"></param>
        /// <param name="password"></param>
        public static void RegisterInAutomateIO(string fullName, string email, string password)
        {
            SeleniumExtension.WaitForElementToBeVisible(Constant.browser, By.ClassName(Constant.class_logo));
            var login = Constant.browser.FindWebElements(By.TagName("a")).FirstOrDefault(ele => ele.Text.Equals("Sign Up"));
            if (login != null)
            {
                login.Click();
            }
            SeleniumExtension.WaitForElementToBeVisible(Constant.browser, By.TagName(Constant.tag_AioSignUp));
            Constant.browser.FindWebElement(By.Id(Constant.id_Name)).SendKeys(fullName);
            Constant.browser.FindWebElement(By.Id(Constant.id_email)).SendKeys(email);
            Constant.browser.FindWebElement(By.Id(Constant.id_Password)).SendKeys(password);
            var registerBUtton = Constant.browser.FindWebElements(By.TagName(Constant.tag_button)).FirstOrDefault(ele => ele.Text.Equals(Constant.button_Register));
            if (registerBUtton!= null)
            {
                registerBUtton.Click();
            }
            SeleniumExtension.WaitForElementToBeVisible(Constant.browser, By.TagName(Constant.tag_aioUsageCard));
        }

        /// <summary>
        /// Add Apps 
        /// </summary>
        /// <param name="AppName"></param>
        public static void AddApps(string AppName)
        {
            var apps = Constant.browser.FindWebElements(By.TagName("a")).FirstOrDefault(ele => ele.Text.Equals("APPS"));
            if (apps != null)
            {
                apps.Click();
            }
            SeleniumExtension.WaitForElementToBeVisible(Constant.browser, By.ClassName("icon-plus"));
            Constant.browser.FindWebElement(By.ClassName("icon-plus")).Click();
            SeleniumExtension.WaitForElementToBeVisible(Constant.browser, By.TagName(Constant.tag_AioUserAppSelectBox));
            var searchBox = Constant.browser.FindWebElement(By.ClassName("form-control"));
            searchBox.SendKeys(AppName);
            SeleniumExtension.WaitForElementToBeVisible(Constant.browser, By.TagName(Constant.tag_AioUserAppAddFigure));
            var app = Constant.browser.FindWebElements(By.TagName(Constant.tag_AioUserAppAddFigure)).FirstOrDefault(ele => ele.GetAttribute("title").Equals(AppName));
            if (app != null)
            {
                app.FindChildWebElement(By.TagName("i")).Click();
            }
            System.Threading.Thread.Sleep(2000);// remove later
            var totalWindows = Constant.browser.WindowHandles;
            Constant.browser.SwitchTo().Window(totalWindows[1]);
            System.Threading.Thread.Sleep(2000);
            var authorizeButton = Constant.browser.FindWebElements(By.TagName(Constant.tag_span)).FirstOrDefault(ele => ele.Text.Equals("Authorize"));
            if (authorizeButton!= null)
            {
                authorizeButton.Click();
            }
            //SeleniumExtension.WaitForElementToBeVisible(Constant.browser, By.ClassName("Xb9hP"));
            //Constant.browser.FindWebElement(By.ClassName("Xb9hP")).FindChildWebElement(By.TagName("input")).SendKeys(Constant.uName);
            //Constant.browser.FindWebElement(By.ClassName("CwaK9")).FindChildWebElement(By.TagName(Constant.tag_span)).Click();
            //System.Threading.Thread.Sleep(1000);
            SeleniumExtension.WaitForElementToBeVisible(Constant.browser, By.ClassName("CwaK9"));
            Constant.browser.FindWebElement(By.ClassName("CwaK9")).FindChildWebElement(By.TagName(Constant.tag_span)).Click();
            var save = Constant.browser.FindWebElements(By.TagName(Constant.tag_button)).FirstOrDefault(ele => ele.Text.Equals("Save"));
            save.Click();
            Constant.browser.SwitchTo().Window(totalWindows[1]).Close();
            Constant.browser.SwitchTo().Window(totalWindows[0]);
            System.Threading.Thread.Sleep(1000);
            var appItem = Constant.browser.FindWebElement(By.TagName(Constant.tag_AioUserAppItem)).FindChildWebElements(By.TagName("div")).FirstOrDefault(ele => ele.Text.Equals(Constant.uName));
            Assert.IsTrue(appItem.Equals(Constant.uName), "User is not matching");
        }


        public static void CreateBots()
        {
            SeleniumExtension.WaitForElementToBeVisible(Constant.browser, By.ClassName("add-bot-link-wrapper"));
            var addBots = Constant.browser.FindWebElements(By.TagName("a")).FirstOrDefault(ele => ele.Text.Equals(Constant.createBot));
            if (addBots!=null)
            {
                addBots.Click();
            }
            SeleniumExtension.WaitForElementToBeVisible(Constant.browser, By.TagName(Constant.tag_AioWorkflowCard));
            Constant.browser.FindWebElements(By.TagName(Constant.tag_span)).FirstOrDefault(ele => ele.Text.Equals(Constant.appName)).Click();
            System.Threading.Thread.Sleep(1000);
            Constant.browser.FindWebElements(By.TagName(Constant.tag_span)).FirstOrDefault(ele => ele.Text.Equals("New Email")).Click();


        }

    }
}
