using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3
{
    public class IO
    {
        public static bool Warn;
        public static string Warning;
        public static string Help;
        public static string[] aTail;
        public static string[] stemloop;
        public static string[] tTail;
        public static int[] stemloopPosition;
        public static int[] traceBackNumber;
        public static int[][,] structure;
        public static double[] terminatorEfficiency;

        public static void input(string terminatorSequence, int top, int minTTailSequenceLength, bool tailScoreAlgorithm, bool autoExtendTail, bool spacer, double HairpinscoreUpbounded, double ttailscoreUpbounded)
        {
            OverallManager.OverallManagerConstructor(terminatorSequence, top, minTTailSequenceLength, tailScoreAlgorithm, autoExtendTail, spacer, HairpinscoreUpbounded, ttailscoreUpbounded);
            errorDisplay.errorDisplayConstructor();
            if (OverallManager.errorState != 0)
            {
                Warn = true;
            }
            else
            {
                Warn = false;
            }
            Warning = errorDisplay.Warning;
            Help = errorDisplay.Help;
            if (Warn == false)
            {
                aTail = new string[top];
                aTail = OverallManager.aTail;
                stemloop = new string[top];
                stemloop = OverallManager.stemloop;
                tTail = new string[top];
                tTail = OverallManager.tTail;
                stemloopPosition = new int[top * 2];
                stemloopPosition = Stemloop.tophairpinScorePosition;
                structure = OverallManager.structure;
                traceBackNumber = OverallManager.traceBackNumber;
                terminatorEfficiency = OverallManager.terminatorEfficiency;

            }


        }
    }
}