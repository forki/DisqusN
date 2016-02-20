using System.ComponentModel;

namespace DisqusN
{
    public enum ThreadInclude
    {
        [Description("open")]
        Open,
        [Description("closed")]
        Closed,
        [Description("killed")]
        Killed
    }
}
