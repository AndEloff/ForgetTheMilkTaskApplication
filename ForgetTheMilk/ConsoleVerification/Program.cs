using System;
using ForgetTheMilk.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleVerification
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.ReadLine();
        }

        public static void PrintOutcome(bool success, string failureMessage)
        {
            if (success)
            {
                Console.WriteLine("SUCCESS");
            }
            else
            {
                Console.WriteLine("ERROR: ");
                Console.WriteLine(failureMessage);
            }
            Console.WriteLine();
        }
    }
}
