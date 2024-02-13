using System.Xml.Serialization;

namespace NoteToNumberWeb
{
    [XmlRoot(ElementName = "system-layout")]
    public class Systemlayout
    {

        [XmlElement(ElementName = "system-margins")]
        public Systemmargins Systemmargins { get; set; }

        [XmlElement(ElementName = "system-distance")]
        public int Systemdistance { get; set; }

        [XmlElement(ElementName = "top-system-distance")]
        public int Topsystemdistance { get; set; }
    }
}
