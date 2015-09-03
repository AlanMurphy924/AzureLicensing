using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace AzureLicensing
{
    public class SmtpConfigSection : ConfigurationSection
    {
        [ConfigurationProperty("smtp", IsRequired = true)]
        public SmtpElement Smtp
        {
            get
            {
                return (SmtpElement)base["smtp"];
            }

            set
            {
                base["smtp"] = value;
            }
        }

        public class SmtpElement : ConfigurationElement
        {
            [ConfigurationProperty("server", IsRequired = true)]
            public string Server
            {
                get
                {
                    return (string)base["server"];
                }

                set
                {
                    base["server"] = value;
                }
            }

            [ConfigurationProperty("port", IsRequired = true)]
            public int Port
            {
                get
                {
                    return (int)base["port"];
                }

                set
                {
                    base["port"] = value;
                }
            }

            [ConfigurationProperty("from", IsRequired = true)]
            public string From
            {
                get
                {
                    return (string)base["from"];
                }

                set
                {
                    base["from"] = value;
                }
            }

            [ConfigurationProperty("to", IsRequired = true)]
            public string To
            {
                get
                {
                    return (string)base["to"];
                }

                set
                {
                    base["to"] = value;
                }
            }
        }

        [ConfigurationProperty("credentials", IsRequired = true)]
        public CredentialsElement Credentials
        {
            get
            {
                return (CredentialsElement)base["credentials"];
            }

            set
            {
                base["credentials"] = value;
            }
        }

        public class CredentialsElement : ConfigurationElement
        {
            [ConfigurationProperty("username", IsRequired = true)]
            public string Username
            {
                get
                {
                    return (string)base["username"];
                }

                set
                {
                    base["username"] = value;
                }
            }

            [ConfigurationProperty("password", IsRequired = true)]
            public string Password
            {
                get
                {
                    return (string)base["password"];
                }

                set
                {
                    base["password"] = value;
                }
            }
        }
    }
}