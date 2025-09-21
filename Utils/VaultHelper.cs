using PasswordVault.Exceptions;
using PasswordVault.Models;

namespace PasswordVault.Utils
{
    // Helpers dos cofres
    public class VaultHelper
    {
        // Verifica se o cofre existe
        public static void VerifyPlataformExists(string platform, List<Vault> vaults)
        {
            Vault? vault = vaults.FirstOrDefault(
                x => string.Equals(x.Platform, platform, StringComparison.OrdinalIgnoreCase)
            );

            if (vault != null)
            {
                throw new PlatformAlreadyExistException("This platform already exist");
            }
        }

        // Retorna uma plataforma
        public static Vault FindVaultOrThrow(string platform, List<Vault> vaults)
        {
            Vault? vault = vaults.FirstOrDefault(
                x => String.Equals(x.Platform, platform, StringComparison.OrdinalIgnoreCase)
            );

            if (vault == null)
            {
                throw new PlatformIsNotRegisteredException("This platform is not registered");
            }

            return vault;
        }
    }
}
