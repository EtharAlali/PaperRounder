using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace StreetReporter
{
    public class Street
    {
        public Street()
        {
            NorthSide = new Houses();
            SouthSide = new Houses();
            Houses = new Houses();
        }

        public static Street Parse(string houseNumbers)
        {
            return Build(houseNumbers);
        }

        private static Street Build(string houseNumbers)
        {
            var result = new Street();

            result.Houses.AddRange(houseNumbers.Split(' ').ToList());

            var allHouses = result.Houses.Select(int.Parse);

            var enumerable = allHouses as int[] ?? allHouses.ToArray();
            result.NorthSide.AddRange(enumerable.Where(h => (h%2) != 0).Select(i => i.ToString(CultureInfo.InvariantCulture)));
            result.SouthSide.AddRange(enumerable.Where(h => (h % 2) == 0).Select(i => i.ToString(CultureInfo.InvariantCulture)));

            return result;
        }

        public bool IsValid(string filename)
        {
            try
            {
                LoadFrom(filename);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static Street LoadFrom(string filename)
        {
            return Parse(File.ReadAllText(filename));
        }

        public int Count(Houses houses)
        {
            return Houses.Count();
        }

        public Houses Houses { get; private set; }
        public Houses NorthSide { get; private set; }
        public Houses SouthSide { get; set; }
    }

    public class Houses : List<string>
    {
    }
}
