using LanguageExt;

namespace DisqusN
{
    public interface IDisqusRequester
    {
        Option<AccessToken> AccessToken { get; set; }
        Option<DisqusApiPublicKey> PublicKey { get; set; }
        IDisqusResponseMessage Request<T>(DisqusRequest<T> request);
    }
}
