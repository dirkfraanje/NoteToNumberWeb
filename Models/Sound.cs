using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NoteToNumberWeb
{
    [XmlRoot(ElementName = "sound")]
    public class Sound
    {

        [XmlElement(ElementName = "swing")]
        public Swing Swing { get; set; }

        [XmlAttribute(AttributeName = "tempo")]
        public int Tempo { get; set; }
    }
}
