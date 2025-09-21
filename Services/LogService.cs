namespace PasswordVault.Services
{
    // Classe para manipular arquivos de log
    public class LogService
    {
        // Criar a pasta de log
        public static void CreateFolder()
        {
            string path = Path.Combine(Environment.CurrentDirectory, "Data");
            Directory.CreateDirectory(path);
        }

        // Salvar os logs
        public static void SaveInLog(string actionDescription)
        {
            try
            {
                string path = Path.Combine(Environment.CurrentDirectory, "Data", "log.txt");

                CreateFolder();

                string logLine = $"[{DateTime.Now}] {actionDescription}";

                File.AppendAllText(path, logLine + Environment.NewLine);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nERROR: {ex.Message}\n");
            }
        }
    }
}
