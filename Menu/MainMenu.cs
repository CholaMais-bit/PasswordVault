using PasswordVault.Exceptions;
using PasswordVault.Models;
using PasswordVault.Services;
using PasswordVault.Utils;

namespace PasswordVault.Menu
{
    // Classe que representa o menu principal
    public class MainMenu
    {
        private readonly VaultService vaultService;

        public MainMenu(VaultService vaultService)
        {
            this.vaultService = vaultService;
        }

        // Exibe as opções do MainMenu
        public void DisplayMainMenu()
        {
            Console.WriteLine("=== Main Menu ===");
            Console.WriteLine("[0] Exit program");
            Console.WriteLine("[1] Create session password");
            Console.WriteLine("[2] Change session password");
            Console.WriteLine("[3] Create vault");
            Console.WriteLine("[4] Display vaults");
            Console.WriteLine("[5] Change password");
            Console.WriteLine("[6] Delete vault");
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
                Console.WriteLine("=== Create Session Password ===\n");
                string password = InputHelper.StringInput("Password: ");

                Session session = new Session(password);

                Console.WriteLine("\nPassword created successfully!\n");
            }
            catch (SessionPasswordAlreadyExistsException ex)
            {
                Console.WriteLine($"\nError: {ex.Message}\n");
            }
            catch (ForbiddenCharsException ex)
            {
                Console.WriteLine($"\nError: {ex.Message}\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError: {ex.Message}\n");
            }
        }

        // Mudar a senha mestra
        public void ChangeSessionPassword()
        {
            try
            {
                Console.Clear();

                Console.WriteLine("=== Change Session Password ===\n");
                string password = InputHelper.StringInput("Session password: ");
                Session.VerifyPasswordSession(password);
                string newPassword = InputHelper.StringInput("New password: ");

                Session.ChangePassword(newPassword);

                Console.WriteLine("\nPassword changed successfully!\n");
            }
            catch (SessionPasswordWrongException ex)
            {
                Console.WriteLine($"\nERROR: {ex.Message}\n");
            }
            catch (ForbiddenCharsException ex)
            {
                Console.WriteLine($"\nERROR: {ex.Message}\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR: {ex.Message}\n");
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
                string platform = InputHelper.StringInput("Platform: ");
                string password = InputHelper.StringInput("Password: ");

                vaultService.CreateVault(platform, password);

                Console.WriteLine("\nVault created successfully!\n");
            }
            catch (PlatformAlreadyExistException ex)
            {
                Console.WriteLine($"\nERROR: {ex.Message}\n");
            }
            catch (ForbiddenCharsException ex)
            {
                Console.WriteLine($"\nError: {ex.Message}\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError: {ex.Message}\n");
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
                Session.VerifyPasswordSession(password);

                Console.WriteLine();
                foreach (var vault in vaults)
                {
                    Console.WriteLine($"Platform: {vault.Platform}");
                    Console.WriteLine($"Password: {vault.Password}");
                    Console.WriteLine($"Date of Creation: {vault.DateOfCreation}");
                    if (vault.DateOfLastChange != default)
                    {
                        Console.WriteLine($"Date of Last Change: {vault.DateOfLastChange}");
                    }
                    Console.WriteLine();
                }

                if (vaults.Count == 0)
                {
                    Console.WriteLine("No registered safe\n");
                }
            }
            catch (SessionPasswordWrongException ex)
            {
                Console.WriteLine($"\nError: {ex.Message}\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError: {ex.Message}\n");
            }
        }

        // Edita a senha de uma plataforma
        public void ChangeVaultPassword()
        {
            try
            {
                Console.Clear();

                Console.WriteLine("=== Change Vault Password ===\n");
                string sessionPassword = InputHelper.StringInput("Session password: ");
                Session.VerifyPasswordSession(sessionPassword);
                string platform = InputHelper.StringInput("Platform: ");
                string password = InputHelper.StringInput("Password: ");

                vaultService.ChangePassword(platform, password);

                Console.WriteLine("\nPassword changed successfully!\n");
            }
            catch (SessionPasswordWrongException ex)
            {
                Console.WriteLine($"\nERROR: {ex.Message}\n");
            }
            catch (PlatformIsNotRegisteredException ex)
            {
                Console.WriteLine($"\nERROR: {ex.Message}\n");
            }
            catch (ForbiddenCharsException ex)
            {
                Console.WriteLine($"\nError: {ex.Message}\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError: {ex.Message}\n");
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
                Session.VerifyPasswordSession(password);
                string platform = InputHelper.StringInput("Platform: ");

                vaultService.DeleteVault(platform);

                Console.WriteLine("\nVault deleted successfully!\n");
            }
            catch (SessionPasswordWrongException ex)
            {
                Console.WriteLine($"\nERROR: {ex.Message}\n");
            }
            catch (PlatformIsNotRegisteredException ex)
            {
                Console.WriteLine($"\nERROR: {ex.Message}\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError: {ex.Message}\n");
            }
        }
    }
}
