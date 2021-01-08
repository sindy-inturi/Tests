using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Xml;

namespace CommonFramework
{
    public class GuiMapParser
    {
        private readonly string fullPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\GuiMaps\";

        private readonly string xmlNodePath = "/ObjectRepository/Element";

        private GuiMap guiMap = null;

        public GuiMapParser(string xmlFileName)
        {
            fullPath = fullPath + xmlFileName;
        }

        public Dictionary<String, GuiMap> GetObjectCollectionFromFile()
        {
            Dictionary<String, GuiMap> guiObjCollection = new Dictionary<string, GuiMap>();
            string _locator;
            XmlDocument doc = new XmlDocument();
            doc.Load(fullPath);
            XmlNodeList rootNode = doc.DocumentElement.SelectNodes(xmlNodePath);
            foreach (XmlNode node in rootNode)
            {
                guiMap = new GuiMap();
                guiMap.LogicalName = node.Attributes["name"].InnerText;
                _locator = node.FirstChild.Name;
                switch (_locator.ToLower())
                {
                    case "id":
                        guiMap.IdentificationType = LocatorType.Id;
                        guiMap.Id = node.FirstChild.InnerText;
                        break;
                    case "classname":
                        guiMap.IdentificationType = LocatorType.ClassName;
                        guiMap.ClassName = node.FirstChild.InnerText;
                        break;
                    case "xpath":
                        guiMap.IdentificationType = LocatorType.Xpath;
                        guiMap.Xpath = node.FirstChild.InnerText;
                        break;
                    case "cssselector":
                        guiMap.IdentificationType = LocatorType.CssSelector;
                        guiMap.CssSelector = node.FirstChild.InnerText;
                        break;
                    case "name":
                        guiMap.IdentificationType = LocatorType.Name;
                        guiMap.Name = node.FirstChild.InnerText;
                        break;
                    case "linktext":
                        guiMap.IdentificationType = LocatorType.LinkText;
                        guiMap.Name = node.FirstChild.InnerText;
                        break;
                    case "partiallinktext":
                        guiMap.IdentificationType = LocatorType.PartialLinkText;
                        guiMap.Name = node.FirstChild.InnerText;
                        break;
                    case "tagname":
                        guiMap.IdentificationType = LocatorType.TagName;
                        guiMap.Name = node.FirstChild.InnerText;
                        break;
                }
                guiObjCollection.Add(guiMap.LogicalName, guiMap);
            }
            return guiObjCollection;
        }
    }
}