using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NoteToNumberWeb
{
    [XmlRoot(ElementName = "staccato")]
    public class Staccato
    {

        [XmlAttribute(AttributeName = "default-x")]
        public int DefaultX { get; set; }

        [XmlAttribute(AttributeName = "default-y")]
        public int DefaultY { get; set; }

        [XmlAttribute(AttributeName = "placement")]
        public string Placement { get; set; }
    }
}
