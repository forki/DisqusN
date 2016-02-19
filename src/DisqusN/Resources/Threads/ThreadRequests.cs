using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisqusN.Core.Resources.Threads
{
    public static class ThreadRequests
    {
        public static ThreadListPostsRequest ListPosts(ThreadListPostsParameters parameters)
        {
            return new ThreadListPostsRequest();
        }
    }

    public abstract class ThreadRequest
    {
        
    }

    public class ThreadListPostsRequest : ThreadRequest
    {
        
    }

    public abstract class ThreadParameters
    {
        public int ThreadId { get; set; }
    }

    public class ThreadListPostsParameters : ThreadParameters
    {
        
    }
}
