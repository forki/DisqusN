using LanguageExt;

namespace DisqusN.Resources.Forums
{
    public sealed class ForumDetailsParameters : ForumsParameters
    {
        public ForumDetailsParameters(string forum) : base(forum)
        {
        }

        [DisqusParameter("attach")]
        public Option<ForumAttach[]> Attach { get; set; }
    }
}
