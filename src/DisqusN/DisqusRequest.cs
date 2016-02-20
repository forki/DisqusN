using System.Text;

namespace DisqusN
{
    public abstract class DisqusRequest<T>
    {
        private readonly DisqusRequestParameters _parameters;

        private readonly string _resource;
        private readonly string _resourceMethod;

        protected DisqusRequest(string resource, string resourceMethod, DisqusRequestParameters parameters)
        {
            _resource = resource;
            _resourceMethod = resourceMethod;
            _parameters = parameters;
        }

        public string GetRequestUri()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(_resource);
            builder.Append("/");
            builder.Append(_resourceMethod);
            builder.Append(".json");

            var query = _parameters.GetResourceUriQuery();
            if (query.Length > 0)
            {
                builder.Append("?");
                builder.Append(query);
            }

            return builder.ToString();
        }
    }
}