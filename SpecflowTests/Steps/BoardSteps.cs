using CommonFramework.APIEndpoints;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using System;
using System.Net;
using TechTalk.SpecFlow;
using Tests;

namespace SpecflowTests.Steps
{
    [Binding]
    public class BoardSteps: Page
    {
        IRestResponse response;

           [Given(@"A board is created with (.*)")]
        public void GivenABoardIsCreatedWithRestSharpTest(string boardName)
        {
            response=BoardClient.CreateNewBoard(boardName+ DateTime.Now.ToString("yyyyMMddHHmm"));
            Assert.IsTrue(response.StatusCode == HttpStatusCode.OK);

        }


        [Given(@"user updates board description using PUT method")]
        public void GivenUserUpdatesBoardDescriptionUsingPUTMethod()
        {
           var boardID = BoardClient.GetBoardId(response.Content);
            BoardClient.UpdateBoardDescription(boardID, "This description has been updated using an automated test");
            Assert.IsTrue(response.StatusCode == HttpStatusCode.OK);
        }
        
        [Then(@"The description should updated")]
        public void ThenTheDescriptionShouldUpdated()
        {
            var boardID = BoardClient.GetBoardId(response.Content);
            var boardInfo = BoardClient.GetBoard(boardID);
            Assert.IsTrue(BoardClient.GetBoardDescription(boardInfo.Content) == "This description has been updated using an automated test");


        }
    }
}
