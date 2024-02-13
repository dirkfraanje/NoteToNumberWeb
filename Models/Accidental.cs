using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NoteToNumberWeb
{
    [XmlRoot(ElementName = "accidental")]
    public class Accidental
    {
        [XmlText]
        public string Text { get; set; }
    }
}
