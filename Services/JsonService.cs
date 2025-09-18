using System.Text.Json;
using PasswordVault.Models;

namespace PasswordVault.Services
{
    // Classe para manipular arquivo JSON
    public class JsonService
    {
        private readonly VaultService vaultService;

        // Recebe a mesma instância do VaultService
        public JsonService(VaultService vaultService)
        {
            this.vaultService = vaultService;
        }

        // Cria um arquivo JSON
        public void CreateJsonFolder()
        {
            string past = Path.Combine(Environment.CurrentDirectory, "Data");
            Directory.CreateDirectory(past);
        }

        // Salvar no JSON
        public void SaveInJson()
        {
            var dataToSave = new
            {
                SessionHash = Session.GetPasswordHash(),
                Vaults = vaultService.GetAllVaults()
            };

            string jsonString = JsonSerializer.Serialize(dataToSave, new JsonSerializerOptions { WriteIndented = true });

            CreateJsonFolder();

            string ArquivePath = Path.Combine(Environment.CurrentDirectory, "Data", "vaults.json");

            File.WriteAllText(ArquivePath, jsonString);
        }

        // Carregar o JSON
        public List<Vault> LoadJson()
        {
            try
            {
                string path = Path.Combine(Environment.CurrentDirectory, "Data", "vaults.json");
                if (!File.Exists(path))
                {
                    return new List<Vault>();
                }

                string json = File.ReadAllText(path);
                return JsonSerializer.Deserialize<List<Vault>>(json) ?? new List<Vault>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nERROR: {ex.Message}!\n");
                return new List<Vault>();
            }
        }
    }
}
