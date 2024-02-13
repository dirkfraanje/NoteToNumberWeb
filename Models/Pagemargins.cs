using System.Xml.Serialization;

namespace NoteToNumberWeb
{
    [XmlRoot(ElementName = "page-margins")]
    public class Pagemargins
    {

        [XmlElement(ElementName = "left-margin")]
        public int Leftmargin { get; set; }

        [XmlElement(ElementName = "right-margin")]
        public int Rightmargin { get; set; }

        [XmlElement(ElementName = "top-margin")]
        public int Topmargin { get; set; }

        [XmlElement(ElementName = "bottom-margin")]
        public int Bottommargin { get; set; }

        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }

        [XmlText]
        public string Text { get; set; }
    }
}
