using Microsoft.AspNetCore.Http;
using System.Net.Http;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Http.Client.Proxying;

namespace AbpProject.Web
{
    [Dependency(ReplaceServices =true)]
    [ExposeServices(typeof(IProxyHttpClientFactory))]
    public class CustomProxyHttpClientFactory : IProxyHttpClientFactory,ITransientDependency
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IHttpContextAccessor Accessor;
        public CustomProxyHttpClientFactory(IHttpClientFactory httpClientFactory,
            IHttpContextAccessor accessor)
        {
            _httpClientFactory = httpClientFactory;
            Accessor = accessor;
        }
        public HttpClient Create()
        {
            Accessor.HttpContext.Request.Headers.TryGetValue("sessionId",out var sessionId);
           var client=_httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Add("sessionId", sessionId.ToString());
            return client;
        }

        public HttpClient Create(string name)
        {
            Accessor.HttpContext.Request.Headers.TryGetValue("sessionId", out var sessionId);
            var client = _httpClientFactory.CreateClient(name);
            client.DefaultRequestHeaders.Add("sessionId", sessionId.ToString());
            return client;
        }
    }
}
