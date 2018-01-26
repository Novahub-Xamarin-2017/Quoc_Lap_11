using System.Collections.Generic;
using System.Xml.Serialization;

namespace Exercise5.Models
{
    [XmlRoot(ElementName = "city")]
    public class City
    {
        [XmlElement(ElementName = "item")]
        public List<GoldRate> GoldRates { get; set; }

        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
    }
}