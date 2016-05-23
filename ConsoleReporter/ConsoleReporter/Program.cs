using System;
using StreetReporter;

namespace ConsoleReporter
{
    class Program
    {
        static void Main(string[] args)
        {
            // Until now, we've shown nothing. Not very useful. So let's deliver value by showing something
            Console.WriteLine(String.Format("Is the file valid? {0}", new Street().IsValid("street1.txt")));
            Console.ReadLine();
        }
    }
}
