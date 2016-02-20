using LanguageExt;

namespace DisqusN
{
    public class DisqusApiResponse<T>
    {
        public int Code { get; private set; }

        public ApplicationRateLimit RateLimit { get; private set; }

        public Either<ErrorResponseMessage, T> Response { get; private set; }

        public DisqusApiResponse(ApplicationRateLimit rateLimit, int code, Either<ErrorResponseMessage, T> response)
        {
            RateLimit = rateLimit;
            Code = code;
            Response = response;
        }
    }
}