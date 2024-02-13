using System.Xml.Serialization;

namespace NoteToNumberWeb
{
   
    [XmlRoot(ElementName = "creator")]
    public class Creator
    {

        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }

        [XmlText]
        public string Text { get; set; }
    }
}
