using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NoteToNumberWeb
{
    [XmlRoot(ElementName = "swing")]
    public class Swing
    {

        [XmlElement(ElementName = "straight")]
        public object Straight { get; set; }
    }
}
