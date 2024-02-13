using System.Xml.Serialization;

namespace NoteToNumberWeb
{
    [XmlRoot(ElementName = "system-margins")]
    public class Systemmargins
    {

        [XmlElement(ElementName = "left-margin")]
        public int Leftmargin { get; set; }

        [XmlElement(ElementName = "right-margin")]
        public int Rightmargin { get; set; }
    }
}
