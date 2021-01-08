using CommonFramework;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace PageObject
{
    public class PageBase
    {
        private readonly GuiMapParser map = null;
        private readonly Dictionary<string, GuiMap> dictionary = null;

        public PageBase(string fileName)
        {
            map = new GuiMapParser(fileName);
            dictionary = new Dictionary<string, GuiMap>();
            dictionary = map.GetObjectCollectionFromFile();
        }
        private string GetElementLocatorValue(string LogicalName)
        {
            GuiMap _guiMap = dictionary[LogicalName];
            string locatorValue = null;
            switch (_guiMap.IdentificationType)
            {
                case LocatorType.Id:
                    {
                        locatorValue = "Id." + _guiMap.Id;
                        break;
                    }
                case LocatorType.ClassName:
                    {
                        locatorValue = "ClassName." + _guiMap.ClassName;
                        break;
                    }
                case LocatorType.CssSelector:
                    {
                        locatorValue = "CssSelector." + _guiMap.CssSelector;
                        break;
                    }
                case LocatorType.Name:
                    {
                        locatorValue = "Name." + _guiMap.Name;
                        break;
                    }
                case LocatorType.Xpath:
                    {
                        locatorValue = "Xpath." + _guiMap.Xpath;
                        break;
                    }
                case LocatorType.TagName:
                    {
                        locatorValue = "TagName." + _guiMap.TagName;
                        break;
                    }
                case LocatorType.LinkText:
                    {
                        locatorValue = "LinkText." + _guiMap.LinkText;
                        break;
                    }
                case LocatorType.PartialLinkText:
                    {
                        locatorValue = "PartialLinkText." + _guiMap.PartialLinkText;
                        break;
                    }
            }
            return locatorValue;
        }

        protected IWebElement GetElement(string logicalName, string elementValue="")
        {
            string completeLocator = GetElementLocatorValue(logicalName);
            string[] subStrings = completeLocator.Split('.');
            IWebElement element = null;
            switch (subStrings[0])
            {
                case "Id":
                    {
                        element = ActionUtils.GetElementFromLocator(LocatorType.Id, subStrings[1]);
                        break;
                    }
                case "CssSelector":
                    {
                        element = ActionUtils.GetElementFromLocator(LocatorType.CssSelector, subStrings[1]);
                        break;
                    }
                case "Xpath":
                    {
                        element = ActionUtils.GetElementFromLocator(LocatorType.Xpath, subStrings[1],elementValue);
                        break;
                    }
                case "Name":
                    {
                        element = ActionUtils.GetElementFromLocator(LocatorType.Name, subStrings[1]);
                        break;
                    }
                case "ClassName":
                    {
                        element = ActionUtils.GetElementFromLocator(LocatorType.ClassName, subStrings[1]);
                        break;
                    }
                case "TagName":
                    {
                        element = ActionUtils.GetElementFromLocator(LocatorType.TagName, subStrings[1]);
                        break;
                    }
                case "LinkText":
                    {
                        element = ActionUtils.GetElementFromLocator(LocatorType.LinkText, subStrings[1]);
                        break;
                    }
                case "PartialLinkText":
                    {
                        element = ActionUtils.GetElementFromLocator(LocatorType.PartialLinkText, subStrings[1]);
                        break;
                    }
            }
            return element;
        }
        protected bool IsElementPresent(string LogicalName)
        {
            bool flag = false;
            string locator = GetElementLocatorValue(LogicalName);
            string[] subStrings = locator.Split('.');
            switch (subStrings[0])
            {
                case "Id":
                    {
                        flag = ActionUtils.IsElementPresent(LocatorType.Id, subStrings[1]);
                        break;
                    }
                case "CssSelector":
                    {
                        flag = ActionUtils.IsElementPresent(LocatorType.CssSelector, subStrings[1]);
                        break;
                    }
                case "Xpath":
                    {
                        flag = ActionUtils.IsElementPresent(LocatorType.Xpath, subStrings[1]);
                        break;
                    }
                case "Name":
                    {
                        flag = ActionUtils.IsElementPresent(LocatorType.Name, subStrings[1]);
                        break;
                    }
                case "ClassName":
                    {
                        flag = ActionUtils.IsElementPresent(LocatorType.ClassName, subStrings[1]);
                        break;
                    }
                case "TagName":
                    {
                        flag = ActionUtils.IsElementPresent(LocatorType.TagName, subStrings[1]);
                        break;
                    }
                case "LinkText":
                    {
                        flag = ActionUtils.IsElementPresent(LocatorType.LinkText, subStrings[1]);
                        break;
                    }
                case "PartialLinkText":
                    {
                        flag = ActionUtils.IsElementPresent(LocatorType.PartialLinkText, subStrings[1]);
                        break;
                    }
            }
            return flag;
        }
    }
}
