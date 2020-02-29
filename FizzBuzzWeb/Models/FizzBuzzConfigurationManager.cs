using System.Configuration;

namespace FizzBuzzWeb.Models
{
    public class FizzBuzzConfigurationManager //: ConfigurationElement
    {
        //[ConfigurationProperty("ProductNumber", DefaultValue = 00000, IsRequired = true)]
        public int Limite => int.Parse(ConfigurationManager.AppSettings["Limit"]);
    }
}