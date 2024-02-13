using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NoteToNumberWeb
{
    [XmlRoot(ElementName = "attributes")]
    public class Attributes
    {

        [XmlElement(ElementName = "divisions")]
        public int Divisions { get; set; }

        [XmlElement(ElementName = "key")]
        public Key Key { get; set; }

        [XmlElement(ElementName = "time")]
        public Time Time { get; set; }

        [XmlElement(ElementName = "staves")]
        public int Staves { get; set; }

        [XmlElement(ElementName = "clef")]
        public List<Clef> Clef { get; set; }
    }
}
