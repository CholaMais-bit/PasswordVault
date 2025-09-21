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
            string path = Path.Combine(Environment.CurrentDirectory, "Data");
            Directory.CreateDirectory(path);
        }

        // Salvar no JSON
        public void SaveInJson()
        {
            try
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
            catch (Exception ex)
            {
                Console.WriteLine($"\nERROR: {ex.Message}\n");
            }

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

                // Classe interna apenas para leitura do JSON
                var jsonData = JsonSerializer.Deserialize<JsonElement>(File.ReadAllText(path));

                // Atualiza a SessionHash estática
                Session.LoadPasswordFromJson(jsonData.GetProperty("SessionHash").GetString() ?? "");

                // Retorna os vaults
                var vaultsJson = jsonData.GetProperty("Vaults").GetRawText();
                return JsonSerializer.Deserialize<List<Vault>>(vaultsJson) ?? new List<Vault>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nERROR: {ex.Message}\n");
                return new List<Vault>();
            }
        }
    }
}
