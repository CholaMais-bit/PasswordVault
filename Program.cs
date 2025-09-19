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
            // Boleano para salvar as alterações do projeto
            bool changed = false;

            switch (option)
            {
                case 0:
                    // Finaliza o programa
                    running = mainMenu.ExitProgram();
                    changed = true;
                    break;

                case 1:
                    // Cria uma senha para acessar os cofres
                    mainMenu.CreatePasswordForVault();
                    changed = true;
                    break;

                case 2:
                    // Cria um cofre
                    mainMenu.CreateVault();
                    changed = true;
                    break;

                case 3:
                    // Exibe os cofres
                    mainMenu.DisplayVaults();
                    changed = true;
                    break;

                case 4:
                    // Muda a senha de um cofre
                    mainMenu.ChangePassword();
                    changed = true;
                    break;

                case 5:
                    // Deleta um cofre
                    mainMenu.DeleteVault();
                    changed = true;
                    break;

                default:
                    Console.Clear();
                    Console.WriteLine("Insert a valid value");
                    break;
            }

            if (changed)
            {
                jsonService.SaveInJson();
            }

        } while (running);
    }

    // Instâncias
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
