using CommonFramework.APIEndpoints;
using PageObject.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class Page
    {
        private LoginPage loginPage;
        public LoginPage LoginPage
        {
            get
            {
                if (null == loginPage)
                {
                    loginPage = new LoginPage();
                }
                return loginPage;
            }
        }
        private HomePage homePage;
        public HomePage HomePage
        {
            get
            {
                if (null == homePage)
                {
                    homePage = new HomePage();
                }
                return homePage;
            }
        }

        private BoardPage boardPage;
        public BoardPage BoardPage
        {
            get
            {
                if (null == boardPage)
                {
                    boardPage = new BoardPage();
                }
                return boardPage;
            }
        }

        private BoardClient boardClient;
        public BoardClient BoardClient
        {
            get
            {
                if (null == boardClient)
                {
                    boardClient = new BoardClient();
                }
                return boardClient;
            }
        }

    }
}
