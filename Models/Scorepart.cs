using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NoteToNumberWeb
{

    [XmlRoot(ElementName = "score-part")]
    public class Scorepart
    {

        [XmlElement(ElementName = "part-name")]
        public Partname Partname { get; set; }

        [XmlElement(ElementName = "score-instrument")]
        public Scoreinstrument Scoreinstrument { get; set; }

        [XmlElement(ElementName = "midi-instrument")]
        public Midiinstrument Midiinstrument { get; set; }

        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }

        [XmlText]
        public string Text { get; set; }
    }
}
