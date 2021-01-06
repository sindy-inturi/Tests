﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Threading;
using PageObject.Pages;
using Tests;

namespace SpecflowTests.Steps
{
    [Binding]
    public class LoginSteps : Page 
    {
        [Given(@"User enters Username (.*)")]
        public void GivenUserEntersUsernameSindyinturiGmail_Com(string username)
        {

            LoginPage.EnterUserName(username);
        }

        [Given(@"User clicks on Login with Atllasian button")]
        public void GivenUserClicksOnLoginWithAtllasianButton()
        {
            LoginPage.ClickOnLoginWithAtlassian();
        }

        [Given(@"User enters password (.*)")]
        public void GivenUserEntersPasswordSindy(string password)
        {
            LoginPage.EnterPassword(password);
        }
        
        [When(@"User clicks on submit")]
        public void WhenUserClicksOnSubmit()
        {
            LoginPage.ClickOnLogin();

        }

        [Then(@"User should go to trello homepage")]
        public void ThenUserShouldGoToTrelloHomepage()
        {
            Assert.IsTrue(HomePage.IsUserProfileDisplayed("Sindy"));
        }
        
    }
}
