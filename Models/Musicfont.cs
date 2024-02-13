using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NoteToNumberWeb
{
    [XmlRoot(ElementName = "music-font")]
    public class Musicfont
    {

        [XmlAttribute(AttributeName = "font-family")]
        public string FontFamily { get; set; }

        [XmlAttribute(AttributeName = "font-size")]
        public double FontSize { get; set; }
    }
}
