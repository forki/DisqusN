namespace DisqusN.Resources.Forums
{
    public static class ForumRequests
    {
        public static ForumsListThreadsRequest ListThreads(ForumListThreadsParameters parameters)
        {
            return new ForumsListThreadsRequest(parameters);
        }
    }
}
