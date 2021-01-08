using System;

namespace PageObject.Pages
{
    public class LoginPage : PageBase
    {
        public LoginPage() : base("LoginPage.xml")
        {
        }

        public void EnterUserName(string userName)
        {
            try
            {
                GetElement("username").SendKeys(userName);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public void EnterPassword(string password)
        {
            try
            {
                GetElement("password").SendKeys(password);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        public void ClickOnLogin()
        {
            try
            {
                GetElement("login").Click();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }

        public void ClickOnLoginWithAtlassian()
        {
            try
            {
                GetElement("logInWithAtlassian").Click();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }
    }
}
