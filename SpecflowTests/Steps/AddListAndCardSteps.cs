using Microsoft.VisualStudio.TestTools.UnitTesting;
using PageObject.Pages;
using System;
using TechTalk.SpecFlow;
using Tests;

namespace SpecflowTests.Steps
{
    [Binding]
    public class AddListAndCardSteps:Page
    {
        [Given(@"User creates a new list")]
        public void GivenUserCreatesANewList()
        {
            BoardPage.ClickAddAListLabel();
            BoardPage.EnterListName("Test");
            BoardPage.ClickAddButton();
            
        }
        
        [Given(@"User tries to a new card")]
        public void GivenUserTriesToANewCard()
        {
            BoardPage.ClickAddACardLabel();
            BoardPage.EnterCardDetails("This is a new card");
            
        }
        
        [When(@"user saves the card")]
        public void WhenUserSavesTheCard()
        {
            BoardPage.ClickAddCardButton();
        }
        
        [Then(@"card should get added to the list")]
        public void ThenCardShouldGetAddedToTheList()
        {
            Assert.IsTrue(BoardPage.IsCardDisplayed("This is a new card"));
        }

        [Given(@"User goes to a board")]
        public void GivenUserGoesToABoard()
        {
            HomePage.ClickOnBoard("Test_DoNotDelete");
        }

    }
}
