using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;

namespace WebApplication3
{
    public class Stemloop
    {
        public static int[] hairpinScorePositionArray;

        public static bool arraySizeWarning;
        public static bool stemloopMinSizeWarning;
        public const int stemloopMinSize = 11;
        public static ArrayList hairpinScore = new ArrayList(0);
        public static ArrayList hairpinScorePosition = new ArrayList(0);
        public static double[] tophairpinScore;
        public static int[] tophairpinScorePosition;


        public static void stemloopConstructor(string terminatorSequence, bool spacer, int top, double upbounded)
        {
            int stemloopMinSizeErrorState = 1;
            if (spacer == true)
            {
                for (int t = 0; t <= protentialTTail.protentialTtailPosition.Length - 1; t++)   //须保证protentialTTailPosition不是空数组
                {
                    if (protentialTTail.protentialTtailPosition[t] - 3 - stemloopMinSize + 1 >= 0)  //当所有的t都不能使得protentialTTailPosition[t]-3之前有至少stemloopMinSize个字符的时候警告
                    {
                        stemloopMinSizeErrorState = 0;
                        for (int j = protentialTTail.protentialTtailPosition[t] - 1; j >= protentialTTail.protentialTtailPosition[t] - 3; j--)
                        {
                            for (int i = 0; i <= j - stemloopMinSize - 1; i++)
                            {
                                i = terminatorSequence.IndexOf(calculationCore.complementaryResidue(terminatorSequence.Substring(j, 1)), i, j - stemloopMinSize - i);
                                if (i != -1)
                                {
                                    hairpinScore.Add(calculationCore.getMatrix(i, j));
                                    hairpinScorePosition.Add(i);
                                    hairpinScorePosition.Add(j);
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                    }
                }

                if (stemloopMinSizeErrorState == 0)
                {
                    stemloopMinSizeWarning = false;
                    hairpinScorePositionArray = new int[hairpinScorePosition.Count];
                    hairpinScorePositionArray = (int[])hairpinScorePosition.ToArray(typeof(int));
                    arrayManipulation.arrayManipulationConstructor((double[])hairpinScore.ToArray(typeof(double)), top, upbounded);
                    arraySizeWarning = arrayManipulation.getArraySizeWarning();
                    if (arraySizeWarning == false)
                    {
                        tophairpinScore = arrayManipulation.sortedArray;
                        tophairpinScorePosition = new int[2 * top];
                        tophairpinScore = new double[top];
                        for (int i = 0; i <= top - 1; i++)
                        {
                            tophairpinScorePosition[2 * i] = hairpinScorePositionArray[2 * (arrayManipulation.sortedArrayPosition[i])];
                            tophairpinScorePosition[2 * i + 1] = hairpinScorePositionArray[2 * (arrayManipulation.sortedArrayPosition[i]) + 1];
                        }
                    }
                }
                else
                {
                    stemloopMinSizeWarning = true;
                }
            }










            else
            {
                for (int t = 0; t <= protentialTTail.protentialTtailPosition.Length - 1; t++)   //须保证protentialTTailPosition不是空数组
                {
                    if (protentialTTail.protentialTtailPosition[t] - 1 - stemloopMinSize + 1 >= 0)  //当所有的t都不能使得protentialTTailPosition[t]-3之前有至少stemloopMinSize个字符的时候警告
                    {
                        for (int j = protentialTTail.protentialTtailPosition[t] - 1; j >= protentialTTail.protentialTtailPosition[t] - 1; j--)
                        {
                            for (int i = 0; i <= j - stemloopMinSize - 1; i++)
                            {
                                i = terminatorSequence.IndexOf(calculationCore.complementaryResidue(terminatorSequence.Substring(j, 1)), i, j - stemloopMinSize - i);
                                if (i != -1)
                                {
                                    hairpinScore.Add(calculationCore.getMatrix(i, j));
                                    hairpinScorePosition.Add(i);
                                    hairpinScorePosition.Add(j);
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                    }
                }


                stemloopMinSizeWarning = false;
                hairpinScorePositionArray = new int[hairpinScorePosition.Count];
                hairpinScorePositionArray = (int[])hairpinScorePosition.ToArray(typeof(int));
                arrayManipulation.arrayManipulationConstructor((double[])hairpinScore.ToArray(typeof(double)), top, upbounded);
                arraySizeWarning = arrayManipulation.getArraySizeWarning();
                if (arraySizeWarning == false)
                {
                    tophairpinScore = arrayManipulation.sortedArray;
                    tophairpinScorePosition = new int[2 * top];
                    tophairpinScore = new double[top];
                    for (int i = 0; i <= top - 1; i++)
                    {
                        tophairpinScorePosition[2 * i] = hairpinScorePositionArray[2 * (arrayManipulation.sortedArrayPosition[i])];
                        tophairpinScorePosition[2 * i + 1] = hairpinScorePositionArray[2 * (arrayManipulation.sortedArrayPosition[i]) + 1];
                    }
                }

            }
        }

        public static bool getStemLoopMinSizeWarning()
        {
            return stemloopMinSizeWarning;
        }

        public static bool getArraySizeWarning()
        {
            return arraySizeWarning;
        }
    }
}