//
// [Module]
// Contains class for handling user input.
//

using System;

namespace Calculator
{

    static class UserInput
    {

        // Prompt the user for an integer.
        public static int InputInteger(string message)
        {
            while(true)
            {
                Console.Write(message + ": ");
                string input = Console.ReadLine();
                int value;
                if (int.TryParse(input, out value)) return value;
            }
        }

        // Prompt the user for an integer.
        // Keeps prompting until the integer is within the range.
        public static int InputInteger(string message, int minimum, int maximum)
        {
            while(true)
            {
                Console.Write(message + $" [{minimum}-{maximum}]: ");
                string input = Console.ReadLine();
                int value;
                if (int.TryParse(input, out value))
                {
                    if ((value >= minimum) && (value <= maximum)) return value;
                }
            }
        }

        // Prompt the user for a floating point number.
        public static float InputFloat(string message)
        {
            while(true)
            {
                Console.Write(message + ": ");
                string input = Console.ReadLine();
                float value;
                if (float.TryParse(input, out value)) return value;
            }
        }

        // Prompt the user for a 'double' (floating point number).
        public static double InputDouble(string message)
        {
            while(true)
            {
                Console.Write(message + ": ");
                string input = Console.ReadLine();
                double value;
                if (double.TryParse(input, out value)) return value;
            }
        }

        // Prompt the user for a 'double' (floating point number).
        public static double InputDouble(string message, bool allowZero)
        {
            while(true)
            {
                Console.Write(message + ": ");
                string input = Console.ReadLine();
                double value;
                if (double.TryParse(input, out value))
                {
                    if ((value == 0.0) && (!allowZero)) continue;
                    return value;
                }
            }
        }

        // Prompt the user for a string.
        public static string InputString(string message, bool allowEmptyString)
        {
            while(true)
            {
                Console.Write(message + ": ");
                string input = Console.ReadLine().Trim();
                if ((input.Equals("")) && (!allowEmptyString)) continue;
                return input;
            }
        }

        // Prompt the user to press a key.
        public static void WaitForKey()
        {
            Console.Write("\nPress any key to continue ...");
            Console.ReadKey();   
            Console.WriteLine();  
        }

    }

}