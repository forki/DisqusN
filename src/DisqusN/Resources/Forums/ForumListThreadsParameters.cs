using LanguageExt;

namespace DisqusN.Resources.Forums
{
    public sealed class ForumListThreadsParameters : ForumsParameters
    {
        public ForumListThreadsParameters(string forum)
            :base(forum)
        {
        }

        [DisqusParameter("limit")]
        public Option<int> Limit { get; set; }

        [DisqusParameter("order")]
        public Option<ItemOrdering> Order { get; set; }

        [DisqusParameter("cursor")]
        public Option<string> Cursor { get; set; }

        [DisqusParameter("thread")]
        public Option<long[]> Threads { get; set; }

        [DisqusParameter("include")]
        public Option<ThreadInclude[]> Include { get; set; }

        [DisqusParameter("related")]
        public Option<ForumRelated[]> Related { get; set; }

        // TODO 
        // since
    }
}