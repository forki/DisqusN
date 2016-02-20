namespace DisqusN
{
    public class ApplicationRateLimit
    {
        public int Remaining { get; private set; }

        public int Limit { get; private set; }

        public int Reset { get; private set; }

        public ApplicationRateLimit(int remaining, int limit, int reset)
        {
            Remaining = remaining;
            Limit = limit;
            Reset = reset;
        }
    }
}