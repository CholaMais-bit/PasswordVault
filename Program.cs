using PasswordVault.Menu;
using PasswordVault.Services;
using PasswordVault.Utils;

class Program
{
    static void Main()
    {
        // Limpar o console do vscode
        Console.Clear();
        
        // Valor para manter ou finalizar o programa
        bool running = true;

        // Incializar instâncias
        var (vaultService, mainMenu, jsonService) = Initialize();

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
                    jsonService.SaveInJson();
                    break;

                case 2:
                    // Cria um cofre
                    mainMenu.CreateVault();
                    jsonService.SaveInJson();
                    break;

                case 3:
                    // Exibe os cofres
                    mainMenu.DisplayVaults();
                    jsonService.SaveInJson();
                    break;

                case 4:
                    // Muda a senha de um cofre
                    mainMenu.ChangePassword();
                    jsonService.SaveInJson();
                    break;

                case 5:
                    // Deleta um cofre
                    mainMenu.DeleteVault();
                    jsonService.SaveInJson();
                    break;

                default:
                    Console.Clear();
                    Console.WriteLine("Insert a valid value");
                    break;
            }
        } while (running);
    }

    static (VaultService vaultService, MainMenu mainMenu, JsonService jsonService) Initialize()
    {
        // Criar uma única instância de VaultService
        VaultService vaultService = new VaultService();
        // Instância de MainMenu
        MainMenu mainMenu = new MainMenu(vaultService);
        // Instância de JsonService
        JsonService jsonService = new JsonService(vaultService);
        // Carrega os dados do JSON
        var vaultsFromJson = jsonService.LoadJson();
        vaultService.SetVaults(vaultsFromJson);

        return (vaultService, mainMenu, jsonService);
    }
}
