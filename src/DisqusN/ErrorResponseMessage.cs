using System;
using LanguageExt;

namespace DisqusN
{
    public class ErrorResponseMessage
    {
        public ErrorResponseMessage(string message)
        {
            Message = message;
        }

        public string Message { get; private set; }
        public Option<Exception> Exception { get; internal set; } = Prelude.None;
    }
}