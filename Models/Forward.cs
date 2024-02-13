using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NoteToNumberWeb
{
    [XmlRoot(ElementName = "forward")]
    public class Forward : DurationAttribute
    {
        
        [XmlElement(ElementName = "duration")]
        public int Duration { get; set; }

        [XmlElement(ElementName = "voice")]
        public int Voice { get; set; }

        [XmlElement(ElementName = "staff")]
        public int Staff { get; set; }
    }
}
