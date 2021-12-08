//
// [Main  Program]
// A console application with a menu system, where the user can run 16 functions.
//

using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApplication
{

    class Program
    {
        private const string TextFileName = "text.txt";
        
        static void DisplayMenu()
        {
            string[] menuLines = { 
                "\nMenu\n",
                "[ 1] Hello, World!                      [ 9] Floating point number",
                "[ 2] Input (name and age)               [10] Multiplication table",
                "[ 3] Toggle text color                  [11] Randomize numbers and sort",
                "[ 4] Show todays date                   [12] Palindrome",
                "[ 5] Highest number                     [13] Sequence",
                "[ 6] Guess the number                   [14] Odd and even numbers",
                "[ 7] Save a text line to a file         [15] Addition of numbers",
                "[ 8] Read a text file                   [16] Player and opponent",
                "\n[ 0] Exit\n"};

            Console.Clear();
            for (int i = 0; i < menuLines.Length; i++)
            {
                Console.WriteLine(menuLines[i]);
            }
        }

        static void GuessingGame()
        {
            Random random = new Random();
            int number = random.Next(100) + 1;
            int tries = 1;
            while(true)
            {
                int guess = UserInput.InputInteger("Guess a number", 1, 100);
                if (guess == number)
                {
                    Console.WriteLine($"\nYou have guessed the right number! [{tries} tries]");
                    break;
                }
                else if (guess > number)
                {
                    Console.WriteLine("\nThe number is lower!\n");
                }
                else
                {
                    Console.WriteLine("\nThe number if higher!\n");
                }
                tries++;
            }
        }

        static void SaveTextToFile(string fileName)
        {
            string line = UserInput.InputString("Enter a text line", false);
            Console.WriteLine("");
            if (File.Exists(fileName)) Console.WriteLine($"Overwriting '{fileName}'\n");
            try
            {
                File.WriteAllText(fileName, line);
                Console.WriteLine("The text line is saved!");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        static void ReadTextFromFile(string fileName)
        {
            if (!File.Exists(fileName))
            {
                Console.WriteLine($"The file '{fileName}' does not exist! Run function [7] from the menu first!");
                return;
            }
            try
            {
                string text = File.ReadAllText(fileName);
                Console.WriteLine(text);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        static void MultiplicationTable()
        {
            for (int row = 1; row < 11; row++)
            {
                string line = "";
                for (int column = 1; column < 11; column++)
                {
                    int value = column * row;
                    line += $"{value}".PadLeft(6);
                }
                Console.WriteLine(line);
            }
        }

        static void SortArray(int[] array)
        {
            while(true)
            {
                bool change = false;
                for (int i = 0; i < array.Length - 1; i++)
                {
                    if (array[i] > array[i+1])
                    {
                        int swap = array[i];
                        array[i] = array[i+1];
                        array[i+1] = swap;
                        change = true;
                    }
                }
                if (!change) break;
            }
        }

        static void SortRandomNumbers()
        {
            const int Numbers = 10;
            int[] randomNumbers = new int[Numbers];
            int[] sortedNumbers = new int[Numbers];
            Random random = new Random();
            for (int i = 0; i < Numbers; i++)
            {
                randomNumbers[i] = random.Next(101); // 0-100
                sortedNumbers[i] = randomNumbers[i];
            }
            SortArray(sortedNumbers);
            string randomLine = "";
            string sortedLine = "";
            for (int i = 0; i < Numbers; i++)
            {
                if (i > 0)
                {
                    randomLine += ", ";
                    sortedLine += ", ";
                }
                randomLine += $"{randomNumbers[i]}";
                sortedLine += $"{sortedNumbers[i]}";
            }
            Console.WriteLine($"Randomized numbers: {randomLine}");
            Console.WriteLine($"\nSorted numbers: {sortedLine}");
        }

        static void Palindrome()
        {
            string phrase = UserInput.InputString("Input a number or a phrase", false).Trim().ToLower();
            string reverse = "";
            for (int i = phrase.Length - 1; i >= 0; i--) reverse += phrase[i];
            if (phrase.Equals(reverse))
            {
                Console.WriteLine($"\n{phrase} is a palindrome!");
            }
            else
            {
                Console.WriteLine($"\n{phrase} is NOT a palindrome!");
            }
        }

        static void NumberSequence()
        {
            int firstNumber = UserInput.InputInteger("Input a number");
            int secondNumber = UserInput.InputInteger("Input another number");
            Console.WriteLine("");
            if (firstNumber > secondNumber)
            {
                for (int i = firstNumber; i >= secondNumber; i--)
                {
                    if ((i == firstNumber) || (i == secondNumber))
                    {
                        Console.Write($"[{i}] ");
                    }
                    else
                    {
                        Console.Write($"{i} ");
                    }
                }
            }
            else
            {
                for (int i = firstNumber; i < secondNumber + 1; i++)
                {
                    if ((i == firstNumber) || (i == secondNumber))
                    {
                        Console.Write($"[{i}] ");
                    }
                    else
                    {
                        Console.Write($"{i} ");
                    }
                }
            }
            Console.WriteLine("");
        }

        static void SortList(List<int> list)
        {
            while(true)
            {
                bool change = false;
                for (int i = 0; i < list.Count - 1; i++)
                {
                    if (list[i] > list[i+1])
                    {
                        int swap = list[i];
                        list[i] = list[i+1];
                        list[i+1] = swap;
                        change = true;
                    }
                }
                if (!change) break;
            }
        }

        static void OddAndEvenNumbers()
        {
            string line = UserInput.InputString("Input a sequence of numbers, separate with a comma", false);
            string[] numbers = line.Split(',');
            List<int> oddNumbers = new List<int>();
            List<int> evenNumbers = new List<int>();
            bool foundError = false;
            foreach(var number in numbers)
            {
                int value;
                if (Int32.TryParse(number, out value))
                {
                    if (value % 2 == 0)
                    {
                        evenNumbers.Add(value);
                    }
                    else
                    {
                        oddNumbers.Add(value);
                    }
                }
                else if (number.Trim().Equals(""))
                {
                    Console.WriteLine("\nNumber expected!");
                    foundError = true;
                    break;
                }
                else
                {
                    Console.WriteLine($"\nNot a valid number [{number.Trim()}]!");
                    foundError = true;
                    break;
                }
            }
            if (!foundError)
            {
                SortList(oddNumbers);
                Console.Write("\nOdd numbers:");
                for (int i = 0; i < oddNumbers.Count; i++) Console.Write($" {oddNumbers[i]}");
                SortList(evenNumbers);
                Console.Write("\nEven numbers:");
                for (int i = 0; i < evenNumbers.Count; i++) Console.Write($" {evenNumbers[i]}");
                Console.WriteLine("");
            }
        }

        static void AddingNumbers()
        {
            string line = UserInput.InputString("Input a sequence of numbers, separate with a comma", false);
            string[] numbers = line.Split(',');
            bool foundError = false;
            int result = 0;
            foreach(var number in numbers)
            {
                int value;
                if (Int32.TryParse(number, out value))
                {
                    result += value;
                }
                else if (number.Trim().Equals(""))
                {
                    Console.WriteLine("\nNumber expected!");
                    foundError = true;
                    break;
                }
                else
                {
                    Console.WriteLine($"\nNot a valid number [{number.Trim()}]!");
                    foundError = true;
                    break;
                }
            }
            if (!foundError) Console.WriteLine($"\nResult: {result}");
        }



        static void Main(/*string[] args*/)
        {
            ConsoleColor defaultColor = Console.ForegroundColor;
            ConsoleColor alternateColor = ConsoleColor.Green;
            if (defaultColor == alternateColor) alternateColor = ConsoleColor.Gray;

            bool isRunning = true;
            while(isRunning)
            {
                DisplayMenu();

                int menuChoice = UserInput.InputInteger("Select", 0, 16);
                Console.WriteLine("");

                switch(menuChoice)
                {
                    case 0:
                        isRunning = false;
                        break;

                    case 1:
                        Console.WriteLine("Hello, World!");
                        UserInput.WaitForKey();                  
                        break;

                    case 2:
                        string firstName = UserInput.InputString("First name", false);
                        string lastName = UserInput.InputString("Last name", false);
                        int age = UserInput.InputInteger("Age", 0, 100);
                        Console.WriteLine($"\nHello {firstName} {lastName}!");
                        Console.WriteLine($"Your age is {age}.");
                        UserInput.WaitForKey();
                        break;

                    case 3:
                        Console.ForegroundColor = (Console.ForegroundColor == defaultColor) ? alternateColor : defaultColor;
                        break;

                    case 4:
                        DateTime today = DateTime.Today;
                        Console.WriteLine("Todays date is {0:d}", today);
                        UserInput.WaitForKey();
                        break;

                    case 5:
                        int firstNumber = UserInput.InputInteger("Input a number");
                        int secondNumber = UserInput.InputInteger("Input another number");
                        int highestNumber = (firstNumber >= secondNumber) ? firstNumber : secondNumber;
                        Console.WriteLine($"\nThe highest number is: {highestNumber}");
                        UserInput.WaitForKey();
                        break;

                    case 6:
                        GuessingGame();
                        UserInput.WaitForKey();
                        break;

                    case 7:
                        SaveTextToFile(TextFileName);
                        UserInput.WaitForKey();
                        break;

                    case 8:
                        ReadTextFromFile(TextFileName);
                        UserInput.WaitForKey();
                        break;

                    case 9:
                        double number = UserInput.InputDouble("Input a floating point number");
                        double result = Math.Sqrt(Math.Pow(Math.Pow(number, 2), 10));
                        Console.WriteLine($"\nThe root of ({number} ^ 2 ^ 10) is: {result}");
                        UserInput.WaitForKey();
                        break;

                    case 10:
                        MultiplicationTable();
                        UserInput.WaitForKey();
                        break;

                    case 11:
                        SortRandomNumbers();
                        UserInput.WaitForKey();
                        break;

                    case 12:
                        Palindrome();
                        UserInput.WaitForKey();
                        break;

                    case 13:
                        NumberSequence();
                        UserInput.WaitForKey();
                        break;

                    case 14:
                        OddAndEvenNumbers();
                        UserInput.WaitForKey();
                        break;

                    case 15:
                        AddingNumbers();
                        UserInput.WaitForKey();
                        break;

                    case 16:
                        Character player = new Character(UserInput.InputString("Input a name for your character", false));
                        Character opponent = new Character(UserInput.InputString("Input a name for your opponent", false));
                        Console.WriteLine("");
                        player.DisplayCharacter();
                        opponent.DisplayCharacter();
                        UserInput.WaitForKey();
                        break;

                }
            }

            Console.ForegroundColor = defaultColor;

        }

    }

}