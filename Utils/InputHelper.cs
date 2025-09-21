namespace PasswordVault.Utils
{
    // Contém as validações de entrada do usuário
    public class InputHelper
    {
        // Validação de entrada int
        public static int IntInput(string message)
        {
            Console.Write(message);
            int val;

            while (!int.TryParse(Console.ReadLine(), out val))
            {
                Console.WriteLine("Invalid entry. Try again: ");
            }

            return val;
        }

        // Validação de entrada string
        public static string StringInput(string message)
        {
            Console.Write(message);
            string str = Console.ReadLine() ?? "";

            while (string.IsNullOrWhiteSpace(str))
            {
                Console.WriteLine("Invalid entry. Try again: ");
                str = Console.ReadLine() ?? "";
            }

            return str;
        }

        // Validação de entrada y/n
        public static char CharInput(string message, char[] permitedChars)
        {
            Console.Write(message);
            string str = Console.ReadLine() ?? "";

            while (str.Length != 1 || !permitedChars.Contains(str[0]))
            {
                Console.Write("Invalid entry. Try again: ");
                str = Console.ReadLine() ?? "";
            }

            return str[0];
        }
    }
}
