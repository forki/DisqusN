using System.Collections.Generic;

namespace DisqusN
{
    public class DisqusResponseList<T> : DisqusResponse<List<T>> where T : new()
    {
    }
}
