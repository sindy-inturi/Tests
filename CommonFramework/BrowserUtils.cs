using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System.Configuration;

namespace CommonFramework
{
    public static class BrowserUtils
    {
        private static IWebDriver _driver;

        public static IWebDriver Driver
        {
            get
            {
                return _driver;
            }
            set
            {
                _driver = value;
            }
        }

        private static string _baseUrl;

        public static string BaseUrl
        {
            get
            {
                return _baseUrl;
            }
            set
            {
                _baseUrl = value;
            }
        }

        private static string _browserName;

        public static string BrowserName
        {
            get
            {
                return _browserName;
            }
            set
            {
                _browserName = value;
            }
        }

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
