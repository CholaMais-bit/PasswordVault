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

        // Verifica se já há uma senha para o site ou app
        public void VerifySite(string site)
        {
            bool vault = vaults.Any(x => x.Site == site);
            throw new Exception ("You already have a password for this site");
        }

        // Criar um vault
        public void CreateVault(string site, string password)
        {
            // Verifica se já existe uma senha para o site/app
            VerifySite(site);
            
            Vault newVault = new Vault(site, password);
            vaults.Add(newVault);
        }
    }
}
