using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NoteToNumberWeb
{
    [XmlRoot(ElementName = "stem")]
    public class Stem
    {

        [XmlAttribute(AttributeName = "default-y")]
        public string DefaultY { get; set; }

        [XmlText]
        public string Text { get; set; }
    }
}
