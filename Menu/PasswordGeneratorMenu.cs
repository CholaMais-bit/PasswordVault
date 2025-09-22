using PasswordVault.Exceptions;
using PasswordVault.Services;
using PasswordVault.Utils;

namespace PasswordVault.Menu
{
    // Menu para gerar senha
    public class PasswordGeneratorMenu
    {
        // Exibir opções do menu
        public void DisplayPasswordGeneratorOptions()
        {
            Console.WriteLine("[1] Create password");
            Console.WriteLine("[2] Generate password");
        }

        // Gerar senha
        public string GeneratePassword()
        {
            try
            {
                Console.Clear();

                Console.WriteLine("=== Generate Password ===\n");
                int size = InputHelper.IntInput("Size of password: ");

                return PasswordGenerator.GeneratePassword(size);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nERROR: {ex.Message}\n");
                return "";
            }
        }
    }
}
