using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteToNumberWeb
{
    public class Number
    {
        public string First { get; set; }
        public string Second { get; set; }
        public string Third { get; set; }
        public string Fourth { get; set; }
        public int Duration { get; set; }
        public int Measure { get; set; }
        public Number(int measure)
        {
            Measure = measure;
        }

        public bool SecondHigherThenFirst
        {
            get
            {
                if (int.TryParse(First, out int first_Number) && int.TryParse(Second, out int second_Number) && second_Number > first_Number)
                    return true;
                return false;
            }
        }

        public bool FourthHigherThenThird
        {
            get
            {
                if (int.TryParse(Third, out int first_Number) && int.TryParse(Fourth, out int second_Number) && second_Number > first_Number)
                    return true;
                return false;
            }
        }
    }
}
