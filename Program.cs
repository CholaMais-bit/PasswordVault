using PasswordVault.Menu;
using PasswordVault.Utils;

class Program
{
    static void Main()
    {
        // Limpar o console do vscode
        Console.Clear();
        // Valor para manter ou finalizar o programa
        bool running = true;
        // Instância de MainMenu
        MainMenu mainMenu = new MainMenu();

        do
        {
            // Exibe o menu do MainMenu
            mainMenu.DisplayMainMenu();
            // Exibe o menu principal do programa
            int option = InputHelper.IntInput("Option: ");

            switch (option)
            {
                case 0:
                    // Finaliza o programa
                    running = mainMenu.ExitProgram();
                    break;

                case 1:
                    // Cria uma senha para acessar os cofres
                    mainMenu.CreatePasswordForVault();
                    break;

                case 2:
                    // Cria um cofre
                    mainMenu.CreateVault();
                    break;

                case 3:
                    // Exibe os cofres
                    mainMenu.DisplayVaults();
                    break;

                case 4:
                    // Muda a senha de um cofre
                    mainMenu.ChangePassword();
                    break;

                case 5:
                    // Deleta um cofre
                    mainMenu.DeleteVault();
                    break;

                default:
                    Console.Clear();
                    Console.WriteLine("Insert a valid value");
                    break;
            }
        } while (running);
    }
}
