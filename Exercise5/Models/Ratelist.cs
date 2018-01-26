using System.Collections.Generic;
using System.Xml.Serialization;

namespace Exercise5.Models
{
    [XmlRoot(ElementName = "ratelist")]
    public class Ratelist
    {
        [XmlElement(ElementName = "city")]
        public List<City> City { get; set; }

        [XmlAttribute(AttributeName = "updated")]
        public string Updated { get; set; }

        [XmlAttribute(AttributeName = "unit")]
        public string Unit { get; set; }
    }
}