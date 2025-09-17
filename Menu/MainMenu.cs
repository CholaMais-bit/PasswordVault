using PasswordVault.Models;
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
            Console.WriteLine("[1] Create password for vault");
            Console.WriteLine("[2] Create vault");
            Console.WriteLine("[3] Display vaults");
            Console.WriteLine("[4] Change password");
            Console.WriteLine("[5] Delete vault");
        }

        // Sair do programa
        public bool ExitProgram()
        {
            Console.Clear();
            Console.WriteLine("Finalized Program");
            return false;
        }

        // Criar uma senha para acessar o cofre
        public void CreatePasswordForVault()
        {
            try
            {
                Console.Clear();

                // Pede os dados para o usuário
                Console.WriteLine("=== Create Password ===\n");
                string password = InputHelper.StringInput("Password: ");

                Session session = new Session(password);

                Console.WriteLine("\nPassword created successfully!\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError: {ex.Message}!\n");
            }
        }

        // Criar um cofre de senha
        public void CreateVault()
        {
            try
            {
                Console.Clear();

                // Pede os dados para o usuário
                Console.WriteLine("=== Create Vault ===\n");
                string plataform = InputHelper.StringInput("Plataform: ");
                string password = InputHelper.StringInput("Password: ");

                vaultService.CreateVault(plataform, password);

                Console.WriteLine("\nVault created successfully!\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError: {ex.Message}!\n");
            }
        }

        // Exibir os cofres
        public void DisplayVaults()
        {
            try
            {
                Console.Clear();
                var vaults = vaultService.GetAllVaults();

                Console.WriteLine("=== Vaults ===\n");
                string password = InputHelper.StringInput("Session Password: ");

                SessionHelper.VerifyPasswordSession(password);

                Console.WriteLine();
                foreach (var vault in vaults)
                {
                    Console.WriteLine($"Plataform: {vault.Plataform}");
                    Console.WriteLine($"Password: {vault.Password}");
                    Console.WriteLine($"Date of Creation: {vault.DateOfCreation}");
                    if (vault.DateOfLastChange != default)
                    {
                        Console.WriteLine($"Date of Last Change: {vault.DateOfLastChange}");
                    }
                    Console.WriteLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError: {ex.Message}!\n");
            }
        }

        // Edita a senha de uma plataforma
        public void ChangePassword()
        {
            try
            {
                Console.Clear();

                Console.WriteLine("=== Change Password ===\n");
                string plataform = InputHelper.StringInput("Plataform: ");
                string password = InputHelper.StringInput("Password: ");

                vaultService.ChangePassword(plataform, password);

                Console.WriteLine("\nPassword changed successfully!\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError: {ex.Message}!\n");
            }
        }

        // Remove um cofre
        public void DeleteVault()
        {
            try
            {
                Console.Clear();

                Console.WriteLine("=== Delete Vault ===\n");
                string password = InputHelper.StringInput("Session Password: ");
                SessionHelper.VerifyPasswordSession(password);
                string plataform = InputHelper.StringInput("Plataform: ");

                vaultService.DeleteVault(plataform);

                Console.WriteLine("\nVault deleted successfully!\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError: {ex.Message}!\n");
            }
        }
    }
}
