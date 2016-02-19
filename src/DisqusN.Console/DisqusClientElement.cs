using System.Configuration;

namespace DisqusN.Console
{
    public class DisqusClientElement : ConfigurationElement
    {
        [ConfigurationProperty("Name", IsKey = true, IsRequired = true)]
        public string Name
        {
            get { return (string) this["Name"]; }
            set { this["Name"] = value; }
        }

        [ConfigurationProperty("PublicKey", IsRequired = true)]
        public string PublicKey
        {
            get { return (string)this["PublicKey"]; }
            set { this["PublicKey"] = value; }
        }

        [ConfigurationProperty("PrivateKey")]
        public string PrivateKey
        {
            get { return (string)this["PrivateKey"]; }
            set { this["PrivateKey"] = value; }
        }

        [ConfigurationProperty("AccessToken")]
        public string AccessToken
        {
            get { return (string)this["AccessToken"]; }
            set { this["AccessToken"] = value; }
        }
    }
}
