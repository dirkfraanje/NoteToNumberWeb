using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NoteToNumberWeb
{
    [XmlRoot(ElementName = "time")]
    public class Time
    {

        [XmlElement(ElementName = "beats")]
        public int Beats { get; set; }

        [XmlElement(ElementName = "beat-type")]
        public int Beattype { get; set; }

        [XmlAttribute(AttributeName = "print-object")]
        public string PrintObject { get; set; }

        [XmlText]
        public string Text { get; set; }
    }
}
