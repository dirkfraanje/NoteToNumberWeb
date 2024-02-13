using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NoteToNumberWeb
{
    [XmlRoot(ElementName = "clef")]
    public class Clef
    {

        [XmlElement(ElementName = "sign")]
        public string Sign { get; set; }

        [XmlElement(ElementName = "line")]
        public int Line { get; set; }

        [XmlAttribute(AttributeName = "number")]
        public int Number { get; set; }

        [XmlText]
        public string Text { get; set; }
    }

}
