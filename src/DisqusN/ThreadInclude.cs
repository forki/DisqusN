using System.ComponentModel;

namespace DisqusN.Core
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
