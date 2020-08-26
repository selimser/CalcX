using System;
using System.Collections.Generic;
using System.Text;

namespace Calcx.Core.Entity
{
    public sealed class DegreeMinuteSecond
    {
        public double Degrees { get; internal set; }
        public double Minutes { get; internal set; }
        public double Seconds { get; internal set; }
        public string GetFormattedString()
        {
            return $"{Degrees}{Convert.ToChar("0xB0")} {Minutes}\" {Seconds}'";
        }

        public string GetLaTeXString() //TODO: verify this.
        {
            return Degrees + @"^{\circ} " + $"{Minutes}\" {Seconds}'";
        }


    }
}
