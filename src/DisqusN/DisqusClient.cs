using System;
using LanguageExt;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using static LanguageExt.Prelude;

namespace DisqusN.Core
{
    public class DisqusClient
    {
        private Option<AccessToken> _accessToken = None;
        private Option<DisqusApiPublicKey> _publicKey = None;

        private IDisqusRequester _disqusRequester = null;

        public DisqusClient(DisqusApiPublicKey publicKey, ApplicationOwnerAccessToken accessToken)
            :this()
        {
            _publicKey = publicKey;
            _accessToken = accessToken;
        }

        private DisqusClient()
        {
            _disqusRequester = new DisqusRequester();
        }

        internal DisqusClient(IDisqusRequester disqusRequester, ApplicationOwnerAccessToken accessToken)
        {
            _disqusRequester = disqusRequester;
            _accessToken = accessToken;
        }

        public bool ApplyStrictResponseParsing { get; set; }

        public Either<ErrorResponseMessage, DisqusApiResponse<T>> Request<T>(DisqusRequest<T> request)
        {
            _disqusRequester.AccessToken = _accessToken;
            _disqusRequester.PublicKey = _publicKey;

            IDisqusResponseMessage result = _disqusRequester.Request(request);

            if (result.ApplicationRateLimit.IsNone)
                return Left<ErrorResponseMessage, DisqusApiResponse<T>>(new ErrorResponseMessage(result.Body));

            DisqusApiResponse<T> apiResponse;

            int code = -1;

            ApplicationRateLimit rateLimit = null;

            result.ApplicationRateLimit.Match(
                Some: v => rateLimit = v,
                None: () => { });

            T deserialized = default(T);

            JObject jsonBody = null;

            try
            {
                jsonBody = JObject.Parse(result.Body);

                var codeFragment = jsonBody["code"];

                if (codeFragment != null)
                    code = (int)codeFragment;

                MemoryTraceWriter traceWriter = new MemoryTraceWriter();

                deserialized = JsonConvert.DeserializeObject<T>(result.Body, new JsonSerializerSettings
                {
                    Formatting = Formatting.Indented,
                    MissingMemberHandling = ApplyStrictResponseParsing
                        ? MissingMemberHandling.Error
                        : MissingMemberHandling.Ignore,
                    TraceWriter = traceWriter
                });

                apiResponse = new DisqusApiResponse<T>(rateLimit, code, Right<ErrorResponseMessage, T>(deserialized));
            }
            catch (Exception ex)
            {
                string errorMessage = "Unknown error";

                var codeFragment = jsonBody?["response"];

                if (codeFragment != null)
                    errorMessage = (string)codeFragment;

                apiResponse = new DisqusApiResponse<T>(rateLimit, code,
                        Left<ErrorResponseMessage, T>(new ErrorResponseMessage(errorMessage) { Exception = ex }));
            }

            return apiResponse;
        }
    }
}
