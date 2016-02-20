namespace DisqusN.Resources.Forums
{
    public abstract class ForumsRequest<T> : DisqusRequest<T>
    {
        private const string _resource = "forums";

        protected ForumsRequest(string resourceMethod, ForumsParameters parameters)
            :base(_resource, resourceMethod, parameters)
        {
        }
    }
}