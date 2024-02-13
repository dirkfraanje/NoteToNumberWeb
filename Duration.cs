using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteToNumberWeb
{
    public struct Duration
    {
        public Duration(Note note)
        {
            Note = note;
            Durations = new List<string>();
        }
        public Note Note { get; set; }
        public List<string> Durations { get; set; }
    }
}
