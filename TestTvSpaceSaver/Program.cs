using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TvEngine;

namespace TestTvSpaceSaver
{
    class Program
    {
        static void Main(string[] args)
        {
            TvSpaceSaver.ProcessRecording("C:\\Users\\tom\\git\\Twilight Zone\\Frosty the Snowman - CBS - 2015-11-28.ts");
            //TvSpaceSaver.TestCutChapters("TwilightZone", "C:\\Users\\tom\\git\\Twilight Zone\\TwilightZone");
        }
    }
}