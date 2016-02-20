using System.Collections.Generic;

namespace DisqusN
{
    public class DisqusResponseList<T> where T : new()
    {
        public int Code { get; set; }
        public Cursor Cursor { set; get; }
        public List<T> Response { get; set; }
    }
}
