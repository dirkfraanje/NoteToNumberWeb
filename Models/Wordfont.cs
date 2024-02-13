using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NoteToNumberWeb
{
    [XmlRoot(ElementName = "word-font")]
    public class Wordfont
    {

        [XmlAttribute(AttributeName = "font-family")]
        public string FontFamily { get; set; }

        [XmlAttribute(AttributeName = "font-size")]
        public int FontSize { get; set; }
    }
}
