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
                    running = mainMenu.ExitProgram();
                    break;

                case 1:
                    mainMenu.CreatePasswordForVault();
                    break;

                case 2:
                    mainMenu.CreateVault();
                    break;

                case 3:
                    mainMenu.DisplayVaults();
                    break;

                case 4:
                    mainMenu.ChangePassword();
                    break;

                case 5:
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
