using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NoteToNumberWeb
{
    [XmlRoot(ElementName = "midi-instrument")]
    public class Midiinstrument
    {

        [XmlElement(ElementName = "midi-channel")]
        public int Midichannel { get; set; }

        [XmlElement(ElementName = "midi-program")]
        public int Midiprogram { get; set; }

        [XmlElement(ElementName = "volume")]
        public double Volume { get; set; }

        [XmlElement(ElementName = "pan")]
        public int Pan { get; set; }

        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }

        [XmlText]
        public string Text { get; set; }
    }
}
