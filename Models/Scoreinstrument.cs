using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NoteToNumberWeb
{
    [XmlRoot(ElementName = "score-instrument")]
    public class Scoreinstrument
    {

        [XmlElement(ElementName = "instrument-name")]
        public string Instrumentname { get; set; }

        [XmlElement(ElementName = "instrument-sound")]
        public string Instrumentsound { get; set; }

        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }

        [XmlText]
        public string Text { get; set; }
    }
}
