using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Support.UI;

namespace CommonFramework
{
    public static class ActionUtils
    {
        private static ITakesScreenshot screenshotdriver = null;
        private static IJavaScriptExecutor aScriptExecutor = null;
        private static SelectElement selectElement = null;
        public static void NavigateToPreviousPage()
        {
            BrowserUtils.Driver.Navigate().Back();
        }
        public static void GoToURL(string URL)
        {
            BrowserUtils.Driver.Navigate().GoToUrl(URL);
        }
        public static void NavigateToForwardPage()
        {
            BrowserUtils.Driver.Navigate().Forward();
        }
        public static string GetPageTitle()
        {
            return BrowserUtils.Driver.Title;
        }
        public static string GetCurrentURL()
        {
            return BrowserUtils.Driver.Url;
        }
        public static bool IsAlertPresent()
        {
            try
            {
                BrowserUtils.Driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }
        public static void CaptureScreenShot()
        {
            try
            {
                screenshotdriver = BrowserUtils.Driver as ITakesScreenshot;
                if (!System.IO.Directory.Exists("Screenshots"))
                {
                    System.IO.Directory.CreateDirectory("Screenshots");
                }
                Screenshot screenshot = screenshotdriver.GetScreenshot();
                screenshot.SaveAsFile("Screenshots\\image.png", ScreenshotImageFormat.Png);
            }
            catch (Exception e)
            {
                Exception exception = new Exception("Unable to take screenshot: " + e);
                throw exception;
            }
        }
        public static void RefreshBrowser()
        {
            BrowserUtils.Driver.Navigate().Refresh();
        }
        public static void SwitchToAlert()
        {
            try
            {
                BrowserUtils.Driver.SwitchTo().Alert();
            }
            catch (NoAlertPresentException)
            {
                throw new Exception("No alert present");
            }
        }
        public static void SwitchToWindow()
        {
            IList<string> windows = BrowserUtils.Driver.WindowHandles;
            BrowserUtils.Driver.SwitchTo().Window(windows.Last());
        }
        public static void Highlight(IWebElement aWebElement)
        {
            aScriptExecutor = (IJavaScriptExecutor)BrowserUtils.Driver;
            for (int i = 0; i < 5; i++)
            {
                object aStyle = aScriptExecutor.ExecuteScript("arguments[0].getAttribute('style');", aWebElement);
                aScriptExecutor.ExecuteScript(
                    "arguments[0].setAttribute('style', arguments[1]);",
                    aWebElement,
                    "border: 3px solid green;");
                aScriptExecutor.ExecuteScript(
                    "arguments[0].setAttribute('style', arguments[1]);",
                    aWebElement,
                    aStyle);
            }
        }
        public static void EnterText(IWebElement element, string textValue)
        {
            element.Clear();
            element.SendKeys(textValue);
        }
        public static void SelectDropDownByText(IWebElement element, string textValue)
        {
            selectElement = new SelectElement(element);

            if (selectElement.Options.Select(e => e.Text == textValue).Count() != 0)
            {
                selectElement.SelectByText(textValue);
            }
            else
            {
                throw new Exception("DropDown does not contain the option with text : " + textValue);
            }
        }

        public static void SelectDropDownByValue(IWebElement element, string Value)
        {
            selectElement = new SelectElement(element);

            if (selectElement.Options.Select(e => e.GetAttribute("value") == Value).Count() != 0 || selectElement.Options.Select(e => e.GetAttribute("Value") == Value).Count() != 0)
            {
                selectElement.SelectByValue(Value);
            }
            else
            {
                throw new Exception("DropDown does not contain the option with value : " + Value);
            }
        }

        public static void SelectDropDownByIndex(IWebElement element, int index)
        {
            selectElement = new SelectElement(element);

            if (selectElement.Options.Count() > index)
            {
                selectElement.SelectByIndex(index);
            }
            else
            {
                throw new Exception("DropDown does not contain the option with index : " + index);
            }
        }
        public static object ExecuteJavaScript(string javaScript, IWebElement aWebElement)
        {
            aScriptExecutor = (IJavaScriptExecutor)BrowserUtils.Driver;
            return aScriptExecutor.ExecuteScript(javaScript, aWebElement);
        }

        private static By LocateElement(LocatorType locator, string locatorValue, string elementValue = "")
        {
            if(!string.IsNullOrEmpty(elementValue))
            {
                locatorValue = String.Format(locatorValue, elementValue);
            }
            By by = null;
            switch (locator)
            {
                case LocatorType.Id:
                    {
                        by = By.Id(locatorValue);
                        break;
                    }
                case LocatorType.ClassName:
                    {
                        by = By.ClassName(locatorValue);
                        break;
                    }
                case LocatorType.CssSelector:
                    {
                        by = By.CssSelector(locatorValue);
                        break;
                    }
                case LocatorType.LinkText:
                    {
                        by = By.LinkText(locatorValue);
                        break;
                    }
                case LocatorType.Name:
                    {
                        by = By.Name(locatorValue);
                        break;
                    }
                case LocatorType.PartialLinkText:
                    {
                        by = By.PartialLinkText(locatorValue);
                        break;
                    }
                case LocatorType.TagName:
                    {
                        by = By.TagName(locatorValue);
                        break;
                    }
                case LocatorType.Xpath:
                    {
                        by = By.XPath(locatorValue);
                        break;
                    }
            }
            return by;
        }

        public static IWebElement GetElementFromLocator(LocatorType locator, string LocatorValue, string elementValue = "")
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(BrowserUtils.Driver, TimeSpan.FromSeconds(60));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(LocateElement(locator, LocatorValue, elementValue)));
                wait.Until((SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(LocateElement(locator, LocatorValue,elementValue))));
                return BrowserUtils.Driver.FindElement(LocateElement(locator, LocatorValue,elementValue));
            }
            catch (NoSuchElementException)
            {
                throw new Exception("Elements not found with " + locator + " : " + LocatorValue);
            }
        }
        public static IReadOnlyList<IWebElement> GetListOfElementsFromLocator(LocatorType locator, string LocatorValue)
        {
            try
            {
                return BrowserUtils.Driver.FindElements(LocateElement(locator, LocatorValue));
            }
            catch (NoSuchElementException)
            {
                throw new Exception("Elements not found with " + locator + " : " + LocatorValue);
            }
        }

        public static bool IsElementPresent(LocatorType locator, string LocatorValue)
        {
            if (GetListOfElementsFromLocator(locator, LocatorValue).Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
