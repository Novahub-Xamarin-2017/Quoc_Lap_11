using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Exercise6.Utils
{
    public class XmlSerializerUtil
    {
        public static T DesirializeObject<T>(string data)
        {
            var serializer = new XmlSerializer(typeof(T));
            using (var stream = new MemoryStream())
            {
                var bytes = Encoding.UTF8.GetBytes(data);
                stream.Write(bytes, 0, bytes.Length);
                stream.Position = 0;
                return (T)serializer.Deserialize(stream);
            }
        }
    }
}
