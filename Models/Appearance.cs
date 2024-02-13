using System.Collections.Generic;
using System.Xml.Serialization;

namespace NoteToNumberWeb
{
    [XmlRoot(ElementName = "appearance")]
    public class Appearance
    {

        [XmlElement(ElementName = "linewidth")]
        public List<Linewidth> Linewidth { get; set; }

        [XmlElement(ElementName = "notesize")]
        public List<Notesize> Notesize { get; set; }

        [XmlElement(ElementName = "distance")]
        public List<Distance> Distance { get; set; }
    }
}
