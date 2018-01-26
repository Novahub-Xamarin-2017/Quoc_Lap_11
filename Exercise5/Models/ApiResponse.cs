using System.Xml.Serialization;

namespace Exercise5.Models
{
    [XmlRoot(ElementName = "root")]
    public class ApiResponse
    {
        [XmlElement(ElementName = "title")]
        public string Title { get; set; }

        [XmlElement(ElementName = "url")]
        public string Url { get; set; }

        [XmlElement(ElementName = "ratelist")]
        public Ratelist Ratelist { get; set; }
    }
}