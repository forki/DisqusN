using System.Collections.Generic;

namespace DisqusN.Core
{
    public class DisqusResponseList<T> where T : new()
    {
        public int Code { get; set; }
        public Cursor Cursor { set; get; }
        public List<T> Response { get; set; }
    }
}
