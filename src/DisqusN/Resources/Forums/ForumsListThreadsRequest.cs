namespace DisqusN.Core.Resources.Forums
{
    public class ForumsListThreadsRequest : ForumsRequest<Threads>
    {
        private const string _resourceMethod = "listThreads";

        public ForumsListThreadsRequest(ForumListThreadsParameters parameters)
            :base(_resourceMethod, parameters)
        {
        }
    }
}