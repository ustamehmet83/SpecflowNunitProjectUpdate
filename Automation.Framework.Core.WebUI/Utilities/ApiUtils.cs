using RestSharp;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using NUnit.Framework;

namespace Automation.Framework.Core.WebUI.Utilities
{
    public class ApiUtils
    {
        //private readonly RestClient _client;
        //
        //public ApiUtils(string baseUrl)
        //{
        //    _client = new RestClient(baseUrl);
        //}
        //
        //
        //
        //
        //
        //public IDictionary<string, object> RequestMap(IDictionary<string, object> postRequestFutureContract, string module, string endPoint)
        //{
        //    return SendPostRequest(module, endPoint, postRequestFutureContract);
        //}
        //
        //public IDictionary<string, object> RequestMap(string module, string endPoint)
        //{
        //    return SendPostRequest(module, endPoint, null);
        //}
        //
        //public IDictionary<string, object> RequestMapGet(string module, string endPoint)
        //{
        //    return SendGetRequest(module, endPoint);
        //}
        //
        //public IDictionary<string, object> MarketFkeyList(string module)
        //{
        //    return SendGetRequest(module, EndPoints.MarketFkeyList);
        //}
        //
        //private IDictionary<string, object> SendPostRequest(string module, string endpoint, IDictionary<string, object> body)
        //{
        //    var request = new RestRequest(endpoint, Method.Post);
        //    request.AddJsonBody(body);
        //    var response = _client.Execute(request);
        //    Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        //    ValidateResponse(response);
        //
        //    return JsonConvert.DeserializeObject<IDictionary<string, object>>(response.Content);
        //}
        //
        //private IDictionary<string, object> SendGetRequest(string module, string endpoint)
        //{
        //    var request = new RestRequest(endpoint, Method.Get);
        //
        //    var response = _client.Execute(request);
        //    ValidateResponse(response);
        //
        //    return JsonConvert.DeserializeObject<IDictionary<string, object>>(response.Content);
        //}
        //
        //private void ValidateResponse(RestResponse response)
        //{
        //    if (!response.IsSuccessful)
        //    {
        //        throw new Exception($"Request failed with status code {response.StatusCode}: {response.Content}");
        //    }
        //}


    }
}
