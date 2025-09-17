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
    }
}
