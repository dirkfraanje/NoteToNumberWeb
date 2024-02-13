using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NoteToNumberWeb
{
    [XmlRoot(ElementName = "print")]
    public class Print
    {

        [XmlElement(ElementName = "system-layout")]
        public Systemlayout Systemlayout { get; set; }

        [XmlElement(ElementName = "staff-layout")]
        public Stafflayout Stafflayout { get; set; }

        [XmlElement(ElementName = "measure-numbering")]
        public string Measurenumbering { get; set; }
    }
}
