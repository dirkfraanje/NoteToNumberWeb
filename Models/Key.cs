using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NoteToNumberWeb
{
    [XmlRoot(ElementName = "key")]
    public class Key
    {

        [XmlElement(ElementName = "fifths")]
        public int Fifths { get; set; }

        [XmlElement(ElementName = "mode")]
        public string Mode { get; set; }
    }
}
