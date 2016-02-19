namespace DisqusN.Core
{
    public class AccessToken
    {
        public string Token { get; private set; }

        public AccessToken(string token)
        {
            Token = token;
        }
    }
}
