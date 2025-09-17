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

        // Verifica se a plataforma existe
        public Vault VerifyPlataformExists(string plataform, string message)
        {
            Vault? vault = vaults.FirstOrDefault(x => x.Plataform == plataform);

            if (vault == null)
            {
                throw new Exception(message);
            }

            return vault;
        }

        // Criar um cofre
        public void CreateVault(string plataform, string password)
        {
            // Verifica se a plataforma existe
            bool plataformExists = vaults.Any(x => x.Plataform == plataform);

            if (plataformExists)
            {
                throw new Exception("You already have a password for this plataform");
            }

            Vault newVault = new Vault(plataform, password);
            vaults.Add(newVault);
        }

        // Mudar a senha de um cofre
        public void ChangePassword(string plataform, string password)
        {
            // Verifica se a plataforma existe
            Vault vault = VerifyPlataformExists(plataform, "This platform is not registered");

            vault.ChangePassword(password);
        }

        // Deletar um cofre
        public void DeleteVault(string plataform)
        {
            // Verifica se a plataforma existe
            Vault vault = VerifyPlataformExists(plataform, "This platform is not registered");

            vaults.Remove(vault);
        }
    }
}
