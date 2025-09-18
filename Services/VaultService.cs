using PasswordVault.Models;

namespace PasswordVault.Services
{
    // Classe que representa os serviços de cofre
    public class VaultService
    {
        // Lista de cofres
        private List<Vault> vaults = new List<Vault>();

        // Retorna uma copia de vaults
        public List<Vault> GetAllVaults()
        {
            return new List<Vault>(vaults);
        }

        // Pegar a lista vaults carregas no JSON e colocar em vaults
        public void SetVaults(List<Vault> loadedVaults)
        {
            vaults = loadedVaults;
        }

        // Verifica se a plataforma existe
        public Vault VerifyPlataformExists(string platform, string message)
        {
            Vault? vault = vaults.FirstOrDefault(x => x.Platform == platform);

            if (vault == null)
            {
                throw new Exception(message);
            }

            return vault;
        }

        // Criar um cofre
        public void CreateVault(string platform, string password)
        {
            // Verifica se a plataforma existe
            bool plataformExists = vaults.Any(x => x.Platform == platform);

            if (plataformExists)
            {
                throw new Exception("You already have a password for this platform");
            }

            Vault newVault = new Vault(platform, password);
            vaults.Add(newVault);
        }

        // Mudar a senha de um cofre
        public void ChangePassword(string platform, string password)
        {
            // Verifica se a plataforma existe
            Vault vault = VerifyPlataformExists(platform, "This platform is not registered");

            vault.ChangePassword(password);
        }

        // Deletar um cofre
        public void DeleteVault(string platform)
        {
            // Verifica se a plataforma existe
            Vault vault = VerifyPlataformExists(platform, "This platform is not registered");

            vaults.Remove(vault);
        }
    }
}
