namespace DisqusN.Core
{
    public class DisqusApiPublicKey
    {
        public string Key { get; private set; }

        public DisqusApiPublicKey(string publicKey)
        {
            Key = publicKey;
        }
    }
}
