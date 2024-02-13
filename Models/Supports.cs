using System.Xml.Serialization;

namespace NoteToNumberWeb
{
    [XmlRoot(ElementName = "supports")]
    public class Supports
    {

        [XmlAttribute(AttributeName = "attribute")]
        public string Attribute { get; set; }

        [XmlAttribute(AttributeName = "element")]
        public string Element { get; set; }

        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }

        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }
    }
}
