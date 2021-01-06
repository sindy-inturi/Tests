using System;

namespace PageObject.Pages
{
    public class HomePage : PageBase
    {
        public HomePage() : base("HomePage.xml")
        {
        }

        public bool IsUserProfileDisplayed(string userProfileText)
        {
            return GetElement("userprofile", userProfileText).Displayed;
        }

        public void ClickOnBoard(string boardName)
        {
            try
            {
                GetElement("board", boardName).Click();
            }
            catch (Exception e) { Console.WriteLine(e); }
        }

    }
}
