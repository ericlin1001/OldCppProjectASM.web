using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;

namespace WebApplication3
{
    public class protentialTTail
    {
        public static ArrayList protentialTtailPositionArray;
        public static int[] protentialTtailPosition;
        public static bool noTTailWarning;
        public const int stemloopMinSize = 11;
        public static void protentialTtailCalculation(string terminatorSequence)
        {
            protentialTtailPositionArray = new ArrayList(terminatorSequence.Length);
            for (int i = stemloopMinSize; i <= terminatorSequence.Length - 2; i++)
            {
                i = terminatorSequence.IndexOf("TT", i);
                protentialTtailPositionArray.Add(i);
               if (i == -1)
                {
                    break;
                }
            }
            protentialTtailPositionArray.Remove(-1);
            for (int j = protentialTtailPositionArray.Count - 1; j >= 1; j--)
            {
                if (Convert.ToInt32(protentialTtailPositionArray[j]) == Convert.ToInt32(protentialTtailPositionArray[j - 1]) + 1)
                {
                    protentialTtailPositionArray.RemoveAt(j);
                }
            }

            if (protentialTtailPositionArray.Count != 0)
            {
                noTTailWarning = false;
                protentialTtailPosition = (int[])protentialTtailPositionArray.ToArray(typeof(int));
            }
            else
            {
                noTTailWarning = true;
            }
        }

        public static bool getNoTTailWarning()
        {
            return noTTailWarning;
        }
    }
}