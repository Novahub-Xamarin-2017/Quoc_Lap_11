using System.Xml.Serialization;

namespace Exercise5.Models
{
    [XmlRoot(ElementName = "item")]
    public class GoldRate
    {
        [XmlAttribute(AttributeName = "buy")]
        public string Buy { get; set; }

        [XmlAttribute(AttributeName = "sell")]
        public string Sell { get; set; }

        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
    }
}