namespace DisqusN
{
    public class DisqusResponse<T>
    {
        public int Code { get; set; }
        public Cursor Cursor { set; get; }
        public T Response { get; set; }
    }
}
