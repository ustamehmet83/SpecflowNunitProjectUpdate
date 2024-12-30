using RestSharp;

namespace Automation.Framework.Core.WebUI.Base;

public interface IRestLibrary
{
    RestClient RestClient { get; }
}

public class RestLibrary : IRestLibrary
{
    public RestLibrary()
    {
        var restClientOptions = new RestClientOptions
        {
            BaseUrl = new Uri("https://localhost:5001/"),
            RemoteCertificateValidationCallback = (sender, certificate, chain, errors) => true
        };

        //Rest Client
        RestClient = new RestClient(restClientOptions);
    }
    public RestClient RestClient { get; }

}

