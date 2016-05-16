using System;
using System.IO;

namespace StreetReporter
{
    public class StreetAnalyser
    {
        public static bool IsValid(string Filename)
        {
            // Refactored to include all the relevant functionality in here
            // Now that our thought process is clearer.
            try
            {
                File.ReadAllText(Filename);
                
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static int CountHouses()
        {
            return 0;
        }
    }
}
