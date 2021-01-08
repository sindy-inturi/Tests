using Newtonsoft.Json;
using RestSharp;
using System;
using System.Linq;
using CommonFramework.Components;
using System.Xml.Linq;
using System.IO;
using System.Reflection;

namespace CommonFramework.APIEndpoints
{
   
    public class BoardClient
    {
        readonly string key;
        readonly string token;

        public BoardClient()
        {

            XDocument xdoc = XDocument.Load(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\APIEndpoints\TrelloAuthentication.xml");
            key = xdoc.Descendants("key").First().Value;
            token = xdoc.Descendants("token").First().Value;
        }

        public  IRestResponse CreateNewBoard(string boardName)
        {

            RestClient client = new RestClient("https://api.trello.com/1/boards/");
            var request = new RestRequest(Method.POST);
            request.AddQueryParameter("key", key);
            request.AddQueryParameter("token", token);
            request.AddQueryParameter("name", boardName);

            IRestResponse response = client.Execute(request);
            return response;
        }

        public  string GetBoardId(string response)

        {
            var result = JsonConvert.DeserializeObject<Board>(response);
            return result.Id;
        }


        public  IRestResponse UpdateBoardDescription(string boardID, string description)
        {
            RestClient client = new RestClient(String.Format("https://api.trello.com/1/boards/{0}", boardID));
            var request = new RestRequest(Method.PUT);
            request.AddQueryParameter("key", key);
            request.AddQueryParameter("token", token);
            request.AddQueryParameter("desc", description);

            IRestResponse response = client.Execute(request);
            return response;
        }

        public  IRestResponse GetBoard(string boardID)
        {


            RestClient client = new RestClient(String.Format("https://api.trello.com/1/boards/{0}", boardID));
            var request = new RestRequest(Method.PUT);
            request.AddQueryParameter("key", key);
            request.AddQueryParameter("token", token);
            IRestResponse response = client.Execute(request);
            return response;
        }

        public  string GetBoardDescription(string response)

        {
            var result = JsonConvert.DeserializeObject<Board>(response);
            return result.Desc;
        }
    }
}

