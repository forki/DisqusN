using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using LanguageExt;

namespace DisqusN
{
    public class DisqusRequester : IDisqusRequester
    {
        public Option<AccessToken> AccessToken { get; set; }
        public Option<DisqusApiPublicKey> PublicKey { get; set; }

        public IDisqusResponseMessage Request<T>(DisqusRequest<T> request)
        {
            DisqusResponseMessage responseMessage = null;

            using (HttpClientHandler gzipHandler = new HttpClientHandler())
            {
                if (gzipHandler.SupportsAutomaticDecompression)
                    gzipHandler.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

                using (var client = new HttpClient(gzipHandler))
                {
                    client.BaseAddress = new Uri("https://disqus.com/api/3.0/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var resourceUri = request.GetRequestUri();

                    var endPoint = client.BaseAddress.AbsoluteUri + resourceUri;
                    PublicKey.IfSome(v=> endPoint += "&api_key=" + v.Key);
                    //AccessToken.IfSome(v => endPoint += "&access_token=" + v);

                    Task<HttpResponseMessage> response = client.GetAsync(endPoint);

                    response.Wait();

                    responseMessage = new DisqusResponseMessage(response.Result);

                    // TODO Deal with failure here?
                }
            }

            return responseMessage;
        }
    }
}
