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
        var (vaultService, mainMenu, jsonService, loginMenu) = Initialize();
        // Logar no programa
        Login(loginMenu, mainMenu);

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
                    // Cria um cofre
                    mainMenu.CreateVault();
                    changed = true;
                    break;

                case 2:
                    // Exibe os cofres
                    mainMenu.DisplayVaults();
                    changed = true;
                    break;

                case 3:
                    // Muda a senha de um cofre
                    mainMenu.ChangeVaultPassword();
                    changed = true;
                    break;

                case 4:
                    // Deleta um cofre
                    mainMenu.DeleteVault();
                    changed = true;
                    break;

                case 5:
                    // Mudar a senha da sessão
                    mainMenu.ChangeSessionPassword();
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
    static (
        VaultService vaultService,
        MainMenu mainMenu,
        JsonService jsonService,
        LoginMenu loginMenu
    ) Initialize()
    {
        // Criar uma única instância de VaultService
        VaultService vaultService = new VaultService();
        // Instância de PasswordGeneratorMenu
        PasswordGeneratorMenu passwordGeneratorMenu = new PasswordGeneratorMenu();
        // Instância de MainMenu
        MainMenu mainMenu = new MainMenu(vaultService, passwordGeneratorMenu);
        // Instância de JsonService
        JsonService jsonService = new JsonService(vaultService);
        // Instância de LoginMenu
        LoginMenu loginMenu = new LoginMenu(vaultService);
        // Carrega os dados do JSON
        var vaultsFromJson = jsonService.LoadJson();
        vaultService.SetVaults(vaultsFromJson);

        return (vaultService, mainMenu, jsonService, loginMenu);
    }

    // Função para logar no programa
    static void Login(LoginMenu loginMenu, MainMenu mainMenu)
    {
        // Caso o usuário logar ir para o menu principal
        bool logged = false;

        while (!logged)
        {
            loginMenu.DisplayLoginMenuOptions();
            int option = InputHelper.IntInput("Option: ");

            switch (option)
            {
                case 0:
                    // Finaliza o programa
                    mainMenu.ExitProgram();
                    Environment.Exit(0);
                    break;

                case 1:
                    logged = loginMenu.Login();
                    break;

                case 2:
                    loginMenu.SignUp();
                    break;

                default:
                    Console.Clear();
                    Console.WriteLine("Insert a valid value");
                    break;
            }
        }
    }
}
