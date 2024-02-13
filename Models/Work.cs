using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NoteToNumberWeb
{
    [XmlRoot(ElementName = "work")]
    public class Work
    {
        [XmlElement(ElementName = "work-title")]
        public WorktTitle WorktTitle { get; set; }
        
    }
    [XmlRoot(ElementName = "work-title")]
    public class WorktTitle
    {
        [XmlText]
        public string Text { get; set; }
    }
}
