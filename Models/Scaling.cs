using System.Xml.Serialization;

namespace NoteToNumberWeb
{
    [XmlRoot(ElementName = "scaling")]
    public class Scaling
    {

        [XmlElement(ElementName = "millimeters")]
        public double Millimeters { get; set; }

        [XmlElement(ElementName = "tenths")]
        public int Tenths { get; set; }
    }
}
