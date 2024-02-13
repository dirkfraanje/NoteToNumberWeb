using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NoteToNumberWeb
{
    [XmlRoot(ElementName = "grace")]
    public class Grace
    {

        [XmlAttribute(AttributeName = "slash")]
        public string Slash { get; set; }
    }
}
