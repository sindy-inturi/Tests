﻿using CommonFramework;
using TechTalk.SpecFlow;

namespace Tests
{
    [Binding]
    public sealed class Hooks :Page
    {

        [BeforeScenario("UI")]
        public void BeforeScenario()
        {
            BrowserUtils.BaseUrl = "https://trello.com/login";
            BrowserUtils.BrowserName = "Chrome";
            BrowserUtils.InitBrowser();
        }

        [AfterScenario("UI")]
        public void AfterScenario()
        {
            BrowserUtils.QuitBrowser();
        }

        [AfterScenario("deleteTestCard",Order=0)]
        public void AfterDeleteScenario()
        {
            BoardPage.ArchieveList("Test");

        }
    }
}
