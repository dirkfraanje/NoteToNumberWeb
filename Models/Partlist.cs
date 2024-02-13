using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NoteToNumberWeb
{
    [XmlRoot(ElementName = "part-list")]
    public class Partlist
    {

        [XmlElement(ElementName = "score-part")]
        public Scorepart Scorepart { get; set; }
    }
}
