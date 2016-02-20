namespace DisqusN.Resources.Forums
{
    public abstract class ForumsParameters : DisqusRequestParameters
    {
        protected ForumsParameters(string forum)
        {
            Forum = forum;
        }

        [DisqusParameter("forum")]
        public string Forum { get; private set; }
    }
}