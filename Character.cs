//
// [Module]
// Contains class for handling characters.
//

using System;

namespace ConsoleApplication
{

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
            Health = 50 + random.Next(25);
            Strength = 20 + random.Next(10);
            Luck = 20 + random.Next(20);
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
            Console.WriteLine($"{Name} -> Health: {Health}, Strength: {Strength}, Luck: {Luck}");
        }

    }

}