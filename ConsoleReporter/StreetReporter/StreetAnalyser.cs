using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace StreetReporter
{
    public class StreetAnalyser
    {
        public static bool IsValid(string filename)
        {
            /* Now, this isn't fit for purpose any more. 
            Plus, This class is obviously doing more than it should do anyway */
            try
            {
                File.ReadAllText(filename);
                
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static int CountHouses(List<string> houses)
        {
            return houses.Count();
        }
    }
}
