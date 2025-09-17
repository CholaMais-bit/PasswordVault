using PasswordVault.Utils;

class Program
{
    static void Main()
    {
        // Limpar o console do vscode
        Console.Clear();
        // Valor para manter ou finalizar o programa
        bool running = true;

        do
        {
            // Exibe o menu principal do programa
            int option = InputHelper.IntInput("Option: ");

            switch (option)
            {
                default:
                    Console.Clear();
                    Console.WriteLine("Insert a valid value");
                    break;
            }
        } while (running);
    }
}
