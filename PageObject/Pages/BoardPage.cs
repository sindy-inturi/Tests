using System;

namespace PageObject.Pages
{
    public class BoardPage : PageBase
    {
        public BoardPage() : base("BoardPage.xml")
        {

        }

        public void ClickAddAListLabel() => GetElement("addlist").Click();
        public void EnterListName(string listName) => GetElement("listName").SendKeys(listName);
        public void ClickAddButton() => GetElement("addbutton").Click();
        public void ClickAddACardLabel() => GetElement("addcard").Click();
        public void EnterCardDetails(string cardDetails) => GetElement("entercarddetails").SendKeys(cardDetails);
        public void ClickAddCardButton() => GetElement("addcardbutton").Click();

        public void ArchieveList(string listName)
        {
            try
            {
                GetElement("extramenu", listName).Click();
                GetElement("archievelist").Click();
            }
            catch (Exception e) { Console.WriteLine(e); }
        

        }

        public bool IsCardDisplayed(string cardDetails) => GetElement("cardname", cardDetails).Displayed;
    }
}
