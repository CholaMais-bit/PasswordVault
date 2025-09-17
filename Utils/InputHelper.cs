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
    }
}
