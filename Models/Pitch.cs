using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NoteToNumberWeb
{
    [XmlRoot(ElementName = "pitch")]
    public class Pitch
    {
        #region XML Import region
        [XmlElement(ElementName = "step")]
        public string Step { get; set; }

        [XmlElement(ElementName = "alter")]
        public int Alter { get; set; }

        [XmlElement(ElementName = "octave")]
        public int Octave { get; set; }
        #endregion

        #region Translation to Number
        public string GetNumber(Translator translator)
        {
            switch (Step)
            {
                case "A":
                    return Note_A(translator.DefaultOctave, translator);
                case "B":
                    return Note_B(translator.DefaultOctave, translator);
                case "C":
                    return Note_C(translator.DefaultOctave, translator);
                case "D":
                    return Note_D(translator.DefaultOctave, translator);
                case "E":
                    return Note_E(translator.DefaultOctave, translator);
                case "F":
                    return Note_F(translator.DefaultOctave, translator);
                case "G":
                    return Note_G(translator.DefaultOctave, translator);
                default:
                    break;
            }
            translator.ErrorLog.AppendLine(Step + " is not implemented");
            translator.ErrorLog.AppendLine();
            return ("\x26A0");
        }

        private string Note_G(int defaultOctave, Translator translator)
        {
            //Default octave
            if(Octave == defaultOctave)
            {
                if (Alter == 0) return "5";
                if (Alter == -1) return "4*";
                if (Alter == 1) return "5*";
            }
            //Default octave + 1
            if (Octave == defaultOctave + 1)
            {
                if (Alter == 0) return "12";
                if (Alter == -1) return "11*";
                if (Alter == 1) return "12*";
            }
            //Default octave - 1
            if (Octave == defaultOctave - 1)
            {
                if (Alter == 0) return "g";
                if (Alter == -1) return "f*";
                if (Alter == 1) return "g*";
            }
            //Default octave - 2
            if (Octave == defaultOctave - 2)
            {
                if (Alter == 0) return "G";
                if (Alter == -1) return "F*";
                if (Alter == 1) return "G*";
            }
            translator.ErrorLog.AppendLine($"Octave {Octave} with alter {Alter} is not implemented for G");
            translator.ErrorLog.AppendLine();
            return ("\x26A0");
        }

        private string Note_F(int defaultOctave, Translator translator)
        {
            //Default octave
            if (Octave == defaultOctave)
            {
                if (Alter == 0) return "4";
                if (Alter == -1) return "3";
                if (Alter == 1) return "4*";
            }
            //Default octave + 1
            if (Octave == defaultOctave + 1)
            {
                if (Alter == 0) return "11";
                if (Alter == -1) return "10";
                if (Alter == 1) return "11*";
            }
            //Default octave -1
            if (Octave == defaultOctave - 1)
            {
                if (Alter == 0) return "f";
                if (Alter == -1) return "e";
                if (Alter == 1) return "f*";
            }
            //Default octave - 2
            if (Octave == defaultOctave - 2)
            {
                if (Alter == 0) return "F";
                if (Alter == -1) return "E";
                if (Alter == 1) return "F*";
            }
            translator.ErrorLog.AppendLine($"Octave {Octave} with alter {Alter} is not implemented for F");
            translator.ErrorLog.AppendLine();
            return ("\x26A0");
        }

        private string Note_E(int defaultOctave, Translator translator)
        {
            //Default octave
            if (Octave == defaultOctave)
            {
                if (Alter == 0) return "3";
                if (Alter == -1) return "2*";
                if (Alter == 1) return "4";
            }
            //Default octave + 1
            if (Octave == defaultOctave + 1)
            {
                if (Alter == 0) return "10";
                if (Alter == -1) return "9*";
                if (Alter == 1) return "11";
            }
            //Default octave - 1
            if (Octave == defaultOctave - 1)
            {
                if (Alter == 0) return "e";
                if (Alter == -1) return "d*";
                if (Alter == 1) return "f";
            }
            //Default octave - 2
            if (Octave == defaultOctave - 2)
            {
                if (Alter == 0) return "E";
                if (Alter == -1) return "D*";
                if (Alter == 1) return "F";
            }
            translator.ErrorLog.AppendLine($"Octave {Octave} with alter {Alter} is not implemented for E");
            translator.ErrorLog.AppendLine();
            return ("\x26A0");
        }

        private string Note_D(int defaultOctave, Translator translator)
        {
            //Default octave
            if (Octave == defaultOctave)
            {
                if (Alter == 0) return "2";
                if (Alter == -1) return "1*";
                if (Alter == 1) return "2*";
            }
            //Default octave + 1
            if (Octave == defaultOctave + 1)
            {
                if (Alter == 0) return "9";
                if (Alter == -1) return "8*";
                if (Alter == 1) return "9*";
            }
            //Default octave -1
            if (Octave == defaultOctave - 1)
            {
                if (Alter == 0) return "d";
                if (Alter == -1) return "c*";
                if (Alter == 1) return "d*";
            }
            //Default octave -2
            if (Octave == defaultOctave - 2)
            {
                if (Alter == 0) return "D";
                if (Alter == -1) return "C*";
                if (Alter == 1) return "D*";
            }
            translator.ErrorLog.AppendLine($"Octave {Octave} with alter {Alter} is not implemented for D");
            translator.ErrorLog.AppendLine();
            return ("\x26A0");
        }

        string Note_A(int defaultOctave, Translator translator)
        {
            //Default octave
            if (Octave == defaultOctave)
            {
                if (Alter == 0) return "6";
                if (Alter == -1) return "5*";
                if (Alter == 1) return "6*";
            }
            //Default octave + 1
            if (Octave == defaultOctave + 1)
            {
                if (Alter == 0) return "13";
                if (Alter == -1) return "12*";
                if (Alter == 1) return "13*";
            }
            //Default octave - 1
            if (Octave == defaultOctave - 1)
            {
                if (Alter == 0) return "a";
                if (Alter == -1) return "g*";
                if (Alter == 1) return "a*";
            }
            //Default octave - 2
            if (Octave == defaultOctave - 2)
            {
                if (Alter == 0) return "A";
                if (Alter == -1) return "G*";
                if (Alter == 1) return "A*";
            }
            translator.ErrorLog.AppendLine($"Octave {Octave} with alter {Alter} is not implemented for A");
            translator.ErrorLog.AppendLine();
            return ("\x26A0");
        }
        string Note_B(int defaultOctave, Translator translator)
        {
            //Default octave
            if (Octave == defaultOctave)
            {
                if (Alter == 0) return "7";
                if (Alter == -1) return "6*";
                if (Alter == 1) return "8";
            }
            //Default octave + 1
            if (Octave == defaultOctave + 1)
            {
                if (Alter == 0) return "14";
                if (Alter == -1) return "13*";
                if (Alter == 1) return "15*";
            }
            //Default octave - 1
            if (Octave == defaultOctave - 1)
            {
                if (Alter == 0) return "b";
                if (Alter == -1) return "a*";
                if (Alter == 1) return "1";
            }
            //Default octave -2
            if (Octave == defaultOctave - 2)
            {
                if (Alter == 0) return "B";
                if (Alter == -1) return "A*";
                if (Alter == 1) return "c";
            }
            translator.ErrorLog.AppendLine($"Octave {Octave} with alter {Alter} is not implemented for B");
            translator.ErrorLog.AppendLine();
            return ("\x26A0");
        }
        string Note_C(int defaultOctave, Translator translator)
        {
            //Default octave
            if (Octave == defaultOctave)
            {
                if (Alter == 0) return "1";
                if (Alter == -1) return "b";
                if (Alter == 1) return "1*";

            }
            //Default octave + 1
            if (Octave == defaultOctave + 1)
            {
                if (Alter == 0) return "8";
                if (Alter == -1) return "7";
                if (Alter == 1) return "8*";

            }
            //Default octave - 1
            if (Octave == defaultOctave - 1)
            {
                if (Alter == 0) return "c";
                if (Alter == -1) return "B";
                if (Alter == 1) return "c*";

            }
            //Default octave - 2
            if (Octave == defaultOctave - 2)
            {
                if (Alter == 0) return "C";
                if (Alter == 1) return "C*";
            }
            translator.ErrorLog.AppendLine($"Octave {Octave} with alter {Alter} is not implemented for C");
            translator.ErrorLog.AppendLine();
            return ("\x26A0");
        }
        #endregion
    }
}
