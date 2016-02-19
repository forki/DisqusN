using System;
using System.Configuration;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace DisqusN.Console
{
    public class DisqusClientConfigurationSection : ConfigurationSection
    {
        private static ConfigurationPropertyCollection _properties;
        private static ConfigurationProperty _file;
        private static ConfigurationProperty _disqusClients;

        [ConfigurationProperty("DisqusClients", IsDefaultCollection = false)]
        [ConfigurationCollection(typeof(DisqusClientElementCollection),
           AddItemName = "DisqusClient")]
        public DisqusClientElementCollection DisqusClients
        {
            get
            {
                return (DisqusClientElementCollection)base[_disqusClients];
            }
            set
            {
                base[_disqusClients] = value;
            }
        }

        [ConfigurationProperty("File", DefaultValue = "")]
        public string File
        {
            get
            {
                string fileValue = (string)base[_file];
                if (fileValue == null)
                {
                    return string.Empty;
                }
                return fileValue;
            }
            set
            {
                base[_file] = value;
            }
        }

        private static ConfigurationPropertyCollection EnsureStaticPropertyBag()
        {
            if (_properties == null)
            {
                ConfigurationProperty propFile = new ConfigurationProperty("File", typeof(string), string.Empty, ConfigurationPropertyOptions.None);
                ConfigurationProperty propDisqusClients = new ConfigurationProperty("DisqusClients", typeof(DisqusClientElementCollection), null, ConfigurationPropertyOptions.None);

                ConfigurationPropertyCollection properties = new ConfigurationPropertyCollection();
                properties.Add(propDisqusClients);
                properties.Add(propFile);

                
                _file = propFile;
                _disqusClients = propDisqusClients;
                _properties = properties;
            }

            return _properties;
        }

        public DisqusClientConfigurationSection()
        {
            EnsureStaticPropertyBag();
        }

        protected override ConfigurationPropertyCollection Properties
        {
            get
            {
                return EnsureStaticPropertyBag();
            }
        }

        protected override void DeserializeElement(XmlReader reader, bool serializeCollectionKey)
        {
            base.DeserializeElement(reader, serializeCollectionKey);

            if (!string.IsNullOrEmpty(File))
            {
                string sourceFileFullPath;
                string configFileDirectory;
                string configFile;

                // Determine file location
                configFile = ElementInformation.Source;

                if (String.IsNullOrEmpty(configFile))
                {
                    sourceFileFullPath = File;
                }
                else {
                    configFileDirectory = System.IO.Path.GetDirectoryName(configFile);
                    sourceFileFullPath = System.IO.Path.Combine(configFileDirectory, File);
                }

                if (System.IO.File.Exists(sourceFileFullPath))
                {
                    XDocument xdoc = XDocument.Load(sourceFileFullPath);

                    var disqusClients = xdoc.Descendants("DisqusClients").SingleOrDefault();

                    if(disqusClients == null)
                        return;

                    var clients = disqusClients.Descendants("add");

                    if (!clients.Any())
                        return;

                    DisqusClientElementCollection elements = new DisqusClientElementCollection();

                    foreach (var client in clients)
                    {
                        DisqusClientElement clientElement = new DisqusClientElement();

                        clientElement.Name = client.Attribute("Name").Value;
                        clientElement.PublicKey = client.Attribute("PublicKey").Value;

                        var privateKeyAttrib = client.Attribute("PrivateKey");
                        if(privateKeyAttrib != null)
                            clientElement.PrivateKey = privateKeyAttrib.Value;

                        var accessTokenKeyAttrib = client.Attribute("AccessToken");
                        if (privateKeyAttrib != null)
                            clientElement.AccessToken = accessTokenKeyAttrib.Value;

                        elements.Add(clientElement);
                    }

                    DisqusClients = elements;
                }
            }
        }
    }
}
