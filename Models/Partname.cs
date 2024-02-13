using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NoteToNumberWeb
{
    [XmlRoot(ElementName = "part-name")]
    public class Partname
    {

        [XmlAttribute(AttributeName = "print-object")]
        public string PrintObject { get; set; }

        [XmlText]
        public string Text { get; set; }
    }
}
