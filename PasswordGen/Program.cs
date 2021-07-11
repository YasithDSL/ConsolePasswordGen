using System;
using System.Windows.Forms;

namespace PasswordGen
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            Console.WriteLine("Passowrd Generator");
            Console.WriteLine("1. Generate a new password without saving to clipboard");
            Console.WriteLine("2. Generate a new password saving to clipboard");
            Console.WriteLine("\n3. Exit");
            int input = Convert.ToInt32(Console.ReadLine());
            switch (input)
            {
                case 1:
                    Gen(false);
                    Menu();
                    break;
                case 2:
                    Gen(true);
                    Menu();
                    break;
                case 3:
                    return;
                default:
                    Menu();
                    break;
            }
        }

        static void Gen(bool clipboard)
        {
            bool acceptInput = false;
            int length = 1;
            while(!acceptInput)
            {
                try
                {
                    Console.WriteLine("\nEnter desired length of password: ");
                    length = Convert.ToInt32(Console.ReadLine());
                    acceptInput = length > 0;
                }
                catch
                {
                    Console.WriteLine("Input was not a positive integer. Please try again.");
                }
            }
            Console.WriteLine("Allow special characters: [Y/N] (any other input will result in false)");
            bool allowSpecialChars = Console.ReadLine().ToUpper() == "Y" ? true : false;
            bool bias = false;
            if (allowSpecialChars)
            {
                Console.WriteLine("Allow lower chance of special characters appearing: [Y/N] (any other input will result in false)");
                bias = Console.ReadLine().ToUpper() == "Y";
            }
            string generatedPassword = PasswordGen.Generate(length, allowSpecialChars, bias);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n{generatedPassword}\n");
            Console.ForegroundColor = ConsoleColor.Gray;
            if(clipboard)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Clipboard.SetText(generatedPassword);
                Console.WriteLine("Coppied to clipboard!\n");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }
    }
}
