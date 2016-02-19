namespace DisqusN.Core
{
    public class DisqusApiPrivateKey
    {
        public string Key { get; set; }

        public DisqusApiPrivateKey(string privateKey)
        {
            Key = privateKey;
        }
    }
}
