namespace DisqusN.Resources.Forums
{
    public static class ForumRequests
    {
        public static ForumsListThreadsRequest ListThreads(ForumListThreadsParameters parameters)
        {
            return new ForumsListThreadsRequest(parameters);
        }

        public static ForumsDetailsRequest Details(ForumDetailsParameters parameters)
        {
            return new ForumsDetailsRequest(parameters);
        }
    }
}
