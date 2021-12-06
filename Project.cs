//
// Programmering Föreberedande kurs
//
// Ett konsollprojekt med ett menysystem, där användaren kan köra 16 olika funktioner.
//
// ------------
// Andreas Berg
// ------------
//

using System;
using System.Collections.Generic;
using System.IO;

namespace Project
{

    static class UserInput
    {

        public static int InputInteger(string message)
        {
            while(true)
            {
                Console.Write(message + ": ");
                string input = Console.ReadLine();
                int value;
                if (Int32.TryParse(input, out value)) return value;
            }
        }

        public static int InputInteger(string message, int minimum, int maximum)
        {
            while(true)
            {
                Console.Write(message + $" [{minimum}-{maximum}]: ");
                string input = Console.ReadLine();
                int value;
                if (Int32.TryParse(input, out value))
                {
                    if ((value >= minimum) && (value <= maximum)) return value;
                }
            }
        }

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

        public static void WaitForKey()
        {
            Console.Write("\nTryck på en tangent för att fortsätta ...");
            Console.ReadKey();   
            Console.WriteLine();  
        }

    }



    public class Menu
    {
        
        List<string> menuLines = new List<string>();

        public void AddMenuLine(string menuLine)
        {
            menuLines.Add(menuLine);
        }

        public void DisplayMenu()
        {
            for (int i = 0; i < menuLines.Count; i++) Console.WriteLine(menuLines[i]);
        }

    }



    public class Character
    {
        private string Name;
        private int Health;
        private int Strength;
        private int Luck;

        public Character(string name)
        {
            Random random = new Random();
            Name = name;
            Health = random.Next(100) + 1;
            Strength = random.Next(100) + 1;
            Luck = random.Next(100) + 1;
        }

        public string GetName()
        {
            return Name;
        }

        public int GetHealth()
        {
            return Health;
        }

        public int GetStrength()
        {
            return Strength;
        }

        public int GetLuck()
        {
            return Luck;
        }

        public void DisplayCharacter()
        {
            Console.WriteLine($"{Name} -> Hälsa: {Health}, Styrka: {Strength}, Tur: {Luck}");
        }

    }



    class Program
    {
        private const string TextFileName = "text.txt";
        
        static void BuildMenu(Menu menu)
        {
            string[] menuLines = { 
                "\n[ 1] Hello, World!                      [ 9] Decimaltal",
                "[ 2] Inmatning (namn och ålder)         [10] Multiplikationstabell",
                "[ 3] Växla textfärg                     [11] Slumpa tal och sortera",
                "[ 4] Visa dagens datum                  [12] Palindrom",
                "[ 5] Största talet                      [13] Siffror mellan två tal",
                "[ 6] Gissa talet                        [14] Udda och jämna tal",
                "[ 7] Spara textrad till fil             [15] Addera tal",
                "[ 8] Läs in en textfil                  [16] Karaktär och motståndare",
                "\n[ 0] Avsluta\n"};

            for (int i = 0; i < menuLines.Length; i++)
            {
                menu.AddMenuLine(menuLines[i]);
            }
        }

        static void GuessingGame()
        {
            Random random = new Random();
            int number = random.Next(100) + 1;
            int tries = 1;
            while(true)
            {
                int guess = UserInput.InputInteger("Gissa ett tal", 1, 100);
                if (guess == number)
                {
                    Console.WriteLine($"\nDu har gissat rätt! Det tog {tries} försök.");
                    break;
                }
                else if (guess > number)
                {
                    Console.WriteLine("\nTalet är lägre!\n");
                }
                else
                {
                    Console.WriteLine("\nTalet är högre!\n");
                }
                tries++;
            }
        }

        static void SaveTextToFile(string fileName)
        {
            string line = UserInput.InputString("Mata in en textrad", false);
            Console.WriteLine("");
            if (File.Exists(fileName)) Console.WriteLine($"Skriver över '{fileName}'\n");
            try
            {
                File.WriteAllText(fileName, line);
                Console.WriteLine("Textraden är sparad!");
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
                Console.WriteLine($"Filen '{fileName}' finns inte! Kör funktion [7] från menyn först!");
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
            Console.WriteLine($"Slumpade tal: {randomLine}");
            Console.WriteLine($"\nSorterade tal: {sortedLine}");
        }

        static void Palindrome()
        {
            string phrase = UserInput.InputString("Mata in ett ord eller fras", false).Trim().ToLower();
            string reverse = "";
            for (int i = phrase.Length - 1; i >= 0; i--) reverse += phrase[i];
            if (phrase.Equals(reverse))
            {
                Console.WriteLine($"\n{phrase} är en palindrom!");
            }
            else
            {
                Console.WriteLine($"\n{phrase} är INTE en palindrom!");
            }
        }

        static void NumbersBetween()
        {
            int firstNumber = UserInput.InputInteger("Ange ett tal");
            int secondNumber = UserInput.InputInteger("Ange ytterligare ett tal");
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
            string line = UserInput.InputString("Ange en serie med tal, separera med kommatecken", false);
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
                    Console.WriteLine("\nTal förväntades!");
                    foundError = true;
                    break;
                }
                else
                {
                    Console.WriteLine($"\nEj giltligt tal [{number.Trim()}]!");
                    foundError = true;
                    break;
                }
            }
            if (!foundError)
            {
                SortList(oddNumbers);
                Console.Write("\nUdda tal:");
                for (int i = 0; i < oddNumbers.Count; i++) Console.Write($" {oddNumbers[i]}");
                SortList(evenNumbers);
                Console.Write("\nJämna tal:");
                for (int i = 0; i < evenNumbers.Count; i++) Console.Write($" {evenNumbers[i]}");
                Console.WriteLine("");
            }
        }

        static void AddingNumbers()
        {
            string line = UserInput.InputString("Ange en serie med tal, separera med kommatecken", false);
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
                    Console.WriteLine("\nTal förväntades!");
                    foundError = true;
                    break;
                }
                else
                {
                    Console.WriteLine($"\nEj giltligt tal [{number.Trim()}]!");
                    foundError = true;
                    break;
                }
            }
            if (!foundError) Console.WriteLine($"\nSumman är: {result}");
        }

        static void Main(/*string[] args*/)
        {
            ConsoleColor defaultColor = Console.ForegroundColor;
            ConsoleColor alternateColor = ConsoleColor.Green;
            if (defaultColor == alternateColor) alternateColor = ConsoleColor.Gray;

            Menu menu = new Menu();
            BuildMenu(menu);         

            bool isRunning = true;
            while(isRunning)
            {
                menu.DisplayMenu();

                int menuChoice = UserInput.InputInteger("Val", 0, 16);
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
                        string firstName = UserInput.InputString("Förnamn", false);
                        string lastName = UserInput.InputString("Efternamn", false);
                        int age = UserInput.InputInteger("Ålder", 0, 100);
                        Console.WriteLine($"\nHej {firstName} {lastName}!");
                        Console.WriteLine($"Du är {age} år.");
                        UserInput.WaitForKey();   
                        break;

                    case 3:
                        Console.ForegroundColor = (Console.ForegroundColor == defaultColor) ? alternateColor : defaultColor;
                        break;

                    case 4:
                        DateTime today = DateTime.Today;
                        Console.WriteLine("Dagens datum är {0:d}", today);
                        UserInput.WaitForKey();
                        break;

                    case 5:
                        int firstNumber = UserInput.InputInteger("Ange ett heltal");
                        int secondNumber = UserInput.InputInteger("Ange ytterligare ett heltal");
                        int highestNumber = (firstNumber >= secondNumber) ? firstNumber : secondNumber;
                        Console.WriteLine($"\nDet största talet är: {highestNumber}");
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
                        double number = UserInput.InputDouble("Ange ett decimaltal");
                        double result = Math.Sqrt(Math.Pow(Math.Pow(number, 2), 10));
                        Console.WriteLine($"\nRoten av ({number} ^ 2 ^ 10) är: {result}");
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
                        NumbersBetween();
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
                        Character player = new Character(UserInput.InputString("Ange ett namn för din karaktär", false));
                        Character opponent = new Character(UserInput.InputString("Ange ett namn för din moståndare", false));
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