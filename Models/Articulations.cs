using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NoteToNumberWeb
{

    [XmlRoot(ElementName = "articulations")]
    public class Articulations
    {

        [XmlElement(ElementName = "staccato")]
        public Staccato Staccato { get; set; }
    }
}
