using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.SelfHost;


namespace Ambev.DeveloperEvaluation.Integration.Base
{
    [TestClass]
    public abstract class ControllerApiTesteBase
    {
        protected HttpSelfHostServer? servidor;
        protected const string urlBase = "https://localhost:7181/";

        [TestInitialize]
        public void Setup()
        {
            var config = new HttpSelfHostConfiguration(urlBase) { IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always };
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });
            config.Routes.MapHttpRoute(
                name: "ActionApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional });
            servidor = new HttpSelfHostServer(config);
        }

        [TestCleanup]
        public void DesfazServer()
        {
            if (servidor != default)
                servidor.Dispose();
        }

        protected HttpRequestMessage CriarRequest(string url, HttpMethod method, object? content = default, string mediaType = "application/json", MediaTypeFormatter? formatter = default)
        {
            var request = new HttpRequestMessage { RequestUri = new Uri(urlBase + url), Method = method };
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(mediaType));
            if (content != null)
                request.Content = new ObjectContent(content.GetType(), content, formatter ?? new JsonMediaTypeFormatter());
            return request;
        }
    }
}
