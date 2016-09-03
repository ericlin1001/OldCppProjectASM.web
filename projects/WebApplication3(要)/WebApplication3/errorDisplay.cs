using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3
{
    public class errorDisplay
    {
        public static string Warning;
        public static string Help;
        public static void errorDisplayConstructor()
        {
            if (OverallManager.errorState == 0)
            {
                Warning = "";
                Help = "";
            }
            if (OverallManager.errorState == 1)
            {
                Warning = "No T tail";
                Help = "Enter the T tail sequence.";
            }
            if (OverallManager.errorState == 2)
            {
                Warning = "No enough protential structures";
                Help = "Lower top needed";
            }
            if (OverallManager.errorState == 3)
            {
                Warning = "The sequence is too short to have a spacer.";
                Help = "Turn off the spacer";
            }
        }
    }
}