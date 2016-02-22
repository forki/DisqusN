namespace DisqusN.Resources.Forums
{
    public sealed class ForumsDetailsRequest : ForumsRequest<DisqusResponse<Forum>>
    {
        private const string _resourceMethod = "details";

        public ForumsDetailsRequest(ForumDetailsParameters parameters)
            :base(_resourceMethod, parameters)
        {
        }
    }
}
