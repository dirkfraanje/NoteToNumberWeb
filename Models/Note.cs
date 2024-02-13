using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NoteToNumberWeb
{
    [XmlRoot(ElementName = "note")]
    public class Note : DurationAttribute
    {
        #region XML Import region

        [XmlElement(ElementName = "beam")]
        public List<Beam> Beam { get; set; }

        [XmlElement(ElementName = "notations")]
        public Notations Notations { get; set; }

        [XmlAttribute(AttributeName = "default-x")]
        public int DefaultX { get; set; }

        [XmlText]
        public string Text { get; set; }

        [XmlElement(ElementName = "grace")]
        public object Grace { get; set; }

        [XmlElement(ElementName = "rest")]
        public Rest Rest { get; set; }

        [XmlElement(ElementName = "pitch")]
        public Pitch Pitch { get; set; }

        [XmlElement(ElementName = "voice")]
        public int Voice { get; set; }

        [XmlElement(ElementName = "type")]
        public string Type { get; set; }

        [XmlElement(ElementName = "stem")]
        public Stem Stem { get; set; }

        [XmlElement(ElementName = "accidental")]
        public Accidental Accidental { get; set; }

        [XmlElement(ElementName = "staff")]
        public int Staff { get; set; }

        [XmlElement(ElementName = "duration")]
        public int Duration { get; set; }

        [XmlElement(ElementName = "dot")]
        public object Dot { get; set; }

        [XmlElement(ElementName = "chord")]
        public object Chord { get; set; }
        #endregion

        internal void SetDurations(Translator translator)
        {
            for (int i = translator.CurrentDuration; i < translator.CurrentDuration + Duration; i++)
            {
                if (Pitch == null)
                    continue;
                if (translator.Durations.TryGetValue(i, out var duration))
                    duration.Durations.Add(Pitch.GetNumber(translator));
                else
                {
                    var newDuration = new Duration(this);
                    newDuration.Durations.Add(Pitch.GetNumber(translator));
                    translator.Durations.Add(i, newDuration);
                }
            }
        }
    }
}
