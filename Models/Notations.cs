using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NoteToNumberWeb
{
    [XmlRoot(ElementName = "notations")]
    public class Notations
    {

        [XmlElement(ElementName = "arpeggiate")]
        public Arpeggiate Arpeggiate { get; set; }

        [XmlElement(ElementName = "slur")]
        public Slur Slur { get; set; }

        [XmlElement(ElementName = "articulations")]
        public Articulations Articulations { get; set; }
    }

}
