using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using LanguageExt;
using static LanguageExt.Prelude;

namespace DisqusN.Core
{
    public interface IDisqusResponseMessage
    {
        string Body { get; }
        Option<ApplicationRateLimit> ApplicationRateLimit { get; } 
    }

    public class DisqusResponseMessage : IDisqusResponseMessage
    {
        public DisqusResponseMessage(HttpResponseMessage httpResponseMessage)
        {
            HttpContent body = null;
            HttpResponseHeaders headers = null;
            ApplicationRateLimit applicationRateLimit = null;

            try
            {
                body = httpResponseMessage.Content;
                headers = httpResponseMessage.Headers;

                IEnumerable<string> values;
                int rateLimitRemaining = -1;
                if (headers.TryGetValues("X-Ratelimit-Remaining", out values))
                {
                    if (!int.TryParse(values.First(), out rateLimitRemaining))
                    {
                        rateLimitRemaining = -1;
                    }
                }

                int rateLimitLimit = -1;
                if (headers.TryGetValues("X-Ratelimit-Limit", out values))
                {
                    if (!int.TryParse(values.First(), out rateLimitLimit))
                    {
                        rateLimitLimit = -1;
                    }
                }

                int rateLimitReset = -1;
                if (headers.TryGetValues("X-Ratelimit-Reset", out values))
                {
                    if (!int.TryParse(values.First(), out rateLimitReset))
                    {
                        rateLimitReset = -1;
                    }
                }

                applicationRateLimit = new ApplicationRateLimit(rateLimitRemaining, rateLimitLimit,
                    rateLimitReset);

                // Try getting out first bit of json to see what code is 

                // If code is zero then we should try and deserialize the whole object

                var jsonBody = body.ReadAsStringAsync();
                jsonBody.Wait();

                Body = jsonBody.Result;
            }
            catch
            {

            }
            finally
            {
                if (applicationRateLimit != null)
                {
                    ApplicationRateLimit = Some(applicationRateLimit);
                }

            }
        }

        public string Body { get; private set; } = string.Empty;
        public Option<ApplicationRateLimit> ApplicationRateLimit { get; private set; } = None;
    }
}
