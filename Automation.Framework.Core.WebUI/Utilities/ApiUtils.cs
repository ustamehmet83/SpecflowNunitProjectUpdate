using Automation.Framework.Core.WebUI.Base;
using FluentAssertions;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System.Net;

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

        private IDictionary<string, object> SendPostRequest(string module, string endpoint, IDictionary<string, object> body)
        {
           
            var request = _restBuilder.WithRequest(endpoint).WithBody(body);
            var response = _restLibrary.RestClient.Execute((RestRequest)request);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            ValidateResponse(response);
            return JsonConvert.DeserializeObject<IDictionary<string, object>>(response.Content);
        }

        private async Task<IDictionary<string, object>> SendGetRequest(string endpoint)
        {
            
            RestResponse? response = await _restBuilder              
                .WithRequest(endpoint)
                .WithGet();
            response?.StatusCode.Should().Be(HttpStatusCode.OK);

            return JsonConvert.DeserializeObject<IDictionary<string, object>>(response.Content);
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
