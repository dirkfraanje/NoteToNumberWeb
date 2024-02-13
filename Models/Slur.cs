using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NoteToNumberWeb
{
    [XmlRoot(ElementName = "slur")]
    public class Slur
    {

        [XmlAttribute(AttributeName = "bezier-x")]
        public int BezierX { get; set; }

        [XmlAttribute(AttributeName = "bezier-y")]
        public int BezierY { get; set; }

        [XmlAttribute(AttributeName = "default-x")]
        public int DefaultX { get; set; }

        [XmlAttribute(AttributeName = "default-y")]
        public int DefaultY { get; set; }

        [XmlAttribute(AttributeName = "number")]
        public int Number { get; set; }

        [XmlAttribute(AttributeName = "placement")]
        public string Placement { get; set; }

        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }

        [XmlAttribute(AttributeName = "orientation")]
        public string Orientation { get; set; }
    }
}
