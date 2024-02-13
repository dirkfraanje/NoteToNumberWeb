using System.Xml.Serialization;

namespace NoteToNumberWeb
{
    [XmlRoot(ElementName = "staff-layout")]
    public class Stafflayout
    {

        [XmlElement(ElementName = "staff-distance")]
        public int Staffdistance { get; set; }

        [XmlAttribute(AttributeName = "number")]
        public int Number { get; set; }

        [XmlText]
        public string Text { get; set; }
    }
}
