using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NoteToNumberWeb
{
    [XmlRoot(ElementName = "arpeggiate")]
    public class Arpeggiate
    {

        [XmlAttribute(AttributeName = "default-x")]
        public int DefaultX { get; set; }

        [XmlAttribute(AttributeName = "number")]
        public int Number { get; set; }
    }
}
