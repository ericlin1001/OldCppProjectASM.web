using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3
{
    public class tTailScoreCal
    {
        public static bool shortLengthWarning;
        public static float tailScore;
        public static bool arraySizeWarning;
        public static float[] sortedArray;
        public static int[] sortedArrayPosition;
        public static int min(int a, int b)
        {
            if (a > b)
            {
                a = b;
            }
            return a;
        }
        public static void tTailScore(string tTailSequence, int minTTailSequenceLength, bool tailScoreAlgorithm, bool autoExtendTail)
        {
            if (tTailSequence.Length < minTTailSequenceLength)
            {
                shortLengthWarning = true;
            }
            else
            {
                shortLengthWarning = false;
                float[] xn = new float[15];
                if (tailScoreAlgorithm == true)
                {
                    xn[0] = 1;
                }
                else
                {
                    xn[0] = (float)0.9;
                }
                tailScore = xn[0];
                if (autoExtendTail == true)
                {
                    tTailSequence = tTailSequence.PadRight(15, ' ');
                    for (int i = 1; i <= 14; i++)
                    {
                        if (tTailSequence.Substring(i, 1) == "T")
                        {
                            xn[i] = (float)0.9 * xn[i - 1];
                        }
                        else
                        {
                            xn[i] = (float)0.6 * xn[i - 1];
                        }
                        tailScore += xn[i];
                    }
                }
                if (autoExtendTail == false)
                {
                    for (int i = 1; i <= min(15, tTailSequence.Length); i++)
                    {
                        if ((tTailSequence.Substring(i, 1) == "T"))
                        {
                            xn[i] = (float)0.9 * xn[i - 1];
                        }
                        else
                        {
                            xn[i] = (float)0.6 * xn[i - 1];
                        }
                        tailScore += xn[i];
                    }
                }
            }
        }
        public static float getTailScore()
        {
            return tailScore;
        }
        public static bool getShortLengthWarning()
        {
            return shortLengthWarning;
        }

        public static void arrayTopScore(float[] arrayEnter, int top, float upbounded)
        {
            float[] array = new float[arrayEnter.Length];
            int[] arrayPosition = new int[arrayEnter.Length];
            for (int i = 0; i <= arrayEnter.Length - 1; i++)
            {
                arrayPosition[i] = i + 1;
            }

            int k = 0;
            for (int i = 0; i <= arrayEnter.Length - 1; i++)
            {
                while (arrayEnter[i] <= upbounded)
                {
                    array[k] = arrayEnter[i];
                    arrayPosition[k] = arrayPosition[i];
                    k++;
                }
            }


            if (k < top)
            {
                arraySizeWarning = true;
            }
            else
            {
                arraySizeWarning = false;
                for (int i = 1; i <= k - 1; i++)
                {
                    float array_i = array[i];
                    int arrayPosition_i = arrayPosition[i];
                    int j = i;
                    while ((j > 0) && (array[j - 1] > array_i))
                    {
                        array[j] = array[j - 1];
                        arrayPosition[j] = arrayPosition[j - 1];
                        --j;
                    }
                    array[j] = array_i;
                    arrayPosition[j] = arrayPosition_i;
                }
                sortedArray = new float[top];
                sortedArrayPosition = new int[top];
                for (int i = 1; i <= top - 1; i++)
                {
                    sortedArray[i] = array[i];
                    sortedArrayPosition[i] = arrayPosition[i];
                }
            }
        }



        public static bool getArraySizeWarning()
        {
            return arraySizeWarning;
        }
    }
}