using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteToNumberWeb
{
    public abstract class DurationAttribute
    {
        static int autoNumber = 0;
        public int Sequence { get; }
        public static int AutoNumber { get => autoNumber; }
        public DurationAttribute()
        {
            autoNumber++;
            Sequence = AutoNumber;
        }
    }
}
