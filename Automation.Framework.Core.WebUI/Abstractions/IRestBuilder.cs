using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Framework.Core.WebUI.Abstractions
{
    public interface IRestBuilder
    {
        IRestBuilder WithRequest(string request);
        IRestBuilder WithHeader(string name, string value);
        IRestBuilder WithQueryParameter(string name, string value);
        IRestBuilder WithUrlSegment(string name, string value);
        IRestBuilder WithBody(object body);
        Task<T?> WithGet<T>();
        Task<T?> WithPost<T>();
        Task<RestResponse> WithPost();
        Task<RestResponse> WithGet();
        Task<T?> WithPut<T>();
        Task<T?> WithDelete<T>();
        Task<T?> WithPatch<T>();
    }
}
