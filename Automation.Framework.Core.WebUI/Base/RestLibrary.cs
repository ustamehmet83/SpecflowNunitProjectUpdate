
using RestSharp;

namespace RestSharpDemoRider.Base;

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



    public static void getUrl(string url)
    {
        switch (url)
        {
            case Modules.YatırımURL:
                Modules.MM = "http://192.168.10.191:32282";
                Modules.FX = "http://192.168.10.191:32463";
                Modules.FIBATCH = "http://192.168.10.191:30091";
                Modules.FI = "http://192.168.10.191:30230";
                Modules.COMMON = "http://192.168.10.191:30825";
                break;
            case Modules.LocalURL:
                Modules.MM = "http://localhost:5041";
                Modules.FX = "http://localhost:5011";
                Modules.FIBATCH = "http://localhost:5022";
                Modules.FI = "http://localhost:5021";
                Modules.COMMON = "http://localhost:5051";
                break;
            default:
                Modules.MM = "http://192.168.10.221:5041";
                Modules.FX = "http://192.168.10.221:5011";
                Modules.FIBATCH = "http://192.168.10.221:5022";
                Modules.FI = "http://192.168.10.221:5021";
                Modules.COMMON = "http://192.168.10.221:5051";
                break;
        }

    }



}

public class Modules
{

    public static string FX = "Fx";
    public static string FI = "Fi";
    public static string MM = "Mm";
    public static string COMMON = "Common";
    public static readonly string ACCOUNTING = "Accounting";
    public static string FIBATCH = "FiBatch";

    public const string LocalURL = "http://localhost:5032/Login";
    public const string KatılımURL = "http://192.168.10.181:30173/Login";
    public const string YatırımURL = "http://192.168.10.191:30157/Login";
    public const string DockerURL = "http://192.168.10.221:5032/Login";



}
