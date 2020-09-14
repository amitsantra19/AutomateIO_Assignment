using OpenQA.Selenium;
using System.Security.Policy;

namespace AutomateIO
{
    public class Constant
    {
        public static IWebDriver browser;
        public static string browserName = "Chrome";
        //public static string browserName = "Firefox";
        //public static string browserName = "Edge";
        public static Screenshot screenshot = null;
        public static IWebElement busyIndicator = null;
        public const string host = "https://automate.io";
        public const string uName = "mailme.amitsantra@gmail.com";
        public const string pass = "Amit12345@";
        public const string name = "amit";
        public const string fullName = "Amit Kumar Santra";
        public const string class_logo = "logo";
        public const string tag_AioSignIn = "aio-sign-in";
        public const string tag_AioSignUp = "aio-sign-up";
        public const string tag_aioUsageCard = "aio-usage-card";
        public const string tag_span = "span";
        public const string tag_button = "button";
        public const string tag_AioUserAppSelectBox = "aio-user-app-select-box";
        public const string tag_AioUserAppAddFigure = "aio-user-app-add-figure";
        public const string tag_AioAddUserApps = "aio-add-user-apps";
        public const string tag_AioUserAppItem = "aio-user-app-item";
        public const string tag_AioWorkflowCard = "aio-workflow-card";
        public const string id_email = "email";
        public const string id_Password = "password";
        public const string id_Name = "name";
        public const string button_LoginText = "LOGIN";
        public const string button_Register = "REGISTER";
        public const string userMissmatch = "Current user is not matching with expected user: Insecure Log in Issue";
        public const string nav_Apps = "APPS";
        public const string appName = "Gmail";
        public const string createBot = "Create a Bot";



    }
}
