using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NoteToNumberWeb
{
    [XmlRoot(ElementName = "beam")]
    public class Beam
    {

        [XmlAttribute(AttributeName = "number")]
        public int Number { get; set; }

        [XmlText]
        public string Text { get; set; }
    }
}
