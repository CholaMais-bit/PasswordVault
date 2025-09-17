using PasswordVault.Services;
using PasswordVault.Utils;

namespace PasswordVault.Menu
{
    // Classe que representa o menu principal
    public class MainMenu
    {
        // Instância de VaultService
        private VaultService vaultService = new VaultService();

        // Exibe as opções do MainMenu
        public void DisplayMainMenu()
        {
            Console.WriteLine("=== Main Menu ===");
            Console.WriteLine("[0] Exit program");
            Console.WriteLine("[1] Create vault");
        }

        // Sair do programa
        public bool ExitProgram()
        {
            Console.Clear();
            Console.WriteLine("Finalized Program");
            return false;
        }

        // Criar um cofre de senha
        public void CreateVault()
        {
            try
            {
                Console.Clear();

                // Pede os dados para o usuário
                Console.WriteLine("=== Create Vault ===");
                string site = InputHelper.StringInput("Site or App: ");
                string password = InputHelper.StringInput("Password: ");

                vaultService.CreateVault(site, password);

                Console.WriteLine("Vault created successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}!");
            }
        }
    }
}
