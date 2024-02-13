using System.Collections.Generic;
using System.Xml.Serialization;

namespace NoteToNumberWeb
{
    [XmlRoot(ElementName = "encoding")]
    public class Encoding
    {

        [XmlElement(ElementName = "software")]
        public string Software { get; set; }

        [XmlElement(ElementName = "encoding-date")]
        public System.DateTime Encodingdate { get; set; }

        [XmlElement(ElementName = "supports")]
        public List<Supports> Supports { get; set; }
    }
}
