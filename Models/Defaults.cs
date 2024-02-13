using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NoteToNumberWeb
{
    [XmlRoot(ElementName = "defaults")]
    public class Defaults
    {

        [XmlElement(ElementName = "scaling")]
        public Scaling Scaling { get; set; }

        [XmlElement(ElementName = "page-layout")]
        public Pagelayout Pagelayout { get; set; }

        [XmlElement(ElementName = "system-layout")]
        public Systemlayout Systemlayout { get; set; }

        [XmlElement(ElementName = "staff-layout")]
        public Stafflayout Stafflayout { get; set; }

        [XmlElement(ElementName = "appearance")]
        public Appearance Appearance { get; set; }

        [XmlElement(ElementName = "music-font")]
        public Musicfont Musicfont { get; set; }

        [XmlElement(ElementName = "word-font")]
        public Wordfont Wordfont { get; set; }
    }
}
