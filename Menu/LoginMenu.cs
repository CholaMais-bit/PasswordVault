using PasswordVault.Exceptions;
using PasswordVault.Models;
using PasswordVault.Services;
using PasswordVault.Utils;

namespace PasswordVault.Menu
{
    // Menu de login
    public class LoginMenu
    {
        public readonly VaultService vaultService;

        public LoginMenu(VaultService vaultService)
        {
            this.vaultService = vaultService;
        }

        // Exibe as opções de login
        public void DisplayLoginMenuOptions()
        {
            Console.WriteLine("=== PasswordVault ===");
            Console.WriteLine("[0] Exit");
            Console.WriteLine("[1] Login");
            Console.WriteLine("[2] Sign Up");
        }

        public bool Login()
        {
            try
            {
                Console.Clear();

                Console.WriteLine("=== Login ===\n");
                string password = InputHelper.StringInput("Password: ");

                if (!Session.VerifyPasswordSession(password))
                {
                    Console.WriteLine("Incorrect password");
                }

                Console.WriteLine("\nLogged!\n");
                LogService.SaveInLog("User logged");
                return true;
            }
            catch (SessionPasswordWrongException ex)
            {
                Console.WriteLine($"\nERROR: {ex.Message}\n");
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nERROR: {ex.Message}\n");
                return false;
            }
        }

        // Criar uma senha para acessar o cofre
        public void SignUp()
        {
            try
            {
                Console.Clear();

                // Pede os dados para o usuário
                Console.WriteLine("=== Create Session Password ===\n");
                string password = InputHelper.StringInput("Password: ");
                string confirmPassword = InputHelper.StringInput("Confirm password: ");

                if (password != confirmPassword)
                {
                    Console.WriteLine("\nThe passwords do not match\n");
                    return;
                }

                Session session = new Session(password);

                Console.WriteLine("\nPassword created successfully!\n");
                LogService.SaveInLog("User registered");
            }
            catch (SessionPasswordAlreadyExistsException ex)
            {
                Console.WriteLine($"\nERROR: {ex.Message}\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nERROR: {ex.Message}\n");
            }
        }
    }
}
