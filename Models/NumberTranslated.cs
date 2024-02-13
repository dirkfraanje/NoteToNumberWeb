using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteToNumberWeb
{
    internal class NumberTranslated
    {
        public string Line {  get; set; }
        public string Duration { get; set; }
        public int Measure {  get; set; }
        public NumberTranslated(string line, string duration, int measure)
        {
            Line = line;
            Duration = duration;
            Measure = measure;
        }
        public NumberTranslated(string line)
        {
            Line = line;
        }
    }
}
