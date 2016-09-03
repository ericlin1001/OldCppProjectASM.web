using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3
{
    public class Efficiency
    {
        public static double dscore;
        public static double terminatorEfficiency;
        public static void dscoreCal(double ttailscore, double hairpinscore, int LH)
        {
            dscore = ttailscore * 18.16 - hairpinscore * 96.59 / LH - 116.87;
        }
        public static double terminatorEfficiencyCal(double ttailscore, double hairpinscore, int LH)
        {
            dscoreCal(ttailscore,  hairpinscore, LH);
            return dscore;
        }
           //*dscoreCal(ttailscore, hairpinscore, LH);
         //   if (dscore < -10)
         //   {
        //
//                terminatorEfficiency = 0;
           // }
           // if ((dscore >= -10) && (dscore < 25))
         //   {
        //        terminatorEfficiency = 2.5 * dscore + 15;
        //    }
        //    if (dscore >= 25)
       //     {
         //       terminatorEfficiency = -0.02 * (dscore * dscore) + 2 * dscore + 40;
       //     }
           
            //*
            
        
    }
}