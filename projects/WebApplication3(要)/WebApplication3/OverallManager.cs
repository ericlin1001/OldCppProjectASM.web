using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3
{
    public class OverallManager
    {
        public static int errorState = 0;
        public static string[] aTail;
        public static string[] stemloop;
        public static string[] tTail;
        public static double ttailscore;
        public static double[] terminatorEfficiency;
        public static int[] traceBackNumber;
        public static int[][] recrusionTrackArray;
        public static int[][,] structure;
        public static void OverallManagerConstructor(string terminatorSequence, int top, int minTTailSequenceLength, bool tailScoreAlgorithm, bool autoExtendTail, bool spacer, double HairpinscoreUpbounded, double ttailscoreUpbounded)
        {

            protentialTTail.protentialTtailCalculation(terminatorSequence);

            if (protentialTTail.getNoTTailWarning() == true)
            {
                errorState = 1;
            }
            else
            {
                calculationCore.terminatorSequence = terminatorSequence;
                calculationCore.calculationCoreConstructor();
                Stemloop.stemloopConstructor(terminatorSequence, spacer, top, HairpinscoreUpbounded);
                recrusionTrackArray = new int[top][];
                structure = new int[top][,];
                traceBackNumber = new int[top];
                terminatorEfficiency = new double[top];
                aTail = new string[top];
                stemloop = new string[top];
                tTail = new string[top];



                if ((Stemloop.getArraySizeWarning() == false) && (Stemloop.getStemLoopMinSizeWarning() == false))
                {
                    for (int i = 0; i <= top - 1; i++)
                    {

                        calculationCore.traceBack(Stemloop.tophairpinScorePosition[2 * i], Stemloop.tophairpinScorePosition[2 * i + 1]);
                        recrusionTrackArray[i] = new int[calculationCore.recrusionTrackNumber * terminatorSequence.Length];
                        structure[i] = new int[calculationCore.recrusionTrackNumber, terminatorSequence.Length];
                        for (int j = 0; j <= calculationCore.recrusionTrackNumber * terminatorSequence.Length - 1; j++)
                        {

                            recrusionTrackArray[i][j] = calculationCore.recrusionTrack[j];

                        }
                        for (int t = 0; t <= calculationCore.recrusionTrackNumber; t++)
                        {
                            for (int j = 0; j <= calculationCore.recrusionTrackNumber * terminatorSequence.Length - 1; j++)
                            {
                                if ((j <= (t + 1) * terminatorSequence.Length - 1) && (j >= t * terminatorSequence.Length))
                                {
                                    structure[i][t, j - t * terminatorSequence.Length] = recrusionTrackArray[i][j];
                                }
                            }
                        }
                        tTailScore.tTailScoreConstructor(terminatorSequence.Substring(Stemloop.tophairpinScorePosition[2 * i + 1] + 1), minTTailSequenceLength, tailScoreAlgorithm, autoExtendTail);
                        ttailscore = tTailScore.getTailScore();
                        traceBackNumber[i] = calculationCore.recrusionTrackNumber;
                        terminatorEfficiency[i] = Efficiency.terminatorEfficiencyCal(ttailscore, Stemloop.tophairpinScore[i], Stemloop.tophairpinScorePosition[2 * i + 1] - Stemloop.tophairpinScorePosition[2 * i]);
                        aTail[i] = terminatorSequence.Substring(0, Stemloop.tophairpinScorePosition[2 * i]);
                        stemloop[i] = terminatorSequence.Substring(Stemloop.tophairpinScorePosition[2 * i], Stemloop.tophairpinScorePosition[2 * i + 1] - Stemloop.tophairpinScorePosition[2 * i] + 1);
                        tTail[i] = terminatorSequence.Substring(Stemloop.tophairpinScorePosition[2 * i + 1] + 1);


                    }
                }
                else
                {
                    if (Stemloop.getArraySizeWarning() == true)
                    {
                        errorState = 2;
                    }
                    if (Stemloop.getStemLoopMinSizeWarning() == true)
                    {
                        errorState = 3;
                    }
                }


            }



        }
    }
}