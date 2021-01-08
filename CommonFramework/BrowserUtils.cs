using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace CommonFramework
{
    public static class BrowserUtils
    {
        public static IWebDriver Driver { get; set; }

        public static string BaseUrl { get; set; }

        public static string BrowserName { get; set; }

        public static void InitBrowser()
        {
            switch (BrowserName.ToLower())
            {
                case "chrome":
                default:
                    {
                        Driver = new ChromeDriver(@"C:\SeleniumDrivers");
                        break;
                    }
                case "ie":
                    {
                        Driver = new InternetExplorerDriver();
                        break;
                    }
                case "firefox":
                    {
                        Driver = new FirefoxDriver();
                        break;
                    }
            }
            Driver.Navigate().GoToUrl(BaseUrl);
            Driver.Manage().Window.Maximize();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(1);
        }

        public static void QuitBrowser()
        {
            Driver.Close();
            Driver.Quit();
            Driver = null;
        }
    }
}
