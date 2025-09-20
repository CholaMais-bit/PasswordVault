using PasswordVault.Exceptions;
using PasswordVault.Models;
using PasswordVault.Utils;

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

        // Criar um cofre
        public void CreateVault(string platform, string password)
        {
            if (VaultHelper.VerifyPlataformExists(platform, vaults))
            {
                throw new PlatformAlreadyExistException("You already have a password for this platform");
            }

            Vault newVault = new Vault(platform, password);
            vaults.Add(newVault);
        }

        // Mudar a senha de um cofre
        public void ChangePassword(string platform, string password)
        {
            // Verifica se a plataforma existe
            Vault vault = VaultHelper.FindVaultOrThrow(platform, vaults);

            vault.ChangePassword(password);
        }

        // Deletar um cofre
        public void DeleteVault(string platform)
        {
            // Verifica se a plataforma existe
            Vault vault = VaultHelper.FindVaultOrThrow(platform, vaults);

            vaults.Remove(vault);
        }
    }
}
