using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NoteToNumberWeb
{
    [XmlRoot(ElementName = "backup")]
    public class Backup
    {

        [XmlElement(ElementName = "duration")]
        public int Duration { get; set; }
    }
}
