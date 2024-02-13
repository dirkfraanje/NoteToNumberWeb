using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NoteToNumberWeb
{
    [XmlRoot(ElementName = "score-partwise")]
    public class Scorepartwise
    {
        #region XML Import region
        [XmlElement(ElementName = "movement-title")]
        public string Movementtitle { get; set; }

        [XmlElement(ElementName = "identification")]
        public Identification Identification { get; set; }

        [XmlElement(ElementName = "defaults")]
        public Defaults Defaults { get; set; }

        [XmlElement(ElementName = "part-list")]
        public Partlist Partlist { get; set; }

        [XmlElement(ElementName = "part")]
        public List<Part> Parts { get; set; }

        [XmlAttribute(AttributeName = "version")]
        public double Version { get; set; }
        [XmlElement(ElementName = "work")]
        public Work Work { get; set; }
        [XmlText]
        public string Text { get; set; }
        #endregion

        #region Translation to Number
        internal void TranslateToNumber(Translator translator)
        {
            foreach (var part in Parts)
            {
                translator.SetDefaults(part);
                foreach (var measure in part.Measures)
                {
                    measure.Translate(translator);
                }
            }
        }

        #endregion
    }
}
