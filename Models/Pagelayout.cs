using System.Xml.Serialization;

namespace NoteToNumberWeb
{
    [XmlRoot(ElementName = "page-layout")]
    public class Pagelayout
    {

        [XmlElement(ElementName = "page-height")]
        public int Pageheight { get; set; }

        [XmlElement(ElementName = "page-width")]
        public int Pagewidth { get; set; }

        [XmlElement(ElementName = "page-margins")]
        public Pagemargins Pagemargins { get; set; }
    }
}
