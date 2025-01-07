using Automation.Framework.Core.WebUI.Base;
using FluentAssertions;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System.Net;
using TechTalk.SpecFlow.CommonModels;

namespace Automation.Framework.Core.WebUI.Utilities
{
    public class ApiUtils
    {

        private readonly RestLibrary _restLibrary;
        private readonly IRestBuilder _restBuilder;
    

        public ApiUtils(RestLibrary restLibrary, IRestBuilder restBuilder)
        {
            _restLibrary = restLibrary;
            _restBuilder = restBuilder;
        }

        public IDictionary<string, object> RequestMap(IDictionary<string, object> postRequestFutureContract, string module, string endPoint)
        {
            
            return SendPostRequest(module, endPoint, postRequestFutureContract);
        }

        public IDictionary<string, object> RequestMap(string module, string endPoint)
        {
            return SendPostRequest(module, endPoint, null);
        }

        public IDictionary<string, object> RequestMapGet(string module, string endPoint)
        {
            
            return (IDictionary<string, object>)SendGetRequest(endPoint);
        }

        public IDictionary<string, object> MarketFkeyList( string endpoint)
        {
           
            return (IDictionary<string, object>)SendGetRequest( endpoint);
        }

        private async Task<IDictionary<string, object>> SendPostRequest(string endpoint, IDictionary<string, object> body)
        {
            RestResponse? response = await _restBuilder
                .WithRequest(endpoint)
                .WithBody(body)
                .WithPost();
            if (response == null || response.Content == null)
            {
                throw new Exception("Response or response content is null.");
            } 
            
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK), $"Unexpected status code: {response.StatusCode}");
           
            var result= JsonConvert.DeserializeObject<IDictionary<string, object>>(response.Content);

            if (result == null)
            {
                throw new Exception("Failed to deserialize the response content.");
            }
            return result;
        }

        private async Task<IDictionary<string, object>> SendGetRequest(string endpoint)
        {
            
            RestResponse? response = await _restBuilder              
                .WithRequest(endpoint)
                .WithGet();
            var result = JsonConvert.DeserializeObject<IDictionary<string, object>>(response.Content);

            if (result == null)
            {
                throw new Exception("Failed to deserialize the response content.");
            }
            return result;
        }

        private void ValidateResponse(RestResponse response)
        {
            if (!response.IsSuccessful)
            {
                throw new Exception($"Request failed with status code {response.StatusCode}: {response.Content}");
            }
        }




    }
}
