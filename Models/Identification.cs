using System.Xml.Serialization;

namespace NoteToNumberWeb
{
    [XmlRoot(ElementName = "identification")]
    public class Identification
    {

        [XmlElement(ElementName = "creator")]
        public Creator Creator { get; set; }

        [XmlElement(ElementName = "rights")]
        public string Rights { get; set; }

        [XmlElement(ElementName = "encoding")]
        public Encoding Encoding { get; set; }
    }
}
