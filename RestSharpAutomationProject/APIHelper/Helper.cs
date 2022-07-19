using Newtonsoft.Json;
using RestSharp;
using RestSharpAutomationProject.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpAutomationProject
{
    public class Helper<T>
    {
        public RestClient restClient;
        public RestRequest restRequest;
        public string baseUrl = "https://jsonplaceholder.typicode.com/";


        public RestClient SetUrl(string endPoint)
        {
            var url = Path.Combine(baseUrl, endPoint);
            var restClient = new RestClient(url);
            return restClient;

        }

        public RestRequest CreatePostRequest(string payload)
        {
            var restRequest = new RestRequest(Method.POST);
            restRequest.AddHeader("Accept", "application/json");            
            restRequest.AddParameter("application/json", payload, ParameterType.RequestBody);
            return restRequest;
        }

        public RestRequest CreatePutRequest(string payload)
        {
            var restRequest = new RestRequest(Method.PUT);
            restRequest.AddHeader("Accept", "application/json");
            restRequest.AddParameter("application/json", payload, ParameterType.RequestBody);
            return restRequest;
        }

        public RestRequest CreateGetRequest()
        {
            var restRequest = new RestRequest(Method.GET);
            restRequest.AddHeader("Accept", "application/json");            
            return restRequest;
        }

        public RestRequest CreateDeleteRequest()
        {
            var restRequest = new RestRequest(Method.DELETE);
            restRequest.AddHeader("Accept", "application/json");            
            return restRequest;
        }

        public IRestResponse GetResponse(RestClient client, RestRequest request)
        {
            return client.Execute(request);
        }
       
        public DATA GetContent<DATA>(IRestResponse response)
        {
            var content = response.Content;
            DATA objData = JsonConvert.DeserializeObject<DATA>(content);
            return objData;

        }

        public Post GETData(string endPoint)
        {
            var helper = new Helper<Post>();
            var url = helper.SetUrl(endPoint);
            var request = helper.CreateGetRequest();
            var response = helper.GetResponse(url, request);
            Post content = helper.GetContent<Post>(response);
            return content;

        }

        public Post POSTData(string endPoint, dynamic payload)
        {
            var helper = new Helper<Post>();
            var url = helper.SetUrl(endPoint);
            var request = helper.CreatePostRequest(payload);
            var response = helper.GetResponse(url, request);
            Post content = helper.GetContent<Post>(response);
            return content;

        }

        public IRestResponse DELETEData(string endPoint)
        {
            var helper = new Helper<Post>();
            var url = helper.SetUrl(endPoint);
            var request = helper.CreateDeleteRequest();
            IRestResponse response = helper.GetResponse(url, request);

            return response;
            
        }

        public Post PUTData(string endPoint, dynamic payload)
        {
            var helper = new Helper<Post>();
            var url = helper.SetUrl(endPoint);
            var request = helper.CreatePutRequest(payload);
            var response = helper.GetResponse(url, request);
            Post content = helper.GetContent<Post>(response);
            return content;

        }

        public Comment Comment_POSTData(string endPoint, dynamic payload)
        {
            var helper = new Helper<Comment>();
            var url = helper.SetUrl(endPoint);
            var request = helper.CreatePostRequest(payload);
            var response = helper.GetResponse(url, request);
            Comment content = helper.GetContent<Comment>(response);
            return content;

        }

        public List<Comment> Comment_GETData(string endPoint)
        {
            var helper = new Helper<Comment>();
            var url = helper.SetUrl(endPoint);
            var request = helper.CreateGetRequest();
            var response = helper.GetResponse(url, request);
            List<Comment> content = helper.GetContent1<List<Comment>>(response);
            return content;
           
        }

        public List<Comment> GetContent1<DATA>(IRestResponse response)
        {
            var content = response.Content;          
            List<Comment> objData = JsonConvert.DeserializeObject<List<Comment>>(content);
            return objData;

        }

    }
}
