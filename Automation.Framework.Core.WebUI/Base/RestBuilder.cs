using Automation.Framework.Core.WebUI.Abstractions;
using RestSharp;

namespace Automation.Framework.Core.WebUI.Base;




public class RestBuilder : IRestBuilder
{
    private readonly IRestLibrary _restLibrary;
    private RestRequest RestRequest { get; set; } = null!;

    public RestBuilder(IRestLibrary restLibrary)
    {
        _restLibrary = restLibrary;
    }

    public IRestBuilder WithRequest(string request)
    {
        RestRequest = new RestRequest(request);
        return this;

    }

    public IRestBuilder WithHeader(string name, string value)
    {
        RestRequest.AddHeader(name, value);
        return this;
    }

    public IRestBuilder WithQueryParameter(string name, string value)
    {
        RestRequest.AddQueryParameter(name, value);
        return this;
    }

    public IRestBuilder WithUrlSegment(string name, string value)
    {
        RestRequest.AddUrlSegment(name, value);
        return this;
    }

    public IRestBuilder WithBody(object body)
    {
        RestRequest.AddJsonBody(body);
        return this;
    }

    public async Task<T?> WithGet<T>()
    {
        return await _restLibrary.RestClient.GetAsync<T>(RestRequest);
    }

    public async Task<RestResponse> WithGet()
    {
        return await _restLibrary.RestClient.GetAsync(RestRequest);
    }

    public async Task<T?> WithPost<T>()
    {
        return await _restLibrary.RestClient.PostAsync<T>(RestRequest);
    }

    public async Task<RestResponse> WithPost()
    {
        return await _restLibrary.RestClient.PostAsync(RestRequest);
    }

    public async Task<T?> WithPut<T>()
    {
        return await _restLibrary.RestClient.PutAsync<T>(RestRequest);
    }

    public async Task<T?> WithDelete<T>()
    {
        return await _restLibrary.RestClient.DeleteAsync<T>(RestRequest);
    }

    public async Task<T?> WithPatch<T>()
    {
        return await _restLibrary.RestClient.PatchAsync<T>(RestRequest);
    }



}
