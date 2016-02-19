using System;

namespace DisqusN.Core
{
    [AttributeUsage(AttributeTargets.Property)]
    public class DisqusParameterAttribute : Attribute
    {
        public DisqusParameterAttribute(string parameterName)
        {
            ParameterName = parameterName;
        }

        public string ParameterName { get; private set; }
    }
}
