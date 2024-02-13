using System.Xml.Serialization;

namespace NoteToNumberWeb
{
    [XmlRoot(ElementName = "note-size")]
    public class Notesize
    {

        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }

        [XmlText]
        public int Text { get; set; }
    }
}
