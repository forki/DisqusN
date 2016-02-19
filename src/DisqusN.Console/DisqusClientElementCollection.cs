using System.Configuration;

namespace DisqusN.Console
{
    public class DisqusClientElementCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new DisqusClientElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((DisqusClientElement)element).Name;
        }

        public DisqusClientElement this[int index]
        {
            get { return (DisqusClientElement)BaseGet(index); }
            set
            {
                if (BaseGet(index) != null)
                {
                    BaseRemoveAt(index);
                }
                BaseAdd(index, value);
            }
        }

        public void Add(DisqusClientElement serviceConfig)
        {
            BaseAdd(serviceConfig);
        }

        public void Clear()
        {
            BaseClear();
        }

        public void Remove(DisqusClientElement serviceConfig)
        {
            BaseRemove(serviceConfig.Name);
        }

        public void RemoveAt(int index)
        {
            BaseRemoveAt(index);
        }

        public void Remove(string name)
        {
            BaseRemove(name);
        }
    }
}
